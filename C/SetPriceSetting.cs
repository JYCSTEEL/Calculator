using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class SetPriceSetting : Controls
    {
      

        public TextBox SP_POWDER { get => mainView.SP_POWDER; set => mainView.SP_POWDER = value; }
        public TextBox SP_GOLD { get => mainView.SP_GOLD; set => mainView.SP_GOLD = value; }
        public TextBox SP_BRONZE { get => mainView.SP_BRONZE; set => mainView.SP_BRONZE = value; }
        public TextBox SP_METAL_SHEET { get => mainView.SP_METAL_SHEET; set => mainView.SP_METAL_SHEET = value; }
        public TextBox SP_PLASITC { get => mainView.SP_PLASITC; set => mainView.SP_PLASITC = value; }
        public TextBox SP_GALSS { get => mainView.SP_GALSS; set => mainView.SP_GALSS = value; }
        public TextBox SP_CURVE { get => mainView.SP_CURVE; set => mainView.SP_CURVE = value; }
        public TextBox SP_SWING { get => mainView.SP_SWING; set => mainView.SP_SWING = value; }
        public TextBox SP_CLOSER { get => mainView.SP_CLOSER; set => mainView.SP_CLOSER = value; }
        public TextBox SP_SLIDING { get => mainView.SP_SLIDING; set => mainView.SP_SLIDING = value; }
        public TextBox SP_DOORINDOOR { get => mainView.SP_DOORINDOOR; set => mainView.SP_DOORINDOOR = value; }
        public TextBox SP_SCREEN { get => mainView.SP_SCREEN; set => mainView.SP_SCREEN = value; }
        public TextBox SP_NORMAL_LOCK { get => mainView.SP_NORMAL_LOCK; set => mainView.SP_NORMAL_LOCK = value; }
        public TextBox SP_FINGER_PRINT_LOCK { get => mainView.SP_FINGER_PRINT_LOCK; set => mainView.SP_FINGER_PRINT_LOCK = value; }
        public TextBox SP_CODE_LOCK { get => mainView.SP_CODE_LOCK; set => mainView.SP_CODE_LOCK = value; }

        public Button SP_BTN_UPDATE { get => mainView.SP_BTN_UPDATE; set => mainView.SP_BTN_UPDATE = value; }

        public Button SP_BTN_LOAD { get => mainView.SP_BTN_LOAD; set => mainView.SP_BTN_LOAD = value; }



        private static readonly SetPriceSetting _instance = new SetPriceSetting();

        // 私有构造函数，防止外部实例化
        private SetPriceSetting()
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static SetPriceSetting Instance
        {
            get
            {
                return _instance;
            }
        }


     
    }
}
