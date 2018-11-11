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
        /// <summary>
        /// List of users.
        /// </summary>
        private static List<Client> users;
        /// <summary>
        /// Gets or sets path for password.
        /// </summary>
        public static string PathPassword { get; set; }

        /// <summary>
        /// Gets or sets path for user information.
        /// </summary>
        public static string PathUsers { get; set; }
        static bool ifChanged = false;
        public static List<Client> Users { get { ifChanged = true; return users; } set { users = value; } }
        public static List<Order> orders;

        static Login()
        {
            PathPassword = "password.txt";
            PathUsers = "orders.txt";
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
            using (FileStream sr = new FileStream(PathUsers, FileMode.OpenOrCreate))
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
            using (FileStream sr = new FileStream(PathUsers, FileMode.OpenOrCreate))
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
            using (FileStream sr = new FileStream(PathPassword, FileMode.OpenOrCreate))
            {
                f.Serialize(sr, users);
            }
        }
        public static void SeriaOrd()
        {
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
            using (FileStream sr = new FileStream(PathUsers, FileMode.OpenOrCreate))
            {
                f1.Serialize(sr, orders);
            }
        }
    }
}
