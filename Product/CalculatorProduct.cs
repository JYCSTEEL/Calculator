using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    // 抽象类表示产品的共性
    public  class CalculatorProduct: CustomizedProduct
    {
        public int SinglePrice { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }

        public int DesignQty { get; set; }

        public int WidthOrLength { get; set; }
        public int HeightOrDeepth { get; set; }

        public int WidthOrLengthFeet { get; set; }
        public int HeightOrDeepthFeet { get; set; }

        public int Sqft { get; set; }
        public CalculatorProduct() { 


        }

    }



}
