using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // 1. Создание категорий и продуктов
                var electronics = new Category { Name = "Electronics" };
                var phone = new Product { Name = "Smartphone", Price = 500, Category = electronics };
                var laptop = new Product { Name = "Laptop", Price = 1000, Category = electronics };

                context.Categories.Add(electronics);
                context.Products.AddRange(phone, laptop);
                context.SaveChanges();
                Console.WriteLine("Categories and products created.");

                // 2. Чтение продуктов по категории
                var category = context.Categories.Include(c => c.Products)
                                                  .FirstOrDefault(c => c.Name == "Electronics");

                if (category != null)
                {
                    Console.WriteLine($"Category: {category.Name}");
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine($"  Product: {product.Name}, Price: {product.Price}");
                    }
                }

                // 3. Обновление категории у продукта
                var productToUpdate = context.Products.FirstOrDefault(p => p.Name == "Smartphone");
                if (productToUpdate != null)
                {
                    var newCategory = new Category { Name = "Mobile Devices" };
                    context.Categories.Add(newCategory);
                    productToUpdate.Category = newCategory;
                    context.SaveChanges();
                    Console.WriteLine("Product category updated.");
                }

                // 4. Удаление категории и всех связанных продуктов
                var categoryToDelete = context.Categories.FirstOrDefault(c => c.Name == "Electronics");
                if (categoryToDelete != null)
                {
                    context.Categories.Remove(categoryToDelete);
                    context.SaveChanges();
                    Console.WriteLine("Category and associated products deleted.");
                }
            }
        }
    }
}


