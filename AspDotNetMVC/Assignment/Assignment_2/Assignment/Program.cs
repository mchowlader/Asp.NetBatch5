using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Assignment
{
    class Program
    {
    static void Main(string[] args)
        {
            var orm = new MyORM<StudentInfos>(DbConnection.connectionString);

            StudentInfos student = new StudentInfos() {Id=1,Name = "Mithun", Dept = "CSE", Address = "CTG" };

            //student.info( new StudentInfos {Id = 2, Name = "AA",Address="x",Dept="c"} );

            //orm.Delete(student);
            //orm.Update(student);
            //var y = orm.GetById(4);

            //var uu = orm.GetById(1);
            //foreach (var value in uu)
            //{
            //    Console.WriteLine($"{value.Id} {value.Name} {value.Dept} {value.Address}");
            //}

           //var uu = orm.GetAll();
           // foreach (var value in uu)
           // {
           //     Console.WriteLine($"{value.Id} {value.Name} {value.Dept} {value.Address}");
           // }

            //orm.Insert(student);
            orm.Delete(4);


        }
    }
}
