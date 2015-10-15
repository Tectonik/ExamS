using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebServer.Framework.Json
{
    class ResultWithoutCaching : DecoratorJson
    {
        public ResultWithoutCaching(HttpRequest request, object model, string corsSettings)
            : base(request, model)
        {
            this.JsonResult.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", corsSettings));
        }
    }
}
