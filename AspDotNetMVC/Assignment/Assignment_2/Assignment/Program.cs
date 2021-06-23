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

            var orm2 = new MyORM<Courses>(DbConnection.connectionString);

            //Courses course = new Courses() { Id = 2, Title = "ASP.NET", Credit = "6.0" };
            //orm2.Delete(1);

            //Courses course = new Courses() {Id = 1, Title = "CSharp", Credit = "3.5" };
            //orm2.Update(course);
            //var uu = orm2.GetAll();
            //var uu = orm2.GetById(1);
            //foreach (var value in uu)
            //{
            //    Console.WriteLine($"Id: {value.Id} Name:{value.Title} Credit:{value.Credit}");
            //}


            StudentInfos student = new StudentInfos() {Id=1,Name = "Mithun", Dept = "CSE", Address = "CTG" };
            //orm.Insert(student);
            orm.Delete(student);
            //orm.Delete(4);
            //orm.Update(student);
            //var uu = orm.GetById(1);
            //var uu = orm.GetAll();
            //foreach (var value in uu)
            //{
            //    Console.WriteLine($"Id: {value.Id} Name:{value.Name} Dept:{value.Dept} Address:{value.Address}");
            //}






        }
    }
}
