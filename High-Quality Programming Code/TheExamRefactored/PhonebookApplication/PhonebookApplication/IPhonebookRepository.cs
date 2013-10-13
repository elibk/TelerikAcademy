namespace PhonebookApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds new entrie to the phonebook. If the name compered case insensitive 
        /// exists, the numbers are merged to it. Dublicates are not accepted.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <param name="phoneNumbers">The phone numbers to be added.</param>
        /// <returns>True if contact had existed or False if it has been added new</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Replaces the old phone number with new in all contacts that use it.
        /// </summary>
        /// <param name="oldPhoneNumber">The old phone number.</param>
        /// <param name="newPhoneNumber">The new phone number.</param>
        /// <returns> The number of contacts in which the number has been updated.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Gets array of entries ordered by name.
        /// </summary>
        /// <param name="startIndex">The start index to get entries.</param>
        /// <param name="count">The count of entries to be get.</param>
        /// <returns>Array containig the requated entries.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">In case the startIndex or the count are invalid.</exception>
        Contact[] ListEntries(int startIndex, int count);
    }
}
