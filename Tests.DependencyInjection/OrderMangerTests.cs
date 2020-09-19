using System;
using System.Runtime.InteropServices;
using DependencyInjection;
using Moq;
using Xunit;

namespace Tests.DependencyInjection
{
    public class OrderMangerTests
    {
        [Fact]
        public void ProductNotInStock()
        {
            var productStockRepositoryMock = new Mock<IProductStockRepository>();
            productStockRepositoryMock.Setup(m=>m.IsInStock(It.IsAny<Product>())).Returns(false);

            var paymentServiceMock = new Mock<PaymentService>();
            var shippingServiceMock = new Mock<IShippingService>();

            var orderManger = new OrderManger(productStockRepositoryMock.Object, paymentServiceMock.Object,shippingServiceMock.Object);
            Assert.ThrowsAny<Exception>(() => orderManger.Submit(Product.Keyboard, "1000200030004000", "0124"));
        }
    }
}
