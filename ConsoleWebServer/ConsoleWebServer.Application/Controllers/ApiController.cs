using System;
using System.Linq;

public class ApiController : Controller
{
    public ApiController(HttpRq request) : base(request)
    {
    }

    public IActionResult ReturnMe(string param)
    {
        return this.Json(new { param });
    }

    public IActionResult GetDateWithCors(string domainName)
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
        return new JsonActionResultWithCors(
            this.Request,
            new { date = DateTime.Now.ToString("yyyy-MM-dd"), moreInfo = string.Format("Data available for {0}", domainName) },
            domainName);
    }
}