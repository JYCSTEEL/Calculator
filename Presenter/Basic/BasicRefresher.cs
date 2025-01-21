using System;
using System.Collections.Generic;
using System.Data;
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

         
            string material = BasicSetting.Instance.SelectedMaterial;
            List<Product> products = ProductsInfoList.GetAllProductsByMaterial(material);
           
            List<string> productTypes = new List<string> ();

            foreach (var item in products)
            {
                productTypes.Add(item.Type);

            }
           

            // 清空下拉框并加载新数据
            BasicSetting.Instance.CB_PRODUCT_TYPE.Items.Clear();
            BasicSetting.Instance.CB_PRODUCT_TYPE.Items.AddRange(productTypes.ToArray());
         

            // 默认选择第一项（如果有数据）
            if (BasicSetting.Instance.CB_PRODUCT_TYPE.Items.Count > 0)
            {
                BasicSetting.Instance.CB_PRODUCT_TYPE.SelectedIndex = 0;
            }
            string type = BasicSetting.Instance.SelectedProductType;
            var product = ProductsInfoList.FindProductFirstOneByMaterialAndType(material, type);
            if(product != null)
            {
                string price = product.UnitPrice.ToString();
                BasicSetting.Instance.TB_BASIC_UNIT_PRICE.Text = price;
            }
            else
            {
                string price = "0";
                BasicSetting.Instance.TB_BASIC_UNIT_PRICE.Text = price;
            }
          

        }


        public void LoadData(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
        public void LoadData()
        {
            LoadComboBoxData();
        }
        private void RefreshUnitPrice()
        {
            string price = DatabaseHelper.Instance.GetUnitPrice(BasicSetting.Instance.SelectedMaterial, BasicSetting.Instance.SelectedProductType).ToString();
            BasicSetting.Instance.TB_BASIC_UNIT_PRICE.Text = price;

        }
        public void RefreshUnitPrice(object sender, EventArgs e)
        {
            RefreshUnitPrice();
        }
        public void ReFreshDataGridView()
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DatabaseHelper.Instance.GetAllProducts();
        
            BasicSetting.Instance.DATAVIEW.DataSource = bindingSource;


        }
        public void ReFreshDataGridView(object sender, EventArgs e)
        {

            ReFreshDataGridView();


        }


        public void LoadSelectedRow(object sender, DataGridViewCellEventArgs e)
        {
            Product product = ViewMGR.GetSelectedProduct(BasicSetting.Instance.DATAVIEW);


            switch (product.Material)
            {


                case "铁":
            BasicSetting.Instance.RB_IS_IRON.Checked = true;

                    BasicSetting.Instance.RB_IS_STAINLESS.Checked = false;
                    break;
                case "不锈钢":
                    BasicSetting.Instance.RB_IS_STAINLESS.Checked = true;
                    BasicSetting.Instance.RB_IS_IRON.Checked = false;
                    break;
            }
            BasicSetting.Instance.CB_PRODUCT_TYPE.Text = product.Type;
            BasicSetting.Instance.TB_BASIC_UNIT_PRICE.Text = product.UnitPrice.ToString();


        }
    }
}
