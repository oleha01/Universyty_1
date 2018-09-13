namespace Task1
{
    using System;
    using System.IO;

    public class SkypeContact : Contact, IFileManager
    {
        public SkypeContact(string name_, string nicknameInSkype_) : base(name_)
        {
            NicknameInSkype = nicknameInSkype_;
        }

        public SkypeContact() : base()
        {
            NicknameInSkype = string.Empty;
        }

        public string NicknameInSkype { get; set; }

        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            Name = s[0];
            NicknameInSkype = s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", Name, NicknameInSkype);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}\n", Name, NicknameInSkype);
        }

        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return String.Compare(Name, element2.Name);
        }
    }
}