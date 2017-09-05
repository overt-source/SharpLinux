using System;
using System.IO;
namespace CMDLinux {
class CatFile {
static void Main(string[] args) {
string file="";
string argument;
try {
argument=args[0];
if(argument == "-v") {
Console.WriteLine("SharpLinux CoreUtils v0.3.0-00 (2017-09-05 11:58:21 NZST) /bin/cat\n\nusage: cat <file> [-v]\n\nPrints files to the screen.\n\n-v, show version and exit.");
Environment.Exit(0);
}

file=File.ReadAllText(argument);
}

catch(System.IndexOutOfRangeException) {
Console.WriteLine("cat: malformed parameters");
}
Console.WriteLine(file);
}
}
}
