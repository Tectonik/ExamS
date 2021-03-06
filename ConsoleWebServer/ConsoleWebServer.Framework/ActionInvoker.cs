﻿namespace ConsoleWebServer.Framework
{
    using System.Linq;
    using System.Reflection;
    using ConsoleWebServer.Framework.Interfaces;

    public class ActionInvoker
    {
        // Hint: Just do not touch this magic :)
        public IResult InvokeAction(Controller c, RequestUriDescriptor ad)
        { /*
         * Child processes that use such C run-time functions as printf() and fprintf() can behave poorly when redirected.
         * The C run-time functions maintain separate IO buffers. When redirected, these buffers might not be flushed immediately after each IO call.
         * As a result, the output to the redirection pipe of a printf() call or the input from a getch() call is not flushed immediately and delays, sometimes-infinite delays occur.
         * This problem is avoided if the child process flushes the IO buffers after each call to a C run-time IO function.
         * Only the child process can flush its C run-time IO buffers. A process can flush its C run-time IO buffers by calling the fflush() function.
         */
            // I'm sorry, but I just can't understand what this horrible contraption does
            MethodInfo methodWithStringParameter = c.GetType()
                                                    .GetMethods()
                                                    .FirstOrDefault(
                                                         x => x.Name.ToLower() == ad.ActionName.ToLower() &&
                                                              x.GetParameters().Length == 1 &&
                                                              x.GetParameters()[0].ParameterType == typeof(string) &&
                                                              x.ReturnType == typeof(IResult));
            if (methodWithStringParameter == null)
            {
                throw new HttpResourceNotFoundException(string.Format("Expected method with signature IActionResult {0}(string) in class {1}Controller", ad.ActionName, ad.ControllerName));
            }

            try
            {
                var actionResult = (IResult)
                methodWithStringParameter.Invoke(c, new object[] { ad.Parameter });
                return actionResult;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}