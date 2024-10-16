using System;

public class Account
{
    // Hesap temel özellikleri
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    // Constructor
    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Para yatırma işlemi
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{amount} TL yatırıldı. Yeni bakiye: {Balance} TL");
    }

    // Para çekme işlemi
    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} TL çekildi. Yeni bakiye: {Balance} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }
}

// Tasarruf hesabı sınıfı
public class SavingsAccount : Account
{
    public decimal InterestRate { get; set; } // Faiz oranı

    // Constructor
    public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate)
        : base(accountNumber, initialBalance)
    {
        InterestRate = interestRate;
    }

    // Faiz hesaplama işlemi
    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate / 100;
        Balance += interest;
        Console.WriteLine($"Faiz uygulandı: {interest} TL. Yeni bakiye: {Balance} TL");
    }
}

// Vadesiz hesap sınıfı
public class CheckingAccount : Account
{
    public int CheckLimit { get; set; } // Çek yazma limiti

    // Constructor
    public CheckingAccount(string accountNumber, decimal initialBalance, int checkLimit)
        : base(accountNumber, initialBalance)
    {
        CheckLimit = checkLimit;
    }

    // Çek yazma işlemi
    public void WriteCheck(decimal amount)
    {
        if (Balance >= amount && CheckLimit > 0)
        {
            Balance -= amount;
            CheckLimit--;
            Console.WriteLine($"{amount} TL tutarında çek yazıldı. Kalan bakiye: {Balance} TL, Kalan çek limiti: {CheckLimit}");
        }
        else if (CheckLimit == 0)
        {
            Console.WriteLine("Çek limiti doldu.");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    // Para çekme işlemi override edildi
    public override void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} TL vadesiz hesaptan çekildi. Yeni bakiye: {Balance} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye (Vadesiz hesap).");
        }
    }
}

// Program
class Program
{
    static void Main()
    {
        // Tasarruf hesabı oluşturma
        SavingsAccount savings = new SavingsAccount("TR123456789", 1000, 5); // %5 faiz oranı
        savings.Deposit(500); // Para yatırma
        savings.ApplyInterest(); // Faiz uygulama

        Console.WriteLine();

        // Vadesiz hesap oluşturma
        CheckingAccount checking = new CheckingAccount("TR987654321", 2000, 3); // 3 çek limiti
        checking.WriteCheck(400); // Çek yazma
        checking.WriteCheck(700); // Çek yazma
        checking.Withdraw(500); // Vadesiz hesaptan para çekme
    }
}