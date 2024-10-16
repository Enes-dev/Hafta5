using System;

public class Product
{
    // Ürün temel özellikleri
    public string Name { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    // Constructor
    public Product(string name, double price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    // Stok kontrol etme metodu
    public void CheckStock()
    {
        if (StockQuantity > 0)
        {
            Console.WriteLine($"{Name} stokta var. Mevcut stok: {StockQuantity}");
        }
        else
        {
            Console.WriteLine($"{Name} stokta yok.");
        }
    }

    // Stok güncelleme metodu
    public void UpdateStock(int quantity)
    {
        StockQuantity += quantity;
        Console.WriteLine($"{Name} stok miktarı güncellendi. Yeni stok: {StockQuantity}");
    }
}

// Gıda Ürünü sınıfı
public class FoodProduct : Product
{
    public DateTime ExpirationDate { get; set; } // Son Kullanma Tarihi

    // Constructor
    public FoodProduct(string name, double price, int stockQuantity, DateTime expirationDate)
        : base(name, price, stockQuantity)
    {
        ExpirationDate = expirationDate;
    }

    // Son kullanma tarihi kontrol etme metodu
    public void CheckExpirationDate()
    {
        if (DateTime.Now > ExpirationDate)
        {
            Console.WriteLine($"{Name} ürünü son kullanma tarihini geçti.");
        }
        else
        {
            Console.WriteLine($"{Name} ürünü halen kullanılabilir. Son kullanma tarihi: {ExpirationDate.ToShortDateString()}");
        }
    }
}

// Elektronik Ürün sınıfı
public class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; } // Garanti Süresi (ay cinsinden)

    // Constructor
    public ElectronicProduct(string name, double price, int stockQuantity, int warrantyPeriod)
        : base(name, price, stockQuantity)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    // Garanti süresi kontrol etme metodu
    public void CheckWarranty()
    {
        Console.WriteLine($"{Name} ürünü {WarrantyPeriod} ay garantilidir.");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Gıda ürünü oluşturma ve işlemler
        FoodProduct apple = new FoodProduct("Elma", 3.50, 100, new DateTime(2024, 12, 30));
        apple.CheckStock();
        apple.CheckExpirationDate();
        apple.UpdateStock(-20);
        
        Console.WriteLine();

        // Elektronik ürünü oluşturma ve işlemler
        ElectronicProduct laptop = new ElectronicProduct("Laptop", 5000, 10, 24);
        laptop.CheckStock();
        laptop.CheckWarranty();
        laptop.UpdateStock(5);
    }
}