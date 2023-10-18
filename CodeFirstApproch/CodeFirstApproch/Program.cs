using CodeFirstApproch.Data;
using CodeFirstApproch.Models;
using System;

namespace CodeFirstApproch
{
    internal class Program
    {

       

        static void Main(string[] args)
        {
            using DemoContext context = new DemoContext();  // using - context will not exist after execution

            // Add new record

            Product shirt = new Product()
            {
                Name = "polo T-shirt",
                Price = 1000
            };

            context.Products.Add(shirt);  // 1st time you need to specify which table so we use products after that its not required

            Product jeans = new Product()
            {
                Name = "Levis jeans",
                Price = 1000
            };

            context.Add(jeans);
            context.SaveChanges();

            //Linq Operations...

            
            var Products = context.Products.Where(Product => Product.Price > 150).OrderBy(Product => Product.Name);

            foreach (var Product in Products)
            {
                   Console.WriteLine($"Id: {Product.ID}");
                   Console.WriteLine(Product.Name);
                   Console.WriteLine(Product.Price);
            }

            var totalPrice = context.Products.Sum(Product => Product.Price);
            var AvgPrice = context.Products.Average(Product => Product.Price);
            var MinPrice = context.Products.Min(Product => Product.Price);
            var MaxPrice = context.Products.Max(Product => Product.Price);
            var count = context.Products.Count(Product => Product.ID > 0);
            var selectK = context.Products.Select(Product => Product.Name);

            Console.WriteLine(totalPrice);
            Console.WriteLine(AvgPrice);
            Console.WriteLine(MinPrice);
            Console.WriteLine(MaxPrice);
            Console.WriteLine(count);
            Console.WriteLine(selectK);

            var tshirt = context.Products.FirstOrDefault(Product => Product.Name == "polo T-shirt");
            if(tshirt != null)
            {
                tshirt.Price = 175;
            }

            context.SaveChanges();

            var deleteJ = context.Products.FirstOrDefault(Product => Product.Name == "polo T-shirt");
            if (tshirt != null)
            {
                context.Remove(deleteJ);
            }

            context.SaveChanges();
        }
    }
}