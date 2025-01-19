using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class BasicRefresher
    {
        private static readonly BasicRefresher _instance = new BasicRefresher();

        // 私有构造函数，防止外部实例化
        private BasicRefresher()
        {
            // 初始化逻辑（如果需要）
         
        }
        public static BasicRefresher Instance
        {
            get
            {
                return _instance;
            }
        }
        private void LoadComboBoxData()
        {

            string material = BasicSetUp.Instance.SelectedMaterial;
            List<Product> products = ProductsInfoList.GetAllProductsByMaterial(material);
            List<string> productTypes = new List<string> ();

            foreach (var item in products)
            {
                productTypes.Add(item.Type);

            }
           

            // 清空下拉框并加载新数据
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Clear();
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Count > 0)
            {
                BasicSetUp.Instance.CB_PRODUCT_TYPE.SelectedIndex = 0;
            }
            string type = BasicSetUp.Instance.SelectedProductType;
            var product = ProductsInfoList.FindProductFirstOneByMaterialAndType(material, type);
            if(product != null)
            {
                string price = product.UnitPrice.ToString();
                BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;
            }
            else
            {
                string price = "0";
                BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;
            }
          

        }


        public void LoadData(object sender, EventArgs e)
        {
            LoadComboBoxData();
            ReFreshDataGridView();
        }
        private void RefreshUnitPrice()
        {
            string price = DatabaseHelper.Instance.GetUnitPrice(BasicSetUp.Instance.SelectedMaterial, BasicSetUp.Instance.SelectedProductType).ToString();
            BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;

        }
        public void RefreshUnitPrice(object sender, EventArgs e)
        {
            RefreshUnitPrice();
        }
        private void ReFreshDataGridView()
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ProductsInfoList.GetAllProducts();
            BasicSetUp.Instance.BasicProductView.DataSource = bindingSource;

            BasicSetUp.Instance.BasicProductView.Columns[BasicSetUp.Instance.BasicProductView.Columns.Count - 1].Visible = false;

        }


    }
}
