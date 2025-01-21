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
        public decimal SinglePrice { get; set; }
        public decimal Qty { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal DesignQty { get; set; }

        public decimal WidthOrLength { get; set; }
        public decimal HeightOrDeepth { get; set; }

        public decimal WidthOrLengthFeet { get; set; }
        public decimal HeightOrDeepthFeet { get; set; }

        public decimal Sqft { get; set; }
        public CalculatorProduct() { 


        }

    }



}
