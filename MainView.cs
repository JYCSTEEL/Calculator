using System;
using System.Windows.Forms;

namespace 计价器
{
    public partial class MainView : Form
    {

        /// <summary>
        /// 控件
        /// </summary>
        /// 

        public CheckBox SelectAllCustomized { get => checkBoxSelectAllCustomizedList; set => checkBoxSelectAllCustomizedList = value; }
        public CheckBox SelectAllCalculator { get => checkBoxSelectAllCalculatorList; set => checkBoxSelectAllCalculatorList = value; }
        public CheckedListBox ChecklistBoxCustomized { get => checkedListBoxCustomized; set => checkedListBoxCustomized = value; }
        public CheckedListBox ChecklistBoxCalculator { get => checkedListBoxCalculator; set => checkedListBoxCalculator = value; }

        public DataGridView MainProductView { get => dataGridViewProducts; set => dataGridViewProducts = value; }
        public TabControl MadecimalabControl { get => tabControl; }
        public TabPage TabpageCalculator { get => tabPageCalculate; }
        public TabPage TabpageBasicSetUp { get => tabPageSetting; }

        public string SelectedMaterial { get; set; }
        public string ProductType { get => comboBoxCalculatorName.Text; set => comboBoxCalculatorName.Text = value; }
        public decimal UnitPrice { get => Convert.ToDecimal(textBoxCalculatorUnitPrice.Text); set => textBoxCalculatorUnitPrice.Text = value.ToString(); }
        public decimal LengthWidthInch { get => Convert.ToDecimal(textBoxCalculatorLengthWidth.Text); set => textBoxCalculatorLengthWidth.Text = value.ToString(); }
        public decimal LengthWidthFeet { get => Convert.ToDecimal(textBoxCalculatorLengthWidthFeet.Text); set => textBoxCalculatorLengthWidthFeet.Text = value.ToString(); }
        public decimal HeightDeepthInch { get => Convert.ToDecimal(textBoxCalculatorHeightDeepth.Text); set => textBoxCalculatorHeightDeepth.Text = value.ToString(); }
        public decimal HeightDeepthFeet { get => Convert.ToDecimal(textBoxCalculatorHeightDeepthFeet.Text); set => textBoxCalculatorHeightDeepthFeet.Text = value.ToString(); }
        public decimal Sqft { get => Convert.ToDecimal(textBoxCalculatorSqft.Text); set => textBoxCalculatorSqft.Text = value.ToString(); }
        public decimal PoleQty { get => Convert.ToDecimal(textBoxCalculatorPoleQty.Text); set => textBoxCalculatorPoleQty.Text = value.ToString(); }
        public decimal DesignUnitPrice { get => Convert.ToDecimal(textBoxCalculatorDesignUnitPrice.Text); set => textBoxCalculatorDesignUnitPrice.Text = value.ToString(); }
        public decimal PredictDesignQty { get => Convert.ToDecimal(textBoxCalculatorPredictQtyOfDesign.Text); set => textBoxCalculatorPredictQtyOfDesign.Text = value.ToString(); }
        public bool HasPole { get => checkBoxCalculatorPole.Checked; set => checkBoxCalculatorPole.Checked = value; }
        public bool IsPowderCoating { get => checkBoxCalculatorPowderCoating.Checked; set => checkBoxCalculatorPowderCoating.Checked = value; }
        public bool IsBronze { get => checkBoxCalculatorBronze.Checked; set => checkBoxCalculatorBronze.Checked = value; }
        public bool IsGold { get => checkBoxCalculatorGold.Checked; set => checkBoxCalculatorGold.Checked = value; }
        public bool HasGlass { get => checkBoxCalculatorGlass.Checked; set => checkBoxCalculatorGlass.Checked = value; }
        public bool HasScreen { get => checkBoxCalculatorScreen.Checked; set => checkBoxCalculatorPole.Checked = value; }
        public bool HasPlastic { get => checkBoxCalculatorPlastic.Checked; set => checkBoxCalculatorPlastic.Checked = value; }
        public bool HasMetalSheet { get => checkBoxCalculatorMetalSheet.Checked; set => checkBoxCalculatorMetalSheet.Checked = value; }
        public bool HasCurve { get => checkBoxCalculatorCurve.Checked; set => checkBoxCalculatorCurve.Checked = value; }
        public bool HasCloser { get => checkBoxCalculatorCloser.Checked; set => checkBoxCalculatorCloser.Checked = value; }

        public bool HasLock { get => checkBoxCalculatorHasLock.Checked; set => checkBoxCalculatorHasLock.Checked = value; }
        public bool IsNormalLock { get => checkBoxCalculatorNormalLock.Checked; set => checkBoxCalculatorNormalLock.Checked = value; }

        public bool IsCodeLock { get => checkBoxCalculatorCodeLock.Checked; set => checkBoxCalculatorCodeLock.Checked = value; }

        public bool IsFingerPrdecimalLock { get => checkBoxCalculatorFingerPrdecimalLock.Checked; set => checkBoxCalculatorFingerPrdecimalLock.Checked = value; }
        /// <summary>
        /// 基础设置控件
        /// </summary>
        public bool IsIronSelected { get => radioButtonIsIron.Checked; set => radioButtonIsIron.Checked = value; }
        public bool IsStainlessSteelSelected { get => radioButtonIsStainless.Checked; set => radioButtonIsStainless.Checked = value; }
        public string SelectedProductType { get => comboBoxSetUpProductType.Text; set => comboBoxSetUpProductType.Text = value; }
        public decimal SetUpBasicUnitPrice { get => Convert.ToDecimal( textBoxSetUpUnitPrice.Text); set => textBoxSetUpUnitPrice.Text = value.ToString(); }

        public string NewProductType { get => textBoxNewProductType.Text; set => textBoxNewProductType.Text = value; }
        public decimal NewProductUnitPrice {
            get
            {
                // 如果文本框为空或无法解析为整数，返回默认值 0
                if (string.IsNullOrWhiteSpace(textBoxNewUnitPrice.Text) || !decimal.TryParse(textBoxNewUnitPrice.Text, out decimal value))
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
        public TextBox CP_DESIGN_PRICE { get => textBoxCustomizedDesignPrice; set => textBoxCustomizedDesignPrice = value; }

        public CheckBox CP_HASLOCK { get => checkBoxCustomizedHasLock; set => checkBoxCustomizedHasLock = value; }
        public CheckBox CP_NORMAL_LOCK { get => checkBoxCustomizedNormalLock; set => checkBoxCustomizedNormalLock = value; }
        public CheckBox CP_FINGER_PRdecimal { get => checkBoxCustomizedFingerPrdecimalLock; set => checkBoxCustomizedFingerPrdecimalLock = value; }
        public CheckBox CP_CODE_LOCK { get => checkBoxCustomizedCodeLock; set => checkBoxCustomizedCodeLock = value; }
        public CheckBox CP_AUTO_SWING { get => checkBoxCustomizedSwing; set => checkBoxCustomizedSwing = value; }
        public CheckBox CP_AUTO_SLIDING { get => checkBoxCustomizedSliding; set => checkBoxCustomizedSliding = value; }
        public DataGridView CP_DATA_VIEW { get => dataGridViewCustomized; set => dataGridViewCustomized = value; }
        /// <summary>
        /// 计算器部分的控件定义
        /// </summary>
        public ComboBox CC_MATERIAL { get => comboBoxCalculatorMaterial; set => comboBoxCalculatorMaterial = value; }
        public ComboBox CC_TYPE { get => comboBoxCalculatorType; set => comboBoxCalculatorType = value; }

        public ComboBox CC_PRODUCT_NAME { get => comboBoxCalculatorName; set => comboBoxCalculatorName = value; }

        public TextBox CC_UNIT_PRICE { get => textBoxCalculatorUnitPrice; set => textBoxCalculatorUnitPrice = value; }
        public TextBox CC_WIDTH_LENGTH { get => textBoxCalculatorLengthWidth; set => textBoxCalculatorLengthWidth = value; }

        public TextBox CC_HEIGHT_DEEPTH { get => textBoxCalculatorHeightDeepth; set => textBoxCalculatorHeightDeepth = value; }

        public TextBox CC_DESIGN_PRICE { get => textBoxCalculatorDesignUnitPrice; set => textBoxCalculatorDesignUnitPrice = value; }

        public TextBox CC_WIDTH_LENGTH_FEET { get => textBoxCalculatorLengthWidthFeet; set => textBoxCalculatorLengthWidthFeet = value; }

        public TextBox CC_HEIGHT_DEEPTH_FEET { get => textBoxCalculatorHeightDeepthFeet; set => textBoxCalculatorHeightDeepthFeet = value; }

        public TextBox CC_SQFT { get => textBoxCalculatorSqft; set => textBoxCalculatorSqft = value; }

        public TextBox CC_DESIGN_QTY { get => textBoxCalculatorPredictQtyOfDesign; set => textBoxCalculatorPredictQtyOfDesign = value; }
        public CheckBox CC_POWDER { get => checkBoxCalculatorPowderCoating; set => checkBoxCalculatorPowderCoating = value; }
        public Button CC_BTN_UPDATE { get => buttonCalculatorUpdate; set => buttonCalculatorUpdate = value; }
        public Button CC_BTN_DELETE { get => buttonDelete; set => buttonDelete = value; }
        public Button CC_BTN_ADD { get => buttonCalculatorAdd; set => buttonCalculatorAdd = value; }
        public CheckBox CC_CLOSER { get => checkBoxCalculatorCloser; set => checkBoxCalculatorCloser = value; }
        public CheckBox CC_DOORINDOOR { get => checkBoxCalculatorDoorInDoor; set => checkBoxCalculatorDoorInDoor = value; }
        public CheckBox CC_SCREEN { get => checkBoxCalculatorScreen; set => checkBoxCalculatorScreen = value; }
        public CheckBox CC_GOLD { get => checkBoxCalculatorGold; set => checkBoxCalculatorGold = value; }
        public CheckBox CC_BRONZE { get => checkBoxCalculatorBronze; set => checkBoxCalculatorBronze = value; }

        public CheckBox CC_METAL_SHEET { get => checkBoxCalculatorMetalSheet; set => checkBoxCalculatorMetalSheet = value; }
        public CheckBox CC_PLASTIC { get => checkBoxCalculatorPlastic; set => checkBoxCalculatorPlastic = value; }
        public CheckBox CC_GLASS { get => checkBoxCalculatorGlass; set => checkBoxCalculatorGlass = value; }

        public CheckBox CC_CURVED { get => checkBoxCalculatorCurve; set => checkBoxCalculatorCurve = value; }
        public CheckBox CC_HASPOLE { get => checkBoxCalculatorPole; set => checkBoxCalculatorPole = value; }
        public TextBox CC_POLE_QTY { get => textBoxCalculatorPoleQty; set => textBoxCalculatorPoleQty = value; }
        public TextBox CC_POLE_PRICE { get => textBoxCalculatorPoleUnitPrice; set => textBoxCalculatorPoleUnitPrice = value; }
      
        public CheckBox CC_HASLOCK { get => checkBoxCalculatorHasLock; set => checkBoxCalculatorHasLock = value; }
        public CheckBox CC_NORMAL_LOCK { get => checkBoxCalculatorNormalLock; set => checkBoxCalculatorNormalLock = value; }
        public CheckBox CC_FINGER_PRdecimal { get => checkBoxCalculatorFingerPrdecimalLock; set => checkBoxCalculatorFingerPrdecimalLock = value; }
        public CheckBox CC_CODE_LOCK { get => checkBoxCalculatorCodeLock; set => checkBoxCalculatorCodeLock = value; }
        public CheckBox CC_AUTO_SWING { get => checkBoxCalculatorAutoSwing; set => checkBoxCalculatorAutoSwing = value; }
        public CheckBox CC_AUTO_SLIDING { get => checkBoxCalculatorAutoSliding; set => checkBoxCalculatorAutoSliding = value; }
        public DataGridView CC_DATA_VIEW { get => dataGridViewCalculator; set => dataGridViewCalculator = value; }
        public TextBox CC_ALL_TOTAL_PRICE { get => textBoxCalculatorAllPrice; set => textBoxCalculatorAllPrice = value; }

        public TextBox CC_SINGLE_PRICE { get => textBoxCalculatorPrice; set => textBoxCalculatorPrice = value; }

        public TextBox CC_PRODUCT_QTY { get => textBoxCalculatorQty; set => textBoxCalculatorQty = value; }

        public TextBox CC_TOTAL_PRICE { get => textBoxCalculatorTotalPrice; set => textBoxCalculatorTotalPrice = value; }

        public Button CC_BTN_CALCULATE { get => buttonCalculatorCalculate; set => buttonCalculatorCalculate = value; }


        /// <summary>
        /// 设置价格控件
        /// </summary>
        /// 

        public TextBox SP_POWDER { get => textBoxSetPricePowder; set => textBoxSetPricePowder = value; }
        public TextBox SP_GOLD { get => textBoxSetPriceGold; set => textBoxSetPriceGold = value; }
        public TextBox SP_BRONZE { get => textBoxSetPriceBronze; set => textBoxSetPriceBronze = value; }
        public TextBox SP_METAL_SHEET { get => textBoxSetPriceMetalSheet; set => textBoxSetPriceMetalSheet = value; }
        public TextBox SP_PLASITC { get => textBoxSetPricePlastic; set => textBoxSetPricePlastic = value; }
        public TextBox SP_GALSS { get => textBoxSetPriceGlass; set => textBoxSetPriceGlass = value; }
        public TextBox SP_CURVE { get => textBoxSetPriceCurve; set => textBoxSetPriceCurve = value; }
        public TextBox SP_SWING { get => textBoxSetPriceSwing; set => textBoxSetPriceSwing = value; }

        public TextBox SP_SLIDING { get => textBoxSetPriceSliding; set => textBoxSetPriceSliding = value; }
        public TextBox SP_DOORINDOOR { get => textBoxDoorInDoor; set => textBoxDoorInDoor = value; }
        public TextBox SP_SCREEN { get => textBoxSetPriceScreen; set => textBoxSetPriceScreen = value; }
        public TextBox SP_NORMAL_LOCK { get => textBoxSetPriceNormalLock; set => textBoxSetPriceNormalLock = value; }
        public TextBox SP_FINGER_PRINT_LOCK { get => textBoxSetPriceFinger; set => textBoxSetPriceFinger = value; }
        public TextBox SP_CODE_LOCK{ get => textBoxSetPriceCodeLock; set => textBoxSetPriceCodeLock = value; }

        public TextBox SP_CLOSER { get => textBoxSetPriceCloser; set => textBoxSetPriceCloser = value; }


        public Button SP_BTN_UPDATE { get => buttonSetPriceUpdate; set => buttonSetPriceUpdate = value; }

        public Button SP_BTN_LOAD { get => buttonSetPriceLoad; set => buttonSetPriceLoad = value; }

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
            radioButtonIsStainless.CheckedChanged += SetSelectedMaterial;

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
