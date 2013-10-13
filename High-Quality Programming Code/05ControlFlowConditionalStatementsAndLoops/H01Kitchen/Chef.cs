////
namespace H01Kitchen
{
    using System;
    using System.Linq;

    public class Chef
    {      
        public void Cook()
        {
            Potato potatoForCook = this.GetPotato();
            Carrot carrotForCook = this.GetCarrot();
            Bowl dish;

            this.Peel(potatoForCook);
            this.Peel(carrotForCook);

            this.Cut(potatoForCook);
            this.Cut(carrotForCook);

            dish = this.GetBowl();
            dish.Add(carrotForCook);
            dish.Add(potatoForCook);
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private void Cut(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private void Peel(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }
    }
}
