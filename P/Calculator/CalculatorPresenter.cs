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
                if (!IsIntOverZero(Convert.ToInt32(Calculator.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsIntOverZero(Convert.ToInt32(Calculator.Instance.POLE_QTY.Text)))
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
                if (!IsIntOverZero(Convert.ToInt32(Calculator.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("柱子单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsIntOverZero(Convert.ToInt32(Calculator.Instance.POLE_QTY.Text)))
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
        private bool IsIntOverZero(int unitPriceInput)
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
                    UnitPrice = row["单价"] != DBNull.Value ? Convert.ToInt32(row["单价"]) : 0,


                       SinglePrice  = row["单个产品价格"] != DBNull.Value ? Convert.ToInt32(row["单个产品价格"]) : 0,
                    Qty = row["产品数量"] != DBNull.Value ? Convert.ToInt32(row["产品数量"]) : 0,
                    TotalPrice = row["总共价格"] != DBNull.Value ? Convert.ToInt32(row["总共价格"]) : 0,

                    Property = new ProductProperty
                    {
                        ProductName = row["名称"].ToString(),
                        WidthOrLength = row["长度或宽度"] != DBNull.Value ? Convert.ToInt32(row["长度或宽度"]) : 0,
                        HeightOrDeepth = row["高度或深度"] != DBNull.Value ? Convert.ToInt32(row["高度或深度"]) : 0,
                        WidthOrLengthFeet = row["长度或宽度英尺"] != DBNull.Value ? Convert.ToInt32(row["长度或宽度英尺"]) : 0,
                        HeightOrDeepthFeet = row["高度或深度英尺"] != DBNull.Value ? Convert.ToInt32(row["高度或深度英尺"]) : 0,
                        Sqft = row["平方英尺"] != DBNull.Value ? Convert.ToInt32(row["平方英尺"]) : 0,
                        DesignPrice = row["设计价格"] != DBNull.Value ? Convert.ToInt32(row["设计价格"]) : 0,
                        DesignQty = row["设计数量"] != DBNull.Value ? Convert.ToInt32(row["设计数量"]) : 0,
                        IsPowder = row["粉末涂层"] != DBNull.Value && Convert.ToBoolean(row["粉末涂层"]),
                        IsGold = row["金色"] != DBNull.Value && Convert.ToBoolean(row["金色"]),
                        IsBronze = row["古铜色"] != DBNull.Value && Convert.ToBoolean(row["古铜色"]),
                        HasMetalSheet = row["含金属板"] != DBNull.Value && Convert.ToBoolean(row["含金属板"]),
                        HasPlastic = row["含塑料"] != DBNull.Value && Convert.ToBoolean(row["含塑料"]),
                        HasGlass = row["含玻璃"] != DBNull.Value && Convert.ToBoolean(row["含玻璃"]),
                        HasCurved = row["含弯曲"] != DBNull.Value && Convert.ToBoolean(row["含弯曲"]),
                        HasLock = row["含锁"] != DBNull.Value && Convert.ToBoolean(row["含锁"]),
                        NormalLock = row["普通锁"] != DBNull.Value && Convert.ToBoolean(row["普通锁"]),
                        FingerLock = row["指纹锁"] != DBNull.Value && Convert.ToBoolean(row["指纹锁"]),
                        CodeLock = row["密码锁"] != DBNull.Value && Convert.ToBoolean(row["密码锁"]),
                        HasPole = row["含柱子"] != DBNull.Value && Convert.ToBoolean(row["含柱子"]),
                        HasCloser = row["含闭门器"] != DBNull.Value && Convert.ToBoolean(row["含闭门器"]),
                        HasDoorInDoor = row["含门中门"] != DBNull.Value && Convert.ToBoolean(row["含门中门"]),
                        HasScreen = row["含屏风"] != DBNull.Value && Convert.ToBoolean(row["含屏风"]),
                        HasAutoSwing = row["含自动摆动"] != DBNull.Value && Convert.ToBoolean(row["含自动摆动"]),
                        HasAutoSliding = row["含自动滑动"] != DBNull.Value && Convert.ToBoolean(row["含自动滑动"]),
                        PolePrice = row["柱子价格"] != DBNull.Value ? Convert.ToInt32(row["柱子价格"]) : 0,
                        PoleQty = row["柱子数量"] != DBNull.Value ? Convert.ToInt32(row["柱子数量"]) : 0,
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
                UnitPrice = ProductsInfoList.GetProductUnitPrice(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text)
            };
            product.Property.ProductName = Calculator.Instance.PRODUCT_NAME.Text;
            product.SinglePrice = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "单个产品价格");
            product.Qty = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "产品数量");
            product.TotalPrice = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "总共价格");
            product.Property.WidthOrLength = SafeParseInt(Calculator.Instance.WIDE_LENGTH.Text, "长度或宽度");

            product.Property.HeightOrDeepth = SafeParseInt(Calculator.Instance.HEIGHT_DEEPTH.Text, "高度或深度");
            product.Property.WidthOrLengthFeet = SafeParseInt(Calculator.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺");
            product.Property.HeightOrDeepthFeet = SafeParseInt(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺");

            product.Property.Sqft = SafeParseInt(Calculator.Instance.SQFT.Text, "平方英尺");
            product.Property.DesignPrice = SafeParseInt(Calculator.Instance.DESIGN_PRICE.Text, "设计价格");
            product.Property.DesignQty = SafeParseInt(Calculator.Instance.DESIGN_QTY.Text, "设计数量");


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
                product.Property.PolePrice = SafeParseInt(Calculator.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParseInt(Calculator.Instance.POLE_QTY.Text, "大柱数量");

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
                UnitPrice = ProductsInfoList.GetProductUnitPrice(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text)
            };
            product.Property.ProductName = Calculator.Instance.PRODUCT_NAME.Text;
            product.SinglePrice = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "单个产品价格");
            product.Qty = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "产品数量");
            product.TotalPrice = SafeParseInt(Calculator.Instance.SINGLE_PRICE.Text, "总共价格");

            product.Property.WidthOrLength = SafeParseInt(Calculator.Instance.WIDE_LENGTH.Text, "长度或宽度");

            product.Property.HeightOrDeepth = SafeParseInt(Calculator.Instance.HEIGHT_DEEPTH.Text, "高度或深度");
            product.Property.WidthOrLengthFeet = SafeParseInt(Calculator.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺");
            product.Property.HeightOrDeepthFeet = SafeParseInt(Calculator.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺");

            product.Property.Sqft = SafeParseInt(Calculator.Instance.SQFT.Text, "平方英尺");
            product.Property.DesignPrice = SafeParseInt(Calculator.Instance.DESIGN_PRICE.Text, "设计价格");
            product.Property.DesignQty = SafeParseInt(Calculator.Instance.DESIGN_QTY.Text, "设计数量");

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
                product.Property.PolePrice = SafeParseInt(Calculator.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParseInt(Calculator.Instance.POLE_QTY.Text, "大柱数量");

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

        private int SafeParseInt(string input, string fieldName)
        {
            if (int.TryParse(input, out int result))
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
                UnitPrice = Convert.ToInt32(selectedRow.Cells["单价"].Value),
                SinglePrice = Convert.ToInt32(selectedRow.Cells["单个产品价格"].Value),
                Qty = Convert.ToInt32(selectedRow.Cells["产品数量"].Value),
                TotalPrice = Convert.ToInt32(selectedRow.Cells["总共价格"].Value),
                Property = new ProductProperty
                {
                    ProductName = selectedRow.Cells["名称"].Value.ToString(),
                    WidthOrLength = Convert.ToInt32(selectedRow.Cells["长度或宽度"].Value),
                    HeightOrDeepth = Convert.ToInt32(selectedRow.Cells["高度或深度"].Value),
                    WidthOrLengthFeet = Convert.ToInt32(selectedRow.Cells["长度或宽度英尺"].Value),
                    HeightOrDeepthFeet = Convert.ToInt32(selectedRow.Cells["高度或深度英尺"].Value),
                    Sqft = Convert.ToInt32(selectedRow.Cells["平方英尺"].Value),
                    DesignPrice = Convert.ToInt32(selectedRow.Cells["设计价格"].Value),
                    DesignQty = Convert.ToInt32(selectedRow.Cells["设计数量"].Value),
                    IsPowder = Convert.ToBoolean(selectedRow.Cells["粉末涂层"].Value),
                    IsGold = Convert.ToBoolean(selectedRow.Cells["金色"].Value),
                    IsBronze = Convert.ToBoolean(selectedRow.Cells["古铜色"].Value),
                    HasMetalSheet = Convert.ToBoolean(selectedRow.Cells["含金属板"].Value),
                    HasPlastic = Convert.ToBoolean(selectedRow.Cells["含塑料"].Value),
                    HasGlass = Convert.ToBoolean(selectedRow.Cells["含玻璃"].Value),
                    HasCurved = Convert.ToBoolean(selectedRow.Cells["含弯曲"].Value),
                    HasLock = Convert.ToBoolean(selectedRow.Cells["含锁"].Value),
                    NormalLock = Convert.ToBoolean(selectedRow.Cells["普通锁"].Value),
                    FingerLock = Convert.ToBoolean(selectedRow.Cells["指纹锁"].Value),
                    CodeLock = Convert.ToBoolean(selectedRow.Cells["密码锁"].Value),
                    HasPole = Convert.ToBoolean(selectedRow.Cells["含柱子"].Value),
                    HasCloser = Convert.ToBoolean(selectedRow.Cells["含闭门器"].Value),
                    HasDoorInDoor = Convert.ToBoolean(selectedRow.Cells["含门中门"].Value),
                    HasScreen = Convert.ToBoolean(selectedRow.Cells["含屏风"].Value),
                    HasAutoSwing = Convert.ToBoolean(selectedRow.Cells["含自动摆动"].Value),
                    HasAutoSliding = Convert.ToBoolean(selectedRow.Cells["含自动滑动"].Value),
                    PolePrice = Convert.ToInt32(selectedRow.Cells["柱子价格"].Value),
                    PoleQty = Convert.ToInt32(selectedRow.Cells["柱子数量"].Value)
                }
            };

            return product;
        }

        //示例方法：计算产品价格
        public int CalculateTotalPrice(CustomizedProduct product)
        {
            int price = 0;

            price = product.UnitPrice * product.Property.Sqft;

            return price;

        }
        public int CalculateTotalPrice(List<CustomizedProduct> products)
        {
            int totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Property.Sqft;
            }

            return totalPrice;
        }
        public int CalculateTotalPrice(params CustomizedProduct[] products)
        {
            int totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.UnitPrice * product.Property.Sqft;
            }

            return totalPrice;
        }
    }
}
