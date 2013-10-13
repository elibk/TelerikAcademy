////
namespace H06Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository
    {
        private readonly MultiDictionary<string, PhonebookEntry> dictByFirstName;
        private readonly MultiDictionary<string, PhonebookEntry> dictByMiddleName;
        private readonly MultiDictionary<string, PhonebookEntry> dictByLastName;
        private readonly MultiDictionary<string, PhonebookEntry> dictByNickname;

        public PhonebookRepository()
        {
            this.dictByFirstName = new MultiDictionary<string, PhonebookEntry>(true);
            this.dictByMiddleName = new MultiDictionary<string, PhonebookEntry>(true);
            this.dictByLastName = new MultiDictionary<string, PhonebookEntry>(true);
            this.dictByNickname = new MultiDictionary<string, PhonebookEntry>(true);
        }

        public void AddEntry(PhonebookEntry newEntry)
        {
            if (newEntry.FirstName != PhonebookEntry.NameDefaultValue)
            {
                this.dictByFirstName.Add(newEntry.FirstName, newEntry);
            }

            if (!(newEntry.MiddleName != PhonebookEntry.NameDefaultValue))
            {
                this.dictByMiddleName.Add(newEntry.MiddleName, newEntry);
            }

            if (newEntry.LastName != PhonebookEntry.NameDefaultValue)
            {
                this.dictByLastName.Add(newEntry.LastName, newEntry);
            }

            if (newEntry.NickName != PhonebookEntry.NameDefaultValue)
            {
                this.dictByNickname.Add(newEntry.NickName, newEntry);
            }
        }

        public IEnumerable<PhonebookEntry> Find(string name)
        {
            HashSet<PhonebookEntry> matchedEntries = new HashSet<PhonebookEntry>();
            GetMatches(name, matchedEntries, this.dictByFirstName);
                                          
            GetMatches(name, matchedEntries, this.dictByMiddleName);
                                           
            GetMatches(name, matchedEntries, this.dictByLastName);
                                          
            GetMatches(name, matchedEntries, this.dictByNickname);

            return matchedEntries;
        }

        public IEnumerable<PhonebookEntry> Find(string name, string town)
        {
            var matchedEnties = this.Find(name).Where(entry => entry.Town == town);
            return matchedEnties;
        }

        private static void GetMatches(string name, HashSet<PhonebookEntry> entries, MultiDictionary<string, PhonebookEntry> dict)
        {
            if (dict.ContainsKey(name))
            {
                foreach (var entry in dict[name])
                {
                    if (!entries.Contains(entry))
                    {
                        entries.Add(entry);
                    }
                }
            }
        }
    }
}
