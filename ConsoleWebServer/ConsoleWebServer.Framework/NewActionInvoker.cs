namespace ConsoleWebServer.Framework
{
    internal class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            string className = HttpNotFound.ClassName;
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}