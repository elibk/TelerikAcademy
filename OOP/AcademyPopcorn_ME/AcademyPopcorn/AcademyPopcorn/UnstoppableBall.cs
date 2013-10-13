using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class UnstoppableBall : Ball
    {
       public new const string CollisionGroupString = "UnstoppableBall";

       public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            
        }

       public override bool CanCollideWith(string otherCollisionGroupString)
       {
           return otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
       }

       public override string GetCollisionGroupString()
       {
           return UnstoppableBall.CollisionGroupString;
       }

       public override void RespondToCollision(CollisionData collisionData)
       {
           if (collisionData.hitObjectsCollisionGroupStrings.IndexOf("UnpassableBlock") >= 0 ||
               collisionData.hitObjectsCollisionGroupStrings.IndexOf("racket") >= 0)
           {
               base.RespondToCollision(collisionData);
           }
       }
    }
}
