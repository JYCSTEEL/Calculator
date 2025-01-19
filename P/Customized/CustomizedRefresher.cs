using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class CustomizedRefresher
    {
        private static readonly CustomizedRefresher _instance = new CustomizedRefresher();

        // 私有构造函数，防止外部实例化
        private CustomizedRefresher()
        {
            // 初始化逻辑（如果需要）
         
        }
        public static CustomizedRefresher Instance
        {
            get
            {
                return _instance;
            }
        }
        private void LoadComboBoxData()
        {

            string material = CustomizedSetting.Instance.MATERIAL.Text;
            List<CustomizedProduct> products = CustomizedProductsInfoList.GetAllProductsByMaterial(material);
            List<string> productTypes = new List<string> ();

            foreach (var item in products)
            {
                productTypes.Add(item.Type);

            }
           

            // 清空下拉框并加载新数据
            CustomizedSetting.Instance.TYPE.Items.Clear();
            CustomizedSetting.Instance.TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (CustomizedSetting.Instance.TYPE.Items.Count > 0)
            {
                CustomizedSetting.Instance.TYPE.SelectedIndex = 0;
            }
            string type = CustomizedSetting.Instance.TYPE.Text;
             products = CustomizedProductsInfoList.GetAllProductsByMaterialAndType(material,type);
            foreach (var item in products)
            {
                if (item != null)
                {
                    string name = item.Property.Name.ToString();
                    CustomizedSetting.Instance.CB_NAME.Text = name;
                }
                else
                {
                    string name = "0";
                    CustomizedSetting.Instance.CB_NAME.Text = name;
                }


            }


        }


        public void LoadData(object sender, EventArgs e)
        {
            LoadComboBoxData();
            ReFreshDataGridView();
        }
   
    
        private void ReFreshDataGridView()
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = CustomizedProductsInfoList.GetAllCustomizedProducts();
            CustomizedSetting.Instance.DATAVIEW.DataSource = bindingSource;

            CustomizedSetting.Instance.DATAVIEW.Columns[CustomizedSetting.Instance.DATAVIEW.Columns.Count - 1].Visible = false;

        }


    }
}
