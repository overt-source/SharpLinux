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
string builddate="2017-08-05";
string buildid="1705080001";
string machinetype=Environment.GetEnvironmentVariable("processor_architecture");
string buildhost="Medusa-Cascade";
string compiler="CSC";

Console.Clear();
System.Threading.Thread.Sleep(400);
// check for some important files.
Console.WriteLine("I: Setting up directories...");
Console.WriteLine("W: clobbering any rootpath.cl...");

Environment.SetEnvironmentVariable("rootpath.sl", Directory.GetCurrentDirectory());
Console.WriteLine("I: Set up directory variables.");
System.Threading.Thread.Sleep(400);
string identifyer=""+product+" "+buildhost+" "+version+"-"+codename+"-"+compiler+" "+builddate+" "+machinetype+"";
Environment.SetEnvironmentVariable("uname.sl", identifyer);

Console.WriteLine("I: Starting SharpLinux...");
Console.WriteLine("I: "+identifyer+"");
Console.WriteLine("I: Verifying file structure...");
// if(!File.Exists()
}
}
}
