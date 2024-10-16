using System;

// Ana Event (Etkinlik) Sınıfı
public class Event
{
    // Özellikler
    public string Name { get; set; }   // Etkinlik Adı
    public DateTime Date { get; set; } // Etkinlik Tarihi
    public string Location { get; set; } // Etkinlik Yeri

    // Yapıcı Metot
    public Event(string name, DateTime date, string location)
    {
        Name = name;
        Date = date;
        Location = location;
    }

    // Etkinlik Bilgilerini Gösterme
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Etkinlik: {Name}, Tarih: {Date}, Yer: {Location}");
    }
}

// Toplantı Sınıfı (Meeting)
public class Meeting : Event
{
    public string Agenda { get; set; } // Toplantı Gündemi

    // Yapıcı Metot
    public Meeting(string name, DateTime date, string location, string agenda)
        : base(name, date, location)
    {
        Agenda = agenda;
    }

    // Toplantı Bilgilerini Gösterme
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Gündem: {Agenda}");
    }
}

// Doğum Günü Sınıfı (Birthday)
public class Birthday : Event
{
    public string BirthdayPerson { get; set; } // Doğum Günü Kişisi

    // Yapıcı Metot
    public Birthday(string name, DateTime date, string location, string birthdayPerson)
        : base(name, date, location)
    {
        BirthdayPerson = birthdayPerson;
    }

    // Doğum Günü Bilgilerini Gösterme
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Doğum Günü Kişisi: {BirthdayPerson}");
    }
}

// Görev Sınıfı (Task)
public class Task : Event
{
    public bool IsCompleted { get; private set; } // Görev Tamamlandı mı?

    // Yapıcı Metot
    public Task(string name, DateTime date, string location)
        : base(name, date, location)
    {
        IsCompleted = false;
    }

    // Görevi Tamamlandı Olarak İşaretleme
    public void MarkAsComplete()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Görev tamamlandı: {Name}");
        }
        else
        {
            Console.WriteLine($"Görev zaten tamamlanmış: {Name}");
        }
    }

    // Görev Bilgilerini Gösterme
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Durum: {(IsCompleted ? "Tamamlandı" : "Tamamlanmadı")}");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Toplantı oluşturma
        Meeting meeting = new Meeting("Proje Toplantısı", new DateTime(2024, 10, 20, 10, 30, 0), "Toplantı Odası A", "Proje Gelişimi");
        meeting.DisplayInfo();

        Console.WriteLine();

        // Doğum Günü oluşturma
        Birthday birthday = new Birthday("Enes'in Doğum Günü", new DateTime(2024, 11, 15), "Enes'in Evi", "Enes");
        birthday.DisplayInfo();

        Console.WriteLine();

        // Görev oluşturma
        Task task = new Task("Rapor Hazırlama", new DateTime(2024, 10, 25), "Ofis");
        task.DisplayInfo();

        Console.WriteLine();

        // Görevi tamamlandı olarak işaretleme
        task.MarkAsComplete();
        task.DisplayInfo();
    }
}
