namespace PhonebookApplication
{
    using System;

    public interface IContact
    {
        string Name { get;}

        System.Collections.Generic.SortedSet<string> PhoneNumbers { get; }

        int CompareTo(Contact other);

        string ToString();
    }
}