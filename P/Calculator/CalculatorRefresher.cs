﻿using System;
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

            string material = Calculator.Instance.CC_MATERIAL.Text;
            List<Product> products = ProductsInfoList.GetAllProductsByMaterial(material);
            List<string> productTypes = new List<string>();

            foreach (var item in products)
            {
                productTypes.Add(item.Type);
            }


            // 清空下拉框并加载新数据
            Calculator.Instance.CC_TYPE.Items.Clear();
            Calculator.Instance.CC_TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (Calculator.Instance.CC_TYPE.Items.Count > 0)
            {
                Calculator.Instance.CC_TYPE.SelectedIndex = 0;
            }


        }
        private void LoadComboBoxName()
        {
     
            string material = Calculator.Instance.CC_MATERIAL.Text;

            string type = Calculator.Instance.CC_TYPE.Text;
            List<CustomizedProduct> products = CustomizedProductsInfoList.GetAllProductsByMaterialAndType(material, type);
            List<string> names = new List<string>();

            foreach (var item in products)
            {
                names.Add(item.Property.ProductName);

            }


            // 清空下拉框并加载新数据
            Calculator.Instance.PRODUCT_NAME.Items.Clear();
            Calculator.Instance.PRODUCT_NAME.Items.AddRange(names.ToArray());

            // 默认选择第一项（如果有数据）
            if (Calculator.Instance.PRODUCT_NAME.Items.Count > 0)
            {
                Calculator.Instance.PRODUCT_NAME.SelectedIndex = 0;
            }
        

        }
    

        public void LoadProperty(object sender, EventArgs e)
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text, Calculator.Instance.PRODUCT_NAME.Text);

            Calculator.Instance.UNIT_PRICE.Text = product.UnitPrice.ToString();

            Calculator.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            Calculator.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            Calculator.Instance.SCREEN.Checked = product.Property.HasScreen;
            Calculator.Instance.POWDER.Checked = product.Property.IsPowder;
            Calculator.Instance.GOLD.Checked = product.Property.IsGold;
            Calculator.Instance.BRONZE.Checked = product.Property.IsBronze;
            Calculator.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            Calculator.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            Calculator.Instance.GLASS.Checked = product.Property.HasGlass;
            Calculator.Instance.CURVED.Checked = product.Property.HasCurved;
            Calculator.Instance.POLE.Checked = product.Property.HasPole;

            Calculator.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            Calculator.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            Calculator.Instance.HASLOCK.Checked = product.Property.HasLock;
            Calculator.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            Calculator.Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            Calculator.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            Calculator.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            Calculator.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            Calculator.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

        }
        public void LoadProperty()
        {
            CustomizedProduct product = CustomizedProductsInfoList.FindProductFirstOneByMaterialAndTypeAndName(Calculator.Instance.CC_MATERIAL.Text, Calculator.Instance.CC_TYPE.Text, Calculator.Instance.PRODUCT_NAME.Text);
            if (product == null) return;
            Calculator.Instance.UNIT_PRICE.Text = product.UnitPrice.ToString();

            Calculator.Instance.HASCLOSER.Checked = product.Property.HasCloser;
            Calculator.Instance.DOORINDOOR.Checked = product.Property.HasDoorInDoor;
            Calculator.Instance.SCREEN.Checked = product.Property.HasScreen;
            Calculator.Instance.POWDER.Checked = product.Property.IsPowder;
            Calculator.Instance.GOLD.Checked = product.Property.IsGold;
            Calculator.Instance.BRONZE.Checked = product.Property.IsBronze;
            Calculator.Instance.METALSHEET.Checked = product.Property.HasMetalSheet;
            Calculator.Instance.PLASTIC.Checked = product.Property.HasPlastic;
            Calculator.Instance.GLASS.Checked = product.Property.HasGlass;
            Calculator.Instance.CURVED.Checked = product.Property.HasCurved;
            Calculator.Instance.POLE.Checked = product.Property.HasPole;

            Calculator.Instance.POLE_PRICE.Text = product.Property.PolePrice.ToString();
            Calculator.Instance.POLE_QTY.Text = product.Property.PoleQty.ToString();

            Calculator.Instance.HASLOCK.Checked = product.Property.HasLock;
            Calculator.Instance.NORMAL_LOCK.Checked = product.Property.NormalLock;
            Calculator  .Instance.CODE_LOCK.Checked = product.Property.CodeLock;
            Calculator.Instance.FINGER_LOCK.Checked = product.Property.FingerLock;
            Calculator.Instance.AUTO_SWING.Checked = product.Property.HasAutoSwing;
            Calculator.Instance.AUTO_SLIDING.Checked = product.Property.HasAutoSliding;

            Calculator.Instance.DESIGN_PRICE.Text = product.Property.DesignPrice.ToString();

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
         
          
            Calculator.Instance.DATAVIEW.DataSource = bindingSource;

            List<string> names = ViewMGR.GetCheckedNamesFromCheckedListBox(Calculator.Instance.CheckListBoxCalculator);


            ViewMGR.OnlyShowColumnsByNames(Calculator.Instance.DATAVIEW, names);
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
    }
}
