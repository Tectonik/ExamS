namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
        }

        public HttpRequest Request { get; private set; }

        protected IResult Content(object model)
        {
            return new ContentActionResult(this.Request, model);
        }

        protected IResult Json(object model)
        {
            return new JsonResult(this.Request, model);
        }
    }
}