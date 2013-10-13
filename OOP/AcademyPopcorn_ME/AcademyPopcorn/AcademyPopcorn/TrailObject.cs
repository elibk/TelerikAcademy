using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class TrailObject : GameObject
    {
       private int lifeTime;

       public TrailObject(MatrixCoords topLeft, int lifeTime)
           : base(topLeft, new char[,] { { '*' } })
        {
            this.LifeTime = lifeTime;
        }

       public int LifeTime
        {
            get
            {
                return this.lifeTime;
            }
           private set
            {
                this.lifeTime = value;
            }
        }

        public override void Update()
        {
            this.LifeTime--;
            if (this.LifeTime == 0)
            {
                IsDestroyed = true;
            }
        }
    }
}
