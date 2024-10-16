using System;
using System.Collections.Generic;

public class Book
{
    // Özellikler
    public string Title { get; set; }   // Başlık
    public string Author { get; set; }  // Yazar
    public int Pages { get; set; }      // Sayfa Sayısı
    public string ISBN { get; set; }    // ISBN Numarası
    public bool IsBorrowed { get; private set; }  // Ödünç Alınmış mı?

    // Yapıcı Metot
    public Book(string title, string author, int pages, string isbn)
    {
        Title = title;
        Author = author;
        Pages = pages;
        ISBN = isbn;
        IsBorrowed = false;  // Başlangıçta ödünç alınmamış
    }

    // Ödünç Alma Metodu
    public void Borrow()
    {
        if (IsBorrowed)
        {
            Console.WriteLine($"Kitap zaten ödünç alınmış: {Title}");
        }
        else
        {
            IsBorrowed = true;
            Console.WriteLine($"Kitap ödünç alındı: {Title}");
        }
    }

    // İade Etme Metodu
    public void Return()
    {
        if (!IsBorrowed)
        {
            Console.WriteLine($"Kitap zaten kütüphanede: {Title}");
        }
        else
        {
            IsBorrowed = false;
            Console.WriteLine($"Kitap iade edildi: {Title}");
        }
    }

    // Kitap Bilgileri
    public void DisplayInfo()
    {
        Console.WriteLine($"Başlık: {Title}, Yazar: {Author}, Sayfa Sayısı: {Pages}, ISBN: {ISBN}, Durum: {(IsBorrowed ? "Ödünç Alınmış" : "Kütüphanede")}");
    }
}

// Library (Kütüphane) Sınıfı
public class Library
{
    private List<Book> books;  // Kitap Koleksiyonu

    // Yapıcı Metot
    public Library()
    {
        books = new List<Book>();
    }

    // Kitap Ekleme
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Kitap eklendi: {book.Title}");
    }

    // Kitapları Listeleme
    public void ListBooks()
    {
        Console.WriteLine("Kütüphanedeki Kitaplar:");
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }

    // Kitap Arama (ISBN ile)
    public Book FindBookByISBN(string isbn)
    {
        foreach (var book in books)
        {
            if (book.ISBN == isbn)
                return book;
        }
        Console.WriteLine($"ISBN numarası ile kitap bulunamadı: {isbn}");
        return null;
    }
}

// Program
class Program
{
    static void Main()
    {
        // Kütüphane oluşturma
        Library library = new Library();

        // Kitaplar oluşturma
        Book book1 = new Book("Savaş ve Barış", "Lev Tolstoy", 1225, "978-1234567890");
        Book book2 = new Book("1984", "George Orwell", 328, "978-9876543210");
        Book book3 = new Book("Dönüşüm", "Franz Kafka", 201, "978-1122334455");

        // Kitapları kütüphaneye ekleme
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        Console.WriteLine();

        // Kütüphanedeki kitapları listeleme
        library.ListBooks();

        Console.WriteLine();

        // Kitap ödünç alma
        Book foundBook = library.FindBookByISBN("978-1234567890");
        if (foundBook != null)
        {
            foundBook.Borrow();  // Savaş ve Barış ödünç alındı
        }

        Console.WriteLine();

        // Tekrar ödünç alma (hata durumu)
        foundBook.Borrow();  // Savaş ve Barış zaten ödünç alınmış

        Console.WriteLine();

        // Kitap iade etme
        foundBook.Return();  // Savaş ve Barış iade edildi

        Console.WriteLine();

        // Kitapları tekrar listeleme
        library.ListBooks();
    }
}
