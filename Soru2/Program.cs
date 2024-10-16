using System;

public class Vehicle
{
    // Özellikler
    public string Make { get; set; }    // Marka
    public string Model { get; set; }   // Model
    public int Year { get; set; }       // Üretim Yılı

    // Yapıcı Metot
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    // Taşıt Bilgileri
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Marka: {Make}, Model: {Model}, Yıl: {Year}");
    }
}

// Car (Araba) Sınıfı
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; } // Kapı Sayısı

    public Car(string make, string model, int year, int numberOfDoors) 
        : base(make, model, year)
    {
        NumberOfDoors = numberOfDoors;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Kapı Sayısı: {NumberOfDoors}");
    }
}

// Bicycle (Bisiklet) Sınıfı
public class Bicycle : Vehicle
{
    public bool HasBell { get; set; } // Zil Var mı?

    public Bicycle(string make, string model, int year, bool hasBell) 
        : base(make, model, year)
    {
        HasBell = hasBell;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Zil: {(HasBell ? "Var" : "Yok")}");
    }
}

// Motorcycle (Motosiklet) Sınıfı
public class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; } // Yan Sepet Var mı?

    public Motorcycle(string make, string model, int year, bool hasSidecar) 
        : base(make, model, year)
    {
        HasSidecar = hasSidecar;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Yan Sepet: {(HasSidecar ? "Var" : "Yok")}");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Araba oluşturma
        Car car = new Car("Toyota", "Corolla", 2021, 4);
        car.DisplayInfo();  // Toyota Corolla 2021, 4 kapı

        Console.WriteLine();

        // Bisiklet oluşturma
        Bicycle bicycle = new Bicycle("Giant", "Escape", 2019, true);
        bicycle.DisplayInfo();  // Giant Escape 2019, Zil: Var

        Console.WriteLine();

        // Motosiklet oluşturma
        Motorcycle motorcycle = new Motorcycle("Harley-Davidson", "Sportster", 2020, false);
        motorcycle.DisplayInfo();  // Harley-Davidson Sportster 2020, Yan Sepet: Yok
    }
}