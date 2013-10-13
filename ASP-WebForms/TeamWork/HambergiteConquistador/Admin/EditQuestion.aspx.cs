using Error_Handler_Control;
using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Admin
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        private bool isNewQuestion = false;
        private Question question;
        private int questionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.User.IsInRole("Admin"))
            //{
            //    this.Response.Redirect("/");
            //}
            this.questionId = Convert.ToInt32(Request.Params["id"]);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ConquistadorEntities();

            if (questionId == 0)
            {
                isNewQuestion = true;
            }

            if (!isNewQuestion)
            {
                question = context.Questions.Find(questionId);
                this.TextBoxEdit.Text = question.TextContent;                               
                this.CheckBoxApproved.Checked = question.IsApproved == true? true : false;
                this.RepeaterAnswers.DataSource = question.Answers.ToList();
                this.DataBind();
            }

            else
            {
                this.TextBoxEdit.Text = "";
            }

        }

        protected void Save_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();
            int questionId = Convert.ToInt32(Request.Params["id"]);

            if (questionId == 0)
            {
                isNewQuestion = true;
            }
            if (!isNewQuestion)
            {
                question = context.Questions.Find(questionId);
            }
            else
            {
                question = new Question();
                context.Questions.Add(question);
            }

            question.TextContent = this.TextBoxEdit.Text;
            question.IsApproved = this.CheckBoxApproved.Checked;
            try
            {
                ErrorSuccessNotifier.AddSuccessMessage("Question is edited.");
                context.SaveChanges();                
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                return;
            }   
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();
            int answerId = Convert.ToInt32(e.CommandArgument);
            var answer = context.Answers.Find(answerId);
            context.Answers.Remove(answer);

            try
            {
               
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Answer is deleted.");
            }
            catch (Exception ex)
            {
                
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
          
        }

        protected void CreateAnswer_Click(object sender, EventArgs e)
        {

            Response.Redirect(string.Format("EditAnswers.aspx?questionId={0}", this.questionId));
        }
    }
}