using _01.RowsInCategoriesNorthwind;
using System;
using System.Data.SqlClient;

//Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.

class Program
{
    static void Main()
    {
        SqlConnection dbcon = new SqlConnection(Settings.Default.DBConString);
        dbcon.Open();

        using (dbcon)
        {
            SqlCommand rowsCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", dbcon);
            int count = (int)rowsCount.ExecuteScalar();
            Console.WriteLine(count);
        }
    }
}
