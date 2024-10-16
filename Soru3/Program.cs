using System;

public class Employee
{
    // Özellikler
    public string Name { get; set; }    // İsim
    public int Id { get; set; }         // Kimlik Numarası
    public decimal Salary { get; set; } // Maaş

    // Yapıcı Metot
    public Employee(string name, int id, decimal salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    // Çalışan Bilgileri
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"İsim: {Name}, Kimlik No: {Id}, Maaş: {Salary:C}");
    }
}

// Manager (Yönetici) Sınıfı
public class Manager : Employee
{
    public int NumberOfTeams { get; set; } // Takım Sayısı

    public Manager(string name, int id, decimal salary, int numberOfTeams)
        : base(name, id, salary)
    {
        NumberOfTeams = numberOfTeams;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Yönetilen Takım Sayısı: {NumberOfTeams}");
    }
}

// Developer (Geliştirici) Sınıfı
public class Developer : Employee
{
    public string ProgrammingLanguage { get; set; } // Programlama Dili

    public Developer(string name, int id, decimal salary, string programmingLanguage)
        : base(name, id, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Programlama Dili: {ProgrammingLanguage}");
    }
}

// Intern (Stajyer) Sınıfı
public class Intern : Employee
{
    public int InternshipDuration { get; set; } // Staj Süresi (ay)

    public Intern(string name, int id, decimal salary, int internshipDuration)
        : base(name, id, salary)
    {
        InternshipDuration = internshipDuration;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Staj Süresi: {InternshipDuration} ay");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Manager (Yönetici) oluşturma
        Manager manager = new Manager("Enes Demir", 101, 12000m, 3);
        manager.DisplayInfo();  // Ayşe Yılmaz, Kimlik No: 101, Maaş: 12000, Takım Sayısı: 3

        Console.WriteLine();

        // Developer (Geliştirici) oluşturma
        Developer developer = new Developer("Mehmet Demir", 102, 10000m, "C#");
        developer.DisplayInfo();  // Mehmet Demir, Kimlik No: 102, Maaş: 10000, Programlama Dili: C#

        Console.WriteLine();

        // Intern (Stajyer) oluşturma
        Intern intern = new Intern("Hasan Demir", 103, 3000m, 6);
        intern.DisplayInfo();  // Ali Veli, Kimlik No: 103, Maaş: 3000, Staj Süresi: 6 ay
    }
}