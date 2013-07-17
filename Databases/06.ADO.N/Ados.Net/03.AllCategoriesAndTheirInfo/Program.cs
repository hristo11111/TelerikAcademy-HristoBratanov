using _03.AllCategoriesAndTheirInfo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

//Write a program that retrieves from the Northwind database all product categories and 
//the names of the products in each category. Can you do this with a single SQL query (with table join)?

class Program
{
    static Dictionary<string, List<string>> products = new Dictionary<string, List<string>>();

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnString);
        dbCon.Open();

        using (dbCon)
        {
            SqlCommand retrieveCmd = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c " +
	                                                "INNER JOIN Products p ON c.CategoryID = p.CategoryID", dbCon);
            SqlDataReader reader = retrieveCmd.ExecuteReader();

            using(reader)
	        {
                string catecory = string.Empty;
		        while (reader.Read())
	            {
	                string currentCategory = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];

                    if (products.ContainsKey(currentCategory))
	                {
		                products[currentCategory].Add(product);
	                }
                    else
	                {
                        products.Add(currentCategory,new List<string>() {product});
	                }

                    catecory = currentCategory;
	            }
	        }
        }

        StringBuilder output = new StringBuilder();

        foreach (var category in products)
        {
            output.Append(category.Key + " --> ");
            foreach (var product in category.Value)
            {
                output.Append(product + ", ");
            }

            output.Length--;
            output.Length--;
            output.Append("\n\n");
        }

        Console.WriteLine(output.ToString());
    }
}