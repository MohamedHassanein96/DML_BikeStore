using DML_BikeStore.Data;
using DML_BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DML_BikeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            var result = applicationDbContext.Staffs.Select(e => new { e.FirstName, e.LastName, e.Phone });
            foreach (var item in result)
            {
                Console.WriteLine($"First Name: {item.FirstName}, LastName{item.LastName}, Phone Number{item.Phone}");
            }
            var result2 = applicationDbContext.Customers.Where(e => e.State == "NY").Select(e => new
            {
                FullName = e.FirstName + ' ' + e.LastName,
                PhoneNumber = e.Phone
            });

            foreach (var item in result2)
            {
                Console.WriteLine($"First Name: {item.FullName}, Phone:{item.PhoneNumber}");
            }


            var allCategories = applicationDbContext.Categories.ToList();
            foreach (var item in allCategories)
            {
                Console.WriteLine($"CategoryID: {item.CategoryId}, CategoryName: {item.CategoryName}");
            }

            var allProducts = applicationDbContext.Products.ToList();
            foreach (var item in allProducts)
            {
                Console.WriteLine($"ProductId: {item.ProductId}, ProductName: {item.ProductName}");
            }

            var product1 = applicationDbContext.Products.Find(5);
            Console.WriteLine(product1.ProductId);
            Console.WriteLine(product1.ProductName);



            var allProductsModelYear = applicationDbContext.Products.Where(e=>e.ModelYear==2016);
            foreach (var item in allProductsModelYear)
            {
                Console.WriteLine($"ProductId: {item.ProductId}, ProductName: {item.ProductName}, ModelYear: {item.ModelYear}");
            }


            var customer1 = applicationDbContext.Customers.Where(e => e.CustomerId == 7);
            foreach (var item in customer1)
            {
                Console.WriteLine($"CustomerId: {item.CustomerId}, FirstName: {item.FirstName}.");
            }


            var listofproduct = applicationDbContext.Products.Include(e => e.Brand).Select(e => e);
            foreach (var item in listofproduct)
            {
                Console.WriteLine($"ProductId: {item.ProductId}, ProductName: {item.ProductName}, BrandName: {item.Brand.BrandName}");
            }

            var numberOfProduct = applicationDbContext.Products.Count(e => e.CategoryId == 7);
            Console.WriteLine(numberOfProduct);


            var totalListPriceOfAllProducts = applicationDbContext.Products.Where(e => e.CategoryId == 7).Sum(e => e.ListPrice);
            Console.WriteLine(totalListPriceOfAllProducts);
            

            var averagelListPriceOfAllProducts = applicationDbContext.Products.Average(e => e.ListPrice);
            Console.WriteLine(averagelListPriceOfAllProducts);



            var completedOrders = applicationDbContext.Orders.Where(e => e.OrderStatus == 4);
            foreach (var item in completedOrders)
            {
                Console.WriteLine($"OrderId: {item.OrderId}, OrderDate: {item.OrderDate}");
            }


        }
    }
}
