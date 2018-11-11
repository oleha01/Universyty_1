using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Logic
{
    public static class Login
    {
        public static string path_password { get; set; }
        public static string path_orders { get; set; }
        private static List<Client> users;
        static bool ifChanged = false;
        public static List<Client> Users { get { ifChanged = true; return users; } set { users = value; } }
        public static List<Order> orders;

        static Login()
        {
            path_password = "password.txt";
            path_orders = "orders.txt";
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
            using (FileStream sr = new FileStream(path_password, FileMode.OpenOrCreate))
            {
                try
                {
                    users = f.Deserialize(sr) as List<Client>;
                }
                catch
                {
                    users = new List<Client>();
                }
            }
            using (FileStream sr = new FileStream(path_orders, FileMode.OpenOrCreate))
            {
                try
                {
                    orders = f1.Deserialize(sr) as List<Order>;
                }
                catch
                {
                    orders = new List<Order>();
                }
            }


        }
        public static void Seria()
        {
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            using (FileStream sr = new FileStream(path_password, FileMode.OpenOrCreate))
            {
                f.Serialize(sr, users);
            }
        }
        public static void SeriaOrd()
        {
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
            using (FileStream sr = new FileStream(path_orders, FileMode.OpenOrCreate))
            {
                f1.Serialize(sr, orders);
            }
        }
    }
}
