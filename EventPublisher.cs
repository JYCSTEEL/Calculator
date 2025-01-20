using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计价器
{
    // 定义委托类型
    public delegate void ProductListChangedEventHandler( );

    // 定义包含事件的类
    public static class EventPublisher
    {
        // 声明事件
        public static event ProductListChangedEventHandler OnProductListChangedEvent;

        // 方法触发事件
        public static void RaiseEvent( )
        {
            // 检查是否有订阅者
            if (OnProductListChangedEvent != null)
            {
                OnProductListChangedEvent(); // 触发事件，调用订阅者的方法
            }
        }

        public static void AddProductListChangeEvent(ProductListChangedEventHandler action )
        {
            OnProductListChangedEvent += action;
        }
    }



   

}
