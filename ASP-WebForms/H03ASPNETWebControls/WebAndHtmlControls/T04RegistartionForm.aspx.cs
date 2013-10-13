using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class T04RegistrationForm : System.Web.UI.Page
    {
        private static List<Student> submitedStudents   = new List<Student>();
        public static int SubmitedStudentsCount
        {
            get { return submitedStudents.Count; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // This is not the first load of the page,
                // so we should skip the data binding
                return;
            }
            //submitedStudents  = new List<Student>();
            this.DataBind();
            
        }

        private bool IsValidInput(string input, string inputName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                this.errBox.InnerHtml += string.Format("'{0}' can not be empty. <br/>", inputName);
                return false;
            }

            return true;
        }

        protected void SumbitApplication_Click(object sender, EventArgs e)
        {
            var firstName = this.firstNameTxtBox.Text;
            var lastName = this.lastNameTxtBox.Text;
            var facNum = this.facNumTxtBox.Text;
            var university = this.universityDDList.SelectedItem.Text;
            var speciality = this.specialtyDDList.SelectedItem.Text;

            this.errBox.InnerHtml = "";
            if 
            (
                IsValidInput(firstName,"firstName") &&
                IsValidInput(lastName, "lastName") &&
                IsValidInput(facNum, "facNum") &&
                IsValidInput(university, "university") &&
                IsValidInput(speciality , "speciality")
            )
            {
                 List<string> courses = new List<string>();
                foreach (ListItem li in this.coursesMultiDDList.Items)
                {
                    if (li.Selected == true)
                    {
                        courses.Add(li.Text);
                    }
                }

                var newStudent = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FacNumber = facNum,
                    Speciality = speciality,
                    University = university,
                    Courses = courses
                };

                submitedStudents.Add(newStudent);
                this.DataBind();
            }

            else
	        {
                return;
	        }
        }

        protected void ShowStudentsDetails_Click(object sender, EventArgs e)
        {
            StringWriter stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {

                if (submitedStudents.Count == 0)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.P);

                    writer.Write("No submited students, yet");

                    writer.RenderEndTag();
                }

                foreach (var student in submitedStudents)
                {
                    
                    writer.RenderBeginTag(HtmlTextWriterTag.H1);

                    writer.Write("{0} {1}", HttpUtility.HtmlEncode(student.FirstName), HttpUtility.HtmlEncode(student.LastName));

                    writer.RenderEndTag();
                   
                    writer.RenderBeginTag(HtmlTextWriterTag.P);

                    writer.Write("Faculty number: {0} University: {1}  Speciality: {2}", student.FacNumber, student.University, student.Speciality);

                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.Label);
                    writer.Write("Courses:");
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.Ul);

                    if (student.Courses.Count == 0)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        writer.Write("No sighed courses.");
                        writer.RenderEndTag();
                    }

                    foreach (var course in student.Courses)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        writer.Write(course);
                        writer.RenderEndTag();
                    }
                   

                    writer.RenderEndTag();
                }
            }
          
           this.Detils.InnerHtml = stringWriter.ToString();
        }
    }

    public class Student
    {
        private ICollection<string> courses;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacNumber { get; set; }
        public string University { get; set; }
        public string Speciality { get; set; }
        public ICollection<string> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
        
    }
}