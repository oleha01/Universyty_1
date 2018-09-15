//-----------------------------------------------------------------------
// <copyright file="PhoneContact.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
using System.IO;

namespace Task1
{
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
