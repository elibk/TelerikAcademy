using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
   public class ShootRacketEngine : Engine
    {
       private List<Bullet> bullets = new List<Bullet>();

       public ShootRacketEngine(IRenderer renderer, IUserInterface userInterface, int gameSpeed)
            :base(renderer, userInterface, gameSpeed)
        {
            
        }

       

        public List<Bullet> Bullets
        {
            get
            {
                return this.bullets;
            }
           private set
            {
                this.bullets = value;
            }
        }

        public IEnumerable<GameObject> ShootPlayerRacket()
        {
           this.bullets.RemoveAt(0);
           return bullets;
       }
    }
}
