﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhonebookApplication.Test
{
    [TestClass]
    public class PhonebookRepositoryEasyVersionTest
    {
        [TestMethod]
        public void AddPhone_AddOneContact()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Assert.AreEqual(1, repository.GetContactsCount());
        }

        [TestMethod]
        public void AddPhone_AddTwoSameContact()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Assert.AreEqual(1, repository.GetContactsCount());
        }

        [TestMethod]
        public void AddPhone_AddTwoSameContactIsExists()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
           bool isExists = repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

           Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void AddPhone_AddTwoSameContactCaseSensitive()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            bool isExists = repository.AddPhone("MInKA", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void AddPhone_AddTwoSameContactItDoesNotExists()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            bool isExists = repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
        
            Assert.IsFalse(isExists);
        }

        [TestMethod]
        public void AddPhone_AddFiveDifferentContacts()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Latinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Malinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Ginka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Assert.AreEqual(5, repository.GetContactsCount());
        }

        [TestMethod]
        public void AddPhone_AddFourDifferentContactsAndTwoSame()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Latinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Malinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Ginka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Assert.AreEqual(5, repository.GetContactsCount());
        }

        [TestMethod]
        public void ChangePhone_ChangeOnePhone()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            int phonesChanged = repository.ChangePhone("0888 88 90 00", "0888 88 90 01");

            Assert.AreEqual(1, phonesChanged);
        }

        [TestMethod]
        public void ChangePhone_ChangeUnExistingPhone()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            int phonesChanged = repository.ChangePhone("0888 88 90 05", "0888 88 90 01");

            Assert.AreEqual(0, phonesChanged);
        }

        [TestMethod]
        public void ChangePhone_ChangeFivePhonesOneContact()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();
             
            string[] phones = new string[] 
            {   
                "0888 88 90 00",
                "0888 88 90 00",
                "0888 88 90 00",
                "0888 88 90 00",
                "0888 88 90 00" 
            };
            repository.AddPhone("Minka", phones);

            int phonesChanged = repository.ChangePhone("0888 88 90 00", "0888 88 90 01");

            Assert.AreEqual(1, phonesChanged);
        }

        [TestMethod]
        public void ChangePhone_MatchFiveOfTenContacts()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Latinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Malinka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Ginka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            repository.AddPhone("Minkata", new string[] { "0878 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Latinkata", new string[] { "0878 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Malinkata", new string[] { "0878 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Ginkata", new string[] { "0878 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinkata", new string[] { "0878 88 90 00", "0888 88 90 01" });

            int phonesChanged = repository.ChangePhone("0888 88 90 00", "0888 88 90 01");

            Assert.AreEqual(5, phonesChanged);
        }

        [TestMethod]
        public void ListEntries_OneEntrieOneAsked()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Contact[] expected = { new Contact("Minka", new SortedSet<string> { "0888 88 90 00", "0888 88 90 01" }) };
            Contact[] actual = repository.ListEntries(0, 1);

            Assert.IsTrue(AssistiveMethods.AreEqual(expected, actual));
        }

        [TestMethod]
        public void ListEntries_TwoEntriesOneAsked()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });
            repository.AddPhone("Tinka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            Contact[] expected = { new Contact("Minka", new SortedSet<string> { "0888 88 90 00", "0888 88 90 01" }) };
            Contact[] actual = repository.ListEntries(0, 1);

            Assert.IsTrue(AssistiveMethods.AreEqual(expected, actual));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntries_InvalidCount()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.AddPhone("Minka", new string[] { "0888 88 90 00", "0888 88 90 01" });

            repository.ListEntries(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntries_InvalidCountZeroElementsInRepository()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.ListEntries(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntries_InvalidStartIndex()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            repository.ListEntries(-5, 0);
        }

        [TestMethod]
        public void ListEntries_ZeroElementsAsked()
        {
            PhonebookRepositoryEasyVersion repository = new PhonebookRepositoryEasyVersion();

            Contact[] result = repository.ListEntries(0, 0);

            Assert.IsTrue(result.Length == 0);
        }
    }
}
