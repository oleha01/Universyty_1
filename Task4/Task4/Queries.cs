using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Queries
    {
        string connectionString;

        SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        public Queries()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Q1()
        {
            Console.WriteLine("1.Show all info about the employee with ID 8.");
            command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName, Title, BirthDate, Address, City, Country, HomePhone FROM Employees WHERE EmployeeID=8;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader["FirstName"], reader["LastName"], reader["Title"], reader["BirthDate"], reader["Address"], reader["City"], reader["Country"], reader["HomePhone"]);
            }
            reader.Close();
        }

        public void RunAll()
        {
            Q1();
        }
    }
}