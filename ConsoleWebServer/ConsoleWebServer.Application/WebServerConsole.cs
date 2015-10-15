namespace ConsoleWebServer.Application
{
    using System;
    using System.Linq;
    using System.Text;
    using ConsoleWebServer.Framework;

    public class WebServerConsole
    {
        private readonly ResponseProvider responseProvider;

        public WebServerConsole(ResponseProvider responseProvider)
        {
            this.responseProvider = responseProvider;
        }

        public void ReadCommands(StringBuilder requestBuilder)
        {
            string inputLine = "start";
            while (inputLine != null)
            {
                inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    this.ExecuteCommand(requestBuilder.ToString());
                    requestBuilder.Clear();
                }
                else
                {
                    requestBuilder.AppendLine(inputLine);
                }
            }
        }

        private void ExecuteCommand(string request)
        {
            HttpResponse response = this.responseProvider.GetResponse(request);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(response);
            Console.ResetColor();
        }
    }
}