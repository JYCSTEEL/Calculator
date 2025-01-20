using System;
using System.Collections.Generic;
using System.Data;
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
      

        }
        public static CustomizedRefresher Instance
        {
            get
            {
                return _instance;
            }
        }
    
        private void LoadComboBoxType()
        {

            string material = CustomizedSetting.Instance.MATERIAL.Text;
            List<Product> products = ProductsInfoList.GetAllProductsByMaterial(material);
            List<string> productTypes = new List<string>();

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
        

        }
        private void LoadComboBoxName()
        {

            string material = CustomizedSetting.Instance.MATERIAL.Text;

            string type = CustomizedSetting.Instance.TYPE.Text;
            List<CustomizedProduct> products = CustomizedProductsInfoList.GetAllProductsByMaterialAndType(material, type);
            List<string> names = new List<string>();

            foreach (var item in products)
            {
                names.Add(item.Property.ProductName);

            }


            // 清空下拉框并加载新数据
            CustomizedSetting.Instance.CB_NAME.Items.Clear();
            CustomizedSetting.Instance.CB_NAME.Items.AddRange(names.ToArray());

            // 默认选择第一项（如果有数据）
            if (CustomizedSetting.Instance.CB_NAME.Items.Count > 0)
            {
                CustomizedSetting.Instance.CB_NAME.SelectedIndex = 0;
            }
   

        }

        public void LoadProperty(object sender, EventArgs e)
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text);
            CustomizedSetting.Instance.TX_NAME.Text = product.Property.ProductName;
            CustomizedSetting.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            CustomizedSetting.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            CustomizedSetting.Instance.SCREEN.Checked = product.Property.HasScreen;
            CustomizedSetting.Instance.POWDER.Checked = product.Property.IsPowder;
            CustomizedSetting.Instance.GOLD.Checked = product.Property.IsGold;
            CustomizedSetting.Instance.BRONZE.Checked = product.Property.IsBronze;
            CustomizedSetting.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            CustomizedSetting.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            CustomizedSetting.Instance.GLASS.Checked = product.Property.HasGlass;
            CustomizedSetting.Instance.CURVED.Checked = product.Property.HasCurved;
            CustomizedSetting.Instance.POLE.Checked = product.Property.HasPole;

            CustomizedSetting.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            CustomizedSetting.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            CustomizedSetting.Instance.HASLOCK.Checked = product.Property.HasLock;
            CustomizedSetting.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            CustomizedSetting.Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            CustomizedSetting.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            CustomizedSetting.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            CustomizedSetting.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            CustomizedSetting.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

        }
        public void LoadProperty()
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CustomizedSetting.Instance.MATERIAL.Text, CustomizedSetting.Instance.TYPE.Text, CustomizedSetting.Instance.CB_NAME.Text);
            if (product == null) return;
            CustomizedSetting.Instance.TX_NAME.Text = product.Property.ProductName;
            CustomizedSetting.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            CustomizedSetting.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            CustomizedSetting.Instance.SCREEN.Checked = product.Property.HasScreen;
            CustomizedSetting.Instance.POWDER.Checked = product.Property.IsPowder;
            CustomizedSetting.Instance.GOLD.Checked = product.Property.IsGold;
            CustomizedSetting.Instance.BRONZE.Checked = product.Property.IsBronze;
            CustomizedSetting.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            CustomizedSetting.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            CustomizedSetting.Instance.GLASS.Checked = product.Property.HasGlass;
            CustomizedSetting.Instance.CURVED.Checked = product.Property.HasCurved;
            CustomizedSetting.Instance.POLE.Checked = product.Property.HasPole;

            CustomizedSetting.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            CustomizedSetting.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            CustomizedSetting.Instance.HASLOCK.Checked = product.Property.HasLock;
            CustomizedSetting.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            CustomizedSetting.Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            CustomizedSetting.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            CustomizedSetting.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            CustomizedSetting.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            CustomizedSetting.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

        }

        public void LoadType(object sender, EventArgs e)
        {
            LoadComboBoxType();

            ReFreshDataGridView();
        }
        public void LoadName(object sender, EventArgs e)
        {
            LoadComboBoxName();
            ReFreshDataGridView();
        }
        public void LoadData(object sender, EventArgs e)
        {
            LoadComboBoxType();

            LoadComboBoxName();

            LoadProperty();
            ReFreshDataGridView();
        }

        private void ReFreshDataGridView()
        {

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DatabaseHelper.Instance.GetAllCustomizedProducts();
         
          
            CustomizedSetting.Instance.DATAVIEW.DataSource = bindingSource;
            DataTable dt = bindingSource.DataSource as DataTable;

            string[] names = new string[] { "材料", "类型", "名称", "单价", "粉末涂层", "金色", "古铜色", "含金属板", "含塑料", "含玻璃", "含弯曲" };

            //材料, 类型, 名称, 单价, 长度或宽度, 高度或深度, 长度或宽度英尺, 高度或深度英尺, 平方英尺, 设计价格, 设计数量, 
            //                    粉末涂层, 金色, 古铜色, 
            //                    含金属板, 含塑料, 含玻璃, 含弯曲, 含锁, 普通锁, 指纹锁, 密码锁, 
            //                    含柱子, 含闭门器, 含门中门, 含屏风, 含自动摆动, 含自动滑动, 
            //                    柱子价格, 柱子数量
            DatagridviewMGR.SetDataTableOnlyShow(CustomizedSetting.Instance.DATAVIEW, dt, names);
        }

        public void LoadType()
        {
            LoadComboBoxType();

            ReFreshDataGridView();
        }
        public void LoadName()
        {
            LoadComboBoxName();

            ReFreshDataGridView();
        }
        public void LoadData()
        {
            LoadComboBoxType();
            LoadComboBoxName();
            LoadProperty();
            ReFreshDataGridView();
        }
    }
}
