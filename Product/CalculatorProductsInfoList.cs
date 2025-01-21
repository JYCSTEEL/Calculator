using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{

    public  class CalculatorProductsInfoList
    {
        private static readonly CalculatorProductsInfoList _instance = new CalculatorProductsInfoList();
        private static readonly List<CalculatorProduct> CalculatorProductsList = new List<CalculatorProduct>();
        private static  CalculatorProduct lastAddedProduct = new CalculatorProduct();

        private CalculatorProductsInfoList()
        {
           
        }

        // 静态属性，用于获取单例实例
        public static CalculatorProductsInfoList Instance
        {
            get
            {
                return _instance;
            }
        }


        public static List<CalculatorProduct> GetAllCalculatorProducts()
        {
            return CalculatorProductsList;
        }

        public static CalculatorProduct GetLastAddedProduct( )
        {
            return lastAddedProduct;
        }
        public static List<CalculatorProduct> AddProduct(CalculatorProduct product)
        {
            CalculatorProductsList.Add(product);
            lastAddedProduct = product;
            return CalculatorProductsList;
        }
        public static List<CalculatorProduct> RemoveProduct(CalculatorProduct product)
        {
            CalculatorProductsList.Remove(product);
            return CalculatorProductsList;
        }

        public static CalculatorProduct FindProductFirstOneByMaterialAndTypeAndName(string material, string type,string name)
        {
           
            return CalculatorProductsList.Find(p => (p.Material == material && p.Type == type && p.Property.ProductName == name));
        }

        public static void AddProductList(List<CalculatorProduct> products)
        {
            foreach (CalculatorProduct product in products)
            {
                CalculatorProductsList.Add(product);
            }
        
        }
        public static void RemoveProductList(List<CalculatorProduct> products)
        {
            foreach (CalculatorProduct product in products)
            {
                CalculatorProductsList.Remove(product);
            }
        }
        public static List<CalculatorProduct> GetAllBasicProducts()
        {
            return CalculatorProductsList;
        }
        public static List<CalculatorProduct> GetAllCustomizedProducts()
        {
            return CalculatorProductsList;
        }

        public static List<CalculatorProduct> GetAllProductsByMaterial(string material)
        {
            List<CalculatorProduct> products = new List<CalculatorProduct>();
            foreach(CalculatorProduct product in CalculatorProductsList)
            {
                if (product.Material == material) products.Add(product);
            }
            return products;
        }
        public static List<CalculatorProduct> GetAllProductsByMaterialAndType(string material,string type)
        {
            List<CalculatorProduct> products = new List<CalculatorProduct>();
            foreach (CalculatorProduct product in CalculatorProductsList)
            {
                if (product.Material == material&&product.Type==type) products.Add(product);
            }
            return products;
        }


    }
}