using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
  public  class SkypeContact:Contact,IFileManager
    {
        public string nicknameInSkype { get; set; }
        public SkypeContact(string name_, string nicknameInSkype_) : base(name_)
        {
            nicknameInSkype = nicknameInSkype_;
        }
        public SkypeContact():base()
            {
            nicknameInSkype="";
}

        public void ReadFromFile(StreamReader parth)
        {
            string Row=parth.ReadLine();
            string[] s=Row.Split(' ');
            name=s[0];
            nicknameInSkype=s[1];
        }

        public void WrtiteToFile(StreamWriter parth)
        {
             parth.WriteLine("{0}, {1}",name,nicknameInSkype);
        }
         public override string ToString()
        {
           
           return String.Format("{0}, {1}\n",name,nicknameInSkype);
        }
        public int CompareTo(object obj)
            {
            var element2=obj as IFileManager;
           return String.Compare(name,element2.name);

}
    }
}
