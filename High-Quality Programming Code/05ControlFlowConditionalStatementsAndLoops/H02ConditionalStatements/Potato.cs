////
namespace H02ConditionalStatements
{
    using System;
    using System.Linq;

    internal class Potato
    {
        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }

        public bool IsReadyForCooking()
        {
            if (this == null)
            {
                throw new ArgumentNullException("The potato with value null can not be checked.");
            }

            if (this.IsPeeled && !this.IsRotten)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
