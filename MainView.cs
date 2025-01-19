using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public partial class MainView : Form
    {

        /// <summary>
        /// 控件
        /// </summary>
        /// 

        public DataGridView MainProductView {  get=> dataGridViewProducts; set=> dataGridViewProducts =value; }  
        public TabControl MaintabControl { get => tabControl; }
        public TabPage TabpageCalculator { get => tabPageCalculate; }
        public TabPage TabpageBasicSetUp { get => tabPageSetting; }

        public string SelectedMaterial { get; set; }
        public string ProductType { get => comboBoxProductName.Text; set => comboBoxProductName.Text = value; }
        public int UnitPrice { get => Convert.ToInt32(textBoxUnitPrice.Text); set => textBoxUnitPrice.Text = value.ToString(); }
        public int LengthWidthInch { get => Convert.ToInt32(textBoxLengthWidth.Text); set => textBoxLengthWidth.Text = value.ToString(); }
        public int LengthWidthFeet { get => Convert.ToInt32(textBoxLengthWidthFeet.Text); set => textBoxLengthWidthFeet.Text = value.ToString(); }
        public int HeightDeepthInch { get => Convert.ToInt32(textBoxHeightDeepth.Text); set => textBoxHeightDeepth.Text = value.ToString(); }
        public int HeightDeepthFeet { get => Convert.ToInt32(textBoxHeightDeepthFeet.Text); set => textBoxHeightDeepthFeet.Text = value.ToString(); }
        public int Sqft { get => Convert.ToInt32(textBoxSqft.Text); set => textBoxSqft.Text = value.ToString(); }
        public int PoleQty { get => Convert.ToInt32(textBoxPoleQty.Text); set => textBoxPoleQty.Text = value.ToString(); }
        public int DesignUnitPrice { get => Convert.ToInt32(textBoxDesignUnitPrice.Text); set => textBoxDesignUnitPrice.Text = value.ToString(); }
        public int PredictDesignQty { get => Convert.ToInt32(textBoxPredictQtyOfDesign.Text); set => textBoxPredictQtyOfDesign.Text = value.ToString(); }
        public bool HasPole { get => checkBoxPole.Checked; set => checkBoxPole.Checked = value; }
        public bool IsPowderCoating { get => checkBoxPowderCoating.Checked; set => checkBoxPowderCoating.Checked = value; }
        public bool IsBronze { get => checkBoxBronze.Checked; set => checkBoxBronze.Checked = value; }
        public bool IsGold { get => checkBoxGold.Checked; set => checkBoxGold.Checked = value; }
        public bool HasGlass { get => checkBoxGlass.Checked; set => checkBoxGlass.Checked = value; }
        public bool HasScreen { get => checkBoxScreen.Checked; set => checkBoxPole.Checked = value; }
        public bool HasPlastic { get => checkBoxPlastic.Checked; set => checkBoxPlastic.Checked = value; }
        public bool HasMetalSheet { get => checkBoxMetalSheet.Checked; set => checkBoxMetalSheet.Checked = value; }
        public bool HasCurve { get => checkBoxCurve.Checked; set => checkBoxCurve.Checked = value; }
        public bool HasCloser { get => checkBoxCloser.Checked; set => checkBoxCloser.Checked = value; }

        public bool HasLock { get => checkBoxHasLock.Checked; set => checkBoxHasLock.Checked = value; }
        public bool IsNormalLock { get => checkBoxNormalLock.Checked; set => checkBoxNormalLock.Checked = value; }

        public bool IsCodeLock { get => checkBoxCodeLock.Checked; set => checkBoxCodeLock.Checked = value; }

        public bool IsFingerPrintLock { get => checkBoxFingerPrintLock.Checked; set => checkBoxFingerPrintLock.Checked = value; }
        /// <summary>
        /// 基础设置控件
        /// </summary>
        public bool IsIronSelected { get => radioButtonIsIron.Checked; set => radioButtonIsIron.Checked = value; }
        public bool IsStainlessSteelSelected { get => radioButtonIsStainless.Checked; set => radioButtonIsStainless.Checked = value; }
        public string SelectedProductType { get => comboBoxSetUpProductType.Text; set => comboBoxSetUpProductType.Text = value; }
        public int SetUpBasicUnitPrice { get => Convert.ToInt32( textBoxSetUpUnitPrice.Text); set => textBoxSetUpUnitPrice.Text = value.ToString(); }

        public string NewProductType { get => textBoxNewProductType.Text; set => textBoxNewProductType.Text = value; }
        public int NewProductUnitPrice {
            get
            {
                // 如果文本框为空或无法解析为整数，返回默认值 0
                if (string.IsNullOrWhiteSpace(textBoxNewUnitPrice.Text) || !int.TryParse(textBoxNewUnitPrice.Text, out int value))
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
                textBoxNewUnitPrice.Text = value.ToString();
            }
        }


        ///
        ////

        public RadioButton RB_IS_IRON { get => radioButtonIsIron; set => radioButtonIsIron = value; }
        public RadioButton RB_IS_STAINLESS { get => radioButtonIsStainless; set => radioButtonIsStainless = value; }


        /// <summary>
        /// 基础设置按钮
        /// </summary>
        public Button BTN_UPDATE_UNIT_PRICE { get => buttonUpdateProductType; }
        public Button BTN_DELETE_PRODUCT_TYPE { get => buttonDeleteProductType; }

        public Button BTN_NEW_PRODUCT_TYPE { get => buttonAddProductType; }
        /// <summary>
        /// 下拉框
        /// </summary>

        public ComboBox CB_PRODUCT_TYPE { get => comboBoxSetUpProductType; set => comboBoxSetUpProductType = value; }

        /// <summary>
        /// 文本框
        /// </summary>
        public TextBox TB_BASIC_UNIT_PRICE { get => textBoxSetUpUnitPrice; set => textBoxSetUpUnitPrice = value; }

        public TextBox TB_NEW_PRODUCT_TYPE { get => textBoxNewProductType; set => textBoxNewProductType = value; }
        public TextBox TB_NEW_PRODUCT_UNIT_PRICE { get => textBoxNewUnitPrice; set => textBoxNewUnitPrice = value; }



        /// <summary>
        /// 自定义产品设置
        /// </summary>
        /// 

        public ComboBox CP_MATERIAL { get => comboBoxCustomizedProductMaterial; set => comboBoxCustomizedProductMaterial = value; }
        public ComboBox CP_TYPE { get => comboBoxCustomizedProductType; set => comboBoxCustomizedProductType = value; }
        public ComboBox CP_CB_NAME { get => comboBoxCustomizedName; set => comboBoxCustomizedName = value; }
        public TextBox CP_NEW_NAME { get => textBoxCustomizedProductName; set => textBoxCustomizedProductName = value; }
        public Button CP_BTN_UPDATE { get => buttonCustomizedUpdate; set => buttonCustomizedUpdate = value; }
        public Button CP_BTN_DELETE { get => buttonCustomizedDelete; set => buttonCustomizedDelete = value; }
        public Button CP_BTN_ADD { get => buttonCustomizedAdd; set => buttonCustomizedAdd = value; }
        public CheckBox CP_CLOSER { get => checkBoxCustomizedCloser; set => checkBoxCustomizedCloser = value; }
        public CheckBox CP_DOORINDOOR { get => checkBoxCustomizedDoorInDoor; set => checkBoxCustomizedDoorInDoor = value; }
        public CheckBox CP_SCREEN { get => checkBoxCustomizedScreen; set => checkBoxCustomizedScreen = value; }

        public CheckBox CP_POWDER { get => checkBoxCustomizedPowderCoating; set => checkBoxCustomizedPowderCoating = value; }
        public CheckBox CP_GOLD { get => checkBoxCustomizedGold; set => checkBoxCustomizedGold = value; }
        public CheckBox CP_BRONZE { get => checkBoxCustomizedBronze; set => checkBoxCustomizedBronze = value; }

        public CheckBox CP_METAL_SHEET { get => checkBoxCustomizedMetalSheet; set => checkBoxCustomizedMetalSheet = value; }
        public CheckBox CP_PLASTIC { get => checkBoxCustomizedPlastic; set => checkBoxCustomizedPlastic = value; }
        public CheckBox CP_GLASS { get => checkBoxCustomizedGlass; set => checkBoxCustomizedGlass = value; }

        public CheckBox CP_CURVED { get => checkBoxCustomizedCurved; set => checkBoxCustomizedCurved = value; }
        public CheckBox CP_HASPOLE { get => checkBoxCustomizedPole; set => checkBoxCustomizedPole = value; }
        public TextBox CP_POLE_QTY { get => textBoxCustomizedPoleQty; set => textBoxCustomizedPoleQty = value; }
        public TextBox CP_POLE_PRICE { get => textBoxCustomizedPoleUnitPrice; set => textBoxCustomizedPoleUnitPrice = value; }

        public CheckBox CP_HASLOCK { get => checkBoxCustomizedHasLock; set => checkBoxCustomizedHasLock = value; }
        public CheckBox CP_NORMAL_LOCK { get => checkBoxCustomizedNormalLock; set => checkBoxCustomizedNormalLock = value; }
        public CheckBox CP_FINGER_PRINT { get => checkBoxCustomizedFingerPrintLock; set => checkBoxCustomizedFingerPrintLock = value; }
        public CheckBox CP_CODE_LOCK { get => checkBoxCustomizedCodeLock; set => checkBoxCustomizedCodeLock = value; }
        public CheckBox CP_AUTO_SWING { get => checkBoxCustomizedSwing; set => checkBoxCustomizedSwing = value; }
        public CheckBox CP_AUTO_SLIDING { get => checkBoxCustomizedSliding; set => checkBoxCustomizedSliding = value; }
        public DataGridView CP_DATA_VIEW { get => dataGridViewCustomized; set => dataGridViewCustomized = value; }



        // 静态字段，存储单例实例
        private static readonly MainView _instance = new MainView();

        // 私有构造函数，防止外部实例化
        private MainView()
        {
            // 初始化逻辑（如果需要）
            InitializeComponent();
            BindEvents();
        }

        // 静态属性，用于获取单例实例
        public static MainView Instance
        {
            get
            {
                return _instance;
            }
        }

        private void BindEvents()
        {
            radioButtonIsIron.CheckedChanged += SetSelectedMaterial;

        }

        private void SetSelectedMaterial(object sender, EventArgs e)
        {
            if (radioButtonIsIron.Checked == true)
            {

                SelectedMaterial = radioButtonIsIron.Text;
             
            }
            else
            {

                SelectedMaterial = radioButtonIsStainless.Text;
            }
        }
    }
}
