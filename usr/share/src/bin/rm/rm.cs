using System;
using System.IO;
namespace CMDLinux {
class RMFile {
static void Main(string[] args) {
try {
File.Delete(args[0]);
}
catch(System.IO.FileNotFoundException) {
Console.WriteLine("RM: "+args[0]+": not found");
}
}
}
}
