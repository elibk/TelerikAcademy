////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public interface IEvaluetable
    {
        void Evaluate(int employeeID, int mark);
    }
}
