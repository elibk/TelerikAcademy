using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public new const string CollisionGroupString = "IndestructibleBlock";
        public const char Symbol = '|';

        public IndestructibleBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
            //  || otherCollisionGroupString == "UnstoppableBall"; //in case we want Indestructible block to can be destroyed by  UnstoppableBall
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //if (collisionData.hitObjectsCollisionGroupStrings.IndexOf("UnstoppableBall") >= 0)
            //{
            //    base.RespondToCollision(collisionData);
            //}
        }



        public override string GetCollisionGroupString()
        {
            return IndestructibleBlock.CollisionGroupString;
        }
       
    }
}
