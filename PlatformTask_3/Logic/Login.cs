using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Logic
{
    public class Login
    {
        public string path_password { get; set; }
        public string path_users { get; set; }
        public SortedDictionary<string, string> users;
        public Login(string _path_password = "%AppData%/passowrd.txt")
        {  
            using (StreamReader sr = new StreamReader(File.Open(path_password,FileMode.OpenOrCreate)))
            {
                string[] s = (sr.ReadToEnd()).Split(';');
                foreach(var el in s)
                {
                    string[] s1 = el.Split(' ');
                    users.Add(s1[0], s1[1]);
                    
                }
            }
        }
    }
}
