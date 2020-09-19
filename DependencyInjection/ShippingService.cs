using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class ShippingService
    {
        public void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.RemoveStock(product);
        }
    }
}
