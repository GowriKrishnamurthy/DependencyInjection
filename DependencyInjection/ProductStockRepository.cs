using System.Collections.Generic;

namespace DependencyInjection
{
    public interface IProductStockRepository
    {
        bool IsInStock(Product product);
        void RemoveStock(Product product);
        void AddStock(Product product);
    }
    public class ProductStockRepository:IProductStockRepository
    {
        private static readonly Dictionary<Product, int> _productStockDatabase = Setup();

        private static Dictionary<Product, int> Setup()
        {
            var productStockDatabase = new Dictionary<Product, int>
            {
                {Product.Keyboard, 1}, {Product.Mic, 2}, {Product.Mouse, 3}, {Product.Speaker, 4}
            };
            return productStockDatabase;
        }
        public bool IsInStock(Product product) => _productStockDatabase[product] > 0;
        public void RemoveStock(Product product) => _productStockDatabase[product]--;
        public void AddStock(Product product) => _productStockDatabase[product]++;
    }
}