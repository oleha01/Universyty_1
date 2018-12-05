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

       public SqlConnection connection;

        SqlCommand command;

        SqlDataReader reader;

        public delegate void Que();

        public Que arrqueries;
        public Queries(string s)
        {
            connectionString = s;
             connection = new SqlConnection(connectionString);
            connection.Open();

            arrqueries = Q1;
            arrqueries += Q2;
            arrqueries += Q3;
            arrqueries += Q4;
            arrqueries += Q5;
            arrqueries += Q6;
            arrqueries += Q7;
            arrqueries += Q8;
            arrqueries += Q9;
            arrqueries += Q10;
            arrqueries += Q11;
            arrqueries += Q12;
            arrqueries += Q13;
            arrqueries += Q14;
            arrqueries += Q15;
            arrqueries += Q16;
            arrqueries += Q17;
            arrqueries += Q18;
            arrqueries += Q19;
            arrqueries += Q20;
            arrqueries += Q21;
            arrqueries += Q23;
            arrqueries += Q24;
            arrqueries += Q25;
            arrqueries += Q26;
            arrqueries += Q27;
            arrqueries += Q28;
            arrqueries += Q29;
            arrqueries += Q30;
            arrqueries += Q31;
            arrqueries += Q32;
            arrqueries += Q33;
            arrqueries += Q34;
            arrqueries += Q35;
        }

        public void Q1()
        {

           // 1.Show all info about the employee with ID 8.
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
        public void Q2()
        {
            //2. Show the list of first and last names of the employees from London.
            Console.WriteLine("Show the list of first and last names of the employees from London");
            command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }
        public void Q3()
        {
            // 3.Show the list of first and last names of the employees whose first name begins with letter A.
            Console.WriteLine("\nShow the list of first and last names of the employees whose first name begins with letter A.");
            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'A%' ;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }
        
        public void Q4()
        {
            //4.Show the list of first, last names and ages of the employees whose age is greater than 55. 
            //The result should be sorted by last name.
            Console.WriteLine("\n4.	Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.");
            command.CommandText = "SELECT FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 ORDER BY LastName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader["FirstName"], reader["LastName"],reader["Age"]);
            }
            reader.Close();
        }
        public void Q5()
        {
            // 5.Calculate the count of employees from London.
            Console.WriteLine("\nCalculate the count of employees from London");
            command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["EmployeeQuantity"]);
            }
            reader.Close();
        }
        
        public void Q6()
        {
            //6.Calculate the greatest, the smallest and the average age among the employees from London.
            Console.WriteLine("\nCalculate the greatest, the smallest and the average age among the employees from London.");
            command.CommandText = "SELECT MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxBirth,MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinBirth,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees WHERE City='London';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader["MaxBirth"], reader["MinBirth"], reader["AvgBirth"]);
            }
            reader.Close();
        }
        public void Q7()
        {
            //7.	Calculate the greatest, the smallest and the average age of the employees for each city.
            Console.WriteLine("\nCalculate the greatest, the smallest and the average age of the employees for each city.");
            command.CommandText = "SELECT City, MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxBirth,MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinBirth,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-20}{1}\t{2}\t{3}", reader["City"], reader["MaxBirth"], reader["MinBirth"], reader["AvgBirth"]);
            }
            reader.Close();
        }
        public void Q8()
        {
            //8.Show the list of cities in which the average age of employees is greater than 60 
            //(the average age is also to be shown)
            Console.WriteLine("\nShow the list of cities in which the average age of employees is greater than 60 (the average age is also to be shown)");
            command.CommandText = "SELECT City ,AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgBirth FROM Employees GROUP BY City HAVING AVG(DATEDIFF(year, BirthDate, GETDATE())) > 60;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["City"], reader["AvgBirth"]);
            }
            reader.Close();
        }

        public void Q9()
        {
            //9.	Show the first and last name(s) of the eldest employee(s). 
            Console.WriteLine("\nShow the first and last name of the eldest employee");
            command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE BirthDate=(SELECT MIN(BirthDate) FROM Employees) GROUP BY LastName, FirstName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }

        public void Q10()
        {
            //10.	Show first, last names and ages of 3 eldest employees.
            Console.WriteLine("\nShow first, last names and ages of 3 eldest employees.");
            command.CommandText = "SELECT TOP 3 FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees ORDER BY BirthDate;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader["FirstName"], reader["LastName"],reader["Age"]);
            }
            reader.Close();
        }
        public void Q11()
        {
            //11.Show the list of all cities where the employees are from
            Console.WriteLine("\nShow the list of all cities where the employees are from");
            command.CommandText = "SELECT DISTINCT City  FROM Employees";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}", reader["City"]);
            }
            reader.Close();
        }
        
        public void Q12()
        {
            //12.	Show first, last names and dates of birth of the employees who celebrate their birthdays this month.
            Console.WriteLine("\nShow first, last names and dates of birth of the employees who celebrate their birthdays this month");
            command.CommandText = "SELECT LastName, FirstName  FROM Employees WHERE MONTH(BirthDate)=(MONTH(getdate())) GROUP BY LastName, FirstName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }
        public void Q13()
        {   //13.	Show first and last names of the employees who used to serve orders shipped to Madrid.
            
            Console.WriteLine("\nShow first and last names of the employees who used to serve orders shipped to Madrid.");
            command.CommandText = "SELECT DISTINCT LastName, FirstName  FROM Employees AS e INNER JOIN Orders AS o ON o.EmployeeID=e.EmployeeID WHERE o.ShipCity='Madrid';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
            }
            reader.Close();
        }
        
        public void Q14()
        {
            //14.	Show first and last names of the employees as well as the count of orders
            //each of them have received during the year 1997 (use left join).
            Console.WriteLine("\nShow first and last names of the employees as well as the count of orders each of them have received during the year 1997 (use left join)");
            command.CommandText = "SELECT e.FirstName, e.LastName, COUNT(o.EmployeeID) AS OrdersQuantity FROM Employees AS e LEFT JOIN Orders AS o ON o.EmployeeID=e.EmployeeID " +
                "WHERE o.OrderDate>='01-01-1997' AND o.OrderDate<='31-12-1997' GROUP BY e.FirstName, e.LastName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1,-10}{2}", reader["FirstName"], reader["LastName"], reader["OrdersQuantity"]);
            }
            reader.Close();
        }
        public void Q15()
        {
            //15.	Show first and last names of the employees as well as the count of
            //orders each of them have received during the year 1997 .
            Console.WriteLine("\nShow first and last names of the employees as well as the count of orders each of them have received during the year 1997 ");
            command.CommandText = "SELECT e.FirstName, e.LastName, COUNT(o.EmployeeID) AS OrdersQuantity FROM Employees AS e LEFT JOIN Orders AS o ON o.EmployeeID=e.EmployeeID " +
                "WHERE o.OrderDate>='01-01-1997' AND o.OrderDate<='31-12-1997' GROUP BY e.FirstName, e.LastName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader["FirstName"], reader["LastName"], reader["OrdersQuantity"]);
            }
            reader.Close();
        }
        public void Q16()
        {
            //16.Show first and last names of the employees as well as the count of their orders shipped
            //after required date during the year 1997(use left join).
           Console.WriteLine("\nShow first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join) ");
            command.CommandText = "SELECT E.FirstName, E.LastName, COUNT(O.EmployeeID) AS OrdersQuantity " +
                "FROM Employees AS E " +
                "LEFT JOIN Orders AS O " +
                "ON O.EmployeeID = E.EmployeeID " +
                "WHERE O.ShippedDate > O.RequiredDate AND O.OrderDate BETWEEN '01-01-1997' AND '31-12-1997' GROUP BY E.FirstName, E.LastName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader["FirstName"], reader["LastName"], reader["OrdersQuantity"]);
            }
            reader.Close();
        }
        public void Q17()
        {
            //17.	Show the count of orders made by each customer from France.
            Console.WriteLine("\nShow the count of orders made by each customer from France. ");
            command.CommandText = "SELECT c.ContactName, COUNT(o.CustomerID) AS OrdersQuantity FROM Customers AS c, Orders AS o WHERE c.Country='France'GROUP BY c.ContactName ;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["ContactName"], reader["OrdersQuantity"]);
            }
            reader.Close();
        }
        public void Q18()
        {
            //18.	Show the list of french customers’ names who have made more than one order (use grouping).
            Console.WriteLine("\nShow the list of french customers’ names who have made more than one order (use grouping)");
            command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.Country='France' GROUP BY c.ContactName HAVING COUNT(o.CustomerID)>1;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }
        public void Q19()
        {
            //19.	Show the list of french customers’ names who have made more than one order
            Console.WriteLine("\nShow the list of french customers’ names who have made more than one order");
            command.CommandText = "SELECT DISTINCT C.ContactName FROM Customers C JOIN(SELECT O.CustomerID, Count(*) AS orders_count FROM Orders O GROUP BY O.CustomerID) AS result ON result.CustomerID = C.CustomerID AND C.Country = 'France' AND result.orders_count > 1; ; ";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }

        public void Q20()
        {
            //20.	Show the list of customers’ names who used to order the ‘Tofu’ product.
            Console.WriteLine("\nShow the list of customers’ names who used to order the ‘Tofu’ product.");
            command.CommandText = "SELECT C.ContactName FROM Customers AS C JOIN Orders AS O ON O.CustomerID = C.CustomerID JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID JOIN Products AS P ON P.ProductID = OD.ProductID WHERE P.ProductName = 'Tofu'; ";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }
        public void Q21()
        {
            //21. Show the list of customers’ names who used to order the ‘Tofu’ product,
            //along with the total amount of the product they have ordered and with the total sum
            //for ordered product calculated.
            Console.WriteLine("\nShow the list of customers’ names who used to order the ‘Tofu’ product, along with the total amount of the product they have ordered and with the total sum for ordered product calculated.");
            command.CommandText = "SELECT C.ContactName, SUM(OD.Quantity) AS Count, SUM(OD.UnitPrice * OD.Quantity) AS PriceSum FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON OD.OrderId = O.OrderId LEFT JOIN [Products] AS P ON P.ProductID = OD.ProductID WHERE P.ProductName = 'Tofu' GROUP BY C.ContactName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0, -20} {1,-3} {2}", reader["ContactName"], reader["Count"], reader["PriceSum"]);
            }
            reader.Close();
        }
        public void Q22()
        {
            //22.	*Show the list of french customers’ names who used to order non-french products (use left join).
            Console.WriteLine("\nShow the list of french customers’ names who used to order non-french products (use left join).");
            command.CommandText = "SELECT DISTINCT C.ContactName FROM Customers as C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.Country <> 'France' AND C.Country = 'France'";

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }
        public void Q23()
        {
            //23.	*Show the list of french customers’ names who used to order non-french products.
            Console.WriteLine("\nShow the list of french customers’ names who used to order non-french products.");
            command.CommandText = "SELECT C.ContactName FROM Customers as C WHERE C.Country ='France' AND C.CustomerID IN (SELECT DISTINCT CustomerID FROM Orders AS O LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.Country <> 'France');";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }
        public void Q24()
        {
            //24.	*Show the list of french customers’ names who used to order french products.
            Console.WriteLine("\nShow the list of french customers’ names who used to order french products");
            command.CommandText = "SELECT c.ContactName FROM Customers AS c, Orders AS o WHERE c.CustomerID=o.CustomerID AND c.Country='France' AND o.ShipCountry='France';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ContactName"]);
            }
            reader.Close();
        }

        public void Q25()
        {
            //25.	*Show the total ordering sum calculated for each country of customer.
            Console.WriteLine("\nShow the total ordering sum calculated for each country of customer");
            command.CommandText = "SELECT c.Country, SUM(od.UnitPrice) AS TotalPrice FROM Customers AS c, Orders AS o, [Order Details] AS od WHERE o.CustomerID=c.CustomerID AND o.OrderID=od.OrderID GROUP BY c.Country;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-10}{1}", reader["Country"], reader["TotalPrice"]);
            }
            reader.Close();
        }
        public void Q26()
        {
            //26.Show the total ordering sums calculated for each customer’s country for domestic 
            //and non-domestic products separately (e.g.: “France – French products ordered – 
            //Non -french products ordered” and so on for each country).
            Console.WriteLine("\nShow the total ordering sums calculated for each customer’s country for domestic and non-domestic products separately (e.g.: “France – French products ordered – Non-french products ordered” and so on for each country).");
            command.CommandText = "SELECT D1.Country, D1.Domestic, D2.NonDomestic FROM (SELECT C.Country, COUNT (P.ProductID) AS Domestic FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.country = C.Country GROUP BY C.Country) AS D1 LEFT JOIN (SELECT C.Country, COUNT (P.ProductID) AS NonDomestic FROM Customers AS C LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID WHERE S.country <> C.Country GROUP BY C.Country) AS D2 ON D1.Country = D2.Country;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0, -20}\n\t- {0} products ordered {1} \n\t- Non {0} products ordered {2, -20}", reader["Country"], reader["Domestic"], reader["NonDomestic"]);
            }
            reader.Close();
        }
        public void Q27()
        {
            //27.	*Show the list of product categories along with total ordering sums calculated
            //for the orders made for the products of each category, during the year 1997.
            Console.WriteLine("\n*Show the list of product categories along with total ordering sums calculated for the orders made for the products of each category, during the year 1997");
            command.CommandText = "SELECT C.CategoryName, P.ProductName, COUNT (O.OrderID) AS OrdersAmount FROM Categories AS C LEFT JOIN Products AS P ON P.CategoryID = C.CategoryID LEFT JOIN [Order Details] AS OD ON OD.ProductID = P.ProductID LEFT JOIN Orders AS O ON O.OrderID = OD.OrderID WHERE O.OrderDate BETWEEN '01-01-1997' AND '31-12-1997' GROUP BY P.ProductName, C.CategoryName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-20}{1,-35}{2}", reader["CategoryName"], reader["ProductName"], reader["OrdersAmount"]);
            }
            reader.Close();
        }
        public void Q28()
        {
            //28.Show the list of product names along with unit prices and the history of 
            //unit prices taken from the orders (show ‘Product name – Unit price – Historical price’).
            //The duplicate records should be eliminated. If no orders were made for a certain product,
            //then the result for this product should look like ‘Product name – Unit price – NULL’. 
            //Sort the list by the product name.
            Console.WriteLine("\nShow the list of product names along with unit prices and the history of unit prices taken from the orders (show ‘Product name – Unit price – Historical price’). The duplicate records should be eliminated. If no orders were made for a certain product, then the result for this product should look like ‘Product name – Unit price – NULL’. Sort the list by the product name.");
            command.CommandText = "SELECT P.ProductName, P.UnitPrice, OD.UnitPrice AS HistoricalPrice FROM Products AS P RIGHT JOIN [Order Details] AS OD ON P.ProductID = OD.ProductID WHERE P.UnitPrice <> OD.UnitPrice GROUP BY P.ProductName, P.UnitPrice, OD.UnitPrice ORDER BY P.ProductName;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0, -40} {1, -20} {2}", reader["ProductName"], reader["UnitPrice"], reader["HistoricalPrice"]);
            }
            reader.Close();
        }
        public void Q29()
        {
            //29. * Show the list of employees’ names along with names of their chiefs
            //(use left join with the same table).
             Console.WriteLine("\nShow the list of employees’ names along with names of their chiefs (use left join with the same table).");
            command.CommandText = "SELECT E1.LastName AS Name, E2.LastName AS Chief FROM Employees AS E1 LEFT JOIN Employees AS E2 ON E1.ReportsTo = E2.EmployeeID;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["Name"], reader["Chief"]);
            }
            reader.Close();
        }
        public void Q30()
        {
            //30.	*Show the list of cities where employees and customers are from and
            //where orders have been made to. Duplicates should be eliminated.
            Console.WriteLine("\nShow the list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated.");
            command.CommandText = "(SELECT E.City AS OrderFromCity, O.ShipCity AS OrderToCity FROM Orders AS O LEFT JOIN Employees AS E ON E.EmployeeID = O.EmployeeID GROUP BY E.City, O.ShipCity) UNION (SELECT C.City AS OrderFromCity, O.ShipCity AS OrderToCity FROM Orders AS O LEFT JOIN Customers AS C ON C.CustomerID = O.CustomerID GROUP BY C.City, O.ShipCity);";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}", reader["OrderFromCity"], reader["OrderToCity"]);
            }
            reader.Close();
        }

        public void Q31()
        {
            //31.	*Insert 5 new records into Employees table. Fill in the following  fields: 
            //LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. 
            //The Notes field should contain your own name.
            int insertQuantity = 0;
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Burdeina', 'Ira', '05-01-1999', '03-12-2018', 'Topolna st. 78', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Ivanova', 'Tonia', '14-11-1999', '03-12-2018', 'Bandery st. 8', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Butriy', 'Oleh',  '01-09-1999', '03-12-2018', 'SantaBarbara st. 73', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Koltun', 'Roman',  '03-12-1999', '03-12-2018', 'Stus st. 18', 'Lviv', 'Ukraine', 'Smart');";
            insertQuantity += command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) VALUES ('Loik', 'Nottet',  '07-01-1999', '03-12-2018', 'Loren st. 16', 'Paris', 'France', 'Smart');";
            insertQuantity += command.ExecuteNonQuery();
            Console.WriteLine("\nInserted {0} rows", insertQuantity);
        }
        public void Q32()
        {
            //32. * Fetch the records you have inserted by the SELECT statement
            Console.WriteLine("\nFetch the records you have inserted by the SELECT statement");
            command.CommandText = "SELECT * FROM Employees WHERE Notes LIKE 'Smart';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0,-20}{1}", reader.GetName(i), reader.GetValue(i));
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        public void Q33()
        {
            //33. * Change the City field in one of your records using the UPDATE statement.
             Console.WriteLine("\nChange the City field in one of your records using the UPDATE statement.");
            command.CommandText = "UPDATE Employees SET City = 'New York' WHERE LastName = 'Burdeina' ;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Update {command.ExecuteNonQuery()} row");
            }
            reader.Close();
        }
        public void Q34()
        {
            //34.	*Change the HireDate field in all your records to current date.
            Console.WriteLine("\nChange the HireDate field in all your records to current date.");
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Employees SET HireDate = '03-12-2018' WHERE Notes like 'Smart' ;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Update {command.ExecuteNonQuery()} row");
            }
            reader.Close();
        }
        public void Q35()
        {
            ////35. * Delete one of your records.
            int deletedQuantity = 0;
            command.CommandText = "DELETE FROM Employees WHERE LastName='Nottet' AND FirstName like 'Loik';";
            deletedQuantity += command.ExecuteNonQuery();
            Console.WriteLine("Deleted {0} rows", deletedQuantity);
            connection.Close();
        }
        public void RunAll()
        {
            //viklik 
            Q1();
            Console.ReadKey();
            Q2();
            Console.ReadKey();
            Q3();
            Console.ReadKey();
            Q4();
            Console.ReadKey();
            Q5();
            Console.ReadKey();
            Q6();
            Console.ReadKey();
            Q7();
            Console.ReadKey();
            Q8();
            Console.ReadKey();
            Q9();
            Console.ReadKey();
            Q10();
            Console.ReadKey();
            //---------

            Q11();
            Console.ReadKey();
            Q12();
            Console.ReadKey();
            Q13();
            Console.ReadKey();
            Q14();
            Console.ReadKey();
            Q15();
            Console.ReadKey();
            Q16();
            Console.ReadKey();
            Q17();
            Console.ReadKey();
            Q18();
            Console.ReadKey();
            Q19();
            Console.ReadKey();
            Q20();
            Console.ReadKey();
            //---------
            Q21();
            Console.ReadKey();
            Q22();
            Console.ReadKey();
            Q23();
            Console.ReadKey();
            Q24();
            Console.ReadKey();
            Q25();
            Console.ReadKey();
            Q26();
            Console.ReadKey();
            Q27();
            Console.ReadKey();
            Q28();
            Console.ReadKey();
            Q29();
            Console.ReadKey();
            Q30(); Console.ReadKey();
            //---------
            Q31();
            Console.ReadKey();

            Q32();
            Console.ReadKey();
            Q33();
            Console.ReadKey();
            Q34();
            Console.ReadKey();
            Q35();
            Console.ReadKey();

        }
    }
}