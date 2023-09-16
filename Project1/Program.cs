
namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int elctronicCost, clothingCost,electronicQuantity,clothingQuantity;
            string boolvalue1 = "true";
            string? boolvalue2; //Null Coalescing
            bool bool1,bool2;
            //creating object of the program
            Electronics electronics = new Electronics();
            Clothing clothing = new Clothing();
            
          

            
            electronicQuantity=electronics.GetQuantityInfo();
            Console.WriteLine($"the total elctronics quantity is {electronicQuantity}");
            clothingQuantity =clothing.GetQuantityInfo();
            Console.WriteLine($"the total clothing quantity is {clothingQuantity}");
            electronics.CategoryInfo();
            clothing.CategoryInfo();

            //ternary opertaor
            elctronicCost = electronics.GetCost();
            string result= (elctronicCost==40000)? $"the total elctronics cost is {elctronicCost}" : "Not avaliable";
            Console.WriteLine(result);

            //Using int parse
            Console.WriteLine("Enter the product id:");
            string? input1 = Console.ReadLine();
            int ProductId = int.Parse(input1);

            //using tryparsing
            if(bool.TryParse(boolvalue1, out bool1))
            {
                Console.WriteLine($"Parsing {boolvalue1} succeeded");
            }
            else 
            {
                Console.WriteLine($"Parsing {boolvalue1} failed");
            }
            Console.WriteLine("enter the value of bool:");
            boolvalue2= Console.ReadLine();
            if (bool.TryParse(boolvalue2, out bool2))
            {
                Console.WriteLine($"Parsing {boolvalue2} succeeded");
            }
            else
            {
                Console.WriteLine($"Parsing {boolvalue2} failed");
            }

            //using tuple
            var electronicsInfo = electronics.ElectronicsDetial();
            string? category = electronicsInfo.Item1;
            int price=electronicsInfo.Item2;
            int quantity = electronicsInfo.Item3;
            Console.WriteLine($"Category:{category},Price:{price},quantity:{quantity}");

            //Linq operation
            LINQ.Linq();

        }

    }
}