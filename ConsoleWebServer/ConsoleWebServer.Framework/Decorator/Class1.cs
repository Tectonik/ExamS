using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebServer.Framework.Decorator
{
    internal abstract class Decorator : JsonResult
    {
        protected Decorator(JsonResult jsonResult)
        {
            this.JsonResult = jsonResult;
        }

        protected JsonResult JsonResult { get; private set; }


    }
}
