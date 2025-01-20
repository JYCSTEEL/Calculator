using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    // 抽象类表示产品的共性
    public  class CustomizedProduct:Product
    {
     
        public ProductProperty Property = new ProductProperty();
     
        public CustomizedProduct() { 


        }

    }



}
