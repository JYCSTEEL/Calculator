using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace 计价器
{
    public class CustomizedPresenter
    {


        // 静态字段，存储单例实例
        private static readonly CustomizedPresenter _instance = new CustomizedPresenter(CustomizedSetting.Instance, CustomizedRefresher.Instance);

        // 私有构造函数，防止外部实例化
        private CustomizedPresenter(CustomizedSetting SETTING, CustomizedRefresher BasicRefresher)
        {

            // 初始化逻辑（如果需要）
            BindEvents();
            InitializeProductInfo();

            InitializeCheckedListBox();
            InitializeData();
            

        }

        private void InitializeCheckedListBox()
        {
            
            ViewMGR.IniatialAndSelectAllCheckedListBox("自定义产品表",CustomizedSetting.Instance.CheckListBoxCustomized);
            CustomizedSetting.Instance.CP_SELECT_ALL.Checked = true;
        }

        // 静态属性，用于获取单例实例
        public static CustomizedPresenter Instance
        {
            get
            {
                return _instance;
            }
        }
        public void BindEvents()
        {
            CustomizedSetting.Instance.BTN_ADD.Click += BTN_NEW_PRODUCT_TYPE_Click;
            CustomizedSetting.Instance.BTN_UPDATE.Click += BTN_UPDATE_UNIT_PRICE_Click;
            CustomizedSetting.Instance.BTN_DELETE.Click += BTN_DELETE_PRODUCT_TYPE_Click;


           

        }
    
        private void InitializeProductInfo()
        {
            DataTable dataTable = new DataTable();
            dataTable = DatabaseHelper.Instance.GetAllCustomizedProducts();
            CustomizedProductsInfoList.AddProductList(ConvertDataTableToCustomizedProductList(dataTable));
        }
        private void InitializeData()
        {
            CustomizedSetting.Instance.MATERIAL.Items.Add("铁");
            CustomizedSetting.Instance.MATERIAL.Items.Add("不锈钢");

            // 默认选择第一项

            CustomizedSetting.Instance.MATERIAL.SelectedIndex = 0;
            CustomizedRefresher.Instance.LoadData();
            CustomizedRefresher.Instance.ReFreshDataGridView();
        }
        private bool IsProductExist(string material, string type, string name)
        {
            bool isProductExist = false;
            if (DatabaseHelper.Instance.DoesProductExist(material, type, name))
            {

                isProductExist = true;
            };

            return isProductExist;
        }



        private void AddCustomizedProductInfo() {
            
                CustomizedProduct product = new CustomizedProduct()
                {
                    Material = CustomizedSetting.Instance.MATERIAL.Text,
                    Type = CustomizedSetting.Instance.TYPE.Text,
                    UnitPrice = ProductsInfoList.GetProductUnitPrice(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text)
                };
            product.Property.ProductName = CustomizedSetting.Instance.TX_NAME.Text;
            product.Property.HasCloser = CustomizedSetting.Instance.HASLOCK.Checked;
            product.Property.HasDoorInDoor = CustomizedSetting.Instance.DOORINDOOR.Checked;
            product.Property.HasScreen = CustomizedSetting.Instance.SCREEN.Checked;
            product.Property.IsPowder = CustomizedSetting.Instance.POWDER.Checked;
            product.Property.IsGold = CustomizedSetting.Instance.GOLD.Checked;
            product.Property.IsBronze = CustomizedSetting.Instance.BRONZE.Checked;
            product.Property.HasMetalSheet = CustomizedSetting.Instance.METALSHEET.Checked;
            product.Property.HasPlastic = CustomizedSetting.Instance.PLASTIC.Checked;
            product.Property.HasGlass = CustomizedSetting.Instance.GLASS.Checked;
            product.Property.HasCurved = CustomizedSetting.Instance.CURVED.Checked;
            product.Property.HasPole = CustomizedSetting.Instance.POLE.Checked;
            product.Property.HasLock = CustomizedSetting.Instance.HASLOCK.Checked;
            product.Property.DesignPrice = SafeParsedecimal(CustomizedSetting.Instance.DESIGN_PRICE.Text, "花样价格");

            if (product.Property.HasPole)
            {
                product.Property.PolePrice = SafeParsedecimal(CustomizedSetting.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParsedecimal(CustomizedSetting.Instance.POLE_QTY.Text, "大柱数量");

            }
          
         
          
            if (product.Property.HasLock)
            {
                product.Property.FingerLock = CustomizedSetting.Instance.FINGER_LOCK.Checked;
                product.Property.CodeLock = CustomizedSetting.Instance.CODE_LOCK.Checked;

                product.Property.NormalLock = CustomizedSetting.Instance.NORMAL_LOCK.Checked;
            }


            product.Property.HasAutoSwing = CustomizedSetting.Instance.AUTO_SWING.Checked;


            product.Property.HasAutoSliding = CustomizedSetting.Instance.AUTO_SLIDING.Checked;

            CustomizedProductsInfoList.AddProduct(product);
            }

            private void UpdateCustomizedProductInfo()
            {
                DeleteCustomizedProductInfo();
                CustomizedProduct product = new CustomizedProduct()
                {
                    Material = CustomizedSetting.Instance.MATERIAL.Text,
                    Type = CustomizedSetting.Instance.TYPE.Text,
                    UnitPrice = ProductsInfoList.GetProductUnitPrice(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text)
                };
            product.Property.ProductName = CustomizedSetting.Instance.TX_NAME.Text;
            product.Property.HasCloser = CustomizedSetting.Instance.HASLOCK.Checked;
            product.Property.HasDoorInDoor = CustomizedSetting.Instance.DOORINDOOR.Checked;
            product.Property.HasScreen = CustomizedSetting.Instance.SCREEN.Checked;
            product.Property.IsPowder = CustomizedSetting.Instance.POWDER.Checked;
            product.Property.IsGold = CustomizedSetting.Instance.GOLD.Checked;
            product.Property.IsBronze = CustomizedSetting.Instance.BRONZE.Checked;
            product.Property.HasMetalSheet = CustomizedSetting.Instance.METALSHEET.Checked;
            product.Property.HasPlastic = CustomizedSetting.Instance.PLASTIC.Checked;
            product.Property.HasGlass = CustomizedSetting.Instance.GLASS.Checked;
            product.Property.HasCurved = CustomizedSetting.Instance.CURVED.Checked;

            product.Property.HasPole = CustomizedSetting.Instance.POLE.Checked;

            product.Property.HasLock = CustomizedSetting.Instance.HASLOCK.Checked;

            product.Property.DesignPrice = SafeParsedecimal(CustomizedSetting.Instance.DESIGN_PRICE.Text, "花样价格");
            if (product.Property.HasPole)
            {
                product.Property.PolePrice = SafeParsedecimal(CustomizedSetting.Instance.POLE_PRICE.Text, "大柱单价");
                product.Property.PoleQty = SafeParsedecimal(CustomizedSetting.Instance.POLE_QTY.Text, "大柱数量");

            }



            if (product.Property.HasLock)
            {
                product.Property.FingerLock = CustomizedSetting.Instance.FINGER_LOCK.Checked;
                product.Property.CodeLock = CustomizedSetting.Instance.CODE_LOCK.Checked;

                product.Property.NormalLock = CustomizedSetting.Instance.NORMAL_LOCK.Checked;
            }

            product.Property.HasAutoSwing = CustomizedSetting.Instance.AUTO_SWING.Checked;


            product.Property.HasAutoSliding = CustomizedSetting.Instance.AUTO_SLIDING.Checked;
            CustomizedProductsInfoList.AddProduct(product);
            }




            private void DeleteCustomizedProductInfo()
            {
                CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text);
                CustomizedProductsInfoList.RemoveProduct(product);
            }

            private void BTN_NEW_PRODUCT_TYPE_Click(object sender, EventArgs e)
            {
            if (IsProductExist(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.TX_NAME.Text))
            {
                MessageBox.Show("产品-已存在！");
                return;
            };
            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.MATERIAL.Text))
            {
                MessageBox.Show("材料不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.TYPE.Text))
                {
                    MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.TX_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (CustomizedSetting.Instance.POLE.Checked)
            {
                if (!IsdecimalOverZero(Convert.ToDecimal(CustomizedSetting.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsdecimalOverZero(Convert.ToDecimal(CustomizedSetting.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (CustomizedSetting.Instance.HASLOCK.Checked)
            {
                if (!(CustomizedSetting.Instance.NORMAL_LOCK.Checked|| CustomizedSetting.Instance.FINGER_LOCK.Checked || CustomizedSetting.Instance.CODE_LOCK.Checked ))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }


        
                AddCustomizedProductInfo();
                // 调用数据库助手的插入方法
                CustomizedProduct product = new CustomizedProduct();
            product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.TX_NAME.Text);
          
            DatabaseHelper.Instance.InsertCustomizedProduct(product);
                MessageBox.Show("新建产品类型-成功！");

            }

            private void BTN_UPDATE_UNIT_PRICE_Click(object sender, EventArgs e)
            {
            if (!IsProductExist(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text))
            {
                MessageBox.Show("产品-不存在！");
                return;
            };

            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.MATERIAL.Text))
            {
                MessageBox.Show("材料不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.TYPE.Text))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsStringNotNullOrEmpty(CustomizedSetting.Instance.TX_NAME.Text))
            {
                MessageBox.Show("名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (CustomizedSetting.Instance.POLE.Checked)
            {
                if (!IsdecimalOverZero(Convert.ToDecimal(CustomizedSetting.Instance.POLE_PRICE.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!IsdecimalOverZero(Convert.ToDecimal(CustomizedSetting.Instance.POLE_QTY.Text)))
                {
                    MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (CustomizedSetting.Instance.HASLOCK.Checked)
            {
                if (!(CustomizedSetting.Instance.NORMAL_LOCK.Checked || CustomizedSetting.Instance.FINGER_LOCK.Checked || CustomizedSetting.Instance.CODE_LOCK.Checked))
                {
                    MessageBox.Show("必须选择是什么样的锁！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

          
            UpdateCustomizedProductInfo();
            CustomizedProduct product = new CustomizedProduct();

            product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(
                CustomizedSetting.Instance.MATERIAL.Text, 
                CustomizedSetting.Instance.TYPE.Text, 
                CustomizedSetting.Instance.TX_NAME.Text);

            DatabaseHelper.Instance.UpdateCustomizedProduct(
                CustomizedSetting.Instance.MATERIAL.Text, 
                CustomizedSetting.Instance.TYPE.Text, 
                CustomizedSetting.Instance.CB_NAME.Text,
                product);
            MessageBox.Show("更新产品-成功！");

            }

            private void BTN_DELETE_PRODUCT_TYPE_Click(object sender, EventArgs e)
            {
                if (!DatabaseHelper.Instance.DoesProductExist(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text))
                {
                    MessageBox.Show("产品-不存在！");
                    return;
                };
               
                DatabaseHelper.Instance.DeleteCustomizedProduct(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text);
                MessageBox.Show("删除产品-成功！");
            DeleteCustomizedProductInfo();
        }
            private bool IsStringNotNullOrEmpty(string type)
            {

                if (string.IsNullOrWhiteSpace(type) || type == "")
                {

                    return false;
                }
                return true;

            }
            private bool IsdecimalOverZero(decimal unitPriceInput)
            {
                if (unitPriceInput <= 0)
                {

                    return false;
                }
                return true;
            }
        public List<CustomizedProduct> ConvertDataTableToCustomizedProductList(DataTable dataTable)
        {
            List<CustomizedProduct> products = new List<CustomizedProduct>();

            foreach (DataRow row in dataTable.Rows)
            {
                CustomizedProduct product = new CustomizedProduct
                {
                    Material = row["材料"].ToString(),
                    Type = row["类型"].ToString(),
                    UnitPrice = row["单价"] != DBNull.Value ? Convert.ToDecimal(row["单价"]) : 0,

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
                        PoleQty = row["柱子数量"] != DBNull.Value ? Convert.ToDecimal(row["柱子数量"]) : 0
                    }
                };

                products.Add(product);
            }

            return products;
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

        internal void UpdateProductPrice(object sender, EventArgs e)
        {
            List<CustomizedProduct> products = ConvertDataTableToCustomizedProductList( DatabaseHelper.Instance.GetAllCustomizedProducts());

            foreach (CustomizedProduct product in products)
            {
                if (product.Type== BasicSetting.Instance.CB_PRODUCT_TYPE.Text && product.Material== BasicSetting.Instance.SelectedMaterial)
                {
                    product.UnitPrice = Convert.ToDecimal( BasicSetting.Instance.TB_BASIC_PRICE.Text);
                 CustomizedProduct infoProduct =    CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(product.Material, product.Type,product.Property.ProductName);
                    infoProduct.UnitPrice = product.UnitPrice;
                }
            }


            DatabaseHelper.Instance.UpdateSingleValue("自定义产品表","单价", BasicSetting.Instance.TB_BASIC_PRICE.Text);
        }
    }
}
