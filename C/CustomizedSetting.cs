using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class CustomizedSetting : Controls
    {
        /// <summary>
        /// 基础设置控件属性
        /// </summary>
        /// 
        public ComboBox MATERIAL { get => mainView.CP_MATERIAL; set => mainView.CP_MATERIAL = value; }
        public ComboBox TYPE { get => mainView.CP_TYPE; set => mainView.CP_TYPE = value; }

        public CheckedListBox CheckListBoxCustomized { get => mainView.ChecklistBoxCustomized; set => mainView.ChecklistBoxCustomized = value; }


        public CheckBox CP_SELECT_ALL { get => mainView.SelectAllCustomized; set => mainView.SelectAllCustomized = value; }

        public DataGridView DATAVIEW { get => mainView.CP_DATA_VIEW; set => mainView.CP_DATA_VIEW = value; }
    
        public ComboBox CB_NAME { get => mainView.CP_CB_NAME; set => mainView.CP_CB_NAME = value; }
        public TextBox TX_NAME { get => mainView.CP_NEW_NAME; set => mainView.CP_NEW_NAME = value; }
        public Button BTN_UPDATE { get => mainView.CP_BTN_UPDATE; }
        public Button BTN_DELETE { get => mainView.CP_BTN_DELETE; }

        public Button BTN_ADD { get => mainView.CP_BTN_ADD; }

        public CheckBox DOORINDOOR { get => mainView.CP_DOORINDOOR; set => mainView.CP_DOORINDOOR = value; }
        public CheckBox SCREEN { get => mainView.CP_SCREEN; set => mainView.CP_SCREEN = value; }
        public CheckBox POWDER { get => mainView.CP_POWDER; set => mainView.CP_POWDER = value; }
        public CheckBox GOLD { get => mainView.CP_GOLD; set => mainView.CP_GOLD = value; }
        public CheckBox BRONZE { get => mainView.CP_BRONZE; set => mainView.CP_BRONZE = value; }
        public CheckBox METALSHEET { get => mainView.CP_METAL_SHEET; set => mainView.CP_METAL_SHEET = value; }
        public CheckBox PLASTIC { get => mainView.CP_PLASTIC; set => mainView.CP_PLASTIC = value; }
        public CheckBox GLASS { get => mainView.CP_GLASS; set => mainView.CP_GLASS = value; }
        public CheckBox CURVED { get => mainView.CP_CURVED; set => mainView.CP_CURVED = value; }
        public CheckBox POLE { get => mainView.CP_HASPOLE; set => mainView.CP_HASPOLE = value; }
        public TextBox POLE_PRICE { get => mainView.CP_POLE_PRICE; set => mainView.CP_POLE_PRICE = value; }
        public TextBox POLE_QTY { get => mainView.CP_POLE_QTY; set => mainView.CP_POLE_QTY = value; }
        public CheckBox HASLOCK { get => mainView.CP_HASLOCK; set => mainView.CP_HASLOCK = value; }
        public CheckBox NORMAL_LOCK { get => mainView.CP_NORMAL_LOCK; set => mainView.CP_NORMAL_LOCK = value; }
        public CheckBox FINGER_LOCK { get => mainView.CP_FINGER_PRINT; set => mainView.CP_FINGER_PRINT = value; }
        public CheckBox CODE_LOCK { get => mainView.CP_CODE_LOCK; set => mainView.CP_CODE_LOCK = value; }

        public CheckBox AUTO_SWING { get => mainView.CP_AUTO_SWING; set => mainView.CP_AUTO_SWING = value; }
        public CheckBox AUTO_SLIDING { get => mainView.CP_AUTO_SLIDING; set => mainView.CP_AUTO_SLIDING = value; }

        public CheckBox HASCLOSER { get => mainView.CP_CLOSER; set => mainView.CP_CLOSER = value; }


        public TextBox DESIGN_PRICE { get => mainView.CP_DESIGN_PRICE; set => mainView.CP_DESIGN_PRICE = value; }




        private static readonly CustomizedSetting _instance = new CustomizedSetting();

        // 私有构造函数，防止外部实例化
        private CustomizedSetting()
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static CustomizedSetting Instance
        {
            get
            {
                return _instance;
            }
        }


     
    }
}
