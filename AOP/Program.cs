using Autofac;
using Autofac.Extras.DynamicProxy;
using System;

namespace AOP
{
    public class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Do some maths calculations:");

            // register the components
            var builder = new ContainerBuilder();
            builder.Register(i => new Logger(Console.Out));
            builder.RegisterType<Calculator>().As<ICalculator>().EnableInterfaceInterceptors().InterceptedBy(typeof(Logger));
            Container = builder.Build();
            CalcAdd();            
            CalcSubstract();
        }

        public static void CalcAdd()
        {
            // Create the scope, resolve ICalculator and execute Add method for calculation
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ICalculator>();
                calc.Add(4, 6);
                calc.Add(2, 4);
                calc.Add(6, 9);
                calc.Add(9, 22);
                calc.Add(13, 23);
                Console.WriteLine("Addition calculations complete.");
                Console.WriteLine();
            }
        }

        public static void CalcSubstract()
        {
            // Create the scope, resolve ICalculator and execute Add method for calculation
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ICalculator>();
                calc.Substract(7, 5);
                calc.Substract(6, 9);
                calc.Substract(3, 7);
                calc.Substract(23, 12);
                calc.Substract(14, 35);
                Console.WriteLine("Substraction calculations complete.");
                Console.WriteLine();
            }
        }
    }
}
