using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{

    public static class ProductsInfo
    {

        private static List<Product> ProductsList;
        static ProductsInfo()
        {
            ProductsList = new List<Product>();
        }
        public static List<Product> AddProduct(Product product)
        {
            ProductsList.Add(product);
            return ProductsList;
        }
        public static List<Product> RemoveProduct(Product product)
        {
            ProductsList.Remove(product);
            return ProductsList;
        }
        public static Product FindProduct(string material, string type)
        {
            return ProductsList.Find(p => (p.Material == material && p.Type == type));
        }

        public static List<Product> GetAllProducts()
        {
            return ProductsList;
        }
    }
}