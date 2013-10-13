using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class GiftBlock : Block
    {
       public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

       public override IEnumerable<GameObject> ProduceObjects()
       {
           if (IsDestroyed == true)
           {
               return new List<GameObject> { new Gift(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(1, 0)) };
           }
           else
           {
               return new List<GameObject>();
           }
       }

       public override void RespondToCollision(CollisionData collisionData)
       {
           base.RespondToCollision(collisionData);
           
       }
    }
}
