using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Clothing : ProductCategory, Product
    {

        string category;
        int price;
        int quantity;

        public Clothing()
        {
            category = "Clothing";
            price = 500;
            quantity = 50;
        }
        public int GetCost()
        {
            return quantity * price;
        }

        public int GetQuantityInfo()
        {
            return quantity;
        }
        public override void CategoryInfo()
        {
            Console.WriteLine($"This contain {category} ");
        }
    }
}
