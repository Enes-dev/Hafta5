using System;

public class Calculator
{
    // Toplama işlemi
    public double Add(double a, double b)
    {
        return a + b;
    }

    // Çıkarma işlemi
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    // Çarpma işlemi
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    // Bölme işlemi
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Bölme hatası: Sıfıra bölme yapılamaz.");
            return double.NaN; // Bölme hatası
        }
        return a / b;
    }
}

// ScientificCalculator (Bilimsel Hesap Makinesi) sınıfı
public class ScientificCalculator : Calculator
{
    // Sinüs işlemi
    public double Sin(double angleInDegrees)
    {
        double angleInRadians = Math.PI * angleInDegrees / 180.0;
        return Math.Sin(angleInRadians);
    }

    // Kosinüs işlemi
    public double Cos(double angleInDegrees)
    {
        double angleInRadians = Math.PI * angleInDegrees / 180.0;
        return Math.Cos(angleInRadians);
    }

    // Tangent işlemi
    public double Tan(double angleInDegrees)
    {
        double angleInRadians = Math.PI * angleInDegrees / 180.0;
        return Math.Tan(angleInRadians);
    }
}

// Program
class Program
{
    static void Main()
    {
        // Standart hesap makinesi
        Calculator calculator = new Calculator();

        Console.WriteLine("Toplama: 5 + 3 = " + calculator.Add(5, 3));
        Console.WriteLine("Çıkarma: 8 - 4 = " + calculator.Subtract(8, 4));
        Console.WriteLine("Çarpma: 6 * 7 = " + calculator.Multiply(6, 7));
        Console.WriteLine("Bölme: 10 / 2 = " + calculator.Divide(10, 2));
        
        // Bilimsel hesap makinesi
        ScientificCalculator sciCalculator = new ScientificCalculator();

        Console.WriteLine("\nSinüs (30°): " + sciCalculator.Sin(30));
        Console.WriteLine("Kosinüs (60°): " + sciCalculator.Cos(60));
        Console.WriteLine("Tanjant (45°): " + sciCalculator.Tan(45));
    }
}