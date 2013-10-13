////
namespace JustGSM.AllFunctions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Call
    {
        #region fields
        private static decimal taxPerMinute = 0.37m;

        private DateTime dateAndTime;
        private string dialedPhoneNum;
        private uint duration;
        #endregion

        public Call(DateTime dateAndTime, string dialedPhoneNum, uint duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedPhoneNum = dialedPhoneNum;
            this.Duration = duration;
        }

        #region properties
        public static decimal TaxPerMinute
        {
            get
            { 
                return taxPerMinute;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value for TaxPerMinute can not be nagetive");
                }

                taxPerMinute = value;
            }
        }

        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            set { this.dateAndTime = value; }
        }

        public string DialedPhoneNum
        {
            get { return this.dialedPhoneNum; }
            set { this.dialedPhoneNum = value; }
        }

        public uint Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
        #endregion


        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            strBuild.Append(string.Format(new CultureInfo("es-ES"), "{0:dd/MM/yyyy hh:mm:ss} {1} duration (in seconds): {2,3}", this.dateAndTime, this.dialedPhoneNum, this.duration));
            return strBuild.ToString();
        }      
    }
}
