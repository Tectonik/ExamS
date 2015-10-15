// TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt

namespace ConsoleWebServer.Application
{
    public class EntryPoint
    {
        public static void Main()
        {
            var webServer = new WebServerConsole();
            webServer.ReadCommands();
        }
    }
}