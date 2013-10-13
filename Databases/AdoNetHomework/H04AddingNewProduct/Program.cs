using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H04AddingNewProduct
{
   public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(Settings.Default.DBConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                InsertProduct(dbCon, "banichka", true);
            }
        }

        private static int InsertProduct(SqlConnection dbCon, string name, bool discontinued, 
            int? suppulierID = null, int? categoryID = null, string quantityPrUnit = null,
            int? unitsInStock = null, int? unitsOnOrder = null, int? reorderLevel = null,
         decimal? unitPrice = null)
        {
            SqlCommand cmdInsertProject = new SqlCommand(
                @"INSERT INTO Products
                                    (
                                        ProductName, 
                                        SupplierID,
                                        CategoryID,
                                        QuantityPerUnit,
                                        UnitPrice,
                                        UnitsInStock,
                                        UnitsOnOrder,
                                        ReorderLevel,
                                        Discontinued
                                    ) 
                            VALUES
                                (
                                    @productName,
                                    @supplierID,
                                    @categoryID,
                                    @quantityPerUnit,
                                    @unitPrice,
                                    @unitsInStock,
                                    @unitsOnOrder,
                                    @reorderLevel,
                                    @discontinued
                                )
                                                    ", dbCon);
            cmdInsertProject.Parameters.AddWithValue("@productName", name);


            SqlParameter sqlParameterSuppulierID = new SqlParameter("@supplierID", suppulierID);
            if (suppulierID == null)
            {
                sqlParameterSuppulierID.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterSuppulierID);

            SqlParameter sqlParameterCategoryID = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                sqlParameterCategoryID.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterCategoryID);

            SqlParameter sqlParameterQuantityPrUnit = new SqlParameter("@quantityPerUnit", quantityPrUnit);
            if (quantityPrUnit == null)
            {
                sqlParameterQuantityPrUnit.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterQuantityPrUnit);

            SqlParameter sqlParameterUnitsInStock = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                sqlParameterUnitsInStock.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterUnitsInStock);

            SqlParameter sqlParameterUnitsOnOrder = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                sqlParameterUnitsOnOrder.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterUnitsOnOrder);

            SqlParameter sqlParameterReorderLevel = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                sqlParameterReorderLevel.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterReorderLevel);

            SqlParameter sqlParameterUnitPrice = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                sqlParameterUnitPrice.Value = DBNull.Value;
            }
            cmdInsertProject.Parameters.Add(sqlParameterUnitPrice);
            cmdInsertProject.Parameters.AddWithValue("@discontinued", discontinued);
            cmdInsertProject.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity =
                new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId =
                (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }
    }
}
