using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class T06Calculator: System.Web.UI.Page
    {
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

        protected void MathOperation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this.operatorContainer.InnerText = btn.Text;
        }

        protected void AddNumber_Click(object sender, EventArgs e)
        {
            Button btn= sender as Button;

            var element = this.firstNumber;

            if (this.operatorContainer.InnerText != "")
            {
                element = this.secondNumber;
            }

            element.InnerText += btn.Text;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            this.errBox.InnerText = string.Empty;
            this.resultBox.Text = string.Empty;
            ClearTempFields();
        }

        private void ClearTempFields()
        {
            this.firstNumber.InnerText = string.Empty;
            this.secondNumber.InnerText = string.Empty;
            this.operatorContainer.InnerText = string.Empty;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool isPassed = true;
            int firstNumber;
            int secondNumber;
            bool isFirstNumber = int.TryParse(this.firstNumber.InnerText, out firstNumber);
            bool isSecondNumber = int.TryParse(this.secondNumber.InnerText, out secondNumber);
            var operatorVal = this.operatorContainer.InnerText;
            if (isFirstNumber)
            {

                if (operatorVal == "√" && !isSecondNumber)
                {
                    var result = Math.Sqrt(firstNumber);
                    this.resultBox.Text = result.ToString();
                    var previousVal = (int)result;
                    ClearTempFields();
                    this.firstNumber.InnerText = previousVal.ToString();
                    this.errBox.InnerText = string.Empty;
                    return;
                }
                else
                {
                    try
                    {
                        if (!isSecondNumber)
                        {
                            throw new InvalidOperationException("Invalid input.");
                        }
                        switch (operatorVal)
                        {
                            case "+":
                                this.resultBox.Text = (firstNumber + secondNumber).ToString();
                                break;
                            case "-":
                                this.resultBox.Text = (firstNumber - secondNumber).ToString();
                                break;
                            case "/":
                                this.resultBox.Text = (firstNumber / secondNumber).ToString();
                                break;
                            case "x":
                                this.resultBox.Text = (firstNumber * secondNumber).ToString();
                                break;
                            default:
                                throw new InvalidOperationException("Invalid operator.");

                        }
                        

                    }
                    catch (Exception ex)
                    {
                        this.errBox.InnerText = ex.Message;
                        isPassed = false;
                    }
                
                }
            }
            else
            {
                
                
                this.errBox.InnerText = "Invalid input.";
                isPassed = false;
                
            }

            ClearTempFields();
            if (isPassed)
            {
                operatorContainer.InnerText = "+";
                this.errBox.InnerText = string.Empty;
            }

            this.firstNumber.InnerText = this.resultBox.Text.ToString();

        }

    }
}