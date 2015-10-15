namespace ConsoleWebServer.Application
{
    using System.Text;
    using ConsoleWebServer.Framework;

    public class EntryPoint
    {
        public static void Main()
        {
            var webServer = new WebServerConsole(new ResponseProvider());
            webServer.ReadCommands(new StringBuilder());
        }
    }
}