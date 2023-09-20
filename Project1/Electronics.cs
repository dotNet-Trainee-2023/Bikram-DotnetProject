

namespace Project1
{
    public class Electronics : ProductCategory, Product
    {
        string category;
        int price;
        int quantity;
        public Electronics()
        {
            category = "Electronics";
            price = 1000;
            quantity = 40;
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
        public (string,int,int) ElectronicsDetial()
        {
            return ("Electronics", 1000, 40);
        }
    }
}
