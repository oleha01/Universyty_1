using System;
using System.IO;

namespace Task1
{
    public class MailContact : Contact, IFileManager
    {
        public MailContact(string name_, string email_) : base(name_)
        {
            this.Email = email_;
        }

        public MailContact() : base()
        {
            this.Email = string.Empty;
        }

        public string Email { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            this.Name = s[0];
            this.Email = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", this.Name, this.Email);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}\n", this.Name, this.Email);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return string.Compare(this.Name, element2.Name);
        }
    }
}