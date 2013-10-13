namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class PhonebookRepositoryEasyVersion : IPhonebookRepository
    {
        private List<Contact> contacts;

        public PhonebookRepositoryEasyVersion()
        {
            this.Contacts = new List<Contact>();
        }

        private List<Contact> Contacts
        {
            get
            {
                return this.contacts;
            }

            set
            {
                this.contacts = value;
            }
        }

        public int GetContactsCount()
        {
            return this.Contacts.Count;
        }

        public bool AddPhone(string contactName, IEnumerable<string> contactNumbers)
        {
            var existingContactsWithSameName = from contact in this.Contacts where contact.Name.ToLowerInvariant() == contactName.ToLowerInvariant() select contact;

            Debug.Assert(existingContactsWithSameName.Count() <= 1, "Duplicated name in the phonebook found: " + contactName);

            bool isContactExists = existingContactsWithSameName.Count() != 0;

            if (isContactExists)
            {
                Contact contact = existingContactsWithSameName.First();
                foreach (var num in contactNumbers)
                {
                    contact.PhoneNumbers.Add(num);
                }
            }
            else
            {
                Contact contact = new Contact(contactName, new SortedSet<string>());

                foreach (var num in contactNumbers)
                {
                    contact.PhoneNumbers.Add(num);
                }

                this.Contacts.Add(contact);
            }

            return isContactExists;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var matchingContacts = from contact in this.Contacts where contact.PhoneNumbers.Contains(oldPhoneNumber) select contact;

            int matchingNumbersCount = 0;
            foreach (var contact in matchingContacts)
            {
                contact.PhoneNumbers.Remove(oldPhoneNumber);
                contact.PhoneNumbers.Add(newPhoneNumber);
                matchingNumbersCount++;
            }

            return matchingNumbersCount;
        }

        public Contact[] ListEntries(int start, int countPhoneNumbers)
        {
            if (start < 0 || start + countPhoneNumbers > this.Contacts.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.Contacts.Sort();

            Contact[] contacts = new Contact[countPhoneNumbers];

            for (int i = start; i < start + countPhoneNumbers; i++)
            {
                Contact entry = this.Contacts[i];
                contacts[i - start] = entry;
            }

            return contacts;
        }
    }
}
