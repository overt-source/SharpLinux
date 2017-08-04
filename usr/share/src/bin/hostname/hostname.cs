using System;
using System.IO;
namespace cmdlinux {
class HostnameGet {
static void Main() {
string RootPath=Environment.GetEnvironmentVariable("rootpath.sl");
string hostname;
hostname=File.ReadAllText(""+RootPath+"\\etc\\hostname");


Console.WriteLine(hostname);
}
}
}
