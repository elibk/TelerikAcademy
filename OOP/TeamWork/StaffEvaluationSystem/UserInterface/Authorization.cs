////
namespace UserInterface
{
    using System;
    using System.Linq;
    using StaffEvaluation.Common;

    public static class Authorization
    {
        private static Engine engine;
        private static Client authorizedClient;

        static Authorization()
        {
            engine = Engine.LoadEngine;
        }

        public static bool EmailValidator(string email)
        {
            foreach (var client in engine.ClientList)
            {
                if (email == client.Email)
                {
                    authorizedClient = client;
                    return true;
                }
            }

            return false;
        }

        public static string LoadGreeting()
        {
            if (authorizedClient != null)
            {
                return "Hello " + authorizedClient.FirstName + " " + authorizedClient.LastName + "! Your opinion is important to us, please give us feedback.";
            }
           
            return "You are not autorizatied to use the system.";
        }
    }
}
