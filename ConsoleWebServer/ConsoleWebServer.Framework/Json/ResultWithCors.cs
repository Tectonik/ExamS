namespace ConsoleWebServer.Framework.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ResultWithCors : DecoratorJson
    {
        public ResultWithCors(HttpRequest r, object model)
            : base(r, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}
