using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class login {
static void Main() {
// wait 2 seconds to let the user see kernel messages.
System.Threading.Thread.Sleep(2000);
Console.Clear();
// set up some strings based on variables that init helpfully setup for us:
string LoginHostSource=Environment.GetEnvironmentVariable("hostname.sl");
// strip crlf from /etc/hostname
string LoginHost = System.Text.RegularExpressions.Regex.Replace(LoginHostSource, @"\t|\n|\r", "");
Console.Write(""+LoginHost+" Login:");
string username=Console.ReadLine();
Console.Write("Password:");
string password=Console.ReadLine();
}
}
}
