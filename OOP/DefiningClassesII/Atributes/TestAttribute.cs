////
namespace Atributes
{
    using System;
    using System.Linq;

    [Version(2, 11)]
   public class TestAttribute
    {
       private static void Main(string[] args)
        {
            Type type = typeof(TestAttribute);
            object[] allAttributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("{0} vesion [{1}].", type.Name, attribute.Version);
            }
        }
       //object[] versionAttributes = typeof(Program).GetCustomAttributes(typeof(VersionAttribute), false);
       //  Console.WriteLine("Version: {0}", versionAttributes[0]);
    }
}
