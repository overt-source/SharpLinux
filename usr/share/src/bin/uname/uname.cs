using System;
using System.IO;
namespace cmdlinux {
class Uname {
static void Main() {
string RootPath=Environment.GetEnvironmentVariable("rootpath.sl");
Console.WriteLine(File.ReadAllText(""+RootPath+"/etc/os-release"));
}
}
}
