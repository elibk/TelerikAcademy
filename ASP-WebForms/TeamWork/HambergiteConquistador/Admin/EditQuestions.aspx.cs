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
    public partial class EditAnswers : System.Web.UI.Page
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
           

            if (Convert.ToBoolean(this.Session["ActionComfurmed"]))
            {
                var storedValueControl = (Literal)Master.FindControl("StoredValue");
                if (storedValueControl != null && storedValueControl.Text != string.Empty)
                {
                    var questionId = Convert.ToInt32(storedValueControl.Text);
                    ActualDelete(questionId);
                    this.Session["ActionComfurmed"] = false;
                    storedValueControl.Text = string.Empty;
                }
            }
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            var questionId = e.CommandArgument;
            ErrorSuccessNotifier.AddWarningMessage("Are you sure you want to remove this question and all its answers?");

            var master = Master as SiteMaster;
            if (master != null)
            {
                master.StoreValueForAction(questionId.ToString());
            }
        }

        protected void ActualDelete(int questionId)
        {
            var context = new ConquistadorEntities();
           
            Question question = context.Questions.Include("Answers").FirstOrDefault(x => questionId == x.Id);

            if (question == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Question not found.");
                return;
            }

            foreach (var item in question.Answers)
            {
                item.QuestionId = null;
            }

            context.Answers.RemoveRange(question.Answers);

            context.Questions.Remove(question);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Question is deleted.");
                this.Response.Redirect("~/Admin/EditQuestions.aspx", false);
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

      
        public IQueryable<HambergiteConquistador.Models.Question> GridViewQuestions_GetData()
        {
            var db = new ConquistadorEntities();
            var result = db.Questions.OrderBy(q => q.TextContent);
            return result;
        }

        protected void ButtonEditBook_Command(object sender, CommandEventArgs e)
        {
            int id= Convert.ToInt32(e.CommandArgument);
            Response.Redirect(String.Format("~/Admin/EditQuestion.aspx?id={0}", id));
        }

    }
}