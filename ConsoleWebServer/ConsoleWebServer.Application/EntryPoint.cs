using ConsoleWebServer.Framework;
namespace ConsoleWebServer.Application
{
    public class EntryPoint
    {
        public static void Main()
        {
            var webServer = new WebServerConsole(new ResponseProvider());
            webServer.ReadCommands();
        }
    }
}