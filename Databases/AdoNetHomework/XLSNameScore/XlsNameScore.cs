using System;
using System.Data.OleDb;
using System.Linq;

namespace XLSNameScore
{
    class XlsNameScore
    {
        static void Main(string[] args)
        {
            //Create an Excel file with 2 columns: name and score:
            //Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
            //Implement appending new rows to the Excel file.

            OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;" +
            @"Data Source=..\..\scores.xls;Extended Properties=""Excel 8.0;HDR=Yes;ReadOnly=False;""");

           
            db.Open();
            using (db)
            {
                OleDbCommand addRow = new OleDbCommand("INSERT INTO [Sheet1$] VALUES ('Pesho Peshev', 29)", db);
               
                PrintAllData(db);

                addRow.ExecuteNonQuery();

                PrintAllData(db);

            }

        }

        private static void PrintAllData(OleDbConnection db)
        {
            OleDbCommand selectRows = new OleDbCommand("select * from [Sheet1$]", db);

            OleDbDataReader reader = selectRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("All items in \\bin\\scores.xls:");
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("{0} - score: {1}", name, score);
                }
            }
          
        }
    }
}
