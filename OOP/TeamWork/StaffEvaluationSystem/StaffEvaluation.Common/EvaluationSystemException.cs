////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public class EvaluationSystemException : Exception
    {
        public EvaluationSystemException() : base("A problem has occured while the program is running")
        {
        }

        public EvaluationSystemException(string message) : base(message)
        { 
        }

        public EvaluationSystemException(string message, Exception innerExeption) : base(message, innerExeption)
        {
        }
    }
}
