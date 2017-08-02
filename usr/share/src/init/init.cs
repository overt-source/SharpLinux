using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux
{
class InitBinary
{
static void Main ()
{

// some lovely, lovely globals.
string identifyer;
string rootpath;
 Console.Clear ();
System.Threading.Thread.Sleep (400);

// check for some important files.
Console.WriteLine (" Starting the kernel...");
 Environment.SetEnvironmentVariable ("rootpath.sl", Directory.GetCurrentDirectory ());
rootpath = Directory.GetCurrentDirectory ();
Console.WriteLine (".....");
System.Threading.Thread.Sleep (400);
identifyer =File.ReadAllText(""+rootpath+"/etc/os-release");


Environment.SetEnvironmentVariable ("uname.sl", identifyer);
 Console.WriteLine (".....");

Console.WriteLine (".....");

// see if /bin/login lives.
// actually, we see if it doesn't, and quit if so.
if (!File.Exists ("" + rootpath + "\\bin\\login."))

{
Console.WriteLine ("Error 0x80000002: missing file /bin/login");
Console.WriteLine ("HALT!");
Environment.Exit (1);
}
Console.WriteLine (identifyer);
Console.WriteLine (".....");
Console.WriteLine (".....");
string hostname = File.ReadAllText ("" + rootpath + "\\etc\\hostname");
Environment.SetEnvironmentVariable ("hostname.sl", hostname);
Console.WriteLine ("TTY1 SharpLinux {0}", hostname);
var LoginBin = new Process ();
LoginBin.StartInfo =
new ProcessStartInfo ("" + rootpath + "\\bin\\login") 
{
UseShellExecute = false  };
 LoginBin.Start ();
LoginBin.WaitForExit ();
 }
}
}


