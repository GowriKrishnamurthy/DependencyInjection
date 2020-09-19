using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IShippingService
    {
        void MailProduct(Product product);
    }
    public class ShippingService: IShippingService
    {
        public void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.RemoveStock(product);
        }
    }
}
