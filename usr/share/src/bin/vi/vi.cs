using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class ViWrapper {
static string file;
static void Main(string[] args) {
// a wrapper around vi.
string RootPath=Environment.GetEnvironmentVariable("rootpath.sl");
// first, get the file the user wants to open.
try {
file=args[0];
}
catch (System.IndexOutOfRangeException) {
Console.WriteLine("Vi: malformed parameters");
Environment.Exit(1);
}
// file is in string file, so print message that we're opening vi.
Console.WriteLine("Decompressing the editor");
var Loader = new Process();
Loader.StartInfo = new ProcessStartInfo( ""+RootPath+"\\libexec\\BusyBox.em" ) 
{
        Arguments = "tar -xf "+RootPath+"\\libexec\\LibEdit.cem -C "+RootPath+"\\tmp\\",
        UseShellExecute = false,
RedirectStandardOutput = true,
        CreateNoWindow = true
};
Loader.Start();
Loader.WaitForExit ();
Console.WriteLine("Initialising the WindowServer.");
Console.WriteLine("Loading  "+file+"...");

var editor = new Process();
editor.StartInfo = new ProcessStartInfo( ""+RootPath+"\\tmp\\LibEdit\\vim.exe" ) 
{
        Arguments = file,
        UseShellExecute = true,
        CreateNoWindow = true
};
editor.Start();
Console.WriteLine("\aWindowServer started.");
Console.WriteLine("To interrupt, exit application from other window.");
editor.WaitForExit ();
Console.WriteLine("Shutting down the editor.");
var remover = new Process();
remover.StartInfo = new ProcessStartInfo( ""+RootPath+"\\libexec\\BusyBox.em" ) 
{
        Arguments = "rm -rf "+RootPath+"\\tmp\\LibEdit",
        UseShellExecute = false,
RedirectStandardOutput = true,
        CreateNoWindow = true
};
remover.Start();
remover.WaitForExit ();

}
}
}
