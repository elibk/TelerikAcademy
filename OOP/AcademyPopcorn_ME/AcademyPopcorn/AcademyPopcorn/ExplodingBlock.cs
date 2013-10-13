using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class ExplodingBlock :  Block
    {
       public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

       public override IEnumerable<GameObject> ProduceObjects()
       {
           List<GameObject> bullets = new List<GameObject>();
           if (IsDestroyed == true)
           {
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(-1, 0)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(1, 0)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(0, 1)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(0, -1)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(1, 1)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(-1, -1)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(1, -1)));
               bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col), new MatrixCoords(-1, 1)));
           }
           
           return bullets;
       }
    }
}
