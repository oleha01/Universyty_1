namespace Task1
{
    using System;
    using System.IO;

    public class MailContact : Contact, IFileManager
    {
        public MailContact(string name_, string email_) : base(name_)
        {
            Email = email_;
        }

        public MailContact() : base()
        {
            Email = string.Empty;
        }

        public string Email { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            Name = s[0];
            Email = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", Name, Email);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}\n", Name, Email);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return String.Compare(Name, element2.Name);
        }
    }
}