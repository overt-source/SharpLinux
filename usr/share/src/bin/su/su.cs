using System;
using System.IO;
using System.Diagnostics;
namespace cmdlinux {
class SuperUser_Do {
static string passwordSha;
static string passwordShaCompare;
static string RootPath=Environment.GetEnvironmentVariable("RootPath.sl");
static void Main() {

string lecture=File.ReadAllText(""+RootPath+"/etc/su.msg");
Console.WriteLine(lecture);
Console.WriteLine("\r\n\r\n");
Console.Write("Enter password for user \'root\'");
string password=ReadPassword();
// code below taken from /bin/login with some modifications:
// instantiate libSha for password verification

var libSha = new Process();
libSha.StartInfo = new ProcessStartInfo( ""+RootPath+"\\libexec\\libSha.em" ) 
{
        Arguments = password,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        CreateNoWindow = true
};


libSha.Start();

// capture libSha's output, as that's the sha512 of the password.
while (!libSha.StandardOutput.EndOfStream) {

Environment.SetEnvironmentVariable("passwordSha.sl", libSha.StandardOutput.ReadLine());

// now we have the sha of the password that the user entered.

}

passwordSha=Environment.GetEnvironmentVariable("passwordSha.sl");

Environment.SetEnvironmentVariable("passwordSha.sl", "");
// get that out of memory, very very bad!
// now we read ~/.passwd

passwordShaCompare =File.ReadAllText(""+RootPath+"\\home\\root\\.passwd");
// verification of sha against stored one.

if(passwordSha == passwordShaCompare) {
Console.WriteLine("OK");
RootContext();
}

else {
Console.WriteLine("Su: Authentication failure.");
}
}
static void RootContext() {
 Environment.SetEnvironmentVariable("username.sl", "root");
 Environment.SetEnvironmentVariable("shebang.sl", "#");
var RootShell = new Process();
RootShell.StartInfo = new ProcessStartInfo( ""+RootPath+"\\bin\\tsh" ) 
{
        UseShellExecute = false,
//        CreateNoWindow = false
};


RootShell.Start();


}
public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write(" ");
                    Console.Beep(11100,3);
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
if(string.IsNullOrEmpty(password)) {
Console.Beep(1100,200);
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
