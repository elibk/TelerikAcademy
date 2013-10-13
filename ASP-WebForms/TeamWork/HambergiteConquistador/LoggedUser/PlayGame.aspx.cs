using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.LoggedUser
{
    public partial class PlayGame : System.Web.UI.Page
    {
        private const int QuestionScorePoints = 10;
        private const int AnswerBonusPoints = 2;
        private const int JokerBasePrice = 10;
        private Random rand = new Random();
        private Question CurrentQuestion
        {
            get
            {
                return (Question)this.Session["question"];
            }
            set
            {
                this.Session["question"] = value;
            }
        }
        private IList<Answer> CurrentAnswers
        {
            get
            {
                return (IList<Answer>)this.Session["answers"];
            }
            set
            {
                this.Session["answers"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetQuestion();
            }
        }

        protected void GetQuestion()
        {
            using (ConquistadorEntities db = new ConquistadorEntities())
            {
                IList<Answer> randomisedAnsvers;
                Question question;

                if (this.CurrentQuestion != null)
                {
                    question = this.CurrentQuestion;
                    randomisedAnsvers = this.CurrentAnswers;
                }
                else
                {
                    var questions = db.Questions.Include("Answers").OrderBy(x => Guid.NewGuid());
                    question = questions.First(x => x.IsApproved == true);

                    IEnumerable<Answer> answers = question.Answers.OrderBy(a => Guid.NewGuid());
                    randomisedAnsvers = answers.Take(4).ToList();

                    if (randomisedAnsvers.FirstOrDefault(a => a.IsCorrect == true) == null)
                    {
                        var correctAnswer = answers.FirstOrDefault(a => a.IsCorrect == true);
                        int index = rand.Next(0, 4);
                        randomisedAnsvers[index] = correctAnswer;
                    }
                    // save Current Question state
                    this.CurrentQuestion = question;
                    this.CurrentAnswers = randomisedAnsvers;
                }

                string userName = this.Page.User.Identity.Name;
                var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                this.LiteralScore.Text = currentUser.Score.ToString();

                this.MakePictureFromText.QuestionText = question.TextContent;
                this.RadioButtonListAnswers.DataSource = randomisedAnsvers;
                this.RadioButtonListAnswers.DataBind();

                this.ButtonNextQuestion.Enabled = false;
                this.LiteralAnswer.Text = string.Empty;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.CurrentQuestion != null)
            {
                if (!string.IsNullOrWhiteSpace(this.RadioButtonListAnswers.SelectedValue))
                {
                    int answerId = Convert.ToInt32(this.RadioButtonListAnswers.SelectedValue);
                    using (ConquistadorEntities db = new ConquistadorEntities())
                    {
                        Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
                        if (answer.IsCorrect == true)
                        {
                            Error_Handler_Control.ErrorSuccessNotifier.AddSuccessMessage("Aswer Correct!");
                            string userName = this.Page.User.Identity.Name;
                            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
                            currentUser.Score += QuestionScorePoints;
                            currentUser.Bonus += AnswerBonusPoints;
                            db.SaveChanges();

                            this.LiteralBonus.Text = currentUser.Bonus.ToString();
                            this.LiteralScore.Text = currentUser.Score.ToString();
                        }
                        else
                        {
                            Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Aswer Incorrect!");
                            for (int i = 0; i < 4; i++)
                            {
                                int ansId = Convert.ToInt32(this.RadioButtonListAnswers.Items[i].Value);
                                Answer currAnswer = db.Answers.FirstOrDefault(a => a.Id == ansId);
                                if (currAnswer.IsCorrect == true)
                                {
                                    this.LiteralAnswer.Text = "Correct answer is: " + this.RadioButtonListAnswers.Items[i].Text;
                                    break;
                                }
                            }
                        }
                    }
                    this.CurrentQuestion = null;
                    this.CurrentAnswers = null;
                    ToggleEnabledButtons(true);
                }
            }
            else
            {
                ToggleEnabledButtons(true);
            }
        }

        protected void ButtonNextQuestion_Click(object sender, EventArgs e)
        {
            GetQuestion();
            ToggleEnabledButtons(false);
        }

        protected void ButtonJoker25_Click(object sender, EventArgs e)
        {
            string userName = this.Page.User.Identity.Name;
            ConquistadorEntities db = new ConquistadorEntities();
            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
            if (currentUser.Bonus >= JokerBasePrice)
            {
                currentUser.Bonus -= JokerBasePrice;
                while (true)
                {
                    int random = rand.Next(0, 4);
                    int answerId = Convert.ToInt32(this.RadioButtonListAnswers.Items[random].Value);
                    Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
                    if (answer.IsCorrect != true)
                    {
                        RadioButtonListAnswers.Items[random].Enabled = false;
                        RadioButtonListAnswers.Items[random].Text = "&nbsp;";
                        this.ButtonJoker25.Enabled = false;
                        this.ButtonJoker50.Enabled = false;
                        break;
                    }
                }

                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                db.SaveChanges();
            }
            else
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddInfoMessage("No enought bonus points!");
            }
        }

        protected void ButtonJoker50_Click(object sender, EventArgs e)
        {
            string userName = this.Page.User.Identity.Name;
            ConquistadorEntities db = new ConquistadorEntities();
            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
            db.AspNetUsers.Attach(currentUser);
            if (currentUser.Bonus >= JokerBasePrice * 2)
            {
                currentUser.Bonus -= JokerBasePrice * 2;
                int count = 0;
                while (true)
                {
                    int random = rand.Next(0, 4);
                    int answerId = Convert.ToInt32(this.RadioButtonListAnswers.Items[random].Value);
                    Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
                    if (answer.IsCorrect != true && RadioButtonListAnswers.Items[random].Enabled == true)
                    {
                        RadioButtonListAnswers.Items[random].Enabled = false;
                        RadioButtonListAnswers.Items[random].Text = "&nbsp;";
                        this.ButtonJoker25.Enabled = false;
                        this.ButtonJoker50.Enabled = false;
                        count++;
                        if (count >= 2)
                        {
                            break;
                        }
                    }
                }

                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                db.SaveChanges();
            }
            else
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddInfoMessage("No enough bonus points!");
            }
        }

        protected void ToggleEnabledButtons(bool enabled)
        {
            if (enabled)
            {
                this.RadioButtonListAnswers.Enabled = false;
                this.ButtonSubmit.Enabled = false;
                this.ButtonNextQuestion.Enabled = true;
                this.ButtonJoker25.Enabled = false;
                this.ButtonJoker50.Enabled = false;
            }
            else
            {
                this.RadioButtonListAnswers.Enabled = true;
                this.ButtonSubmit.Enabled = true;
                this.ButtonNextQuestion.Enabled = false;
                this.ButtonJoker25.Enabled = true;
                this.ButtonJoker50.Enabled = true;
            }
        }
    }
}