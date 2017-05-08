using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class InitBinary {
static void Main() {
// some lovely, lovely globals.
string product="SharpLinux";
string version="0.1";
string codename="Leilu";
string builddate="2017-08-09";
string buildid="1705090019";
string machinetype=Environment.GetEnvironmentVariable("processor_architecture");
string buildhost="Medusa-Cascade";
string compiler="CSC";
string identifyer;
string rootpath;

Console.Clear();
System.Threading.Thread.Sleep(400);
// check for some important files.
Console.WriteLine("I: Setting up directories...");
Console.WriteLine("W: clobbering any rootpath.sl...");

Environment.SetEnvironmentVariable("rootpath.sl", Directory.GetCurrentDirectory());
rootpath=Directory.GetCurrentDirectory();
Console.WriteLine("I: Set up directory variables.");
System.Threading.Thread.Sleep(400);
identifyer=""+product+" "+buildhost+" "+version+"-"+codename+"-"+compiler+" "+builddate+"("+buildid+") "+machinetype+"";
Environment.SetEnvironmentVariable("uname.sl", identifyer);

Console.WriteLine("I: Starting SharpLinux...");
Console.WriteLine("I: "+identifyer+"");
Console.WriteLine("I: Verifying file structure ...");
// see if /bin/login lives.
// actually, we see if it doesn't, and quit if so.
if(!File.Exists(""+rootpath+"\\bin\\login.exe"))
{
Console.WriteLine("E: Missing Crucial file.");
Console.WriteLine("E: /bin/login: no such file or directory.");
Console.WriteLine("E: Kernel failed to start.");
Console.WriteLine("W: Exiting NOW.");
Environment.Exit(1);
}
Console.WriteLine("I: Login binary available.");
Console.WriteLine("I: Retrieving hostname...");
string hostname=File.ReadAllText(""+rootpath+"\\etc\\hostname");
Environment.SetEnvironmentVariable("hostname.sl", hostname);
Console.WriteLine("TTY1 SharpLinux {0}", hostname);
var LoginBin = new Process();
LoginBin.StartInfo = new ProcessStartInfo( ""+rootpath+"\\bin\\login.exe" ) 
{
UseShellExecute = false

};

LoginBin.Start();

}
}
}
