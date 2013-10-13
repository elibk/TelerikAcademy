////
namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StaffEvaluation.Common;

    public sealed class Engine
    {
        //// implementing Singleton 

        private static readonly Engine loadEngine = new Engine();

        private Engine()
        {
            this.DepartmentList = SuperFileLoader.LoadData();
            OperationEventsListener.AppendToList(this.DepartmentList);
            this.ClientList = SuperFileLoader.LoadClients();
        }

        public static Engine LoadEngine
        {
            get { return loadEngine; }
        }

        public StaffEvaluationList<Department> DepartmentList { get; set; }

        public List<Client> ClientList { get; set; }

        public void SaveUpdates()
        {
            SuperFileWriter.UpdateFiles(this.DepartmentList);
        }
    }
}
