namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using System.Linq;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public class ApiController : Controller
    {
        public ApiController(HttpRequest request) : base(request)
        {
        }

        public IResult ReturnMe(string param)
        {
            return this.GetResultJson(new { param });
        }

        public IResult GetDateWithCors(string domainName)
        {
            string requestReferer = string.Empty;
            if (this.Request.Headers.ContainsKey("Referer"))
            {
                requestReferer = this.Request.Headers["Referer"].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException("Invalid referer!");
            }

            return new DecoratorResultWithCors(new RequestResultJson(), this.Request, new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = string.Format("Data available for {0}", domainName) }, domainName);
        }
    }
}