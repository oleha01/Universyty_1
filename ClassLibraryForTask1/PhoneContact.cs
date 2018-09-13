namespace Task1
{
    using System;
    using System.IO;

    public class PhoneContact : Contact, IFileManager
    {
        public PhoneContact(string name_, string number_) : base(name_)
        {
            Number = number_;
        }

        public PhoneContact() : base()
        {
            Number = string.Empty;
        }

        public string Number { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            Name = s[0];
            Number = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", Name, Number);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}\n", Name, Number);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return String.Compare(Name, element2.Name);
        }
    }
}
