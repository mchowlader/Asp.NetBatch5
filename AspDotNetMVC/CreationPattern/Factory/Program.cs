using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "camera";
            var price = 2000;
            double? disount = 20;

            IProduct product = ProductFactory.CreateProduct<Electronics>(name, price, disount);

            Console.WriteLine("Product Type: " + product.GetType());
            Console.WriteLine("Product Name: " + product.Name);
            Console.WriteLine("Product Price After Discount: " + product.Price);
        }
    }
}
