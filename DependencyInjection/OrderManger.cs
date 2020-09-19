using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IOrderManger
    {
        void Submit(Product product, string creditCardNumber, string expiryDate);
    }
    public class OrderManger: IOrderManger
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IPaymentService _paymentService;
        private readonly IShippingService _shippingService;

        public OrderManger(IProductStockRepository productStockRepository,
            IPaymentService paymentService,
            IShippingService shippingService)
        {
            _productStockRepository = productStockRepository;
            _paymentService = paymentService;
            _shippingService = shippingService;
        }
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            // check product stock
            if (!_productStockRepository.IsInStock(product))
                throw new Exception($"{product} is not in stock");

            // payment
            _paymentService.ChargeCreditCard(creditCardNumber, expiryDate);

            //ship the product
            _shippingService.MailProduct(product);
        }
    }
}
