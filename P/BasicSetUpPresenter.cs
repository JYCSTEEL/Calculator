using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class BasicSetUpPresenter
    {
        // 静态字段，存储单例实例
        private static readonly BasicSetUpPresenter _instance = new BasicSetUpPresenter(BasicSetUp.Instance);

        // 私有构造函数，防止外部实例化
        private BasicSetUpPresenter(BasicSetUp basicSetUp)
        {
            // 初始化逻辑（如果需要）
            BindEvents();
            LoadData();
            InitializeProductInfo();
            ReFreshDataGridView();
            ConfigureDataGridView(BasicSetUp.Instance.BasicProductView);
        }

        // 静态属性，用于获取单例实例
        public static BasicSetUpPresenter Instance
        {
            get
            {
                return _instance;
            }
        }

        public void LoadData()
        {
            // 从数据库获取产品类型
            List<string> productTypes = DatabaseHelper.Instance.GetProductTypesByMaterial(BasicSetUp.Instance.SelectedMaterial);

            // 清空下拉框并加载新数据
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Clear();
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Count > 0)
            {
                BasicSetUp.Instance.CB_PRODUCT_TYPE.SelectedIndex = 0;
            }
            string material = BasicSetUp.Instance.SelectedMaterial;
            string type = BasicSetUp.Instance.SelectedProductType;
            string price = DatabaseHelper.Instance.GetUnitPrice(material,type).ToString();
            BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;

        }
        private void RefreshUnitPrice()
        {
            string price = DatabaseHelper.Instance.GetUnitPrice(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType).ToString();
            BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;

        }
        private bool VerifyInputType(string type)
        {

            if (string.IsNullOrWhiteSpace(type) || type == "")
            {
              
                return false;
            }
            return true;
          
        }
        private bool VerifyInputUnitPrice(int unitPriceInput)
        {
            if (unitPriceInput <= 0)
            {
               
                return false;
            }
            return true;
        }
        public void BindEvents()
        {
            BasicSetUp.Instance.BTN_NEW_PRODUCT_TYPE.Click += BTN_NEW_PRODUCT_TYPE_Click;
            BasicSetUp.Instance.BTN_UPDATE_UNIT_PRICE.Click += BTN_UPDATE_UNIT_PRICE_Click;
            BasicSetUp.Instance.BTN_DELETE_PRODUCT_TYPE.Click += BTN_DELETE_PRODUCT_TYPE_Click;
            BasicSetUp.Instance.BTN_NEW_PRODUCT_TYPE.Click += LoadData;
            BasicSetUp.Instance.BTN_UPDATE_UNIT_PRICE.Click += LoadData;
            BasicSetUp.Instance.BTN_DELETE_PRODUCT_TYPE.Click += LoadData;
            BasicSetUp.Instance.RB_IS_IRON.CheckedChanged += LoadData;

            BasicSetUp.Instance.CB_PRODUCT_TYPE.SelectedIndexChanged += RefreshUnitPrice;

        }

        private void InitializeProductInfo()
        {
            List<string> productTypes = DatabaseHelper.Instance.GetProductTypesByMaterial("铁");

            foreach (string productType in productTypes)
            {
                Product product = new Product();
                product.Material = "铁";
                product.Type = productType;
                product.UnitPrice = DatabaseHelper.Instance.GetUnitPrice("铁", productType);
                ProductsInfo.AddProduct(product);

            }
            productTypes = DatabaseHelper.Instance.GetProductTypesByMaterial("不锈钢");

            foreach (string productType in productTypes)
            {
                Product product = new Product();
                product.Material = "不锈钢";
                product.Type = productType;
                product.UnitPrice = DatabaseHelper.Instance.GetUnitPrice("不锈钢", productType);
                ProductsInfo.AddProduct(product);
            }
        }

        private void AddProductInfo()
        {
            Product product = new Product()
            {
                Material = BasicSetUp.Instance.SelectedMaterial,
                Type = BasicSetUp.Instance.NewProductType,
                UnitPrice = BasicSetUp.Instance.NewProductUnitPrice,
            };


            ProductsInfo.AddProduct(product);
        }
        private void UpdateProductInfo()
        {
            DeleteProductInfo();
            Product product = new Product()
            {
                Material = BasicSetUp.Instance.SelectedMaterial,
                Type = BasicSetUp.Instance.SelectedProductType,
                UnitPrice = BasicSetUp.Instance.SetUpBasicUnitPrice,
            };
            ProductsInfo.AddProduct(product);
        }
        private void DeleteProductInfo()
        {
            Product product = ProductsInfo.FindProduct(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType);
            ProductsInfo.RemoveProduct(product);
        }
        private void RefreshUnitPrice(object sender, EventArgs e)
        {
            RefreshUnitPrice();
        }

        private void LoadData(object sender, EventArgs e)
        {
            LoadData();
            ReFreshDataGridView();
        }
        private void BTN_NEW_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {
            if (!VerifyInputType(BasicSetUp.Instance.NewProductType))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!VerifyInputUnitPrice(BasicSetUp.Instance.NewProductUnitPrice))
            {
                MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsProductExist(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.NewProductType))
            {
                MessageBox.Show("产品类型-已存在！");
                return;
            };
            AddProductInfo();
            // 调用数据库助手的插入方法
            DatabaseHelper.Instance.InsertProduct(
                BasicSetUp.Instance.SelectedMaterial, 
                BasicSetUp.Instance.NewProductType, 
                BasicSetUp.Instance.NewProductUnitPrice);
            MessageBox.Show("新建产品类型-成功！");
       
        }

        private void BTN_UPDATE_UNIT_PRICE_Click(object sender, EventArgs e)
        {

            if (!VerifyInputType(BasicSetUp.Instance.SelectedMaterial))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (!VerifyInputUnitPrice(BasicSetUp.Instance.SetUpBasicUnitPrice))
            {
                MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!IsProductExist(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType))
            {
                MessageBox.Show("产品类型-不存在！");
                return;
            };
            UpdateProductInfo();
            DatabaseHelper.Instance.UpdateProductPrice(
                BasicSetUp.Instance.SelectedMaterial, 
                BasicSetUp.Instance.SelectedProductType,
                BasicSetUp.Instance.SetUpBasicUnitPrice);
            MessageBox.Show("更新产品类型-成功！");
         
        }

        private void BTN_DELETE_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {
            if (!DatabaseHelper.Instance.RecordExists(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType))
            {
                MessageBox.Show("产品类型-不存在！");
                return;
            };
            DeleteProductInfo();
            DatabaseHelper.Instance.DeleteProduct(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType);
            MessageBox.Show("删除产品类型-成功！");
        
        }
        private bool IsProductExist(string material ,string type)
        {
            bool isProductExist = false;
            if (DatabaseHelper.Instance.RecordExists(material, type))
            {
             
                 isProductExist = true;
            };

            return isProductExist;
        }

        private void ReFreshDataGridView()
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ProductsInfo.GetAllProducts();
            BasicSetUp.Instance.BasicProductView.DataSource = bindingSource;

        }

        private void ConfigureDataGridView(DataGridView dataGridView)
        {
            // 1. 设置只能选择一行
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false; // 禁用多选

            // 2. 设置列头颜色
            dataGridView.EnableHeadersVisualStyles = false; // 禁用系统样式
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // 背景色
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // 前景色（文字颜色）
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold); // 字体加粗

            // 3. 禁止列头选中样式变化
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 4. 隐藏行头
            dataGridView.RowHeadersVisible = false;

            // 5. 设置列宽自适应
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 6. 禁用用户调整列宽
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            // 7. 禁用用户调整行高
            dataGridView.AllowUserToResizeRows = false;

            // 8. 禁止单元格编辑
            dataGridView.ReadOnly = true;

            // 9. 禁止用户通过点击修改内容
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


    }
}
