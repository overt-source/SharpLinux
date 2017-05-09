using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class login {
static void Main() {
// wait 2 seconds to let the user see kernel messages.
System.Threading.Thread.Sleep(2000);
Console.Clear();
// set up some strings based on variables that init helpfully setup for us:
string LoginHostSource=Environment.GetEnvironmentVariable("hostname.sl");
// this one's needed across all apps.
string rootpath=Environment.GetEnvironmentVariable("rootpath.sl");
// strip crlf from /etc/hostname
string LoginHost = System.Text.RegularExpressions.Regex.Replace(LoginHostSource, @"\t|\n|\r", "");
Username:
Console.Write(""+LoginHost+" Login:");
string username=Console.ReadLine();
if(!Directory.Exists(""+rootpath+"\\home\\"+username+"")) {
Console.WriteLine("Bad Username: "+username+"");
System.Threading.Thread.Sleep(100);
goto Username;
}
Console.Write("Password:");
string password=ReadPassword();
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
