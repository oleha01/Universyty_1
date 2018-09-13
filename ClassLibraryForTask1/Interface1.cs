namespace Task1
{
    using System;
    using System.IO;

    public interface IFileManager : IComparable
    {
        string Name { get; set; }

        void ReadFromFile(StreamReader parth);

        void WrtiteToFile(StreamWriter parth);
    }
}
