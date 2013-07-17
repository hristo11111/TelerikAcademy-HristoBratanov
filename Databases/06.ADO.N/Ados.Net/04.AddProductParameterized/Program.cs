using _04.AddProductParameterized;
using System;
using System.Data.SqlClient;

//Write a method that adds a new product in the products table in the Northwind database. 
//Use a parameterized SQL command.

class Program
{
    static SqlConnection dbCon;

    static void Main()
    {
        dbCon = new SqlConnection(Settings.Default.DBConnString);
        dbCon.Open();

        InsertIntoProducts("Piperki", 3, 1, "2", 5.5m, 12, 3, 15, 1);

        dbCon.Close();
    }

    private static void InsertIntoProducts(string productName, int? suplierId,
        int? categoryId, string quantityPerUnit, decimal? unitPrice, int? UnitsInStock,
        int? unitsOnOrder, int? reorderLevel, byte discontinued)
    {
        SqlCommand insertIntoProducts = new SqlCommand("INSERT INTO Products(" +
        " ProductName, SupplierID, CategoryiD, QuantityPerUnit, UnitPrice, UnitsInStock," +
        " UnitsOnOrder, ReorderLevel, Discontinued) " + 
        "VALUES(@ProductName, @SupplierID, @CategoryiD, @QuantityPerUnit, @UnitPrice, @UnitsInStock," +
        " @UnitsOnOrder, @ReorderLevel, @Discontinued)", dbCon);

        insertIntoProducts.Parameters.AddWithValue("@ProductName", productName);
        SqlParameter sqlParameterSuplierId = new SqlParameter("@SupplierID", suplierId);
        if (suplierId == null)
        {
            sqlParameterSuplierId.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParameterSuplierId);

        SqlParameter sqlParameterCategoryId = new SqlParameter("@CategoryID", categoryId);
        if (categoryId == null)
        {
            sqlParameterCategoryId.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParameterCategoryId);

        SqlParameter sqlParameterQuantPerU = new SqlParameter("@QuantityPerUnit", quantityPerUnit);
        if (quantityPerUnit == null)
        {
            sqlParameterQuantPerU.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParameterQuantPerU);

        SqlParameter sqlParameterUnitPrice = new SqlParameter("@UnitPrice", unitPrice);
        if (unitPrice == null)
        {
            sqlParameterUnitPrice.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParameterUnitPrice);

        SqlParameter sqlParamUnitsInStock = new SqlParameter("@UnitsInStock", UnitsInStock);
        if (UnitsInStock == null)
        {
            sqlParamUnitsInStock.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParamUnitsInStock);

        SqlParameter sqlParamUnitsOnOrder = new SqlParameter("@UnitsOnOrder", unitsOnOrder);
        if (unitsOnOrder == null)
        {
            sqlParamUnitsOnOrder.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParamUnitsOnOrder);

        SqlParameter sqlParamReorderLevel = new SqlParameter("@ReorderLevel", reorderLevel);
        if (reorderLevel == null)
        {
            sqlParamReorderLevel.Value = DBNull.Value;
        }
        insertIntoProducts.Parameters.Add(sqlParamReorderLevel);

        insertIntoProducts.Parameters.AddWithValue("@Discontinued", discontinued);

        insertIntoProducts.ExecuteNonQuery();
    }
}
