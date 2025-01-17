using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    public class Calculator
    {
        // 静态字段，存储单例实例
        private static readonly Calculator _instance = new Calculator();

        // 私有构造函数，防止外部实例化
        private Calculator()
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static Calculator Instance
        {
            get
            {
                return _instance;
            }
        }

        // 示例方法：计算产品价格
        public decimal CalculateTotalPrice(Product product)
        {
            decimal price = 0;

            price = product.UnitPrice * product.Sqft;

            return price;
           
        }
        public decimal CalculateTotalPrice(List<Product> products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Sqft;
            }

            return totalPrice;
        }
        public decimal CalculateTotalPrice(params Product[] products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Sqft;
            }

            return totalPrice;
        }

    }

}
