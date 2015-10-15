namespace ConsoleWebServer.Framework
{
    internal class NewActionInvoker
    {
        public IResult InvokeAction(Controller controller, RequestComponentDescriptor actionDescriptor)
        {
            string className = HttpResourceNotFoundException.ClassName;
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}