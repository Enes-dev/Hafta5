using System;

public class Person
{
    // Kişi temel özellikleri
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Ortak metod (türemiş sınıflar tarafından override edilecek)
    public virtual void AttendClass()
    {
        Console.WriteLine($"{Name} derse katılıyor.");
    }
}

// Öğretmen sınıfı
public class Teacher : Person
{
    public string SubjectTaught { get; set; } // Öğrettiği Konu

    // Constructor
    public Teacher(string name, int age, string subjectTaught)
        : base(name, age)
    {
        SubjectTaught = subjectTaught;
    }

    // Derse katılma metodu (override edildi)
    public override void AttendClass()
    {
        Console.WriteLine($"{Name}, {SubjectTaught} dersini öğretiyor.");
    }
}

// Öğrenci sınıfı
public class Student : Person
{
    public int GradeLevel { get; set; } // Sınıf seviyesi

    // Constructor
    public Student(string name, int age, int gradeLevel)
        : base(name, age)
    {
        GradeLevel = gradeLevel;
    }

    // Derse katılma metodu (override edildi)
    public override void AttendClass()
    {
        Console.WriteLine($"{Name}, {GradeLevel}. sınıf öğrencisi olarak derse katılıyor.");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Öğretmen oluşturma ve işlemler
        Teacher mathTeacher = new Teacher("Enes Demir", 40, "Yazılım");
        mathTeacher.AttendClass(); // Öğretmenin derse katılması

        Console.WriteLine();

        // Öğrenci oluşturma ve işlemler
        Student student = new Student("Mehmet Kaya", 16, 10);
        student.AttendClass(); // Öğrencinin derse katılması
    }
}