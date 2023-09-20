using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public abstract class ProductCategory
    {
        const string category= "Allproduct";
        public virtual void CategoryInfo()
        {
            Console.WriteLine($"This contain {category} ");
        }
    }
}
