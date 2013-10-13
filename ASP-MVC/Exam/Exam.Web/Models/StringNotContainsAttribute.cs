using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Web.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringNotContainsAttribute : ValidationAttribute
    {
        private string text;

        public StringNotContainsAttribute(string text, string errorMessage)
            : base(errorMessage)
        {
            this.text = text;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = (value as string).ToLower();

            return !valueAsString.Contains(text);
        }
    }
}
