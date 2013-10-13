namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Contact : IComparable<Contact>, IContact
    {
        private string originalName;
        private string adaptedContactName;
        private SortedSet<string> phoneNumbers;

        public Contact(string name, SortedSet<string> phoneNumbers)
        {
            this.Name = name;
            this.PhoneNumbers = phoneNumbers;
        }

        public SortedSet<string> PhoneNumbers
        {
            get
            {
                return this.phoneNumbers;
            }

            protected set
            {
                this.phoneNumbers = value;
            }
        }

        public string Name
        {
            get
            {
                return this.originalName;
            }

            protected set
            {
                this.originalName = value;

                this.adaptedContactName = value.ToLowerInvariant();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');

            sb.Append(this.Name);
            bool flag = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            return sb.ToString();
        }

        public int CompareTo(Contact other)
        {
            return this.adaptedContactName.CompareTo(other.adaptedContactName);
        }
    }
}
