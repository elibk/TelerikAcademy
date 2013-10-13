////
namespace Atributes
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | 
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

   public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(int major, int minor)
        {
          this.Version = string.Empty + major + '.' + minor;
        }

        public string Version { get; set; }
    }
}
