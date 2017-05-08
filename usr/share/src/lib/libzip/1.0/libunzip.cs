using System;
using System.IO;
using System.IO.Compression;

namespace cmdlinux
{
    class LibUnzip
    {
        static void Main(string[] args)
        {
System.IO.Compression.FileSystem.ZipFile z = new System.IO.Compression.FileSystem.ZipFile();
z.ExtractToDirectory(args[0], args[1]);
        }
    }
}