using _08.EscapingWhenSearch;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnString);
        dbCon.Open();

        using (dbCon)
        {
            string searchWord = Console.ReadLine();

            if (searchWord.Contains("\'"))
            {
                char symbol = '\'';
                searchWord = EscapeSingleQuote(searchWord);
                
            }
            if (searchWord.Contains("%"))
            {
                char symbol = '%';
                searchWord = EscapeSymbol(searchWord, symbol);
            }
            if (searchWord.Contains("\""))
            {
                char symbol = '\"';
                searchWord = EscapeSymbol(searchWord, symbol);
            }
            if (searchWord.Contains("_"))
	        {
                char symbol = '_';
                searchWord = EscapeSymbol(searchWord, symbol);
	        }

            string cmd = "SELECT ProductName FROM Products " +
                "WHERE ProductName LIKE '%" + searchWord + "%'";
            SqlCommand getProducts = new SqlCommand(cmd, dbCon);

            SqlDataReader reader = getProducts.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }
            }
        }
    }

    private static string EscapeSymbol(string searchWord, char symbol)
    {
        int symbolIndex = 0;
        int startIndex = 0;
        while (symbolIndex < searchWord.Length)
        {
            symbolIndex = searchWord.IndexOf(symbol, startIndex);
            if (symbolIndex == -1)
            {
                break;
            }
            searchWord = searchWord.Remove(symbolIndex, 1);
            searchWord = searchWord.Insert(symbolIndex, "[" + symbol +"]");
            startIndex = symbolIndex + 2;
        }

        return searchWord;
    }

    private static string EscapeSingleQuote(string searchWord)
    {
        int symbolIndex = 0;
        int startIndex = 0;
        while (symbolIndex < searchWord.Length)
        {
            symbolIndex = searchWord.IndexOf('\'', startIndex);
            if (symbolIndex == -1)
            {
                break;
            }
            searchWord = searchWord.Remove(symbolIndex, 1);
            searchWord = searchWord.Insert(symbolIndex, "\'\'" );
            startIndex = symbolIndex + 2;
        }

        return searchWord;
    }
}
