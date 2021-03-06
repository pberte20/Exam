using System.Collections.Generic;
using StregSystem.Model.Products;

namespace StregSystem.Model.DataLoaders
{

    public class ProductLoader : IDataLoader<Product>
    {
        public List<Product> LoadData(IEnumerable<string> lines)
        {
            var products = new List<Product>();
            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                string name = parts[1];
                string PriceString = parts[2];
                string ActiveString = parts[3];
                bool IsActive;
                if (ActiveString == "0")
                {
                     IsActive = false;
                }
                else
                {
                    IsActive = true;
                }
                var product = new Product(name, decimal.Parse(PriceString)/100, IsActive);
                products.Add(product);
            }
            return products;
        }
    }
}