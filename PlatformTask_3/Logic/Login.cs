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
        public static  string path_password { get; set; }
        public static string path_users { get; set; }
        private static List<Client> users;
        static bool ifChanged = false;
        public static List<Client> Users { get { ifChanged = true; return users; } set { users = value; } }

        static Login()
        {
            path_password = "password.txt";
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            using (FileStream sr = new FileStream(path_password,FileMode.OpenOrCreate))
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
                
            
        }
       public static void Seria()
        {
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            using (FileStream sr = new FileStream(path_password, FileMode.OpenOrCreate))
            {
                f.Serialize(sr, users);
            }
        }
    }
}
