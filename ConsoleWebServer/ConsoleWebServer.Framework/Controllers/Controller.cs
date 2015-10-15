namespace ConsoleWebServer.Framework
{
    using System;
    using ConsoleWebServer.Framework.Interfaces;
    using ConsoleWebServer.Framework.RequestResult;

    public abstract class Controller 
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
        }

        public HttpRequest Request { get; private set; }

        protected IResult GetResultContent(object model)
        {
            return new RequestResultContent(this.Request, model);
        }

        protected IResult GetResultJson(object model)
        {
            return new JsonResultBasic(this.Request, model);
        }
    }
}