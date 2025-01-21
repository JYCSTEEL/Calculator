using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    // 抽象类表示产品的共性
    public  class Product
    {
        public string Material { get; set; }
        public string Type { get; set; } // 产品名称
        public decimal UnitPrice { get; set; } // 单价

        public Product() { 


        }

    }



}
