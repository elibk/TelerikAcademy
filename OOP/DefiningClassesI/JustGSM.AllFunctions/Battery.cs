////
namespace JustGSM.AllFunctions
{
    using System;
    using System.Linq;
    using System.Text;

    public class Battery
    {
        #region fields
        private string model;
        private uint? hoursIdle;
        private ushort? hoursTalk;
        private BatteryType battType = new BatteryType();
        #endregion     

        #region constructors
        public Battery(string model)
            : this(model, null)
        {
        }

        public Battery(string model, ushort? hoursTalk)
            : this(model, null, hoursTalk)
        {
        }

        public Battery(string model, uint? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model, BatteryType battType)
            : this(model, null)
        {
        }

        public Battery(string model, uint? hoursIdle, ushort? hoursTalk)
            : this(model, hoursIdle, hoursTalk, BatteryType.Unknown)
        {
        }

        public Battery(string model, uint? hoursIdle, ushort? hoursTalk, BatteryType battType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BattType = battType;
        }
        #endregion

        #region properties
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public ushort? HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }

        public BatteryType BattType
        {
            get { return this.battType; }
            set { this.battType = value; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            strBuild.Append(this.Model);

            if (this.hoursIdle != null)
            {
                strBuild.Append(" " + this.HoursIdle);
            }

            if (this.hoursTalk != null)
            {
                strBuild.Append("/" + this.HoursTalk);
            }

            if (this.battType != BatteryType.Unknown)
            {
                strBuild.Append(" " + this.BattType);
            }

            return strBuild.ToString();
        }
    }
}
