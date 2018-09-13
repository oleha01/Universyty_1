using System;
using System.IO;

namespace Task1
{
    public class SkypeContact : Contact, IFileManager
    {
        public SkypeContact(string name_, string nicknameInSkype_) : base(name_)
        {
            this.NicknameInSkype = nicknameInSkype_;
        }

        public SkypeContact() : base()
        {
            this.NicknameInSkype = string.Empty;
        }

        public string NicknameInSkype { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            this.Name = s[0];
            this.NicknameInSkype = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", this.Name, this.NicknameInSkype);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}\n", this.Name, this.NicknameInSkype);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return string.Compare(this.Name, element2.Name);
        }
    }
}