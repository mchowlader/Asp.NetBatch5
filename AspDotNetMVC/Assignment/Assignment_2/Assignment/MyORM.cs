using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class MyORM<T> where T:IData
    {
        private SqlConnection _sqlConnection;

        public MyORM(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public MyORM(string connectionString)
            : this(new SqlConnection(connectionString))
        {

        }

        public void Insert(T item)
        {
            if(_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            var sql = new StringBuilder("insert into ");
            var type = item.GetType();
            var properties = type.GetProperties();

            sql.Append(type.Name);
            sql.Append("( ");

            foreach(var property in properties)
            {
                sql.Append(property.Name);
                sql.Append(",");
            }

            sql.Remove(sql.Length - 1, 1);

            sql.Append(" ) values (");

            foreach(var property in properties)
            {
                sql.Append("@");
                sql.Append(property.Name);
                sql.Append(",");
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append(")");

            var query = sql.ToString();
            var command = new SqlCommand(query, _sqlConnection);

            try
            {

                foreach (var property in properties)
                {
                    command.Parameters.AddWithValue(property.Name, property.GetValue(item));
                }

                command.ExecuteNonQuery();
                Console.WriteLine("insert successfully");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                _sqlConnection.Close();
                command.Dispose();
                _sqlConnection.Dispose();
                Console.WriteLine("Finish");
            }
        }
        public void Update(T item)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            var sql = new StringBuilder("update ");
            var type = item.GetType();
            var properties = type.GetProperties();
            sql.Append(type.Name);
            sql.Append(" set ");

            foreach(var property in properties)
            {
                sql.Append(property.Name);
                sql.Append("= @");
                sql.Append(property.Name);
                sql.Append(", ");
            }

            sql.Remove(sql.Length - 2, 1);

            sql.Append("where ");
            foreach(var property in properties)
            {
                if(property.Name == "Id")
                {
                    sql.Append(property.Name);
                    sql.Append(" = @" + property.Name);
                }
            }

            var query = sql.ToString();
            SqlCommand sqlCommand = new SqlCommand(query,_sqlConnection);

            try
            {
                foreach (var property in properties)
                {
                    sqlCommand.Parameters.AddWithValue(property.Name, property.GetValue(item));
                }

                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("updated");
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"error: {ex}");
            }
            finally
            {
                _sqlConnection.Close();
                sqlCommand.Dispose();
                _sqlConnection.Dispose();
                Console.WriteLine("Finish");
            }
        }
        public void Delete(T item)
        {

            Delete(item.Id);
        }
        public void Delete(int id)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            var sql = new StringBuilder("delete from ");

            var type = typeof(T);
            sql.Append(type.Name);
            sql.Append(" where ");
            var properties = type.GetProperties();
            
            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    sql.Append(property.Name);
                    sql.Append("= ");
                    sql.Append(@id);
                }
            }
            
            var query = sql.ToString();

            SqlCommand command = new SqlCommand(query, _sqlConnection);

            try
            {
                
                command.ExecuteNonQuery();
                Console.WriteLine("Delete by id");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error :{ex}");
            }
            finally
            {
                _sqlConnection.Close();
                command.Dispose();
                _sqlConnection.Dispose();
                Console.WriteLine("Finish");
            }
        }
        public IList<T> GetAll()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            var sql = new StringBuilder("select * from ");
            var type = typeof(T);
            sql.Append(type.Name);
            var query = sql.ToString();

            var list = new List<T>();

            SqlCommand command = new SqlCommand(query, _sqlConnection);

            try
            {
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    var instances = (T)Activator.CreateInstance(type);
                    type.GetProperties().ToList().ForEach(x => 
                        { 
                            x.SetValue(instances, reader[x.Name]);
                        });

                    list.Add(instances);
                }             
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error :{ex}");
            }
            finally
            {
                _sqlConnection.Close();
                command.Dispose();
                _sqlConnection.Dispose();
                Console.WriteLine("Finish");
            }

            return list;

        }
        public IList<T> GetById(int id)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
            var sql = new StringBuilder("select * from ");
            var type = typeof(T);

            sql.Append(type.Name);
            var properties = type.GetProperties();
            sql.Append(" where ");
            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    sql.Append(property.Name);
                    sql.Append("=");
                    sql.Append("@" + property.Name);
                }
            }

            var query = sql.ToString();
            List<T> list = new List<T>();

            SqlCommand command = new SqlCommand(query, _sqlConnection);

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    command.Parameters.AddWithValue("@Id", id);
                }
            }

            try
            {
                var reader = command.ExecuteReader();
                T instance = (T)Activator.CreateInstance(type);

                while (reader.Read())
                {
                    type.GetProperties().ToList().ForEach(x =>
                    {
                        x.SetValue(instance, reader[x.Name]);
                    });
                }
                list.Add(instance);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error :{ex}");
            }
            finally
            {
                _sqlConnection.Close();
                command.Dispose();
                _sqlConnection.Dispose();
                Console.WriteLine("Get By ID");
            }

            return list;
        }
    }
}
