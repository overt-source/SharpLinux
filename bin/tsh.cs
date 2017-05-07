using System;
using System.IO;
using System.Diagnostics;
namespace CMDLinux
{
class sh
{
static void Main(string[] args) {
// import variables to construct prompt.
string shver="3.0.0-2017-07-05";
string WhoAmI = Environment.GetEnvironmentVariable("username.shell");
string PermissionToken = Environment.GetEnvironmentVariable("shebang");
string RootPath = Environment.GetEnvironmentVariable("rootpath.shell");
string binary;
string binary_parameters;
// done with that.
// Tell the user who we are:
Console.WriteLine("Welcome to TinyShell!\r\nFor a list of the commands installed on your system, type:\r\nHELP\r\nFor information about this shell, type:\r\ntshver\r\n");
// give them some prompty goodness.
PromptyGoodness:
Console.Write("Sh-3.0-testing\r\n{0}", PermissionToken);
string Exec;
Exec=Console.ReadLine();
// split this bitch.
string[] Exec_Exec=Exec.Split(';');
// some basic checks to make sure the user isn't doing insane, demonic things.
if(Exec_Exec[0]=="tsh") {
Console.WriteLine("TSH: Recursive shellCall.");
goto PromptyGoodness;
}
if(Exec_Exec[0]=="sh") {
Console.WriteLine("TSH: Recursive shellCall.");
goto PromptyGoodness;
}

if(Exec_Exec[0]=="login") {
Console.WriteLine("TSH: Can't login: already logged in");
goto PromptyGoodness;
}
// shell builtins:
if(Exec_Exec[0]=="pwd") {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("{0}", path);
goto PromptyGoodness;
}

if(String.IsNullOrEmpty(Exec)) {
goto PromptyGoodness;
}
if(Exec_Exec[0]=="cd") {
try {
Directory.SetCurrentDirectory(Exec_Exec[1]);
}
catch(Exception EX) {
Console.WriteLine("TSH: cd: {0}: No such file or directory", Exec_Exec[1]);
string LastError=EX.Message;
}
goto PromptyGoodness;
}
if(Exec_Exec[0]=="tshver") {
Console.WriteLine("TinyShell - version {0} Copyright 2017. For CMDLinux 3.0 (Ashley series).", shver);
goto PromptyGoodness;
}
if(Exec_Exec[0]=="exit") {
Console.Write("Terminate TinyShell and logout? y - n   : ");
string ExitChoice=Console.ReadLine();
if(ExitChoice=="y") {
Console.WriteLine("LOGOUT");
System.Threading.Thread.Sleep(200);
Console.Clear();
Environment.Exit(0);
}
else {
goto PromptyGoodness;
}

}
// here we look for and run whatever the user asked for, in a few places.
if(File.Exists(""+RootPath+"\\bin\\"+Exec_Exec[0]+".exe")) {
binary=Exec_Exec[0];
try {
binary_parameters=Exec_Exec[1];
}
catch(Exception EX) {
string LastError=EX;
binary_parameters="";
}
var p = new Process();
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\"+binary+".exe", "binary_parameters" ) 
        {
            UseShellExecute = false
        };

    p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}

Console.WriteLine("TSh: "+Exec_Exec[0]+": Not Found");
goto PromptyGoodness;
}
}
}
