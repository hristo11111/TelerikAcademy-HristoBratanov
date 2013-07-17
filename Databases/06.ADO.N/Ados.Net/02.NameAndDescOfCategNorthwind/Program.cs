using _02.NameAndDescOfCategNorthwind;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

//Write a program that retrieves the name and description of all categories in the Northwind DB.

class Program
{
    static Dictionary<string, string> categoryInfo = new Dictionary<string, string>();

    static void Main()
    {
        SqlConnection dbcon = new SqlConnection(Settings.Default.DBConnString);
        dbcon.Open();

        using (dbcon)
        {
            SqlCommand retrCmd = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbcon);
            SqlDataReader reader = retrCmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];

                    categoryInfo.Add(name, description);
                }
            }
        }

        foreach (var item in categoryInfo)
        {
            Console.WriteLine(item.Key + "-->" + item.Value);
        }
    }
}
