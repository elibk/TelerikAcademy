using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H01KnapsackProblem
{
    public class Product : IComparable<Product>, IComparable
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public override bool Equals(object obj)
        {
            return this.Name == (obj as Product).Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo((obj as Product));
        }

        public int CompareTo(Product other)
        {
            int check = this.Cost.CompareTo(other.Cost);

            if (check == 0)
            {
                check = this.Weight.CompareTo(other.Weight);
            }

            return check;
        }
    }
}
