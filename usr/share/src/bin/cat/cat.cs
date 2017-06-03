using System;
using System.IO;
namespace CMDLinux {
class CatFile {
static void Main(string[] args) {
Console.WriteLine(args[0]);
string file="";
try {
file=File.ReadAllText(args[0]);
}
catch(System.IndexOutOfRangeException) {
Console.WriteLine("cat: malformed parameters");
}
Console.WriteLine(file);
}
}
}
