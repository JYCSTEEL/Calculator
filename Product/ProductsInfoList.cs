using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{

    public  class ProductsInfoList
    {
        private static readonly ProductsInfoList _instance = new ProductsInfoList();


        private static readonly List<Product> BasicProductsList = new List<Product>();
        private ProductsInfoList()
        {
           
        }

        // 静态属性，用于获取单例实例
        public static ProductsInfoList Instance
        {
            get
            {
                return _instance;
            }
        }

        public static string CountToString
        {
            get => BasicProductsList.Count.ToString();
        }
        public static int Count
        {
            get => BasicProductsList.Count;
        }
        public static int GetProductUnitPrice(Product product)
        {
            return product.UnitPrice;
        }
        public static int GetProductUnitPrice(string material, string type)
        {
            var product = BasicProductsList.FirstOrDefault(p => p.Material == material && p.Type == type);

            if (product != null)
            {
                return product.UnitPrice;
            }
            else
            {
                throw new InvalidOperationException("未找到匹配的产品！");
            }
        }

        public static List<Product> AddProduct(Product product)
        {
            BasicProductsList.Add(product);
            return BasicProductsList;
        }
        public static List<Product> RemoveProduct(Product product)
        {
            BasicProductsList.Remove(product);
            return BasicProductsList;
        }

        public static Product FindProductFirstOneByMaterialAndType(string material, string type)
        {
            
            return BasicProductsList.Find(p => (p.Material == material && p.Type == type));
        }

        public static void AddProductList(List<Product> products)
        {
            foreach (Product product in products)
            {
                BasicProductsList.Add(product);
            }
        
        }
        public static void RemoveProductList(List<Product> products)
        {
            foreach (Product product in products)
            {
                BasicProductsList.Remove(product);
            }
        }
        public static List<Product> GetAllProducts()
        {
            return BasicProductsList;
        }


        public static List<Product> GetAllProductsByMaterial(string material)
        {
            List<Product> products = new List<Product>();
            foreach(Product product in BasicProductsList)
            {
                if (product.Material == material) products.Add(product);
            }
            return products;
        }


    }
}