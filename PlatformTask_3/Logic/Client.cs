using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Address Adress_Client { get; set; }
        public List<string> list { get; set; }
        public Client()
        {
            Name="";
            LastName="";
            Login="";
            Password="";
            Phone="";
            Adress_Client=new Address();
            list=new List<string>();
        }
        public Client(string name,string  lastname, string login,string passwrod,string phone,List<string> list )
        {
            Name=name;
            LastName=lastname;
            Login=login;
            Password=passwrod;
            Phone=phone;
            Adress_Client=new Address();
            this.list=list;
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2},{3},{4},{5}",Name,LastName,Login,Password,Phone );
        }

    }
}
