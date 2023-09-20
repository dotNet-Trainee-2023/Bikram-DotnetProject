using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public class LINQ
    {
        public static void Linq()
        {
            //adding list
            List<ProductDatabase> productDatabase = new List<ProductDatabase>
        {
            new ProductDatabase { Id = 1, Name = "T-shirt", Description = "Clothing", price=400 },
            new ProductDatabase { Id = 2, Name = "Smartphone", Description = "Electronics" ,price = 50000},
            new ProductDatabase { Id = 3, Name = "Sneakers", Description = "Clothing" , price = 3000},
            new ProductDatabase { Id = 4, Name = "Headphones", Description = "Electronics" , price = 6000},
            new ProductDatabase { Id = 5, Name = "Backpack", Description = "Clothing"   , price = 900},
        };
            // Order the list in ascending order by Age.
            IEnumerable<ProductDatabase> clothing = productDatabase.Where(x => x.Description == "Clothing");

            foreach (ProductDatabase p in clothing)
            {
                Console.WriteLine($" {p.Description}");
            }

            var electronicsproductcount= productDatabase.Count(product=>product.Description=="Electronics");
            Console.WriteLine($"the product count is {electronicsproductcount}  ");

            var expensivProduct = productDatabase.OrderByDescending(product => product.price);
            foreach (ProductDatabase p in expensivProduct)
            {
                Console.WriteLine($"the price range from higtolow is {p.price}");
            }

            var producthigherthan500 = productDatabase.Any(product => product.price > 500);
            foreach (ProductDatabase p in expensivProduct)
            {
                Console.WriteLine($"the price range from 500 is {p.Name}");
            }

            var totalsum=productDatabase.Sum(product => product.price);
            Console.WriteLine($"the total sum is {totalsum}");

            var maxprice=productDatabase.Max(product=> product.price);
            Console.WriteLine($"The maximum price is {maxprice}");
        }

    }
}

