using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class CalculatorRefresher
    {
        private static readonly CalculatorRefresher _instance = new CalculatorRefresher();

        // 私有构造函数，防止外部实例化
        private CalculatorRefresher()
        {
      

        }
        public static CalculatorRefresher Instance
        {
            get
            {
                return _instance;
            }
        }

        private void LoadComboBoxType()
        {

            string material = CalculatorSetting.Instance.CC_MATERIAL.Text;
            List<Product> products = ProductsInfoList.GetAllProductsByMaterial(material);
            List<string> productTypes = new List<string>();

            foreach (var item in products)
            {
                productTypes.Add(item.Type);
            }


            // 清空下拉框并加载新数据
            CalculatorSetting.Instance.CC_TYPE.Items.Clear();
            CalculatorSetting.Instance.CC_TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (CalculatorSetting.Instance.CC_TYPE.Items.Count > 0)
            {
                CalculatorSetting.Instance.CC_TYPE.SelectedIndex = 0;
            }


        }
        private void LoadComboBoxName()
        {
     
            string material = CalculatorSetting.Instance.CC_MATERIAL.Text;

            string type = CalculatorSetting.Instance.CC_TYPE.Text;
            List<CustomizedProduct> products = CustomizedProductsInfoList.GetAllProductsByMaterialAndType(material, type);
            List<string> names = new List<string>();

            foreach (var item in products)
            {
                names.Add(item.Property.ProductName);

            }


            // 清空下拉框并加载新数据
            CalculatorSetting.Instance.PRODUCT_NAME.Items.Clear();
            CalculatorSetting.Instance.PRODUCT_NAME.Items.AddRange(names.ToArray());

            // 默认选择第一项（如果有数据）
            if (CalculatorSetting.Instance.PRODUCT_NAME.Items.Count > 0)
            {
                CalculatorSetting.Instance.PRODUCT_NAME.SelectedIndex = 0;
            }
        

        }
    

        public void LoadProperty(object sender, EventArgs e)
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CalculatorSetting.Instance.CC_MATERIAL.Text, CalculatorSetting.Instance.CC_TYPE.Text, CalculatorSetting.Instance.PRODUCT_NAME.Text);

            CalculatorSetting.Instance.UNIT_PRICE.Text = product.UnitPrice.ToString();

            CalculatorSetting.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            CalculatorSetting.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            CalculatorSetting.Instance.SCREEN.Checked = product.Property.HasScreen;
            CalculatorSetting.Instance.POWDER.Checked = product.Property.IsPowder;
            CalculatorSetting.Instance.GOLD.Checked = product.Property.IsGold;
            CalculatorSetting.Instance.BRONZE.Checked = product.Property.IsBronze;
            CalculatorSetting.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            CalculatorSetting.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            CalculatorSetting.Instance.GLASS.Checked = product.Property.HasGlass;
            CalculatorSetting.Instance.CURVED.Checked = product.Property.HasCurved;
            CalculatorSetting.Instance.POLE.Checked = product.Property.HasPole;

            CalculatorSetting.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            CalculatorSetting.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            CalculatorSetting.Instance.HASLOCK.Checked = product.Property.HasLock;
            CalculatorSetting.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            CalculatorSetting.Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            CalculatorSetting.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            CalculatorSetting.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            CalculatorSetting.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            CalculatorSetting.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

        }
        public void LoadProperty()
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(CalculatorSetting.Instance.CC_MATERIAL.Text, CalculatorSetting.Instance.CC_TYPE.Text, CalculatorSetting.Instance.PRODUCT_NAME.Text);
            if (product == null) return;
            CalculatorSetting.Instance.UNIT_PRICE.Text = product.UnitPrice.ToString();

            CalculatorSetting.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            CalculatorSetting.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            CalculatorSetting.Instance.SCREEN.Checked = product.Property.HasScreen;
            CalculatorSetting.Instance.POWDER.Checked = product.Property.IsPowder;
            CalculatorSetting.Instance.GOLD.Checked = product.Property.IsGold;
            CalculatorSetting.Instance.BRONZE.Checked = product.Property.IsBronze;
            CalculatorSetting.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            CalculatorSetting.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            CalculatorSetting.Instance.GLASS.Checked = product.Property.HasGlass;
            CalculatorSetting.Instance.CURVED.Checked = product.Property.HasCurved;
            CalculatorSetting.Instance.POLE.Checked = product.Property.HasPole;

            CalculatorSetting.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            CalculatorSetting.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            CalculatorSetting.Instance.HASLOCK.Checked = product.Property.HasLock;
            CalculatorSetting.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            CalculatorSetting  .Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            CalculatorSetting.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            CalculatorSetting.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            CalculatorSetting.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            CalculatorSetting.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

        }

        public void LoadType(object sender, EventArgs e)
        {
            LoadComboBoxType();

        }
        public void LoadName(object sender, EventArgs e)
        {
            LoadComboBoxName();
        }
        public void LoadData(object sender, EventArgs e)
        {
            LoadComboBoxType();

            LoadComboBoxName();

            LoadProperty();
        }

        public void ReFreshDataGridView()
        {
         
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DatabaseHelper.Instance.GetAllCalculatorProducts();
         
          
            CalculatorSetting.Instance.DATAVIEW.DataSource = bindingSource;

            List<string> names = ViewMGR.GetCheckedNamesFromCheckedListBox(CalculatorSetting.Instance.CheckListBoxCalculator);

            ViewMGR.OnlyShowColumnsByNames(CalculatorSetting.Instance.DATAVIEW, names);

        
        }
   
        public void LoadType()
        {
            LoadComboBoxType();

        }
        public void LoadName()
        {
            LoadComboBoxName();

        }
        public void LoadData()
        {
            LoadComboBoxType();
            LoadComboBoxName();
            LoadProperty();
        }

        public void ReFreshDataGridView(object sender, EventArgs e)
        {
            ReFreshDataGridView();
        }
        public void LoadSelectedRow(object sender, DataGridViewCellEventArgs e)
        {
            CalculatorProduct product = ViewMGR.GetSelectedCalculatorProduct(CalculatorSetting.Instance.DATAVIEW);

            CalculatorSetting.Instance.CC_MATERIAL.Text = product.Material;
            CalculatorSetting.Instance.CC_TYPE.Text = product.Type;
            CalculatorSetting.Instance.PRODUCT_NAME.Text = product.Property.ProductName;
            CalculatorSetting.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();
            CalculatorSetting.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            CalculatorSetting.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();


            CalculatorSetting.Instance.HASCLOSER.Checked = product.Property.HasCloser;

            CalculatorSetting.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;


            CalculatorSetting.Instance.SCREEN.Checked = product.Property.HasScreen;
            CalculatorSetting.Instance.POWDER.Checked = product.Property.IsPowder;
            CalculatorSetting.Instance.GOLD.Checked = product.Property.IsGold;
            CalculatorSetting.Instance.BRONZE.Checked = product.Property.IsBronze;
            CalculatorSetting.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            CalculatorSetting.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            CalculatorSetting.Instance.GLASS.Checked = product.Property.HasGlass;

            CalculatorSetting.Instance.CURVED.Checked = product.Property.HasCurved;
            CalculatorSetting.Instance.POLE.Checked = product.Property.HasPole;
            CalculatorSetting.Instance.HASLOCK.Checked = product.Property.HasLock;
            CalculatorSetting.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            CalculatorSetting.Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            CalculatorSetting.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;

            CalculatorSetting.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            CalculatorSetting.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            CalculatorSetting.Instance.SINGLE_PRICE.Text = product.SinglePrice.ToString();
            CalculatorSetting.Instance.PRODUCT_QTY.Text = product.Qty.ToString();

            CalculatorSetting.Instance.TOTAL_PRICE.Text = product.TotalPrice.ToString();

            CalculatorSetting.Instance.DESIGN_QTY.Text = product.DesignQty.ToString();

            CalculatorSetting.Instance.WIDE_LENGTH.Text = product.WidthOrLength.ToString();
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text = product.WidthOrLengthFeet.ToString();

            CalculatorSetting.Instance.HEIGHT_DEEPTH.Text = product.HeightOrDeepth.ToString();

            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text = product.HeightOrDeepthFeet.ToString();


            CalculatorSetting.Instance.SQFT.Text = product.Sqft.ToString();



        }
    }
}
