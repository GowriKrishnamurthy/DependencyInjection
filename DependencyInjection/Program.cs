using System;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();

        public static void Main(string[] args)
        {
            var product = string.Empty; 
            var orderManger = Container.GetService<IOrderManger>();
            
            while (product != "exit")
            {
                Console.WriteLine(@"Enter product:
                Keyboard = 0,
                Mouse = 1,
                Mic  = 2,
                Speaker = 3");
                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method: XXXXXXXXXXXXXXXXXXXX;MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(';').Length != 2)
                            throw new Exception("Invalid payment method");

                        orderManger.Submit(productEnum,
                            paymentMethod.Split(";")[0],
                            paymentMethod.Split(";")[1]
                        );
                        Console.WriteLine($"{productEnum.ToString()} Product has been shipped successfully");
                    }
                    else
                        Console.WriteLine("Invalid product");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine("Hello World!");
        }
    }
}