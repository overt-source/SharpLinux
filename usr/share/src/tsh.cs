using System;
namespace CMDLinux
{
class sh
{
static void Main(string[] args) {
Console.Beep(100,50);
// import variables to construct prompt.
string WhoAmI = Environment.GetEnvironmentVariable("username.shell");
Console.Beep(200,50);
string PermissionToken = Environment.GetEnvironmentVariable("shebang");
Console.Beep(300,50);
// done with that.
// give the user some prompty goodness.
PromptyGoodness:
Console.Write("Sh-3.0-testing:({0}){1}", WhoAmI, PermissionToken);
}
}
}
