////
namespace H06Phonebook
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class PhonebookEntry : IEquatable<PhonebookEntry>
    {
        internal const string NameDefaultValue = "";
        private const int FieldsNameCount = 4;
        private const int NameMaxLenght = 10;
        private const int TownMaxLenght = 10;
        private const string RegExpresionPhoneNumber = @"^\d[\d ]*\d$";
        private static readonly char[] ForbbidenSymbolsInNickname = { '[', ']', '|' };

        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private string town;
        private string phoneNumber;

        public PhonebookEntry(string firstName, string middleName, string lastName, string nickName, string town, string phoneNumber)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.NickName = nickName;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            protected set
            {
                if (IsValidTown(value))
                {
                    this.town = value;
                    return;
                }

                throw new ArgumentException(value, "Invalid value for 'town'.");
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                if (IsValidName(value))
                {
                    this.firstName = value;
                    return;
                }

                throw new ArgumentException(value, "Invalid value for 'firstName'.");
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            protected set
            {
                if (IsValidName(value))
                {
                    this.middleName = value;
                    return;
                }

                throw new ArgumentException(value, "Invalid value for 'middleName'.");
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                if (IsValidName(value))
                {
                    this.lastName = value;
                    return;
                }

                throw new ArgumentException(value, "Invalid value for 'lastName'.");
            }
        }

        public string NickName
        {
            get
            {
                return this.nickName;
            }

            protected set
            {
                foreach (var symbol in ForbbidenSymbolsInNickname)
                {
                    if (value.Contains(symbol))
                    {
                        throw new ArgumentException(value, "The value for 'nickname' contains forbbiden symbols.");
                    }
                }

                this.nickName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            protected set
            {
                if (IsValidPhoneNumber(value))
                {
                    this.phoneNumber = value;
                    return;
                }

                throw new ArgumentException(value, "Invalid value for 'phoneNumber'.");
            }
        }

        public static PhonebookEntry Parse(string entry)
        {
            int namesEnd = entry.IndexOf('|');

            if (namesEnd < 0 || namesEnd >= entry.Length - 1)
            {
                throw new FormatException("The entry was not in the correct format.");
            }

            var namesStr = entry.Substring(0, namesEnd - 1);
            entry = entry.Substring(namesEnd + 1);
            namesStr = namesStr.Trim();

            string nickname = NameDefaultValue;
            int indexOfNickname = namesStr.IndexOf('[');
            if (indexOfNickname >= 0)
            {
                TryParseNickName(namesStr.Substring(indexOfNickname), out nickname);
                namesStr = namesStr.Substring(0, indexOfNickname);
                namesStr = namesStr.Trim();
            }

            var names = namesStr.Split(' ');
            var firstName = NameDefaultValue;
            var middleName = NameDefaultValue;
            var lastName = NameDefaultValue;

            if (names.Length == 1)
            {
                firstName = names[0];
            }
            else if (names.Length == 2)
            {
                firstName = names[0];

                lastName = names[1];
            }
            else if (names.Length == 3)
            {
                firstName = names[0];
                middleName = names[1];
                lastName = names[2];
            }
            else
            {
                throw new FormatException("The entry was not in the correct format.");
            }

            var townEnd = entry.IndexOf('|');

            if (townEnd < 0 || townEnd >= entry.Length - 1)
            {
                throw new FormatException("The entry was not in the correct format.");
            }

            var town = entry.Substring(0, townEnd);
            town = town.Trim();

            var phoneNumber = entry.Substring(townEnd + 1);
            phoneNumber = phoneNumber.Trim();
            PhonebookEntry parsedEntry;
            try
            {
                parsedEntry = new PhonebookEntry(firstName, middleName, lastName, nickname, town, phoneNumber);
            }
            catch (ArgumentException)
            {
                throw new FormatException("The entry was not in the correct format.");
            }

            return parsedEntry;
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() ^ this.middleName.GetHashCode() ^
                   this.lastName.GetHashCode() ^ this.nickName.GetHashCode() ^ this.town.GetHashCode() ^
                   this.phoneNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PhonebookEntry);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.FirstName != NameDefaultValue)
            {
                result.Append(this.FirstName);
                result.Append(" ");
            }

            if (this.MiddleName != NameDefaultValue)
            {
                result.Append(this.MiddleName);
                result.Append(" ");
            }

            if (this.LastName != NameDefaultValue)
            {
                result.Append(this.LastName);
                result.Append(" ");
            }

            if (this.NickName != NameDefaultValue)
            {
                result.Append('[');
                result.Append(this.NickName);
                result.Append(']');
            }
            
            string padding = new string(' ', (NameMaxLenght * FieldsNameCount) - result.Length);
           
            result.Append(padding);

            result.Append('|');
            result.Append(' ');
            result.Append(this.Town);
            padding = new string(' ', (NameMaxLenght + 1) - (this.Town.Length + 1));
            result.Append(padding);

            result.Append('|');
            result.Append(' ');
            result.Append(this.PhoneNumber);
            return result.ToString();
        }

        public bool Equals(PhonebookEntry other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.FirstName == other.FirstName)
            {
                if (this.MiddleName == other.MiddleName)
                {
                    if (this.LastName == other.LastName)
                    {
                        if (this.NickName == other.NickName)
                        {
                            if (this.Town == other.Town)
                            {
                                if (this.PhoneNumber == other.PhoneNumber)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static bool TryParseNickName(string name, out string nickname)
        {
            if (name.Length >= 3)
            {
                if (name[0] == '[' && name[name.Length - 1] == ']')
                {
                    nickname = name.Substring(1, name.Length - 2);
                    return true;
                }
            }

            nickname = NameDefaultValue;
            return false;
        }

        private static bool IsValidName(string name)
        {
            if (name.All(char.IsLetter) && name.Length <= NameMaxLenght)
            {
                return true;
            }

            if (name == NameDefaultValue)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidTown(string town)
        {
            if (town.All(char.IsLetter) && town.Length <= TownMaxLenght)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, RegExpresionPhoneNumber))
            {
                return true;
            }

            return false;
        }
    }
}
