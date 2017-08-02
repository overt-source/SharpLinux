using System;
namespace cmdlinux {
class WhoAmI {
static void Main() {
Console.WriteLine(Environment.GetEnvironmentVariable("username.sl"));
}
}
}
