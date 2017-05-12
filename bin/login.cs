using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class login {
static void Main() {
// wait 2 seconds to let the user see kernel messages.
System.Threading.Thread.Sleep(2000);
Console.Clear();
// set up some strings
string passwordSha;
string LoginHostSource=Environment.GetEnvironmentVariable("hostname.sl");
// this one's needed across all apps.
string rootpath=Environment.GetEnvironmentVariable("rootpath.sl");
string motd=File.ReadAllText(""+rootpath+"\\etc\\motd");
// strip crlf from /etc/hostname
string LoginHost = System.Text.RegularExpressions.Regex.Replace(LoginHostSource, @"\t|\n|\r", "");
Console.WriteLine(motd);
Username:

Console.Write(""+LoginHost+" Login:");
string username=Console.ReadLine();
// couple of exploit stoppy things
if(username.Contains(".")) {

goto Username;
}
if(username.Contains("/")) {
Console.WriteLine("Illegal username");
goto Username;
}
if(username.Contains("\\")) {
Console.WriteLine("Illegal username");
goto Username;
}
if(username=="") {
Console.WriteLine("Illegal username");
goto Username;
}
if(!Directory.Exists(""+rootpath+"\\home\\"+username+"")) {
Console.WriteLine("Bad Username: "+username+"");
System.Threading.Thread.Sleep(100);
goto Username;
}
Console.Write("Password:");
string password=ReadPassword();
Console.WriteLine("Verifying...");
var libSha = new Process();
libSha.StartInfo = new ProcessStartInfo( ""+rootpath+"\\libexec\\libSha.exe" ) 
{
        Arguments = password,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
};

libSha.Start();

while (!libSha.StandardOutput.EndOfStream) {
Environment.SetEnvironmentVariable("passwordSha.sl", libSha.StandardOutput.ReadLine());
// now we have the sha of the password that the user entered.

}
passwordSha=Environment.GetEnvironmentVariable("passwordSha.sl");
Environment.SetEnvironmentVariable("passwordSha.sl", "");
// now we have the sha of the password, let's see if it is the sha of the user's actual password by reading ~/.passwd.
string passwordShaCompare =File.ReadAllText(""+rootpath+"\\"+username+"\\.passwd");
// do login things.
if(passwordSha == passwordShaCompare) {
// yah! they logged in!
// oh wait, we don't have login code
Console.WriteLine("Nothing from here.");
Environment.Exit(1);

}
// if the user got here, they failed to authenticate
Console.WriteLine("Login incorrect.");
goto Username;

}
     public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }
    }
}
