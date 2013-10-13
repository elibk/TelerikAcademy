using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '$' } }, speed)
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
           
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (IsDestroyed == true)
            {
                return new List<GameObject> { new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(-1, 0)) };
            }
            return base.ProduceObjects();
            
        }
        
        
    }
}
