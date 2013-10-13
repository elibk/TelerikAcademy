using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace HambergiteConquistador.Admin
{
    public partial class EditAnswers1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.User.IsInRole("Admin"))
            //{
            //    this.Response.Redirect("/");
            //}

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ConquistadorEntities();

            if (Convert.ToInt32(Request.Params["answerId"]) != 0)
            {
                var answer = context.Answers.Find(Convert.ToInt32(Request.Params["answerId"]));
                this.TextBoxEdit.Text = answer.ContentText;
                if (answer.IsCorrect == true)
                {
                    this.CheckBoxIsCorrect.Checked = true;
                }
                this.DataBind();
            }
        }


        protected void EditAnswer_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();

            var  question = context.Questions.Find(Convert.ToInt32(Request.Params["questionId"]));

            Answer answer = null;

            if (question == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Question not found.");
                return;
            }

            if ((Convert.ToInt32(Request.Params["answerId"])) == 0)
            {
                
                answer = new Answer();
                if (Convert.ToInt32(Request.Params["questionId"]) == 0)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Question not found.");
                    return;
                }
                answer.QuestionId = Convert.ToInt32(Request.Params["questionId"]);
                context.Answers.Add(answer);
            }
            else
            {
                answer = context.Answers.Find(Convert.ToInt32(Request.Params["answerId"]));
            }

            answer.ContentText = this.TextBoxEdit.Text;

            if (string.IsNullOrWhiteSpace(answer.ContentText))
            {
                ErrorSuccessNotifier.AddErrorMessage("Answer can not be empty.");
                return;
            }

            if (this.CheckBoxIsCorrect.Checked)
            {
                answer.IsCorrect = true;
            }
            else
            {
                answer.IsCorrect = false;
            }

            try
            {
                context.SaveChanges();
                var msg = "Answer is added.";
                if (Convert.ToInt32(Request.Params["answerId"]) != 0)
                {
                    msg = "Answer is edited.";
                }
                ErrorSuccessNotifier.AddSuccessMessage(msg);
                ErrorSuccessNotifier.ShowAfterRedirect = true;

                Response.Redirect(string.Format("EditQuestion.aspx?id={0}", answer.QuestionId), false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                return;
            }

        }
    }
}