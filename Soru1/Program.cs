using System;

public class Animal
{
    // Özellikler
    public string Name { get; set; }
    public int Age { get; set; }
    public string Species { get; set; }

    // Yapıcı Metot
    public Animal(string name, int age, string species)
    {
        Name = name;
        Age = age;
        Species = species;
    }

    // Hayvanın ses çıkarma metodu (virtual)
    public virtual void MakeSound()
    {
        Console.WriteLine("Hayvan sesi");
    }
}

// Lion sınıfı
public class Lion : Animal
{
    public Lion(string name, int age) : base(name, age, "Aslan") { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Kükreme!");
    }
}

// Elephant sınıfı
public class Elephant : Animal
{
    public Elephant(string name, int age) : base(name, age, "Fil") { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Boru sesi!");
    }
}

// Giraffe sınıfı
public class Giraffe : Animal
{
    public Giraffe(string name, int age) : base(name, age, "Zürafa") { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Uzak bir ses!");
    }
}

// Program
class Program
{
    static void Main()
    {
        Animal lion = new Lion("Leo", 5);
        Animal elephant = new Elephant("Dumbo", 10);
        Animal giraffe = new Giraffe("Gigi", 7);

        lion.MakeSound();      // Leo: Kükreme!
        elephant.MakeSound();  // Dumbo: Boru sesi!
        giraffe.MakeSound();   // Gigi: Uzak bir ses!
    }
}
