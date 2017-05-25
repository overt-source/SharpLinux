using System;
using System.IO;
namespace CMDLinux {
class ls {
static void Main() {
string[] FolderPaths = Directory.GetDirectories(Directory.GetCurrentDirectory());
string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
for (int i = 0; i < FolderPaths.Length; ++i) {
    string path = FolderPaths[i];
    Console.WriteLine(System.IO.Path.GetFileName(path));
}

for (int i = 0; i < filePaths.Length; ++i) {
    string path = filePaths[i];
    Console.WriteLine(System.IO.Path.GetFileName(path));
}

}
}
}
