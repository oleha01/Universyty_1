//-----------------------------------------------------------------------
// <copyright file="Queries.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that encapsulates all queries.
    /// </summary>
    public class Queries
    {
        /// <summary>
        /// SQL Server connection strings.
        /// </summary>
        public string connectionString;

        /// <summary>
        /// Represents a connection to a SQL Server database.
        /// </summary>
        public SqlConnection connection;

        /// <summary>
        /// Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. 
        /// </summary>
        public SqlCommand command;

        /// <summary>
        /// Provides a way of reading a forward-only stream of rows from a SQL Server database. 
        /// </summary>
        public SqlDataReader reader;

        /// <summary>
        /// Array of queries. 
        /// </summary>
        public Que arrqueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queries" /> class.
        /// </summary>
        /// <param name="s">Connection string.</param>
        public Queries(string s)
        {
            this.connectionString = s;
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();

            this.arrqueries = this.Q1;
            this.arrqueries += this.Q2;
            this.arrqueries += this.Q3;
            this.arrqueries += this.Q4;
            this.arrqueries += this.Q5;
            this.arrqueries += this.Q6;
            this.arrqueries += this.Q7;
            this.arrqueries += this.Q8;
            this.arrqueries += this.Q9;
            this.arrqueries += this.Q10;
            this.arrqueries += this.Q11;
            this.arrqueries += this.Q12;
            this.arrqueries += this.Q13;
            this.arrqueries += this.Q14;
            this.arrqueries += this.Q15;
            this.arrqueries += this.Q16;
            this.arrqueries += this.Q17;
            this.arrqueries += this.Q18;
            this.arrqueries += this.Q19;
            this.arrqueries += this.Q20;
            this.arrqueries += this.Q21;
            this.arrqueries += this.Q23;
            this.arrqueries += this.Q24;
            this.arrqueries += this.Q25;
            this.arrqueries += this.Q26;
            this.arrqueries += this.Q27;
            this.arrqueries += this.Q28;
            this.arrqueries += this.Q29;
            this.arrqueries += this.Q30;
            this.arrqueries += this.Q31;
            this.arrqueries += this.Q32;
            this.arrqueries += this.Q33;
            this.arrqueries += this.Q34;
            this.arrqueries += this.Q35;
        }

        /// <summary>
        /// Delegate for queries.
        /// </summary>
        public delegate void Que();

        /// <summary>
        /// 1.Show all info about the employee with ID 8. 
        /// </summary>
        public void Q1()
        {
            Console.WriteLine("1.Show all info about the employee with ID 8.");
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "SELECT FirstName, LastName, Title, BirthDate, Address, City, Country, HomePhone FROM Employees WHERE EmployeeID=8;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", this.reader["FirstName"], this.reader["LastName"], this.reader["Title"], this.reader["BirthDate"], this.reader["Address"], this.reader["City"], this.reader["Country"], this.reader["HomePhone"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 2. Show the list of first and last names of the employees from London.
        /// </summary>
        public void Q2()
        {
            Console.WriteLine("Show the list of first and last names of the employees from London");
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["FirstName"], this.reader["LastName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 3.Show the list of first and last names of the employees whose first name begins with letter A.
        /// </summary>
        public void Q3()
        {
            Console.WriteLine("\nShow the list of first and last names of the employees whose first name begins with letter A.");
            this.command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'A%' ;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["FirstName"], this.reader["LastName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 4.Show the list of first, last names and ages of the employees whose age is greater than 55. 
        /// The result should be sorted by last name.
        /// </summary>
        public void Q4()
        {
            Console.WriteLine("\n4.	Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.");
            this.command.CommandText = "SELECT FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 ORDER BY LastName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", this.reader["FirstName"], this.reader["LastName"], this.reader["Age"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 5. Calculate the count of employees from London.
        /// </summary>
        public void Q5()
        {
            Console.WriteLine("\nCalculate the count of employees from London");
            this.command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["EmployeeQuantity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 6. Calculate the greatest, the smallest and the average age among the employees from London.
        /// </summary>
        public void Q6()
        {
            Console.WriteLine("\nCalculate the greatest, the smallest and the average age among the employees from London.");
            this.command.CommandText = "SELECT MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxBirth,MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinBirth,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees WHERE City='London';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", this.reader["MaxBirth"], this.reader["MinBirth"], this.reader["AvgBirth"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 7. Calculate the greatest, the smallest and the average age of the employees for each city.
        /// </summary>
        public void Q7()
        {
            Console.WriteLine("\nCalculate the greatest, the smallest and the average age of the employees for each city.");
            this.command.CommandText = "SELECT City, MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxBirth,MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinBirth,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0,-20}{1}\t{2}\t{3}", this.reader["City"], this.reader["MaxBirth"], this.reader["MinBirth"], this.reader["AvgBirth"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 8.Show the list of cities in which the average age of employees is greater than 60.
        /// (the average age is also to be shown)
        /// </summary>
        public void Q8()
        {
            Console.WriteLine("\nShow the list of cities in which the average age of employees is greater than 60 (the average age is also to be shown)");
            this.command.CommandText = "SELECT City ,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City HAVING AVG(DATEDIFF(year, BirthDate, GETDATE())) > 60;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["City"], this.reader["AvgBirth"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 9. Show the first and last name(s) of the eldest employee(s). 
        /// </summary>
        public void Q9()
        {
            Console.WriteLine("\nShow the first and last name of the eldest employee");
            this.command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE BirthDate=(SELECT MIN(BirthDate) FROM Employees) GROUP BY LastName, FirstName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["FirstName"], this.reader["LastName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 10. Show first, last names and ages of 3 eldest employees.
        /// </summary>
        public void Q10()
        {
            Console.WriteLine("\nShow first, last names and ages of 3 eldest employees.");
            this.command.CommandText = "SELECT TOP 3 FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees ORDER BY BirthDate;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", this.reader["FirstName"], this.reader["LastName"], this.reader["Age"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 11.Show the list of all cities where the employees are from
        /// </summary>
        public void Q11()
        {
            Console.WriteLine("\nShow the list of all cities where the employees are from");
            this.command.CommandText = "SELECT DISTINCT City  FROM Employees";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}", this.reader["City"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 12. Show first, last names and dates of birth of the employees who celebrate their birthdays this month.
        /// </summary>
        public void Q12()
        {
            Console.WriteLine("\nShow first, last names and dates of birth of the employees who celebrate their birthdays this month");
            this.command.CommandText = "SELECT LastName, FirstName  FROM Employees WHERE MONTH(BirthDate)=(MONTH(getdate())) GROUP BY LastName, FirstName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["FirstName"], this.reader["LastName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 13. Show first and last names of the employees who used to serve orders shipped to Madrid.
        /// </summary>
        public void Q13()
        {  
            Console.WriteLine("\nShow first and last names of the employees who used to serve orders shipped to Madrid.");
            this.command.CommandText = "SELECT DISTINCT LastName, FirstName  FROM Employees AS e INNER JOIN Orders AS o ON o.EmployeeID=e.EmployeeID WHERE o.ShipCity='Madrid';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["FirstName"], this.reader["LastName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 14. Show first and last names of the employees as well as the count of orders
        /// each of them have received during the year 1997 (use left join).
        /// </summary>
        public void Q14()
        {
            Console.WriteLine("\nShow first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join)");
            this.command.CommandText = "SELECT e.FirstName, e.LastName, COUNT(o.EmployeeID) AS OrdersQuantity FROM Employees AS e LEFT JOIN Orders AS o ON o.EmployeeID=e.EmployeeID " +
                "WHERE o.OrderDate>='01-01-1997' AND o.OrderDate<='31-12-1997' GROUP BY e.FirstName, e.LastName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0,-10}{1,-10}{2}", this.reader["FirstName"], this.reader["LastName"], this.reader["OrdersQuantity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 15. Show first and last names of the employees as well as the count of orders each of them have received during the year 1997 .
        /// </summary>
        public void Q15()
        {
            Console.WriteLine("\nShow first and last names of the employees as well as the count of orders each of them have received during the year 1997 ");
            this.command.CommandText = "SELECT e.FirstName, e.LastName, COUNT(o.EmployeeID) AS OrdersQuantity FROM Employees AS e LEFT JOIN Orders AS o ON o.EmployeeID=e.EmployeeID " +
                "WHERE o.OrderDate>='01-01-1997' AND o.OrderDate<='31-12-1997' GROUP BY e.FirstName, e.LastName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", this.reader["FirstName"], this.reader["LastName"], this.reader["OrdersQuantity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 16.Show first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join).
        /// </summary>
        public void Q16()
        {
            Console.WriteLine("\nShow first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join) ");
            this.command.CommandText = "SELECT E.FirstName, E.LastName, COUNT(O.EmployeeID) AS OrdersQuantity " +
                "FROM Employees AS E " +
                "LEFT JOIN Orders AS O " +
                "ON O.EmployeeID = E.EmployeeID " +
                "WHERE O.ShippedDate > O.RequiredDate AND O.OrderDate BETWEEN '01-01-1997' AND '31-12-1997' GROUP BY E.FirstName, E.LastName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", this.reader["FirstName"], this.reader["LastName"], this.reader["OrdersQuantity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 17. Show the count of orders made by each customer from France.
        /// </summary>
        public void Q17()
        {
            Console.WriteLine("\nShow the count of orders made by each customer from France. ");
            this.command.CommandText = "SELECT c.ContactName, COUNT(o.CustomerID) AS OrdersQuantity FROM Customers AS c, Orders AS o WHERE c.Country='France'GROUP BY c.ContactName ;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["ContactName"], this.reader["OrdersQuantity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 18. Show the list of french customers’ names who have made more than one order (use grouping).
        /// </summary>
        public void Q18()
        {
            Console.WriteLine("\nShow the list of french customers’ names who have made more than one order (use grouping)");
            this.command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.Country='France' GROUP BY c.ContactName HAVING COUNT(o.CustomerID)>1;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 19. Show the list of french customers’ names who have made more than one order
        /// </summary>
        public void Q19()
        {
            Console.WriteLine("\nShow the list of french customers’ names who have made more than one order");
            this.command.CommandText = "SELECT DISTINCT C.ContactName FROM Customers C JOIN(SELECT O.CustomerID, Count(*) AS orders_count FROM Orders O GROUP BY O.CustomerID) AS result ON result.CustomerID = C.CustomerID AND C.Country = 'France' AND result.orders_count > 1; ; ";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 20. Show the list of customers’ names who used to order the ‘Tofu’ product.
        /// </summary>
        public void Q20()
        {
            Console.WriteLine("\nShow the list of customers’ names who used to order the ‘Tofu’ product.");
            this.command.CommandText = "SELECT Customers.ContactName FROM Customers " +
                "JOIN Orders ON Orders.CustomerID = Customers.CustomerID" +
                " JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID" +
                " JOIN Products ON Products.ProductID = [Order Details].ProductID" +
                " WHERE Products.ProductName = 'Tofu'; ";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 21. Show the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered 
        /// and with the total sum for ordered product calculated.
        /// </summary>
        public void Q21()
        {
            Console.WriteLine("\nShow the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered and with the total sum for ordered product calculated.");
            this.command.CommandText = "SELECT C.ContactName, SUM(OD.Quantity) AS Count, SUM(OD.UnitPrice * OD.Quantity) AS PriceSum FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON OD.OrderId = O.OrderId LEFT JOIN [Products] AS P ON P.ProductID = OD.ProductID WHERE P.ProductName = 'Tofu' GROUP BY C.ContactName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0, -20} {1,-3} {2}", this.reader["ContactName"], this.reader["Count"], this.reader["PriceSum"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 22. *Show the list of french customers’ names who used to order non-french products (use left join).
        /// </summary>
        public void Q22()
        {
            Console.WriteLine("\nShow the list of french customers’ names who used to order non-french products (use left join).");
            this.command.CommandText = "SELECT DISTINCT C.ContactName FROM Customers as C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.Country <> 'France' AND C.Country = 'France'";

            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 23. *Show the list of french customers’ names who used to order non-french products.
        /// </summary>
        public void Q23()
        {
            Console.WriteLine("\nShow the list of french customers’ names who used to order non-french products.");
            this.command.CommandText = "SELECT C.ContactName FROM Customers as C WHERE C.Country ='France' AND C.CustomerID IN (SELECT DISTINCT CustomerID FROM Orders AS O LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.Country <> 'France');";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 24. *Show the list of french customers’ names who used to order french products.
        /// </summary>
        public void Q24()
        {
            Console.WriteLine("\nShow the list of french customers’ names who used to order french products");
            this.command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.CustomerID=o.CustomerID AND c.Country='France' AND o.ShipCountry='France';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine(this.reader["ContactName"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 25. *Show the total ordering sum calculated for each country of customer.
        /// </summary>
        public void Q25()
        {
            Console.WriteLine("\nShow the total ordering sum calculated for each country of customer");
            this.command.CommandText = "SELECT c.Country, SUM(od.UnitPrice) AS TotalPrice FROM Customers AS c, Orders AS o, [Order Details] AS od WHERE o.CustomerID=c.CustomerID AND o.OrderID=od.OrderID GROUP BY c.Country;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0,-10}{1}", this.reader["Country"], this.reader["TotalPrice"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 26.Show the total ordering sums calculated for each customer’s country for domestic and non-domestic products separately 
        /// (e.g.: “France – French products ordered – Non-french products ordered” and so on for each country).
        /// </summary>
        public void Q26()
        {
            Console.WriteLine("\nShow the total ordering sums calculated for each customer’s country for domestic and non-domestic products separately (e.g.: “France – French products ordered – Non-french products ordered” and so on for each country).");
            this.command.CommandText = "SELECT D1.Country, D1.Domestic, D2.NonDomestic FROM (SELECT C.Country, COUNT (P.ProductID) AS Domestic FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.country = C.Country GROUP BY C.Country) AS D1 LEFT JOIN (SELECT C.Country, COUNT (P.ProductID) AS NonDomestic FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.country <> C.Country GROUP BY C.Country) AS D2 ON D1.Country = D2.Country;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0, -20}\n\t- {0} products ordered {1} \n\t- Non {0} products ordered {2, -20}", this.reader["Country"], this.reader["Domestic"], this.reader["NonDomestic"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 27. *Show the list of product categories along with total ordering sums calculated
        /// for the orders made for the products of each category, during the year 1997.
        /// </summary>
        public void Q27()
        {
            Console.WriteLine("\n*Show the list of product categories along with total ordering sums calculated for the orders made for the products of each category, during the year 1997");
            this.command.CommandText = "SELECT C.CategoryName, P.ProductName, COUNT (O.OrderID) AS OrdersAmount FROM Categories AS C LEFT JOIN Products AS P ON P.CategoryID = C.CategoryID LEFT JOIN [Order Details] AS OD ON OD.ProductID = P.ProductID LEFT JOIN Orders AS O ON O.OrderID = OD.OrderID WHERE O.OrderDate BETWEEN '01-01-1997' AND '31-12-1997' GROUP BY P.ProductName, C.CategoryName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0,-20}{1,-35}{2}", this.reader["CategoryName"], this.reader["ProductName"], this.reader["OrdersAmount"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 28.Show the list of product names along with unit prices and the history of 
        /// unit prices taken from the orders (show ‘Product name – Unit price – Historical price’).
        /// The duplicate records should be eliminated. If no orders were made for a certain product,
        /// then the result for this product should look like ‘Product name – Unit price – NULL’. 
        /// Sort the list by the product name.
        /// </summary>
        public void Q28()
        {
            Console.WriteLine("\nShow the list of product names along with unit prices and the history of unit prices taken from the orders (show ‘Product name – Unit price – Historical price’). The duplicate records should be eliminated. If no orders were made for a certain product, then the result for this product should look like ‘Product name – Unit price – NULL’. Sort the list by the product name.");
            this.command.CommandText = "SELECT P.ProductName, P.UnitPrice, OD.UnitPrice AS HistoricalPrice FROM Products AS P RIGHT JOIN [Order Details] AS OD ON P.ProductID = OD.ProductID WHERE P.UnitPrice <> OD.UnitPrice GROUP BY P.ProductName, P.UnitPrice, OD.UnitPrice ORDER BY P.ProductName;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0, -40} {1, -20} {2}", this.reader["ProductName"], this.reader["UnitPrice"], this.reader["HistoricalPrice"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 29. * Show the list of employees’ names along with names of their chiefs(use left join with the same table).
        /// </summary>
        public void Q29()
        {
            Console.WriteLine("\nShow the list of employees’ names along with names of their chiefs (use left join with the same table).");
            this.command.CommandText = "SELECT E1.LastName AS Name, E2.LastName AS Chief FROM Employees AS E1 LEFT JOIN Employees AS E2 ON E1.ReportsTo = E2.EmployeeID;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["Name"], this.reader["Chief"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 30. *Show the list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated.
        /// </summary>
        public void Q30()
        {
            Console.WriteLine("\nShow the list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated.");
            this.command.CommandText = "(SELECT E.City AS OrderFromCity, O.ShipCity AS OrderToCity FROM Orders AS O LEFT JOIN Employees AS E ON E.EmployeeID = O.EmployeeID GROUP BY E.City, O.ShipCity) UNION (SELECT C.City AS OrderFromCity, O.ShipCity AS OrderToCity FROM Orders AS O LEFT JOIN Customers AS C ON C.CustomerID = O.CustomerID GROUP BY C.City, O.ShipCity);";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine("{0}\t{1}", this.reader["OrderFromCity"], this.reader["OrderToCity"]);
            }

            this.reader.Close();
        }

        /// <summary>
        /// 31. *Insert 5 new records into Employees table. Fill in the following  fields:
        /// LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. The Notes field should contain your own name.
        /// </summary>
        public void Q31()
        {
            int insertQuantity = 0;
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Burdeina', 'Ira', '05-01-1999', '03-12-2018', 'Topolna st. 78', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Ivanova', 'Tonia', '14-11-1999', '03-12-2018', 'Bandery st. 8', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Butriy', 'Oleh',  '01-09-1999', '03-12-2018', 'SantaBarbara st. 73', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Koltun', 'Roman',  '03-12-1999', '03-12-2018', 'Stus st. 18', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Loik', 'Nottet',  '07-01-1999', '03-12-2018', 'Loren st. 16', 'Paris', 'France', 'Smart');";
            insertQuantity += this.command.ExecuteNonQuery();
            Console.WriteLine("\nInserted {0} rows", insertQuantity);
        }

        /// <summary>
        /// 32. * Fetch the records you have inserted by the SELECT statement
        /// </summary>
        public void Q32()
        {
            Console.WriteLine("\nFetch the records you have inserted by the SELECT statement");
            this.command.CommandText = "SELECT * FROM Employees WHERE Notes LIKE 'Smart';";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0,-20}{1}", this.reader.GetName(i), this.reader.GetValue(i));
                }

                Console.WriteLine();
            }

            this.reader.Close();
        }

        /// <summary>
        /// 33. * Change the City field in one of your records using the UPDATE statement.
        /// </summary>
        public void Q33()
        {
            Console.WriteLine("\nChange the City field in one of your records using the UPDATE statement.");
            this.command.CommandText = "UPDATE Employees SET City = 'New York' WHERE LastName = 'Burdeina' ;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine($"Update {command.ExecuteNonQuery()} row");
            }

            this.reader.Close();
        }

        /// <summary>
        /// 34. *Change the HireDate field in all your records to current date.
        /// </summary>
        public void Q34()
        {
            Console.WriteLine("\nChange the HireDate field in all your records to current date.");
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "UPDATE Employees SET HireDate = '03-12-2018' WHERE Notes like 'Smart' ;";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                Console.WriteLine($"Update {command.ExecuteNonQuery()} row");
            }

            this.reader.Close();
        }

        /// <summary>
        /// 35. * Delete one of your records.
        /// </summary>
        public void Q35()
        {
            int deletedQuantity = 0;
            this.command.CommandText = "DELETE FROM Employees WHERE LastName='Nottet' AND FirstName like 'Loik';";
            deletedQuantity += this.command.ExecuteNonQuery();
            Console.WriteLine("Deleted {0} rows", deletedQuantity);
            this.connection.Close();
        }

        /// <summary>
        /// Run all queries.
        /// </summary>
        public void RunAll()
        {
            ////viklik 
            this.Q1();
            Console.ReadKey();
            this.Q2();
            Console.ReadKey();
            this.Q3();
            Console.ReadKey();
            this.Q4();
            Console.ReadKey();
            this.Q5();
            Console.ReadKey();
            this.Q6();
            Console.ReadKey();
            this.Q7();
            Console.ReadKey();
            this.Q8();
            Console.ReadKey();
            this.Q9();
            Console.ReadKey();
            this.Q10();
            Console.ReadKey();
            ////---------

            this.Q11();
            Console.ReadKey();
            this.Q12();
            Console.ReadKey();
            this.Q13();
            Console.ReadKey();
            this.Q14();
            Console.ReadKey();
            this.Q15();
            Console.ReadKey();
            this.Q16();
            Console.ReadKey();
            this.Q17();
            Console.ReadKey();
            this.Q18();
            Console.ReadKey();
            this.Q19();
            Console.ReadKey();
            this.Q20();
            Console.ReadKey();
            ////---------
            this.Q21();
            Console.ReadKey();
            this.Q22();
            Console.ReadKey();
            this.Q23();
            Console.ReadKey();
            this.Q24();
            Console.ReadKey();
            this.Q25();
            Console.ReadKey();
            this.Q26();
            Console.ReadKey();
            this.Q27();
            Console.ReadKey();
            this.Q28();
            Console.ReadKey();
            this.Q29();
            Console.ReadKey();
            this.Q30();
            Console.ReadKey();
            ////---------
            this.Q31();
            Console.ReadKey();

            this.Q32();
            Console.ReadKey();
            this.Q33();
            Console.ReadKey();
            this.Q34();
            Console.ReadKey();
            this.Q35();
            Console.ReadKey();
        }
    }
}