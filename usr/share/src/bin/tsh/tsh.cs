using System;
using System.IO;
using System.Diagnostics;
namespace CMDLinux
{
class tsh
{
static void Main(string[] args) {

// import variables to construct prompt.
string tshver="0.3.0-2-release";
string WhoAmI = Environment.GetEnvironmentVariable("username.sl");
string WhereAmI = Environment.GetEnvironmentVariable("hostname.sl");
string PermissionToken = Environment.GetEnvironmentVariable("shebang.sl");
string RootPath = Environment.GetEnvironmentVariable("rootpath.sl");
string binary;
string binary_parameters;
// done with that.
// give them some prompty goodness.
Console.WriteLine("SharpLinux CoreUtils v0.3.0-02 (2017-11-27 22:58:11 NZDT) built-in shell (TSH).\n\n\n\n\n\n\n");
Console.WriteLine(File.ReadAllText(""+RootPath+"\\etc\\shell.msg"));

PromptyGoodness:
Console.Write(""+tshver+" ");
Console.Write(""+WhoAmI+"@"+WhereAmI+" ");
            string path_orig_prompt = Directory.GetCurrentDirectory();
// handle being at root dir...
string path_real_prompt=path_orig_prompt.Replace(RootPath, "/");
// and not...
path_real_prompt=path_orig_prompt.Replace(""+RootPath+"\\", "/");
path_real_prompt=path_real_prompt.Replace("\\", "/");
if(path_real_prompt.Contains("/SharpLinux")) {
// at root dir
Console.Write("/");
goto TokenExit;
}
if(path_real_prompt.Contains("/sharplinux")) {
// at root dir if user cloned it with a lowercase URL.
Console.Write("/");
goto TokenExit;
}

            Console.Write("{0}", path_real_prompt);

TokenExit:
Console.Write(" "+PermissionToken+"");
string Exec;
Exec=Console.ReadLine();

// split this bitch.
string[] Exec_Exec=Exec.Split(';');
// shell builtins:
// print working directory.
if(Exec_Exec[0]=="pwd") {
            string path_orig = Directory.GetCurrentDirectory();
// handle being at root dir...
string path_real=path_orig.Replace(RootPath, "/");
// and not...
path_real=path_orig.Replace(""+RootPath+"\\", "/");
path_real=path_real.Replace("\\", "/");
if(path_real.Contains("/cmdlinux")) {
// at root dir
Console.WriteLine("/");
goto PromptyGoodness;
}
            Console.WriteLine("{0}", path_real);
goto PromptyGoodness;
}

// null builtin (deal with <ret> without a command)
if(String.IsNullOrEmpty(Exec)) {
goto PromptyGoodness;
}
// change directory
if(Exec_Exec[0]=="cd") {
// grab the current directory to jump back to if the destination is out of scope.
string SafeDir=Directory.GetCurrentDirectory();
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
catch(System.IO.IOException EX) {
// What did you do!
Console.WriteLine("TSH: cd: {0}: I/O error", Exec_Exec[1]);
string LastError=EX.Message;
}

// now we do...
string CurDir=Directory.GetCurrentDirectory();
if(!CurDir.Contains(RootPath)) {
// out of scope!
Directory.SetCurrentDirectory(SafeDir);
}
goto PromptyGoodness;
}
// shell version
if(Exec_Exec[0]=="tshver") {
Console.WriteLine("TinyShell from SharpLinux CoreUtils version 0.3.01 Copyright 2017. Compiled 2017-11-26 at WinStation");
goto PromptyGoodness;
}
// exit
if(Exec_Exec[0]=="exit") {
Console.WriteLine("LOGOUT");
System.Threading.Thread.Sleep(200);
Console.Clear();
Environment.Exit(0);

}
// not a shell built-in, apparently.
// block of code below repeated for all recognised directories (/bin, /sbin root only, and /opt/package/bin/package)

if(File.Exists(""+RootPath+"\\bin\\"+Exec_Exec[0]+"")) {
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
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\"+binary+"" ) 
        {
            UseShellExecute = false,
Arguments = binary_parameters
// make it work like a real shell. We don't want each command spawning it's own window, do we?
        };

    p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}

if(File.Exists(""+RootPath+"\\sbin\\"+Exec_Exec[0]+"")) {
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
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\sbin\\"+binary+"" ) 
        {
            UseShellExecute = false,
Arguments = binary_parameters
// make it work like a real shell. We don't want each command spawning it's own window, do we?
        };

// wo there, let's make sure the user is root before starting that
if(WhoAmI!="root") {
Console.WriteLine("TSH: Cannot execute: security error.");
goto PromptyGoodness;
}
p.Start();
    p.WaitForExit();
goto PromptyGoodness;
}


if(File.Exists(""+RootPath+"\\opt\\"+Exec_Exec[0]+"\bin\\"+Exec_Exec[0]+"")) {

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
p.StartInfo = new ProcessStartInfo( ""+RootPath+"\\sbin\\"+binary+"" ) 
        {
            UseShellExecute = false,
Arguments = binary_parameters
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
