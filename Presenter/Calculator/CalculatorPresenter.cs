﻿using System;
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
        private static readonly CalculatorPresenter _instance = new CalculatorPresenter(CalculatorSetting.Instance, CalculatorRefresher.Instance);

        // 私有构造函数，防止外部实例化
        private CalculatorPresenter(CalculatorSetting calculator , CalculatorRefresher calculatorRefresher)
        {

            // 初始化逻辑（如果需要）
            BindEvents();

            InitializeProductInfo();
            InitializeCheckedListBox();
            InitializeData();
         
        }

        private void InitializeProductInfo()
        {
            List<CalculatorProduct> products = ConvertDataTableToCalculatorProductList(DatabaseHelper.Instance.GetAllCalculatorProducts());
            CalculatorProductsInfoList.AddProductList(products);
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
            CalculatorSetting.Instance.BTN_ADD.Click += ADD_TO_LIST;
            CalculatorSetting.Instance.BTN_UPDATE.Click += UPDATE_TO_LIST;
            CalculatorSetting.Instance.BTN_DELETE.Click += DELETE_FROM_LIST;


            CalculatorSetting.Instance.CC_BTN_CALCULATE.Click += CALCULATE_PRICE;

            CalculatorSetting.Instance.WIDE_LENGTH.KeyUp += WIDE_LENGTH_KeyPress;
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.KeyUp += WIDE_LENGTH_FEET_KeyPress;
            CalculatorSetting.Instance.HEIGHT_DEEPTH.KeyUp += HEIGHT_DEEPTH_KeyPress; ;
            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.KeyUp += HEIGHT_DEEPTH_FEET_KeyPress; ;
            CalculatorSetting.Instance.WIDE_LENGTH.KeyUp += CalculateSqft;
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.KeyUp += CalculateSqft;
            CalculatorSetting.Instance.HEIGHT_DEEPTH.KeyUp += CalculateSqft; ;
            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.KeyUp += CalculateSqft; ;
            CalculatorSetting.Instance.SQFT.TextChanged += PreDictDesignQty; ;

        }

        private void WIDE_LENGTH_KeyPress(object sender, KeyEventArgs e)
        {

            decimal size = 0;

            if (string.IsNullOrWhiteSpace(CalculatorSetting.Instance.WIDE_LENGTH.Text))
            {
                size = 0; // 设置默认值为 0
            }
            else
            {
                // 尝试转换，如果失败捕获异常
                try
                {
                    size = Convert.ToDecimal(CalculatorSetting.Instance.WIDE_LENGTH.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("请输入有效的数字！", "无效输入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    size = 0; // 或者根据需求设置其他默认值
                }
            }

            CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text = (size / 12).ToString("F2");
        }

        private void PreDictDesignQty(object sender, EventArgs e)
        {
            CalculatorSetting.Instance.DESIGN_QTY.Text = (Convert.ToDecimal(CalculatorSetting.Instance.SQFT.Text) / 5).ToString("F2");
        }

        private void CalculateSqft(object sender, KeyEventArgs e)
        {
            decimal sizeA = string.IsNullOrWhiteSpace(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text)
                            ? 0
                            : decimal.TryParse(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text, out var resultA) ? resultA : 0;

            decimal sizeB = string.IsNullOrWhiteSpace(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text)
                            ? 0
                            : decimal.TryParse(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text, out var resultB) ? resultB : 0;

            CalculatorSetting.Instance.SQFT.Text = (sizeA * sizeB).ToString("F2");
        }

        private void HEIGHT_DEEPTH_FEET_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = string.IsNullOrWhiteSpace(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text)
                           ? 0
                           : decimal.TryParse(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text, out var result) ? result : 0;

            CalculatorSetting.Instance.HEIGHT_DEEPTH.Text = (size * 12).ToString("F2");
        }

        private void HEIGHT_DEEPTH_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = string.IsNullOrWhiteSpace(CalculatorSetting.Instance.HEIGHT_DEEPTH.Text)
                           ? 0
                           : decimal.TryParse(CalculatorSetting.Instance.HEIGHT_DEEPTH.Text, out var result) ? result : 0;

            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text = (size / 12).ToString("F2");
        }

        private void WIDE_LENGTH_FEET_KeyPress(object sender, KeyEventArgs e)
        {
            decimal size = string.IsNullOrWhiteSpace(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text)
                           ? 0
                           : decimal.TryParse(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text, out var result) ? result : 0;

            CalculatorSetting.Instance.WIDE_LENGTH.Text = (size * 12).ToString("F2");
        }



        private CalculatorProduct ConvertViewToCalculatorProduct
        {
            get
            {
                CalculatorProduct product = new CalculatorProduct
                {
                    TotalPrice = Convert.ToDecimal(CalculatorSetting.Instance.TOTAL_PRICE.Text),
                    SinglePrice = Convert.ToDecimal(CalculatorSetting.Instance.SINGLE_PRICE.Text),
                    Qty = Convert.ToDecimal(CalculatorSetting.Instance.PRODUCT_QTY.Text),
                    Material = CalculatorSetting.Instance.CC_MATERIAL.Text,
                    Type = CalculatorSetting.Instance.CC_TYPE.Text,
                    Sqft = Convert.ToDecimal(CalculatorSetting.Instance.SQFT.Text),
                    WidthOrLength = Convert.ToDecimal(CalculatorSetting.Instance.WIDE_LENGTH.Text),
                    WidthOrLengthFeet = Convert.ToDecimal(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text),
                    HeightOrDeepth = Convert.ToDecimal(CalculatorSetting.Instance.HEIGHT_DEEPTH.Text),
                    HeightOrDeepthFeet = Convert.ToDecimal(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text),
                    DesignQty = Convert.ToDecimal(CalculatorSetting.Instance.DESIGN_QTY.Text),
                      UnitPrice = Convert.ToDecimal(CalculatorSetting.Instance.UNIT_PRICE.Text)


                };
                product.Property.ProductName = CalculatorSetting.Instance.PRODUCT_NAME.Text;
                product.Property.DesignPrice = Convert.ToDecimal(CalculatorSetting.Instance.DESIGN_PRICE.Text);
                product.Property.IsPowder = CalculatorSetting.Instance.POWDER.Checked;
                product.Property.IsGold = CalculatorSetting.Instance.GOLD.Checked;
                product.Property.IsBronze = CalculatorSetting.Instance.BRONZE.Checked;
                product.Property.HasMetalSheet = CalculatorSetting.Instance.METALSHEET.Checked;
                product.Property.HasScreen = CalculatorSetting.Instance.SCREEN.Checked;
                product.Property.HasDoorInDoor = CalculatorSetting.Instance.DOORINDOOR.Checked;
                product.Property.HasAutoSliding = CalculatorSetting.Instance.AUTO_SLIDING.Checked;
                product.Property.HasAutoSwing = CalculatorSetting.Instance.AUTO_SWING.Checked;
                product.Property.HasCloser = CalculatorSetting.Instance.HASCLOSER.Checked;
                product.Property.HasCurved = CalculatorSetting.Instance.CURVED.Checked;
                product.Property.HasGlass = CalculatorSetting.Instance.GLASS.Checked;
                product.Property.HasLock = CalculatorSetting.Instance.HASLOCK.Checked;
                product.Property.HasPole = CalculatorSetting.Instance.POLE.Checked;
                product.Property.HasPlastic = CalculatorSetting.Instance.PLASTIC.Checked;
                product.Property.NormalLock = CalculatorSetting.Instance.NORMAL_LOCK.Checked;
                product.Property.CodeLock = CalculatorSetting.Instance.CODE_LOCK.Checked;
                product.Property.FingerLock = CalculatorSetting.Instance.FINGER_LOCK.Checked;
                product.Property.PolePrice = Convert.ToDecimal(CalculatorSetting.Instance.POLE_PRICE.Text);
                product.Property.PoleQty = Convert.ToDecimal(CalculatorSetting.Instance.POLE_QTY.Text);

                return product;

            }
        }

        private void InitializeCheckedListBox()
        {
            ViewMGR.IniatialCheckedListBox("计价表", CalculatorSetting.Instance.CheckListBoxCalculator);
          DatabaseHelper.Instance.UpdateCheckedListBoxFromDatabase(CalculatorSetting.Instance.CheckListBoxCalculator, "计算显示保存表");
        }

        private void CALCULATE_PRICE(object sender, EventArgs e)
        {
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.CC_TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.PRODUCT_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (CalculatorSetting.Instance.POLE.Checked)
            {
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("柱子单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("柱子数量必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (CalculatorSetting.Instance.HASLOCK.Checked)
            {
                if (!(CalculatorSetting.Instance.NORMAL_LOCK.Checked || CalculatorSetting.Instance.FINGER_LOCK.Checked || CalculatorSetting.Instance.CODE_LOCK.Checked))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            CalculatorProduct product = ConvertViewToCalculatorProduct;
           CalculateTotalPriceShowToView(product);

        }
        private void DELETE_FROM_LIST(object sender, EventArgs e)
        {
          if(CalculatorSetting.Instance.DATAVIEW.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return;
            }
            CalculatorProduct selectedProduct =ViewMGR.GetSelectedCalculatorProduct(CalculatorSetting.Instance.DATAVIEW);
            DeleteCalculatorProductInfo(selectedProduct);
            DatabaseHelper.Instance.DeleteCalculatorProduct(selectedProduct);
        
            MessageBox.Show("删除"+selectedProduct.Property.ProductName+"-成功！");
            UpdateAllTotalPriceText();
        }

        private void UPDATE_TO_LIST(object sender, EventArgs e)
        {
            if (CalculatorSetting.Instance.DATAVIEW.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return;
            }
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.CC_TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.PRODUCT_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (CalculatorSetting.Instance.POLE.Checked)
            {
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("柱子单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("柱子数量必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (CalculatorSetting.Instance.HASLOCK.Checked)
            {
                if (!(CalculatorSetting.Instance.NORMAL_LOCK.Checked || CalculatorSetting.Instance.FINGER_LOCK.Checked || CalculatorSetting.Instance.CODE_LOCK.Checked))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            CalculatorProduct oldProduct = ViewMGR.GetSelectedCalculatorProduct(CalculatorSetting.Instance.DATAVIEW);


            // 调用数据库助手的插入方法
            CalculatorProduct newProduct= GetCalculatorProductFromView();

            UpdateCalculatorProductInfo(oldProduct, newProduct);//删除 CalculatorList里面的oldProduct，再Add oldProduct

            DatabaseHelper.Instance.UpdateCalculatorProduct(oldProduct,newProduct);

            MessageBox.Show("更新" + newProduct.Property.ProductName + "-成功！");
            UpdateAllTotalPriceText();
        }

        private void ADD_TO_LIST(object sender, EventArgs e)
        {
        
           
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.CC_TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CalculatorSetting.Instance.PRODUCT_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
       
            if (CalculatorSetting.Instance.POLE.Checked)
            {
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("柱子单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsINTOverZero(Convert.ToDecimal(CalculatorSetting.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("柱子数量必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (CalculatorSetting.Instance.HASLOCK.Checked)
            {
                if (!(CalculatorSetting.Instance.NORMAL_LOCK.Checked || CalculatorSetting.Instance.FINGER_LOCK.Checked || CalculatorSetting.Instance.CODE_LOCK.Checked))
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

            MessageBox.Show("新增" + product.Property.ProductName + "-成功！");
            UpdateAllTotalPriceText();
        }

        private void UpdateAllTotalPriceText()
        {
            decimal allprice = CalculateAllTotalPrice(CalculatorProductsInfoList.GetAllCalculatorProducts());
            CalculatorSetting.Instance.ALL_TOTAL_PRICE.Text = allprice.ToString();
        }
        private void InitializeData()
        {
            CalculatorSetting.Instance.CC_MATERIAL.Items.Add("铁");
            CalculatorSetting.Instance.CC_MATERIAL.Items.Add("不锈钢");

            // 默认选择第一项

            CalculatorSetting.Instance.CC_MATERIAL.SelectedIndex = 0;
            CalculatorRefresher.Instance.LoadData();
            CalculatorRefresher.Instance.ReFreshDataGridView();
           CalculatorSetting.Instance.ALL_TOTAL_PRICE.Text = CalculateAllTotalPrice(CalculatorProductsInfoList.GetAllCalculatorProducts()).ToString();

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

                   
                    SinglePrice = row["单个产品价格"] != DBNull.Value ? Convert.ToDecimal(row["单个产品价格"]) : 0,
                    Qty = row["产品数量"] != DBNull.Value ? Convert.ToDecimal(row["产品数量"]) : 0,
                    TotalPrice = row["总共价格"] != DBNull.Value ? Convert.ToDecimal(row["总共价格"]) : 0,

                    DesignQty = row["花样数量"] != DBNull.Value ? Convert.ToDecimal(row["花样数量"]) : 0,
                    WidthOrLength = row["长度或宽度"] != DBNull.Value ? Convert.ToDecimal(row["长度或宽度"]) : 0,
                    HeightOrDeepth = row["高度或深度"] != DBNull.Value ? Convert.ToDecimal(row["高度或深度"]) : 0,
                    WidthOrLengthFeet = row["长度或宽度英尺"] != DBNull.Value ? Convert.ToDecimal(row["长度或宽度英尺"]) : 0,
                    HeightOrDeepthFeet = row["高度或深度英尺"] != DBNull.Value ? Convert.ToDecimal(row["高度或深度英尺"]) : 0,
                    Sqft = row["平方英尺"] != DBNull.Value ? Convert.ToDecimal(row["平方英尺"]) : 0,

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

            CalculatorProduct newProduct = GetCalculatorProductFromView();

            CalculatorProductsInfoList.AddProduct(newProduct);
        }
        private void UpdateCalculatorProductInfo(CalculatorProduct oldproduct,CalculatorProduct newProduct)
        {
            DeleteCalculatorProductInfo(oldproduct);

            CalculatorProductsInfoList.AddProduct(newProduct);
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
     
        //示例方法：计算产品价格
        public CalculatorProduct CalculateTotalPriceShowToView(CalculatorProduct product)
        {
            decimal singlePrice = product.UnitPrice * product.Sqft;

            if (product.Property.HasPole)
            {
                decimal polePrice = product.Property.PolePrice;

                decimal poleQty = product.Property.PoleQty;

                singlePrice += polePrice * poleQty;

            }
          
                decimal designPrice = product.Property.DesignPrice;
            decimal designQty = product.DesignQty;


            singlePrice += designPrice * designQty;

         

            // 从数据库中获取单价表的所有值，减少重复查询
            decimal powderPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "烤漆"));
            decimal goldPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "金色"));
            decimal bronzePrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "古铜色"));
            decimal metalSheetPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "铁板"));
            decimal plasticPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "胶板"));
            decimal glassPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "玻璃"));
            decimal curvedPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "弧形"));
            decimal normalLockPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "普通锁"));
            decimal fingerLockPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "指纹锁"));
            decimal codeLockPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "密码锁"));
            decimal closer = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "闭门器"));

            decimal doorInDoorPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "门中门"));
            decimal screenPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "纱窗"));
            decimal autoSwingPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "电动双开"));
            decimal autoSlidingPrice = Convert.ToDecimal(DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "电动推拉"));
        



            // 根据属性逐一计算价格
            if (product.Property.IsPowder)
            {
                singlePrice += powderPrice * product.Sqft;
            }

            if (product.Property.IsGold)
            {
                singlePrice += goldPrice * product.Sqft;
            }

            if (product.Property.IsBronze)
            {
                singlePrice += bronzePrice * product.Sqft;
            }

            if (product.Property.HasMetalSheet)
            {
                singlePrice += metalSheetPrice * product.Sqft;
            }

            if (product.Property.HasPlastic)
            {
                singlePrice += plasticPrice * product.Sqft;
            }

            if (product.Property.HasGlass)
            {
                singlePrice += glassPrice * product.Sqft;
            }

            if (product.Property.HasCurved)
            {
                singlePrice += curvedPrice * product.Sqft;
            }

            if (product.Property.HasLock) {
                if (product.Property.NormalLock)
                {
                    singlePrice += normalLockPrice;
                }

                if (product.Property.FingerLock)
                {
                    singlePrice += fingerLockPrice;
                }

                if (product.Property.CodeLock)
                {
                    singlePrice += codeLockPrice;
                }
            }

           
            if (product.Property.HasCloser)
            {
                singlePrice += closer;
            }
            if (product.Property.HasDoorInDoor)
            {
                singlePrice += doorInDoorPrice * product.Sqft;
            }

            if (product.Property.HasScreen)
            {
                singlePrice += screenPrice * product.Sqft;
            }

            if (product.Property.HasAutoSwing)
            {
                singlePrice += autoSwingPrice;
            }

            if (product.Property.HasAutoSliding)
            {
                singlePrice += autoSlidingPrice;
            }
            product.SinglePrice = singlePrice;
            product.TotalPrice = product.SinglePrice * product.Qty;

            CalculatorSetting.Instance.SINGLE_PRICE.Text = product.SinglePrice.ToString();
            CalculatorSetting.Instance.TOTAL_PRICE.Text = product.TotalPrice.ToString();

            return product;
        }
        public CalculatorProduct GetCalculatorProductFromView()
        {

           CalculatorProduct product = new CalculatorProduct()
            {
                Material = CalculatorSetting.Instance.CC_MATERIAL.Text,
                Type = CalculatorSetting.Instance.CC_TYPE.Text,
                UnitPrice = ProductsInfoList.GetProductUnitPrice(CalculatorSetting.Instance.CC_MATERIAL.Text, CalculatorSetting.Instance.CC_TYPE.Text),
                DesignQty = SafeParsedecimal(CalculatorSetting.Instance.DESIGN_QTY.Text, "设计数量"),
                WidthOrLength = SafeParsedecimal(CalculatorSetting.Instance.WIDE_LENGTH.Text, "长度或宽度"),

                HeightOrDeepth = SafeParsedecimal(CalculatorSetting.Instance.HEIGHT_DEEPTH.Text, "高度或深度"),
                WidthOrLengthFeet = SafeParsedecimal(CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text, "长度或宽度英尺"),
                HeightOrDeepthFeet = SafeParsedecimal(CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text, "高度或深度英尺"),

                Sqft = SafeParsedecimal(CalculatorSetting.Instance.SQFT.Text, "平方英尺")
            };
            product.Property.ProductName = CalculatorSetting.Instance.PRODUCT_NAME.Text;
            product.SinglePrice = SafeParsedecimal(CalculatorSetting.Instance.SINGLE_PRICE.Text, "单个产品价格");
            product.Qty = SafeParsedecimal(CalculatorSetting.Instance.PRODUCT_QTY.Text, "产品数量");
            product.TotalPrice = SafeParsedecimal(CalculatorSetting.Instance.TOTAL_PRICE.Text, "总共价格");

            product.Property.DesignPrice = SafeParsedecimal(CalculatorSetting.Instance.DESIGN_PRICE.Text, "设计价格");

            product.Property.HasCloser = CalculatorSetting.Instance.HASLOCK.Checked;
            product.Property.HasDoorInDoor = CalculatorSetting.Instance.DOORINDOOR.Checked;
            product.Property.HasScreen = CalculatorSetting.Instance.SCREEN.Checked;
            product.Property.IsPowder = CalculatorSetting.Instance.POWDER.Checked;
            product.Property.IsGold = CalculatorSetting.Instance.GOLD.Checked;
            product.Property.IsBronze = CalculatorSetting.Instance.BRONZE.Checked;
            product.Property.HasMetalSheet = CalculatorSetting.Instance.METALSHEET.Checked;
            product.Property.HasPlastic = CalculatorSetting.Instance.PLASTIC.Checked;
            product.Property.HasGlass = CalculatorSetting.Instance.GLASS.Checked;
            product.Property.HasCurved = CalculatorSetting.Instance.CURVED.Checked;

            product.Property.HasPole = CalculatorSetting.Instance.POLE.Checked;

            product.Property.HasLock = CalculatorSetting.Instance.HASLOCK.Checked;
            if (product.Property.HasPole)
            {
                product.Property.PolePrice = SafeParsedecimal(CalculatorSetting.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParsedecimal(CalculatorSetting.Instance.POLE_QTY.Text, "大柱数量");

            }



            if (product.Property.HasLock)
            {
                product.Property.FingerLock = CalculatorSetting.Instance.FINGER_LOCK.Checked;
                product.Property.CodeLock = CalculatorSetting.Instance.CODE_LOCK.Checked;

                product.Property.NormalLock = CalculatorSetting.Instance.NORMAL_LOCK.Checked;
            }

            product.Property.HasAutoSwing = CalculatorSetting.Instance.AUTO_SWING.Checked;


            product.Property.HasAutoSliding = CalculatorSetting.Instance.AUTO_SLIDING.Checked;


            return product;
        }
        public decimal CalculateAllTotalPrice(List<CalculatorProduct> products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.TotalPrice;
            }

            return totalPrice;
        }
        public decimal CalculateAllTotalPrice(params CalculatorProduct[] products)
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
