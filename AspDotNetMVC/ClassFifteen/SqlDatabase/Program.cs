using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlDatabase
{
    class Program
    {
        private const string connectionString = "Server=DESKTOP-VCDQ38S\\SQLEXPRESS;Database=AspDotNet_B5;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            var cmdText = @"select * from StudentInfo";

            var item = ReadOperation(cmdText, connection);

            foreach(var i in item)
            {
                //Console.WriteLine($"ID: {i.Id} Name: {i.Name} Address: {i.Address}");
                Console.WriteLine(i.Id + i.Address + i.Name);
            }


        }



        static IList<Student> ReadOperation(string sql, SqlConnection sqlConnection )
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            using SqlCommand sqlCommand = new SqlCommand(sql,sqlConnection);

            var students = new List<Student>();

            var reader = sqlCommand.ExecuteReader();

            while(reader.Read())
            {
                var student = new Student();
                student.Id = (int)reader["Id"];
                student.Name = (string)reader["Name"];
                student.Address = (string)reader["Address"];

                students.Add(student);
            }

            return students;
        }

    }
}
//var insert = "insert into friendList ([Name], DOB, [Address], Contract) values (@Name, @DOB, @Address, @Contract)";

//ExecuteCommand(connection, insert, new Dictionary<string, object>
//            {
//                {"@Name", name },
//                {"@DOB",DateTime.Parse(dob) },
//                {"@Address",address },
//                {"@Contract",contract }
//            });