using Castle.DynamicProxy;
using System;
using System.IO;

namespace AOP
{
    public class Logger : IInterceptor
    {
        TextWriter writer;

        public Logger(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            writer.WriteLine($"Calling: {invocation.Method.DeclaringType}.{invocation.Method.Name}");
            writer.WriteLine($"Args: {string.Join(", ", invocation.Arguments)}");

            invocation.Proceed(); //Intercepted method is executed here.            

            writer.WriteLine($"Done: result was {invocation.ReturnValue}");
            writer.WriteLine();
        }
    }
}
