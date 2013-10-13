////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

   public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }

        byte Age { get; }
    }
}
