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
	string product = "SharpLinux";
      string version = "0.2";
      string codename = "Sara";
      string builddate = "2017-06-28";
      string buildid = "170628-0028";
      string machinetype =
	Environment.GetEnvironmentVariable ("processor_architecture");
      string buildhost = "Gallifrey";
      string compiler = "CSC";
      string identifyer;
      string rootpath;
       Console.Clear ();
      System.Threading.Thread.Sleep (400);
      
// check for some important files.
	Console.WriteLine (" Setting up directories...");
      Console.WriteLine (" clobbering any rootpath.sl...");
       Environment.SetEnvironmentVariable ("rootpath.sl",
					     Directory.
					     GetCurrentDirectory ());
      rootpath = Directory.GetCurrentDirectory ();
      Console.WriteLine (" Set up directory variables.");
      System.Threading.Thread.Sleep (400);
      identifyer =
	"" + product + " " + buildhost + " " + version + "-" + codename +
	"-" + compiler + " " + builddate + "(" + buildid + ") " +
	machinetype + "";
      Environment.SetEnvironmentVariable ("uname.sl", identifyer);
       Console.WriteLine (" Starting SharpLinux...");

      Console.WriteLine (" Verifying file structure ...");
      
// see if /bin/login lives.
// actually, we see if it doesn't, and quit if so.
	if (!File.Exists ("" + rootpath + "\\bin\\login."))
	
	{
	  Console.WriteLine ("E: Missing Crucial file.");
	  Console.WriteLine ("E: /bin/login: no such file or directory.");
	  Console.WriteLine ("E: Kernel failed to start.");
	  Console.WriteLine (" Exiting NOW.");
	  Environment.Exit (1);
	}
Console.Beep(850,300);
      Console.WriteLine (identifyer);
      Console.WriteLine (" Login binary available.");
      Console.WriteLine (" Retrieving hostname...");
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


