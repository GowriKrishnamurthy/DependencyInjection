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
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            // check product stock
            var productStockRepository = new ProductStockRepository();
            if (!productStockRepository.IsInStock(product))
                throw new Exception($"{product} is not in stock");

            // payment
            var paymentService = new PaymentService();
            paymentService.ChargeCreditCard(creditCardNumber, expiryDate);

            //ship the product
            var shippingService = new ShippingService();
            shippingService.MailProduct(product);
        }
    }
}
