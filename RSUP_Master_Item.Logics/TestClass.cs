using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUP_Master_Item.Logics
{
    public class TestClass
    {
        public void CreateMasterItemFromQuery(List<string> unit_name)
        {
            string connectionString = "Data Source=10.0.0.50;Initial Catalog=Sambu_Staging_RSUP;User ID = sa; Password=pass@word1";
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                #region add the table
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("unit_name", typeof(string));
                #endregion
                #region add data to the created table
                for(int i = 0; i < unit_name.Count; i++)
                {
                    dataTable.Rows.Add((i + 1), unit_name[i]);
                }
                #endregion

                var command = new SqlCommand("dbo.usp_Create_Master_item_Data", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter tableParam = command.Parameters.AddWithValue("@InputTable", dataTable);
                tableParam.SqlDbType = SqlDbType.Structured;
                tableParam.TypeName = "dbo.MyTableType";

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine("id\tunit_name");
                    Console.WriteLine(reader["id"] + "\t" + reader["unit_name"]);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
