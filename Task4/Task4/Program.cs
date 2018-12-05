 using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Task4
{
    class Program
    {
        public delegate void Que();
        static void Main(string[] args)
        {

            Queries que = new Queries(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);

            que.RunAll();
          //  que.Q34();
          
             que.connection.Close();
            Console.ReadKey();
           

        }
    }
  
}
