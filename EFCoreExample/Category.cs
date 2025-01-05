using System.Collections.Generic;

namespace EFCoreExample
{
    public class Category
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Название категории
        public ICollection<Product> Products { get; set; } = new List<Product>(); // Продукты в категории
    }
}