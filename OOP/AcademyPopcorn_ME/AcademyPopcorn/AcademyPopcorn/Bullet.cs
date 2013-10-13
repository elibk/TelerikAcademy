using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class Bullet : Ball
    {
       public const char Symbol = '^';
       public Bullet(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = Bullet.Symbol;
        }
        
        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = true;
        }
    }
}
