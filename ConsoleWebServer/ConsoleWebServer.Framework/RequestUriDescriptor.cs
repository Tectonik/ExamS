namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;

    public class RequestUriDescriptor
    {
        public RequestUriDescriptor(string uri)
        {
            uri = uri ?? string.Empty;

            string[] uriParts = uri.Split(new char[] { '/' }, StringSplitOptions.None);

            this.ControllerName = uriParts.Length > 0 ? uriParts[0] : "Home";
            this.ActionName = uriParts.Length > 1 ? uriParts[1] : "Index";
            this.Parameter = uriParts.Length > 2 ? uriParts[2] : "Param";
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public string Parameter { get; private set; }

        public override string ToString()
        {
            return string.Format("/{0}/{1}/{2}", this.ControllerName, this.ActionName, this.Parameter);
        }
    }
}