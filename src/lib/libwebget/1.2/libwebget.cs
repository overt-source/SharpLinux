using System;
using System.Net;
namespace cmdlinux {
class WebFetcher {
static void Main(string[] args) {
// CMDLinux Web Fetcher library
// Written in C# for ease of coding reasons
// call as /lib/dl.exe url destination.
// dl *will* do it's own error handling and vomit with an error code in %errorlevel% if something dies.

WebClient myWebClient = new WebClient();

try {
myWebClient.DownloadFile(args[0], args[1]);
}
catch(Exception EX) {
if(EX.Message=="The remote server returned an error: (404) Not Found.") {

System.Environment.Exit(404);
}

System.Environment.Exit(5);
}
}
}
}
