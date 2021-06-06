using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    public class DataBase
    {


        public void CreateTable(string cmdText, SqlConnection sqlConnection)
        {
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Table create successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error here: " + ex.ToString());
            }
            finally
            {
                Console.WriteLine("Program Done!");
            }
        }

        public void DataInsert(string cmdText, SqlConnection sqlConnection)
        {
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);

            try
            {
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data insert Successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Data insert error: " + ex.ToString());
            }
            finally
            {
                Console.WriteLine("Program Done!");
            }
        }
    }
}
