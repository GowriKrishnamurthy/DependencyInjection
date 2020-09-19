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
        private readonly IProductStockRepository _productStockRepository;

        public ShippingService(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }
        public void MailProduct(Product product)
        {
            _productStockRepository.RemoveStock(product);
        }
    }
}
