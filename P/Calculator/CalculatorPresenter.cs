using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class CalculatorPresenter
    {
        // 静态字段，存储单例实例
        private static readonly CalculatorPresenter _instance = new CalculatorPresenter(Calculator.Instance, CalculatorRefresher.Instance);

        // 私有构造函数，防止外部实例化
        private CalculatorPresenter(Calculator calculator , CalculatorRefresher calculatorRefresher)
        {

            // 初始化逻辑（如果需要）
            BindEvents();

            InitializeCheckedListBox();
            InitializeData();
        }

        // 静态属性，用于获取单例实例
        public static CalculatorPresenter Instance
        {
            get
            {
                return _instance;
            }
        }
        public void BindEvents()
        {
            Calculator.Instance.BTN_ADD.Click += ADD_TO_LIST;
            Calculator.Instance.BTN_UPDATE.Click += UPDATE_TO_LIST;
            Calculator.Instance.BTN_DELETE.Click += DELETE_FROM_LIST;


            Calculator.Instance.CC_BTN_CALCULATE.Click += CALCULATE_PRICE;

            Calculator.Instance.WIDE_LENGTH.KeyUp += WIDE_LENGTH_KeyPress;
            Calculator.Instance.WIDE_LENGTH_FEET.KeyUp += WIDE_LENGTH_FEET_KeyPress;
            Calculator.Instance.HEIGHT_DEEPTH.KeyUp += HEIGHT_DEEPTH_KeyPress; ;
            Calculator.Instance.HEIGHT_DEEPTH_FEET.KeyUp += HEIGHT_DEEPTH_FEET_KeyPress; ;
            Calculator.Instance.WIDE_LENGTH.KeyUp += CalculateSqft;
            Calculator.Instance.WIDE_LENGTH_FEET.KeyUp += CalculateSqft;
            Calculator.Instance.HEIGHT_DEEPTH.KeyUp += CalculateSqft; ;
            Calculator.Instance.HEIGHT_DEEPTH_FEET.KeyUp += CalculateSqft; ;
            Calculator.Instance.SQFT.TextChanged += PreDictDesignQty; ;

        }

        private void WIDE_LENGTH_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = Convert.ToDecimal(Calculator.Instance.WIDE_LENGTH.Text);
            Calculator.Instance.WIDE_LENGTH_FEET.Text = (size / 12).ToString("F2");
        }

        private void PreDictDesignQty(object sender, EventArgs e)
        {
            Calculator.Instance.DESIGN_QTY.Text = (Convert.ToDecimal(Calculator.Instance.SQFT.Text) / 5).ToString("F2");
        }

        private void CalculateSqft(object sender, KeyEventArgs e)
        {
            decimal sizeA = Convert.ToDecimal(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text);

            decimal sizeB = Convert.ToDecimal(Calculator.Instance.WIDE_LENGTH_FEET.Text);
            Calculator.Instance.SQFT.Text = (sizeA * sizeB).ToString("F2");
        }

        private void HEIGHT_DEEPTH_FEET_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = Convert.ToDecimal(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text);
            Calculator.Instance.HEIGHT_DEEPTH.Text = (size * 12).ToString("F2");
        }

        private void HEIGHT_DEEPTH_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = Convert.ToDecimal(Calculator.Instance.HEIGHT_DEEPTH.Text);
            Calculator.Instance.HEIGHT_DEEPTH_FEET.Text = (size / 12).ToString("F2");
        }

        private void WIDE_LENGTH_FEET_KeyPress(object sender, KeyEventArgs e)   
        {
            decimal size = Convert.ToDecimal(Calculator.Instance.WIDE_LENGTH_FEET.Text);
            Calculator.Instance.WIDE_LENGTH.Text = (size * 12).ToString("F2");
        }

   

        private void CALCULATE_PRICE(object sender, EventArgs e)
        {
            
        }

        private void InitializeCheckedListBox()
        {
            ViewMGR.IniatialAndSelectAllCheckedListBox("计价表", Calculator.Instance.CheckListBoxCalculator);
            Calculator.Instance.CC_SELECT_ALL.Checked = true;
        }
        private void DELETE_FROM_LIST(object sender, EventArgs e)
        {
          if(Calculator.Instance.DATAVIEW.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return;
            }
            CalculatorProduct selectedProduct = GetSelectedCalculatorProduct(Calculator.Instance.DATAVIEW);

            DeleteCalculatorProductInfo(selectedProduct);
            DatabaseHelper.Instance.DeleteCalculatorProduct(selectedProduct);
            MessageBox.Show("删除-成功！");
        }

        private void UPDATE_TO_LIST(object sender, EventArgs e)
        {
            if (Calculator.Instance.DATAVIEW.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return;
            }
            if (!IsStringNotNullOrEmpty(Calculator.Instance.CC_TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(Calculator.Instance.PRODUCT_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (Calculator.Instance.POLE.Checked)
            {
                if (!IsINTOverZero(Convert.ToDecimal(Calculator.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsINTOverZero(Convert.ToDecimal(Calculator.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (Calculator.Instance.HASLOCK.Checked)
            {
                if (!(Calculator.Instance.NORMAL_LOCK.Checked || Calculator.Instance.FINGER_LOCK.Checked || Calculator.Instance.CODE_LOCK.Checked))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            CalculatorProduct oldProduct = GetSelectedCalculatorProduct(Calculator.Instance.DATAVIEW);

            UpdateCalculatorProductInfo(oldProduct);

            // 调用数据库助手的插入方法
            CalculatorProduct newProduct= CalculatorProductsInfoList.GetLastAddedProduct();


            DatabaseHelper.Instance.UpdateCalculatorProduct(oldProduct,newProduct);
            MessageBox.Show("更新-成功！");
        }

        private void ADD_TO_LIST(object sender, EventArgs e)
        {
        
           
            if (!IsStringNotNullOrEmpty(Calculator.Instance.CC_TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(Calculator.Instance.PRODUCT_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
       
            if (Calculator.Instance.POLE.Checked)
            {
                if (!IsINTOverZero(Convert.ToDecimal(Calculator.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("柱子单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsINTOverZero(Convert.ToDecimal(Calculator.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("柱子数量必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (Calculator.Instance.HASLOCK.Checked)
            {
                if (!(Calculator.Instance.NORMAL_LOCK.Checked || Calculator.Instance.FINGER_LOCK.Checked || Calculator.Instance.CODE_LOCK.Checked))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }



            AddCalculatorProductInfo();

            // 调用数据库助手的插入方法
            CalculatorProduct product = CalculatorProductsInfoList.GetLastAddedProduct();
            if (DatabaseHelper.Instance.DoesCalculatorProductExist(product))
            {
                MessageBox.Show("已存在相同的产品，请直接编辑！");
                DeleteCalculatorProductInfo(product);

                return;
            }
            DatabaseHelper.Instance.InsertCalculatorProduct(product);
            MessageBox.Show("新增-成功！");
        }

        private void InitializeData()
        {
            Calculator.Instance.CC_MATERIAL.Items.Add("铁");
            Calculator.Instance.CC_MATERIAL.Items.Add("不锈钢");

            // 默认选择第一项

            Calculator.Instance.CC_MATERIAL.SelectedIndex = 0;
            CalculatorRefresher.Instance.LoadData();
            CalculatorRefresher.Instance.ReFreshDataGridView();

        }

        private bool IsStringNotNullOrEmpty(string type)
        {

            if (string.IsNullOrWhiteSpace(type) || type == "")
            {

                return false;
            }
            return true;

        }
        private bool IsINTOverZero(decimal unitPriceInput)
        {
            if (unitPriceInput <= 0)
            {

                return false;
            }
            return true;
        }
        public List<CalculatorProduct> ConvertDataTableToCalculatorProductList(DataTable dataTable)
        {
            List<CalculatorProduct> products = new List<CalculatorProduct>();

            foreach (DataRow row in dataTable.Rows)
            {
                CalculatorProduct product = new CalculatorProduct
                {
                    Material = row["材料"].ToString(),
                    Type = row["类型"].ToString(),
                    UnitPrice = row["单价"] != DBNull.Value ? Convert.ToDecimal(row["单价"]) : 0,

                    WidthOrLength = row["长度或宽度"] != DBNull.Value ? Convert.ToDecimal(row["长度或宽度"]) : 0,
                    HeightOrDeepth = row["高度或深度"] != DBNull.Value ? Convert.ToDecimal(row["高度或深度"]) : 0,
                    WidthOrLengthFeet = row["长度或宽度英尺"] != DBNull.Value ? Convert.ToDecimal(row["长度或宽度英尺"]) : 0,
                    HeightOrDeepthFeet = row["高度或深度英尺"] != DBNull.Value ? Convert.ToDecimal(row["高度或深度英尺"]) : 0,
                    Sqft = row["平方英尺"] != DBNull.Value ? Convert.ToDecimal(row["平方英尺"]) : 0,
                    SinglePrice = row["单个产品价格"] != DBNull.Value ? Convert.ToDecimal(row["单个产品价格"]) : 0,
                    Qty = row["产品数量"] != DBNull.Value ? Convert.ToDecimal(row["产品数量"]) : 0,
                    TotalPrice = row["总共价格"] != DBNull.Value ? Convert.ToDecimal(row["总共价格"]) : 0,

                    DesignQty = row["花样数量"] != DBNull.Value ? Convert.ToDecimal(row["花样数量"]) : 0,

                    Property = new ProductProperty
                    {
                        ProductName = row["名称"].ToString(),

                        DesignPrice = row["花样价格"] != DBNull.Value ? Convert.ToDecimal(row["花样价格"]) : 0,
                        IsPowder = row["烤漆"] != DBNull.Value && Convert.ToBoolean(row["烤漆"]),
                        IsGold = row["金色"] != DBNull.Value && Convert.ToBoolean(row["金色"]),
                        IsBronze = row["古铜色"] != DBNull.Value && Convert.ToBoolean(row["古铜色"]),
                        HasMetalSheet = row["铁板"] != DBNull.Value && Convert.ToBoolean(row["铁板"]),
                        HasPlastic = row["胶板"] != DBNull.Value && Convert.ToBoolean(row["胶板"]),
                        HasGlass = row["玻璃"] != DBNull.Value && Convert.ToBoolean(row["玻璃"]),
                        HasCurved = row["弧形"] != DBNull.Value && Convert.ToBoolean(row["弧形"]),
                        HasLock = row["有锁"] != DBNull.Value && Convert.ToBoolean(row["有锁"]),
                        NormalLock = row["普通锁"] != DBNull.Value && Convert.ToBoolean(row["普通锁"]),
                        FingerLock = row["指纹锁"] != DBNull.Value && Convert.ToBoolean(row["指纹锁"]),
                        CodeLock = row["密码锁"] != DBNull.Value && Convert.ToBoolean(row["密码锁"]),
                        HasPole = row["有柱子"] != DBNull.Value && Convert.ToBoolean(row["有柱子"]),
                        HasCloser = row["有闭门器"] != DBNull.Value && Convert.ToBoolean(row["有闭门器"]),
                        HasDoorInDoor = row["门中门"] != DBNull.Value && Convert.ToBoolean(row["门中门"]),
                        HasScreen = row["纱窗"] != DBNull.Value && Convert.ToBoolean(row["纱窗"]),
                        HasAutoSwing = row["电动双开"] != DBNull.Value && Convert.ToBoolean(row["电动双开"]),
                        HasAutoSliding = row["电动推拉"] != DBNull.Value && Convert.ToBoolean(row["电动推拉"]),
                        PolePrice = row["柱子价格"] != DBNull.Value ? Convert.ToDecimal(row["柱子价格"]) : 0,
                        PoleQty = row["柱子数量"] != DBNull.Value ? Convert.ToDecimal(row["柱子数量"]) : 0,
                    }
                };

                products.Add(product);
            }

            return products;
        }

        private void AddCalculatorProductInfo()
        {

            CalculatorProduct product = new CalculatorProduct()
            {
                Material = Calculator.Instance.CC_MATERIAL.Text,
                Type = Calculator.Instance.CC_TYPE.Text,
                UnitPrice = ProductsInfoList.GetProductUnitPrice(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text),

                DesignQty = SafeParsedecimal(Calculator.Instance.DESIGN_QTY.Text, "设计数量"),


            WidthOrLength = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH.Text, "长度或宽度"),

                HeightOrDeepth = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH.Text, "高度或深度"),
                WidthOrLengthFeet = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺"),
                HeightOrDeepthFeet = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺"),

                Sqft = SafeParsedecimal(Calculator.Instance.SQFT.Text, "平方英尺")
            };
            product.Property.ProductName = Calculator.Instance.PRODUCT_NAME.Text;
            product.SinglePrice = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "单个产品价格");
            product.Qty = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "产品数量");
            product.TotalPrice = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "总共价格");
            product.Property.DesignPrice = SafeParsedecimal(Calculator.Instance.DESIGN_PRICE.Text, "设计价格");


            product.Property.HasCloser = Calculator.Instance.HASLOCK.Checked;
            product.Property.HasDoorInDoor = Calculator.Instance.DOORINDOOR.Checked;
            product.Property.HasScreen = Calculator.Instance.SCREEN.Checked;
            product.Property.IsPowder = Calculator.Instance.POWDER.Checked;
            product.Property.IsGold = Calculator.Instance.GOLD.Checked;
            product.Property.IsBronze = Calculator.Instance.BRONZE.Checked;
            product.Property.HasMetalSheet = Calculator.Instance.METALSHEET.Checked;
            product.Property.HasPlastic = Calculator.Instance.PLASTIC.Checked;
            product.Property.HasGlass = Calculator.Instance.GLASS.Checked;
            product.Property.HasCurved = Calculator.Instance.CURVED.Checked;
            product.Property.HasPole = Calculator.Instance.POLE.Checked;
            product.Property.HasLock = Calculator.Instance.HASLOCK.Checked;

            if (product.Property.HasPole)
            {
                product.Property.PolePrice = SafeParsedecimal(Calculator.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParsedecimal(Calculator.Instance.POLE_QTY.Text, "大柱数量");

            }



            if (product.Property.HasLock)
            {
                product.Property.FingerLock = Calculator.Instance.FINGER_LOCK.Checked;
                product.Property.CodeLock = Calculator.Instance.CODE_LOCK.Checked;

                product.Property.NormalLock = Calculator.Instance.NORMAL_LOCK.Checked;
            }
    

            product.Property.HasAutoSwing = Calculator.Instance.AUTO_SWING.Checked;


            product.Property.HasAutoSliding = Calculator.Instance.AUTO_SLIDING.Checked;

            CalculatorProductsInfoList.AddProduct(product);
        }
        private void UpdateCalculatorProductInfo(CalculatorProduct oldproduct)
        {
            DeleteCalculatorProductInfo(oldproduct);
            CalculatorProduct product = new CalculatorProduct()
            {
                Material = Calculator.Instance.CC_MATERIAL.Text,
                Type = Calculator.Instance.CC_TYPE.Text,
                UnitPrice = ProductsInfoList.GetProductUnitPrice(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text),
                DesignQty = SafeParsedecimal(Calculator.Instance.DESIGN_QTY.Text, "设计数量"),
                  WidthOrLength = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH.Text, "长度或宽度"),

                HeightOrDeepth = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH.Text, "高度或深度"),
                WidthOrLengthFeet = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺"),
                HeightOrDeepthFeet = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺"),

                Sqft = SafeParsedecimal(Calculator.Instance.SQFT.Text, "平方英尺")
            };
            product.Property.ProductName = Calculator.Instance.PRODUCT_NAME.Text;
            product.SinglePrice = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "单个产品价格");
            product.Qty = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "产品数量");
            product.TotalPrice = SafeParsedecimal(Calculator.Instance.SINGLE_PRICE.Text, "总共价格");

            product.Property.DesignPrice = SafeParsedecimal(Calculator.Instance.DESIGN_PRICE.Text, "设计价格");

            product.Property.HasCloser = Calculator.Instance.HASLOCK.Checked;
            product.Property.HasDoorInDoor = Calculator.Instance.DOORINDOOR.Checked;
            product.Property.HasScreen = Calculator.Instance.SCREEN.Checked;
            product.Property.IsPowder = Calculator.Instance.POWDER.Checked;
            product.Property.IsGold = Calculator.Instance.GOLD.Checked;
            product.Property.IsBronze = Calculator.Instance.BRONZE.Checked;
            product.Property.HasMetalSheet = Calculator.Instance.METALSHEET.Checked;
            product.Property.HasPlastic = Calculator.Instance.PLASTIC.Checked;
            product.Property.HasGlass = Calculator.Instance.GLASS.Checked;
            product.Property.HasCurved = Calculator.Instance.CURVED.Checked;

            product.Property.HasPole = Calculator.Instance.POLE.Checked;

            product.Property.HasLock = Calculator.Instance.HASLOCK.Checked;
            if (product.Property.HasPole)
            {
                product.Property.PolePrice = SafeParsedecimal(Calculator.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParsedecimal(Calculator.Instance.POLE_QTY.Text, "大柱数量");

            }



            if (product.Property.HasLock)
            {
                product.Property.FingerLock = Calculator.Instance.FINGER_LOCK.Checked;
                product.Property.CodeLock = Calculator.Instance.CODE_LOCK.Checked;

                product.Property.NormalLock = Calculator.Instance.NORMAL_LOCK.Checked;
            }

            product.Property.HasAutoSwing = Calculator.Instance.AUTO_SWING.Checked;


            product.Property.HasAutoSliding = Calculator.Instance.AUTO_SLIDING.Checked;


            CalculatorProductsInfoList.AddProduct(product);
        }
        private void DeleteCalculatorProductInfo(CalculatorProduct product)
        {
            CalculatorProductsInfoList.RemoveProduct(product);
        }

        private decimal SafeParsedecimal(string input, string fieldName)
        {
            if (decimal.TryParse(input, out decimal result))
            {
                return result;
            }
            else
            {
                MessageBox.Show($"字段 {fieldName} 的输入无效，请输入有效数字！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0; // 或其他默认值
            }
        }
        private CalculatorProduct GetSelectedCalculatorProduct(DataGridView dataGridView)
        {
            // 检查是否有选中行
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return null;
            }

            // 获取选中的行（第一行）
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            // 创建 CalculatorProduct 实例
            CalculatorProduct product = new CalculatorProduct
            {
                Material = selectedRow.Cells["材料"].Value.ToString(),
                Type = selectedRow.Cells["类型"].Value.ToString(),
                UnitPrice = Convert.ToDecimal(selectedRow.Cells["单价"].Value),
                SinglePrice = Convert.ToDecimal(selectedRow.Cells["单个产品价格"].Value),
                Qty = Convert.ToDecimal(selectedRow.Cells["产品数量"].Value),
                TotalPrice = Convert.ToDecimal(selectedRow.Cells["总共价格"].Value),
                DesignQty = SafeParsedecimal(Calculator.Instance.DESIGN_QTY.Text, "花样数量"),
                WidthOrLength = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH.Text, "长度或宽度"),

                HeightOrDeepth = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH.Text, "高度或深度"),
                WidthOrLengthFeet = SafeParsedecimal(Calculator.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺"),
                HeightOrDeepthFeet = SafeParsedecimal(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺"),

                Sqft = SafeParsedecimal(Calculator.Instance.SQFT.Text, "平方英尺"),
                Property = new ProductProperty
                {
                    ProductName = selectedRow.Cells["名称"].Value.ToString(),
                    DesignPrice = Convert.ToDecimal(selectedRow.Cells["花样价格"].Value),
                    IsPowder = Convert.ToBoolean(selectedRow.Cells["烤漆"].Value),
                    IsGold = Convert.ToBoolean(selectedRow.Cells["金色"].Value),
                    IsBronze = Convert.ToBoolean(selectedRow.Cells["古铜色"].Value),
                    HasMetalSheet = Convert.ToBoolean(selectedRow.Cells["铁板"].Value),
                    HasPlastic = Convert.ToBoolean(selectedRow.Cells["胶板"].Value),
                    HasGlass = Convert.ToBoolean(selectedRow.Cells["玻璃"].Value),
                    HasCurved = Convert.ToBoolean(selectedRow.Cells["弧形"].Value),
                    HasLock = Convert.ToBoolean(selectedRow.Cells["有锁"].Value),
                    NormalLock = Convert.ToBoolean(selectedRow.Cells["普通锁"].Value),
                    FingerLock = Convert.ToBoolean(selectedRow.Cells["指纹锁"].Value),
                    CodeLock = Convert.ToBoolean(selectedRow.Cells["密码锁"].Value),
                    HasPole = Convert.ToBoolean(selectedRow.Cells["有柱子"].Value),
                    HasCloser = Convert.ToBoolean(selectedRow.Cells["有闭门器"].Value),
                    HasDoorInDoor = Convert.ToBoolean(selectedRow.Cells["门中门"].Value),
                    HasScreen = Convert.ToBoolean(selectedRow.Cells["纱窗"].Value),
                    HasAutoSwing = Convert.ToBoolean(selectedRow.Cells["电动双开"].Value),
                    HasAutoSliding = Convert.ToBoolean(selectedRow.Cells["电动推拉"].Value),
                    PolePrice = Convert.ToDecimal(selectedRow.Cells["柱子价格"].Value),
                    PoleQty = Convert.ToDecimal(selectedRow.Cells["柱子数量"].Value)
                }
            };

            return product;
        }


        //示例方法：计算产品价格
        public decimal CalculateTotalPrice(CalculatorProduct product)
        {
            decimal price = 0;

            price = product.UnitPrice * product.Sqft;

            return price;

        }
        public decimal CalculateTotalPrice(List<CalculatorProduct> products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Sqft;
            }

            return totalPrice;
        }
        public decimal CalculateTotalPrice(params CalculatorProduct[] products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Sqft;
            }

            return totalPrice;
        }

       
    }
}
