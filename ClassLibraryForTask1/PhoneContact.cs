using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
  public class PhoneContact:Contact,IFileManager
  {
    public string number { get; set; }
    public PhoneContact(string name_,string number_):base(name_)
    {
      number = number_;
    }
    public PhoneContact():base()
      {
      number="";
}

    public void ReadFromFile(StreamReader parth)
    {
      string Row=parth.ReadLine();
            string[] s=Row.Split(' ');
            name=s[0];
            number=s[1];
    }

    public void WrtiteToFile(StreamWriter parth)
    {
            parth.WriteLine("{0}, {1}",name,number);
    }
        public override string ToString()
        {
           
           return String.Format("{0}, {1}\n",name,number);
        }
       public int CompareTo(object obj)
            {
            var element2=obj as IFileManager;
           return String.Compare(name,element2.name);

}
    }
}
