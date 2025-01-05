namespace EFCoreExample
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Название продукта
        public decimal Price { get; set; } // Цена
        public int CategoryId { get; set; } // Foreign Key для категории
        public Category Category { get; set; } // Навигационное свойство
    }
}
