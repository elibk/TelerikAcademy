////

namespace JustGSM.AllFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

   public class GSM
   {
        #region fields
//       private static string iPhone4S = @"The newest mobile phone IPhone4S
//8 MP Camera w/ 1080p HD Video
//3.5-inch (diagonal) Retina Display
//GPS, Compass, Gyroscope
//Network: GSM + CDMA + HSDPA/HSUPA & EVDO data 
//(AT&T, Verizon, Sprint, Unlocked)
//A5 Chip
//Front Camera";

        private string model,
                       manufacturer,
                       owner;

        private decimal? price = null;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        private static readonly GSM iPhone4S = new GSM("IPhone4S", "Apple", 200);
        #endregion

        #region constructors
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer, null, owner)
        {
        }

        public GSM(string model, string manufacturer, Battery battery)
            : this(model, manufacturer, null, null, battery, null)
        {
        }

        public GSM(string model, string manufacturer, Display display)
            : this(model, manufacturer, null, null, null, display)
        {
        }

        public GSM(string model, string manufacturer, Battery battery, Display display)
            : this(model, manufacturer, null, null, battery, display)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Display display)
            : this(model, manufacturer, price, owner, null, display)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }
        #endregion

        #region properties

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public List<Call> CallHistory 
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            strBuild.Append(this.Model + " " + this.Manufacturer);

            if (this.price != null)
            {
                strBuild.Append(string.Format(new CultureInfo("es-ES"), " Price:{0:C}", this.Price));
            }
            
            if (this.owner != null)
            {
                strBuild.Append(" Owner:" + this.Owner);
            }

            if (this.battery != null)
            {
                strBuild.Append(" Battery:" + this.Battery);
            }

            if (this.display != null)
            {
                strBuild.Append(" Display:" + this.Display);
            }

            return strBuild.ToString();
        }

        #region methods
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.callHistory.Remove(call);
        }
       
        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public decimal  CalculateTax()
        {
           
            uint allCals = 0;
            foreach (var phoneCall in this.CallHistory)
            {
                allCals += phoneCall.Duration;
            }

            decimal tax = (decimal)((double)allCals / 60) * Call.TaxPerMinute;

            return tax;
        }
        #endregion
    }
}