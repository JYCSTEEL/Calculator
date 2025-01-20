using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{

    public  class CustomizedProductsInfoList
    {
        private static readonly CustomizedProductsInfoList _instance = new CustomizedProductsInfoList();
        private static readonly List<CustomizedProduct> CustomizedProductsList = new List<CustomizedProduct>();
        private CustomizedProductsInfoList()
        {
           
        }

        // 静态属性，用于获取单例实例
        public static CustomizedProductsInfoList Instance
        {
            get
            {
                return _instance;
            }
        }

        public static List<CustomizedProduct> AddProduct(CustomizedProduct product)
        {
            CustomizedProductsList.Add(product);
            return CustomizedProductsList;
        }
        public static List<CustomizedProduct> RemoveProduct(CustomizedProduct product)
        {
            CustomizedProductsList.Remove(product);
            return CustomizedProductsList;
        }

        public static CustomizedProduct FindProductFirstOneByMaterialAndTypeAndName(string material, string type,string name)
        {
           
            return CustomizedProductsList.Find(p => (p.Material == material && p.Type == type && p.Property.ProductName == name));
        }

        public static void AddProductList(List<CustomizedProduct> products)
        {
            foreach (CustomizedProduct product in products)
            {
                CustomizedProductsList.Add(product);
            }
        
        }
        public static void RemoveProductList(List<CustomizedProduct> products)
        {
            foreach (CustomizedProduct product in products)
            {
                CustomizedProductsList.Remove(product);
            }
        }
        public static List<CustomizedProduct> GetAllBasicProducts()
        {
            return CustomizedProductsList;
        }
        public static List<CustomizedProduct> GetAllCustomizedProducts()
        {
            return CustomizedProductsList;
        }

        public static List<CustomizedProduct> GetAllProductsByMaterial(string material)
        {
            List<CustomizedProduct> products = new List<CustomizedProduct>();
            foreach(CustomizedProduct product in CustomizedProductsList)
            {
                if (product.Material == material) products.Add(product);
            }
            return products;
        }
        public static List<CustomizedProduct> GetAllProductsByMaterialAndType(string material,string type)
        {
            List<CustomizedProduct> products = new List<CustomizedProduct>();
            foreach (CustomizedProduct product in CustomizedProductsList)
            {
                if (product.Material == material&&product.Type==type) products.Add(product);
            }
            return products;
        }


    }
}