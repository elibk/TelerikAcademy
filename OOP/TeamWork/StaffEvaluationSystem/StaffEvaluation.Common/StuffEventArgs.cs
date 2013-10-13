////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    ////Added by Yordan
    public class StaffEventArgs : EventArgs
    {
        public int StaffEvaluationListID { get; set; }

        public int Mark { get; set; }
    }
}
