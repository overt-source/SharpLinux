using System;
using System.IO;
namespace cmdlinux {
class DF {
static void Main() {
DriveInfo DF = new DriveInfo("c");
Console.WriteLine("Filesystem           1K-blocks      Available Mounted on");
Console.Write(""+DF.DriveFormat+":C           ");
Console.Write(""+DF.TotalSize/1024+"           ");
Console.Write(""+DF.TotalFreeSpace/1024+" ");
Console.Write("/\r\n");
}
}
}
