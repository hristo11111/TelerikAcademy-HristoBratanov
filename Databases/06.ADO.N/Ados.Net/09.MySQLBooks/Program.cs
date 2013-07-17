using MySql.Data.MySqlClient;
using System;
using System.Globalization;

//Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL)
//+ MySQL Workbench GUI administration tool . Create a MySQL database to store Books 
//(title, author, publish date and ISBN). Write methods for listing all books, 
//finding a book by name and adding a book.

class Program
{
    static MySqlConnection dbCon;

    static void Main()
    {
        dbCon = new MySqlConnection(
            "Server=localhost; Port=3306; Database=world; Uid=root; Pwd=itso; pooling=true");

        dbCon.Open();

        using(dbCon)
        {
            ListAllBooks();
            FindBook();
            AddBook();
        }
    }

    private static void AddBook()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Publish date (dd-MMM-yyyy): ");
        string date = Console.ReadLine();
        DateTime formatedDate = Convert.ToDateTime(date);
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();
        MySqlCommand cmd = new MySqlCommand("INSERT INTO Books(BookTitle, Author, PublishDate, ISBN) " +
            "VALUES(@bookTitle, @author, @publishDate, @isbn)", dbCon);
        cmd.Parameters.AddWithValue("@bookTitle", title);
        cmd.Parameters.AddWithValue("@author", author);
        cmd.Parameters.AddWithValue("@publishDate", formatedDate);
        cmd.Parameters.AddWithValue("@isbn", isbn);

        cmd.ExecuteNonQuery();
    }

    private static void FindBook()
    {
        Console.Write("Search for book? Enter title: ");
        string searchBook = Console.ReadLine();

        MySqlCommand cmd = new MySqlCommand("SELECT BookTitle, Author, PublishDate, ISBN " +
            "FROM Books WHERE BookTitle = '" + searchBook + "'", dbCon);
        MySqlDataReader reader = cmd.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                Console.Write("Book found: ");
                string title = (string)reader["BookTitle"];
                string author = (string)reader["Author"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string dateFormatted = publishDate.ToString("dd-MMM-yyyy", new CultureInfo("bg-BG"));
                string isbn = (string)reader["ISBN"];

                Console.Write("Title: {0}, author: {1}, publish date: {2}, ISBN: {3}",
                    title, author, dateFormatted, isbn);
            }
        }
    }

    private static void ListAllBooks()
    {
        MySqlCommand cmd = new MySqlCommand("SELECT BookTitle FROM Books", dbCon);
        MySqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("Books:");
        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["BookTitle"];
                Console.WriteLine(title);
            }
        }
    }
}
