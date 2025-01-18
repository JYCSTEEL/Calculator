﻿using System;
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
        public int UnitPrice { get; set; } // 单价
        public decimal Sqft { get; set; } // 尺寸

      
        public string Color { get; set; } //颜色

        public int Height { get; set; }
        public int Width { get; set; }

        public int Qty { get; set; }

        public int TotalPrice { get; set; }


    }



}
