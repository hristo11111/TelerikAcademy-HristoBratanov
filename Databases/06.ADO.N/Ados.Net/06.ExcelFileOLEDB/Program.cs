using System;
using System.Data;
using System.Data.OleDb;

//Create an Excel file with 2 columns: name and score.
//Write a program that reads your MS Excel file through the OLE DB data provider 
//and displays the name and score row by row.

//Implement appending new rows to the Excel file

class Program
{
    static void Main()
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\WorkFiles\scores.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=Yes;""";

        OleDbConnection dbCon = new OleDbConnection(connectionString);

        dbCon.Open();

        using(dbCon)
	    {
            OleDbCommand readTable = new OleDbCommand("SELECT * FROM [scTable$]", dbCon);
            OleDbDataReader reader = readTable.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            //Print header
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("{0,-20}", column);
            }

            Console.WriteLine();

            //Print rest of the table
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write("{0,-20}", row[column]);
                }

                Console.WriteLine();
            }

            //insert new row
            OleDbCommand insert = new OleDbCommand(
                "INSERT INTO [scTable$] (Name, Score) VALUES (@name, @score)", dbCon);

            insert.Parameters.AddWithValue("@name", "Gosho");
            insert.Parameters.AddWithValue("@score", "102");

            try
            {
                insert.ExecuteNonQuery();

                Console.WriteLine("Row inserted successfully.");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("SQL Error occured: " + exception);
            }

	    }
    }
}
