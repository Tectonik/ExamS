namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    public class ResponseProvider
    {
        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            var temp = requestAsString.Split(' ');
            try
            {
                HttpRequest requestParser = new HttpRequest(temp[0], temp[1], temp[2]);
                request = requestParser.Parse(requestAsString, new HttpRequest(null, null, null));
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            HttpResponse response = this.Process(request);
            return response;
        }

        private HttpResponse Process(HttpRequest request)
        {
            if (request.Method.ToLower() == "options")
            {
                List<string> routes = Assembly.GetEntryAssembly()
                                              .GetTypes()
                                              .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                                              .Select(
                                                   x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IResult)) })
                                              .SelectMany(
                                                   x => x.Methods.Select(
                                                       m => string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace("Controller", string.Empty), m.Name)))
                                              .ToList();

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }
            else if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    Controller controller = this.CreateController(request);
                    var actionInvoker = new ActionInvoker();
                    IResult actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpResourceNotFoundException exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                return response;
            }
            else
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            string controllerClassName = string.Format("{0}Controller", request.Action.ControllerName);
            Type type = Assembly.GetEntryAssembly()
                                .GetTypes()
                                .FirstOrDefault(
                                     x => x.Name.ToLower() == controllerClassName.ToLower() &&
                                          typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpResourceNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}