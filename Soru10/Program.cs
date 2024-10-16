using System;

public class Character
{
    // Karakter temel özellikleri
    public string Name { get; set; }
    public int Health { get; set; }

    // Constructor
    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // Karakter bilgisi
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Karakter: {Name}, Sağlık: {Health}");
    }

    // Saldırı metodu (türemiş sınıflar tarafından override edilebilir)
    public virtual void Attack()
    {
        Console.WriteLine($"{Name} saldırıya hazırlanıyor...");
    }
}

// Savaşçı sınıfı
public class Warrior : Character
{
    // Constructor
    public Warrior(string name, int health)
        : base(name, health)
    {
    }

    // Kılıç saldırısı yeteneği
    public void SwordAttack()
    {
        Console.WriteLine($"{Name} kılıçla saldırıyor!");
    }

    // Override edilmiş saldırı metodu
    public override void Attack()
    {
        SwordAttack();
    }
}

// Büyücü sınıfı
public class Mage : Character
{
    public int Mana { get; set; } // Büyü gücü için mana

    // Constructor
    public Mage(string name, int health, int mana)
        : base(name, health)
    {
        Mana = mana;
    }

    // Büyü yapma yeteneği
    public void CastSpell()
    {
        if (Mana > 0)
        {
            Console.WriteLine($"{Name} büyü yapıyor!");
            Mana -= 10; // Büyü yapıldığında mana azalır
        }
        else
        {
            Console.WriteLine($"{Name} yeterli mana yok!");
        }
    }

    // Override edilmiş saldırı metodu
    public override void Attack()
    {
        CastSpell();
    }

    // Büyücü bilgisi (mana dahil)
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Mana: {Mana}");
    }
}

// Okçu sınıfı
public class Archer : Character
{
    public int Arrows { get; set; } // Ok miktarı

    // Constructor
    public Archer(string name, int health, int arrows)
        : base(name, health)
    {
        Arrows = arrows;
    }

    // Ok atma yeteneği
    public void ShootArrow()
    {
        if (Arrows > 0)
        {
            Console.WriteLine($"{Name} bir ok fırlatıyor!");
            Arrows--;
        }
        else
        {
            Console.WriteLine($"{Name} artık oku kalmadı!");
        }
    }

    // Override edilmiş saldırı metodu
    public override void Attack()
    {
        ShootArrow();
    }

    // Okçu bilgisi (ok miktarı dahil)
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Ok sayısı: {Arrows}");
    }
}

// Program
class Program
{
    static void Main()
    {
        // Savaşçı karakteri oluşturma
        Warrior warrior = new Warrior("Aragorn", 150);
        warrior.DisplayInfo();
        warrior.Attack(); // Kılıç saldırısı

        Console.WriteLine();

        // Büyücü karakteri oluşturma
        Mage mage = new Mage("Gandalf", 100, 50); // 50 mana ile başlar
        mage.DisplayInfo();
        mage.Attack(); // Büyü yapma

        Console.WriteLine();

        // Okçu karakteri oluşturma
        Archer archer = new Archer("Legolas", 120, 10); // 10 ok ile başlar
        archer.DisplayInfo();
        archer.Attack(); // Ok fırlatma
    }
}