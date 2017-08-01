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
        Arguments = "tar -xf "+RootPath+"\\libexec\\LibEdit.cem",
        UseShellExecute = false,
RedirectStandardOutput = true,
        CreateNoWindow = true
};
Loader.Start();
Loader.WaitForExit ();

Console.WriteLine("Loading  "+file+"...");
}
}
}
