using System;
using System.IO;
namespace cmdlinux {
class TouchFile {
static void Main(string[] args) {
try {

File.Create(args[0]).Dispose();
}
catch(System.IndexOutOfRangeException EX) {
Console.WriteLine("Touch: malformed parameters");
}


}
}
}
