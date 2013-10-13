////
namespace StaffEvaluation.Common
{
    using System;
    using System.Linq;

    public static class OperationEventsListener
    {
        private static StaffEvaluationList<Department> privateList;

        public static void AppendToList(StaffEvaluationList<Department> aList)
        {
            privateList = aList;

            privateList.PromoteEvent += PromoteEventAction;
            privateList.DemoteEvent += DemoteEventAction;
            privateList.NormalEvent += NormalEventAction;
        }

        private static void NormalEventAction(object sender, StaffEventArgs e)
        {
            Worker w = privateList.SearchInAllDepartments(e.StaffEvaluationListID);
            if (w != null)
            {
                w.Status = WorkerStatus.Normal;
            }
        }
        
        private static void PromoteEventAction(object sender, StaffEventArgs e)
        {
            Worker w = privateList.SearchInAllDepartments(e.StaffEvaluationListID);
            if (w != null)
            {
                w.Status = WorkerStatus.ForPromotion;
            }
        }

        private static void DemoteEventAction(object sender, StaffEventArgs e)
        {
            Worker w = privateList.SearchInAllDepartments(e.StaffEvaluationListID);
            if (w != null)
            {
                w.Status = WorkerStatus.ForDemotion;
            }
        }
    }
}
