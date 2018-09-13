using System;
using System.IO;

namespace Task1
{
    public class MailContact : Contact, IFileManager
    {
        public string email { get; set; }
        public MailContact(string name_, string email_) : base(name_)
        {
            email = email_;
        }
        public MailContact() : base()
        {
            email = "";
        }
        public void ReadFromFile(StreamReader parth)
        {
            string Row = parth.ReadLine();
            string[] s = Row.Split(' ');
            name = s[0];
            email = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", name, email);
        }
        public override string ToString()
        {

            return String.Format("{0}, {1}\n", name, email);
        }
        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return String.Compare(name, element2.name);

        }
    }
}