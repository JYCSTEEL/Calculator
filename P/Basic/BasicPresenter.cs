using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace 计价器
{
   
    public class BasicPresenter
    {
   
        // 静态字段，存储单例实例
        private static readonly BasicPresenter _instance = new BasicPresenter(BasicSetting.Instance, BasicRefresher.Instance);

        // 私有构造函数，防止外部实例化
        private BasicPresenter(BasicSetting basicSetUp, BasicRefresher BasicRefresher)
        {
            // 初始化逻辑（如果需要）
            BindEvents();
            InitializeProductInfo();

            InitializeData();

         
        }

        // 静态属性，用于获取单例实例
        public static BasicPresenter Instance
        {
            get
            {
                return _instance;
            }
        }
        public void BindEvents()
        {
            BasicSetting.Instance.BTN_NEW_PRODUCT_TYPE.Click += BTN_NEW_PRODUCT_TYPE_Click;
            BasicSetting.Instance.BTN_UPDATE_UNIT_PRICE.Click += BTN_UPDATE_UNIT_PRICE_Click;
            BasicSetting.Instance.BTN_DELETE_PRODUCT_TYPE.Click += BTN_DELETE_PRODUCT_TYPE_Click;


        }

      

        private void InitializeProductInfo()
        {
            DataTable dataTable = new DataTable();
            dataTable = DatabaseHelper.Instance.GetAllProducts();
            ProductsInfoList.AddProductList(ConvertToProducts(dataTable));
      
        }
        private void InitializeData()
        {
            BasicSetting.Instance.RB_IS_IRON.Checked = true;
            // 默认选择第一项

            BasicRefresher.Instance.LoadData();
            BasicRefresher.Instance.ReFreshDataGridView();

        }
        private bool IsProductExist(string material, string type)
        {
            bool isProductExist = false;
            if (DatabaseHelper.Instance.RecordExists(material, type))
            {

                isProductExist = true;
            };

            return isProductExist;
        }

        private void AddProductInfo()
        {
            Product product = new Product()
            {
                Material = BasicSetting.Instance.SelectedMaterial,
                Type = BasicSetting.Instance.NewProductType,
                UnitPrice = BasicSetting.Instance.NewProductUnitPrice,

            };
        

            ProductsInfoList.AddProduct(product);
            EventPublisher.RaiseEvent();
        }
        private void UpdateProductInfo()
        {
            DeleteProductInfo();
            Product product = new Product()
            {
                Material = BasicSetting.Instance.SelectedMaterial,
                Type = BasicSetting.Instance.SelectedProductType,
                UnitPrice = BasicSetting.Instance.SetUpBasicUnitPrice,
            };
            ProductsInfoList.AddProduct(product);
            EventPublisher.RaiseEvent();
        }
        private void DeleteProductInfo()
        {
            Product product = ProductsInfoList.FindProductFirstOneByMaterialAndType(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.SelectedProductType);
            ProductsInfoList.RemoveProduct(product);
            EventPublisher.RaiseEvent();
        }

        private void BTN_NEW_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {
            if (!IsStringNotNullOrEmpty(BasicSetting.Instance.NewProductType))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsINTOverZero(BasicSetting.Instance.NewProductUnitPrice))
            {
                MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsProductExist(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.NewProductType))
            {
                MessageBox.Show("产品类型-已存在！");
                return;
            };
            AddProductInfo();
            // 调用数据库助手的插入方法
            DatabaseHelper.Instance.InsertProduct(
                BasicSetting.Instance.SelectedMaterial,
                BasicSetting.Instance.NewProductType,
                BasicSetting.Instance.NewProductUnitPrice);
            MessageBox.Show("新建产品类型-成功！");

        }

        private void BTN_UPDATE_UNIT_PRICE_Click(object sender, EventArgs e)
        {

            if (!IsStringNotNullOrEmpty(BasicSetting.Instance.SelectedMaterial))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!IsINTOverZero(BasicSetting.Instance.SetUpBasicUnitPrice))
            {
                MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!IsProductExist(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.SelectedProductType))
            {
                MessageBox.Show("产品类型-不存在！");
                return;
            };
            UpdateProductInfo();
            DatabaseHelper.Instance.UpdateProductPrice(
                BasicSetting.Instance.SelectedMaterial,
                BasicSetting.Instance.SelectedProductType,
                BasicSetting.Instance.SetUpBasicUnitPrice);
            MessageBox.Show("更新产品类型-成功！");

        }

        private void BTN_DELETE_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {
            if (!DatabaseHelper.Instance.RecordExists(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.SelectedProductType))
            {
                MessageBox.Show("产品类型-不存在！");
                return;
            };
            DeleteProductInfo();
            DatabaseHelper.Instance.DeleteProduct(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.SelectedProductType);
            MessageBox.Show("删除产品类型-成功！");

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

        public List<Product> ConvertToProducts(DataTable dataTable)
        {
            List<Product> products = new List<Product>();

            foreach (DataRow row in dataTable.Rows)
            {
                Product product = new Product
                {
                    Material = row["材料"].ToString(),

                    Type = row["类型"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["单价"]),
                };
                products.Add(product);
            }

            return products;
        }



    }
}
