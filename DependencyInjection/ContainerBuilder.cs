using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection()
                .AddSingleton<IOrderManger, OrderManger>()
                .AddSingleton<IPaymentService, PaymentService>()
                .AddSingleton<IProductStockRepository, ProductStockRepository>()
                .AddSingleton<IShippingService, ShippingService>();

            return container.BuildServiceProvider();
        }
    }
}
