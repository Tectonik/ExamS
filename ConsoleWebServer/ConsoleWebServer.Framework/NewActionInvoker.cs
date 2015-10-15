namespace ConsoleWebServer.Framework
{
    internal class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            string className = HttpResourceNotFoundException.ClassName;
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}