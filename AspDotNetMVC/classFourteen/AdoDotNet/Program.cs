using System;
using System.Data.SqlClient;

namespace AdoDotNet
{

    
    class Program
    {
        private const string connection = "Server=DESKTOP-VCDQ38S\\SQLEXPRESS;Database=AdoDotNet;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            

            using SqlConnection sqlConnection = new SqlConnection(connection);

            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            var tableCreate = @"  CREATE TABLE dbo.Course
                           ( Id int IDENTITY(1,100) NOT NULL,                           
                            Title nvarchar(50) NOT NULL,
                            CONSTRAINT pk2 PRIMARY KEY(Id)
                           );";

            var dataInsert = "insert into Course (Title) values ('CSharp')";

            var dataBase = new DataBase();
            //dataBase.CreateTable(tableCreate, sqlConnection);
            dataBase.DataInsert(dataInsert, sqlConnection);     

        }

    }
}
