using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class BasicSetUp : Controls
    {
        /// <summary>
        /// 基础设置控件属性
        /// </summary>
        public bool IsIronSelected { get => mainView.IsIronSelected; set => mainView.IsIronSelected = value; }
        public bool IsStainlessSteelSelected { get => mainView.IsStainlessSteelSelected; set => mainView.IsStainlessSteelSelected = value; }
        public string SelectedProductType { get => mainView.SelectedProductType; set => mainView.SelectedProductType = value; }
        public int SetUpBasicUnitPrice { get => mainView.SetUpBasicUnitPrice; set => mainView.SetUpBasicUnitPrice = value; }

        public int NewProductType { get => mainView.NewProductType; set => mainView.NewProductType = value; }
        public int NewProductUnitPrice { get => mainView.NewProductUnitPrice; set => mainView.NewProductUnitPrice = value; }
        /// <summary>
        /// 基础设置按钮
        /// </summary>
        public Button BTN_UPDATE_UNIT_PRICE { get => mainView.BTN_UPDATE_UNIT_PRICE; }
        public Button BTN_DELETE_PRODUCT_TYPE { get => mainView.BTN_DELETE_PRODUCT_TYPE; }

        public Button BTN_NEW_PRODUCT_TYPE { get => mainView.BTN_NEW_PRODUCT_TYPE; }

        public RadioButton RB_IS_IRON { get => mainView.RB_IS_IRON; set => mainView.RB_IS_IRON = value; }
        public RadioButton RB_IS_STAINLESS { get => mainView.RB_IS_STAINLESS; set => mainView.RB_IS_STAINLESS = value; }

        /// <summary>
        /// 下拉框
        /// </summary>

        public ComboBox CB_PRODUCT_TYPE { get => mainView.CB_PRODUCT_TYPE; set => mainView.CB_PRODUCT_TYPE = value; }

        /// <summary>
        /// 文本框
        /// </summary>
        public TextBox TB_BASIC_UNIT_PRICE { get => mainView.TB_BASIC_UNIT_PRICE; set => mainView.TB_BASIC_UNIT_PRICE = value; }

        public TextBox TB_NEW_PRODUCT_TYPE { get => mainView.TB_NEW_PRODUCT_TYPE; set => mainView.TB_NEW_PRODUCT_TYPE = value; }
        public TextBox TB_NEW_PRODUCT_UNIT_PRICE { get => mainView.TB_NEW_PRODUCT_UNIT_PRICE; set => mainView.TB_NEW_PRODUCT_UNIT_PRICE = value; }


        private static readonly BasicSetUp _instance = new BasicSetUp();

        // 私有构造函数，防止外部实例化
        private BasicSetUp()
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static BasicSetUp Instance
        {
            get
            {
                return _instance;
            }
        }

   
    }
}
