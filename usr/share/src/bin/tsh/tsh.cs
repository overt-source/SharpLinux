using System;
using System.IO;
using System.Diagnostics;
namespace CMDLinux
{
class sh
{
static void Main(string[] args) {
// import variables to construct prompt.
string shver="0.1.0-2017-05-08";
string WhoAmI = Environment.GetEnvironmentVariable("username.sl");
string PermissionToken = Environment.GetEnvironmentVariable("shebang.sl");
string RootPath = Environment.GetEnvironmentVariable("rootpath.sl");
string binary;
string binary_parameters;
// done with that.
// Tell the user who we are:
Console.WriteLine("Welcome to TinyShell!\r\nFor a list of the commands installed on your system, type:\r\nHELP\r\nFor information about this shell, type:\r\ntshver\r\n");
// give them some prompty goodness.
PromptyGoodness:
Console.Write("TSH0.1 {0}{1}", WhoAmI, PermissionToken);
string Exec;
Exec=Console.ReadLine();
// split this bitch.
string[] Exec_Exec=Exec.Split(';');
// some basic checks to make sure the user isn't doing insane, demonic things.
// shell builtins:
// print working directory.
if(Exec_Exec[0]=="pwd") {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("{0}", path);
goto PromptyGoodness;
}

// null builtin (deal with <ret> without a command)
if(String.IsNullOrEmpty(Exec)) {
goto PromptyGoodness;
}
// change directory
if(Exec_Exec[0]=="cd") {
try {
Directory.SetCurrentDirectory(Exec_Exec[1]);
}
// exception handling goodness
catch(System.IO.DirectoryNotFoundException EX) {
// that, doesn't live!
Console.WriteLine("TSH: cd: {0}: No such file or directory", Exec_Exec[1]);
string LastError=EX.Message;
}
catch(System.IndexOutOfRangeException EX) {
// yes, we do need parameters...
Console.WriteLine("TSH: cd: malformed parameters.");
string LastError=EX.Message;
}
catch(System.ArgumentException EX) {
// no, you can't leave em blank, either.
Console.WriteLine("TSH: cd: malformed parameters.");
string LastError=EX.Message;
}

goto PromptyGoodness;
}
// shell version
if(Exec_Exec[0]=="tshver") {
Console.WriteLine("TinyShell - version {0} Copyright 2017. For SharpLinux 0.1 Beta (Leilu series).", shver);
goto PromptyGoodness;
}
// exit
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
// not a shell built-in, apparently.
// block of code below repeated for all recognised directories (/bin, /sbin root only, and /opt/package/bin/package)

if(File.Exists(""+RootPath+"\\bin\\"+Exec_Exec[0]+".exe")) {
binary=Exec_Exec[0];
try {
binary_parameters=Exec_Exec[1];
}
catch(Exception EX) {
// clearly no parameters, moving on...
string LastError=EX.Message;
binary_parameters="";
}
var p = new Process();
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\"+binary+".exe", "binary_parameters" ) 
        {
            UseShellExecute = false
// make it work like a real shell. We don't want each command spawning it's own window, do we?
        };

    p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}

if(File.Exists(""+RootPath+"\\sbin\\"+Exec_Exec[0]+".exe")) {
binary=Exec_Exec[0];
try {
binary_parameters=Exec_Exec[1];
}
catch(Exception EX) {
// clearly no parameters, moving on...
string LastError=EX.Message;
binary_parameters="";
}
var p = new Process();
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\"+binary+".exe", "binary_parameters" ) 
        {
            UseShellExecute = false
// make it work like a real shell. We don't want each command spawning it's own window, do we?
        };

    p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}

if(File.Exists(""+RootPath+"\\opt\\"+Exec_Exec[0]+"\bin\\"+Exec_Exec[0]+".exe")) {
binary=Exec_Exec[0];
try {
binary_parameters=Exec_Exec[1];
}
catch(Exception EX) {
// clearly no parameters, moving on...
string LastError=EX.Message;
binary_parameters="";
}
var p = new Process();
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\"+binary+".exe", "binary_parameters" ) 
        {
            UseShellExecute = false
// make it work like a real shell. We don't want each command spawning it's own window, do we?
        };

    p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}

// the user only gets here if all other options have turned up nothing.
Console.WriteLine("TSh: "+Exec_Exec[0]+": Not Found");
goto PromptyGoodness;
}
}
}
