using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("All last names of the employees in Northwind");
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT LastName FROM Employees;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}", reader["LastName"]);
            }
            Console.ReadKey();
            reader.Close();
        }
    }
}
