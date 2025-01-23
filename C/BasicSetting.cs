using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class BasicSetting : Controls
    {
        /// <summary>
        /// 基础设置控件属性
        /// </summary>
        /// 
        public string SelectedMaterial {  get => mainView.SelectedMaterial; set => mainView.SelectedMaterial = value; }
        public bool IsIronSelected { get => mainView.RB_IS_IRON.Checked; set => mainView.RB_IS_IRON.Checked = value; }
        public bool IsStainlessSteelSelected { get => mainView.RB_IS_STAINLESS.Checked; set => mainView.RB_IS_STAINLESS.Checked = value; }
        public string SelectedProductType { get => mainView.CB_PRODUCT_TYPE.Text; set => mainView.CB_PRODUCT_TYPE.Text = value; }
        public decimal SetUpBasicUnitPrice
        {
            get
            {
                // 如果文本框为空或无法解析为整数，返回默认值 0
                if (string.IsNullOrWhiteSpace(mainView.TB_BASIC_PRICE.Text) || !decimal.TryParse(mainView.TB_BASIC_PRICE.Text, out decimal value))
                {
                    return 0; // 默认返回值
                }
                return value;
            }
            set
            {
                // 将值赋给文本框，如果值为负数，可选择处理逻辑
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("单价不能为负数！");
                }
                mainView.TB_BASIC_PRICE.Text = value.ToString();
            }
        }

        public string NewProductType { get => mainView.TB_NEW_PRODUCT_TYPE.Text; set => mainView.TB_NEW_PRODUCT_TYPE.Text= value; }
        public decimal NewProductUnitPrice
        {
            get
            {
                // 如果文本框为空或无法解析为整数，返回默认值 0
                if (string.IsNullOrWhiteSpace(mainView.TB_NEW_PRODUCT_UNIT_PRICE.Text) || !decimal.TryParse(mainView.TB_NEW_PRODUCT_UNIT_PRICE.Text, out decimal value))
                {
                    return 0; // 默认返回值
                }
                return value;
            }
            set
            {
                // 将值赋给文本框，如果值为负数，可选择处理逻辑
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("单价不能为负数！");
                }
                mainView.TB_NEW_PRODUCT_UNIT_PRICE.Text = value.ToString();
            }
        }

        public DataGridView DATAVIEW { get => mainView.MainProductView; set => mainView.MainProductView = value; }
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
        public TextBox TB_BASIC_PRICE { get => mainView.TB_BASIC_PRICE; set => mainView.TB_BASIC_PRICE = value; }

        public TextBox TB_NEW_PRODUCT_TYPE { get => mainView.TB_NEW_PRODUCT_TYPE; set => mainView.TB_NEW_PRODUCT_TYPE = value; }
        public TextBox TB_NEW_PRODUCT_UNIT_PRICE { get => mainView.TB_NEW_PRODUCT_UNIT_PRICE; set => mainView.TB_NEW_PRODUCT_UNIT_PRICE = value; }


        private static readonly BasicSetting _instance = new BasicSetting();

        // 私有构造函数，防止外部实例化
        private BasicSetting()
        {
            // 初始化逻辑（如果需要）
        }

        // 静态属性，用于获取单例实例
        public static BasicSetting Instance
        {
            get
            {
                return _instance;
            }
        }

    
   
    }
}
