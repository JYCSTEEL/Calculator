using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    public class CalculatorPresenter
    {
        // 静态字段，存储单例实例
        private static readonly CalculatorPresenter _instance = new CalculatorPresenter(Calculator.Instance);

        // 私有构造函数，防止外部实例化
        private CalculatorPresenter(Calculator calculator)
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static CalculatorPresenter Instance
        {
            get
            {
                return _instance;
            }
        }

        // 示例方法：计算产品价格
        //public int CalculateTotalPrice(Product product)
        //{
        //    int price = 0;

        //    price = product.UnitPrice * product.Sqft;

        //    return price;

        //}
        //public int CalculateTotalPrice(List<Product> products)
        //{
        //    int totalPrice = 0;

        //    foreach (var product in products)
        //    {
        //        totalPrice += product.UnitPrice * product.Sqft;
        //    }

        //    return totalPrice;
        //}
        //public int CalculateTotalPrice(params Product[] products)
        //{
        //    int totalPrice = 0;

        //    foreach (var product in products)
        //    {
        //        totalPrice += product.UnitPrice * product.Sqft;
        //    }

        //    return totalPrice;
        //}
    }
}
