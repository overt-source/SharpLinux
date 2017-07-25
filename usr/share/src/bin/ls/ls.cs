using System;
using System.IO;
namespace CMDLinux {
class ls {
static void Main() {
string[] FolderPaths = Directory.GetDirectories(Directory.GetCurrentDirectory());
string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
int total=FolderPaths.Length+filePaths.Length;
Console.WriteLine("Total "+total+"");

for (int i = 0; i < FolderPaths.Length; ++i) {

string path = FolderPaths[i];
Console.Write("D ");
Console.Write("WIN:");
Console.Write(System.IO.File.GetAccessControl(path).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString());
Console.Write(" ");
Console.Write(path.Length);
Console.Write(" ");
Console.Write(System.IO.Path.GetFileName(path));
Console.Write("\r\n");

}

for (int i = 0; i < filePaths.Length; ++i) {
    string path = filePaths[i];
Console.Write(". ");
Console.Write("WIN:");
Console.Write(System.IO.File.GetAccessControl(path).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString());
Console.Write(" ");
Console.Write(path.Length);
Console.Write(System.IO.Path.GetFileName(path));
Console.Write("\r\n");
}

}
}
}
