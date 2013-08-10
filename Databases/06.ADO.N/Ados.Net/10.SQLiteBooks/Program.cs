using System;
using System.Linq;
using System.Data.SQLite;
using System.Globalization;
using Mono.Data.Sqlite;

namespace _10.SQLiteBooks
{
    class Program
    {
        static SQLiteConnection dbCon;

        static void Main()
        {
            string dbSource = @"C:\Users\Hristo\Documents\GitHub\TelerikAcademy-HristoBratanov\Databases\" + 
                @"06.ADO.N\Ados.Net\10.SQLiteBooks\BooksSQLite.sqlite";
            string connString = "Data Source=" + dbSource + ";Version=3;";

            dbCon = new SQLiteConnection(connString);
            dbCon.Open();

            dbCon.

            using (dbCon)
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
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Books(BookTitle, Author, PublishDate, ISBN) " +
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

            var dada = 
                from some in dbCon.
                

            SQLiteCommand cmd = new SQLiteCommand("SELECT BookTitle, Author, PublishDate, ISBN " +
                "FROM Books WHERE BookTitle = '" + searchBook + "'", dbCon);
            SQLiteDataReader reader = cmd.ExecuteReader();

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
            SQLiteCommand cmd = new SQLiteCommand("SELECT [BookTitle] FROM Books", dbCon);
            SQLiteDataReader reader = cmd.ExecuteReader();

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
}
