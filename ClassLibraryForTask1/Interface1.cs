using System;
using System.IO;

namespace Task1
{
    public interface IFileManager : IComparable
    {
        string Name { get; set; }

        void ReadFromFile(StreamReader parth);

        void WrtiteToFile(StreamWriter parth);
    }
}
