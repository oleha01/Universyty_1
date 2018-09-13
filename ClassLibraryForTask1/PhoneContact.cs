namespace Task1
{
    using System;
    using System.IO;

    public class PhoneContact : Contact, IFileManager
    {
        public PhoneContact(string name_, string number_) : base(name_)
        {
            this.Number = number_;
        }

        public PhoneContact() : base()
        {
            this.Number = string.Empty;
        }

        public string Number { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            this.Name = s[0];
            this.Number = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", this.Name, this.Number);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}\n", this.Name, this.Number);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return string.Compare(this.Name, element2.Name);
        }
    }
}
