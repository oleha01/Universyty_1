using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task1
{
    public interface IFileManager:IComparable
    {
        string name{get;set;}
        void ReadFromFile(StreamReader parth);
        void WrtiteToFile(StreamWriter parth);
    }
}
