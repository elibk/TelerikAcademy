namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepositoryOriginal : IPhonebookRepository
    {
        private readonly OrderedSet<Contact> sortedContacts = new OrderedSet<Contact>();
        private readonly Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();
        private readonly MultiDictionary<string, Contact> multidict = new MultiDictionary<string, Contact>(false);

        public int GetContactsCount()
        {
            return this.contacts.Count;
        }

        public bool AddPhone(string contactName, IEnumerable<string> contactNumbers)
        {
            string adaptedContactName = contactName.ToLowerInvariant();

            Contact contact;

            bool isContactExists = this.contacts.TryGetValue(adaptedContactName, out contact);

            if (!isContactExists)
            {
                contact = new Contact(contactName, new SortedSet<string>());
                this.contacts.Add(adaptedContactName, contact);
                this.sortedContacts.Add(contact);
            }

            foreach (var num in contactNumbers)
            {
                this.multidict.Add(num, contact);
            }

            contact.PhoneNumbers.UnionWith(contactNumbers);
            return isContactExists;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var matchingContacts = this.multidict[oldPhoneNumber].ToList();
            foreach (var contact in matchingContacts)
            {
                contact.PhoneNumbers.Remove(oldPhoneNumber);
                this.multidict.Remove(oldPhoneNumber, contact);

                contact.PhoneNumbers.Add(newPhoneNumber);
                this.multidict.Add(newPhoneNumber, contact);
            }

            return matchingContacts.Count;
        }

        public Contact[] ListEntries(int startIndex, int countOfEntries)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            Contact[] list = new Contact[countOfEntries];

            for (int i = startIndex; i <= startIndex + countOfEntries - 1; i++)
            {
                Contact entry = this.sortedContacts[i];
                list[i - startIndex] = entry;
            }

            return list;
        }
    }
}
