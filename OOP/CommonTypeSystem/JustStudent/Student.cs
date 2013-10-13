////
namespace JustStudent
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        #region Fields
        
        private string firstName;
        private string middleName;
        private string lastName;
        private int socialSecurityNumber;
        private University university;
        private Faculty faculty;
        private Specialty speciality;
        private Address permanentAddress;
        private string mobilePhone;
        private string email;

        #endregion

        #region Constructor
        public Student(string firstName, string middleName, string lastName, int socialSecurityNumber, University university, Faculty faculty, Specialty speciality, Address permanentAddress, string mobilePhone, string email)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
        }
        #endregion

        #region Properties
        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            
            set
            {
                this.faculty = value;
            }
        }
        
        public Specialty Speciality
        {
            get
            {
                return this.speciality;
            }
            
            set
            {
                this.speciality = value;
            }
        }
        
        public University University
        {
            get
            {
                return this.university;
            }
            
            set
            {
                this.university = value;
            }
        }
        
        public Address PermanentAddress1
        {
            get
            {
                return this.permanentAddress;
            }
            
            set
            {
                this.permanentAddress = value;
            }
        }
        
        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            
            set
            {
                this.mobilePhone = value;
            }
        }
        
        public string Email
        {
            get
            {
                return this.email;
            }
            
            set
            {
                this.email = value;
            }
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            
            set
            {
                this.firstName = value;
            }
        }
        
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            
            set
            {
                this.middleName = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            
            set
            {
                this.lastName = value;
            }
        }
        
        public int SocialSecurityNumber
        {
            get
            {
                return this.socialSecurityNumber;
            }
            
            set
            {
                this.socialSecurityNumber = value;
            }
        }
        
        public Address PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            
            set
            {
                this.permanentAddress = value;
            }
        }
        #endregion

        #region Operators
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.SocialSecurityNumber == secondStudent.SocialSecurityNumber)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            if (firstStudent == secondStudent)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Override_official_Methods
        public override int GetHashCode()
        {
            return this.SocialSecurityNumber;
        }
        
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(this.FirstName + " " + this.MiddleName + " " + this.LastName + " SSN:" + this.SocialSecurityNumber);
            info.Append(Environment.NewLine);
            info.Append(this.University + " " + this.Faculty + " " + this.Speciality);
            info.Append(Environment.NewLine);
            info.Append("Address: " + this.PermanentAddress);
            info.Append(Environment.NewLine);
            info.Append(this.MobilePhone + " " + this.Email);
            return info.ToString();
        }
        #endregion

        #region Methods_OtherInterfaces

        public override bool Equals(object obj)
        {
            if (this.SocialSecurityNumber == (obj as Student).SocialSecurityNumber)
            {
                return true;
            }

            return false;
        }

        public object Clone()
        {
            Student copiedStudent = new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SocialSecurityNumber,
                this.University,
                this.Faculty,
                this.Speciality,
                (Address)this.PermanentAddress.Clone(),
                this.MobilePhone,
                this.Email);
        
            return copiedStudent;
        }
        
        public int CompareTo(Student otherStudent)
        {
            if (this.FirstName.CompareTo(otherStudent.FirstName) == 0)
            {
                if (this.MiddleName.CompareTo(otherStudent.MiddleName) == 0)
                {
                    if (this.LastName.CompareTo(otherStudent.LastName) == 0)
                    {
                        return this.SocialSecurityNumber.CompareTo(otherStudent.SocialSecurityNumber);
                    }
                
                    return this.LastName.CompareTo(otherStudent.LastName);
                }
            
                return this.MiddleName.CompareTo(otherStudent.MiddleName);
            }
        
            return this.FirstName.CompareTo(otherStudent.FirstName);
        }
        #endregion
    }
}
