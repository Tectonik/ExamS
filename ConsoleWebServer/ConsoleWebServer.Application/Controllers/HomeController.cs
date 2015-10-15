namespace ConsoleWebServer.Application.Controllers
{
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.Interfaces;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public IResult Index(string param)
        {
            return this.GetResultContent("Home page :)");
        }

        public IResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, "Live page with no caching");
        }

        public IResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, "Live page with no caching and CORS", "*");
        }
    }
}