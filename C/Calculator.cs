using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class Calculator:Controls
    {
        /// <summary>
        /// 基础设置控件属性
        /// </summary>
        /// 
        public ComboBox CC_MATERIAL { get => mainView.CC_MATERIAL; set => mainView.CC_MATERIAL = value; }
        public ComboBox CC_TYPE { get => mainView.CC_TYPE; set => mainView.CC_TYPE = value; }

        public ComboBox PRODUCT_NAME { get => mainView.CC_PRODUCT_NAME; set => mainView.CC_PRODUCT_NAME = value; }
     


        public TextBox UNIT_PRICE { get => mainView.CC_UNIT_PRICE; set => mainView.CC_UNIT_PRICE = value; }

        public DataGridView DATAVIEW { get => mainView.CC_DATA_VIEW; set => mainView.CC_DATA_VIEW = value; }

        public Button BTN_UPDATE { get => mainView.CC_BTN_UPDATE; }
        public Button BTN_DELETE { get => mainView.CC_BTN_DELETE; }

        public Button BTN_ADD { get => mainView.CC_BTN_ADD; }

        public CheckBox DOORINDOOR { get => mainView.CC_DOORINDOOR; set => mainView.CC_DOORINDOOR = value; }
        public CheckBox SCREEN { get => mainView.CC_SCREEN; set => mainView.CC_SCREEN = value; }
        public CheckBox POWDER { get => mainView.CC_POWDER; set => mainView.CC_POWDER = value; }
        public CheckBox GOLD { get => mainView.CC_GOLD; set => mainView.CC_GOLD = value; }
        public CheckBox BRONZE { get => mainView.CC_BRONZE; set => mainView.CC_BRONZE = value; }
        public CheckBox METALSHEET { get => mainView.CC_METAL_SHEET; set => mainView.CC_METAL_SHEET = value; }
        public CheckBox PLASTIC { get => mainView.CC_PLASTIC; set => mainView.CC_PLASTIC = value; }
        public CheckBox GLASS { get => mainView.CC_GLASS; set => mainView.CC_GLASS = value; }
        public CheckBox CURVED { get => mainView.CC_CURVED; set => mainView.CC_CURVED = value; }
        public CheckBox POLE { get => mainView.CC_HASPOLE; set => mainView.CC_HASPOLE = value; }
        public TextBox POLE_PRICE { get => mainView.CC_POLE_PRICE; set => mainView.CC_POLE_PRICE = value; }
        public TextBox POLE_QTY { get => mainView.CC_POLE_QTY; set => mainView.CC_POLE_QTY = value; }
        public CheckBox HASLOCK { get => mainView.CC_HASLOCK; set => mainView.CC_HASLOCK = value; }
        public CheckBox NORMAL_LOCK { get => mainView.CC_NORMAL_LOCK; set => mainView.CC_NORMAL_LOCK = value; }
        public CheckBox FINGER_LOCK { get => mainView.CC_FINGER_PRINT; set => mainView.CC_FINGER_PRINT = value; }
        public CheckBox CODE_LOCK { get => mainView.CC_CODE_LOCK; set => mainView.CC_CODE_LOCK = value; }

        public CheckBox AUTO_SWING { get => mainView.CC_AUTO_SWING; set => mainView.CC_AUTO_SWING = value; }
        public CheckBox AUTO_SLIDING { get => mainView.CC_AUTO_SLIDING; set => mainView.CC_AUTO_SLIDING = value; }

        public CheckBox HASCLOSER { get => mainView.CC_CLOSER; set => mainView.CC_CLOSER = value; }


        public TextBox DESIGN_PRICE { get => mainView.CC_DESIGN_PRICE; set => mainView.CC_DESIGN_PRICE = value; }
        public TextBox DESIGN_QTY { get => mainView.CC_DESIGN_QTY; set => mainView.CC_DESIGN_QTY = value; }

        public TextBox ALL_TOTAL_PRICE { get => mainView.CC_ALL_TOTAL_PRICE; set => mainView.CC_ALL_TOTAL_PRICE = value; }

        public TextBox SINGLE_PRICE { get => mainView.CC_SINGLE_PRICE; set => mainView.CC_SINGLE_PRICE = value; }

        public TextBox PRODUCT_QTY { get => mainView.CC_PRODUCT_QTY; set => mainView.CC_PRODUCT_QTY = value; }

        public TextBox TOTAL_PRICE { get => mainView.CC_TOTAL_PRICE; set => mainView.CC_TOTAL_PRICE = value; }


        public TextBox WIDE_LENGTH { get => mainView.CC_WIDTH_LENGTH; set => mainView.CC_WIDTH_LENGTH = value; }

        public TextBox HEIGHT_DEEPTH { get => mainView.CC_HEIGHT_DEEPTH; set => mainView.CC_HEIGHT_DEEPTH = value; }

        public TextBox WIDE_LENGTH_FEET { get => mainView.CC_WIDTH_LENGTH_FEET; set => mainView.CC_WIDTH_LENGTH_FEET = value; }

        public TextBox HEIGHT_DEEPTH_FEET { get => mainView.CC_HEIGHT_DEEPTH_FEET; set => mainView.CC_HEIGHT_DEEPTH_FEET = value; }
        public TextBox SQFT { get => mainView.CC_SQFT; set => mainView.CC_SQFT = value; }


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


    }

}
