using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlWithReflection
{
    public class MyORM<T> where T:IData
    {
        private SqlConnection _sqlConnection;

        public MyORM(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public MyORM(string connectionString)
            :this(new SqlConnection(connectionString) )
        {

        }

        public void Insert(T item)
        {
            /*
            var insert = "insert into friendList ([Name], DOB, [Address], Contract)
            values (@Name, @DOB, @Address, @Contract)";
            */
            var sql = new StringBuilder("Insert into ");
            var type = item.GetType();
            var properties = type.GetProperties();
            sql.Append(type.Name);
            sql.Append(" (");

            foreach(var property in properties)
            {
                sql.Append(property.Name);
                sql.Append(", ");
            }
            sql.Remove(sql.Length-1,1);
            sql.Append(" ) Values (");

            foreach(var property in properties)
            {
                sql.Append('@').Append(property.Name).Append(',');
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append(" );");

            var query = sql.ToString();
            var command = new SqlCommand(query, _sqlConnection);

            foreach(var property in properties)
            {

            }


        }

        public void Update(T item)
        {

        }

        public void Delete(T item)
        {
            Delete(item.Id);
        }

        public void Delete(int Id)
        {

        }

        public IList<T> GetAll(T item)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
