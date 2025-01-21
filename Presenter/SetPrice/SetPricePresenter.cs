using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public class SetPricePresenter
    {
        // 静态字段，存储单例实例
        private static readonly SetPricePresenter _instance = new SetPricePresenter(SetPriceSetting.Instance);

        // 私有构造函数，防止外部实例化
        private SetPricePresenter(SetPriceSetting calculator )
        {

            // 初始化逻辑（如果需要）
            BindEvents();
            LoadTextBox();
        }

        private void LoadTextBox()
        {
            // 从数据库获取值并设置到文本框
            SetPriceSetting.Instance.SP_POWDER.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "烤漆");
            SetPriceSetting.Instance.SP_GOLD.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "金色");
            SetPriceSetting.Instance.SP_BRONZE.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "古铜色");
            SetPriceSetting.Instance.SP_METAL_SHEET.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "铁板");
            SetPriceSetting.Instance.SP_PLASITC.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "胶板");
            SetPriceSetting.Instance.SP_GALSS.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "玻璃");
            SetPriceSetting.Instance.SP_CURVE.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "弧形");
            SetPriceSetting.Instance.SP_NORMAL_LOCK.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "普通锁");
            SetPriceSetting.Instance.SP_FINGER_PRINT_LOCK.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "指纹锁");
            SetPriceSetting.Instance.SP_CODE_LOCK.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "密码锁");
            SetPriceSetting.Instance.SP_CLOSER.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "闭门器");
            SetPriceSetting.Instance.SP_DOORINDOOR.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "门中门");
            SetPriceSetting.Instance.SP_SCREEN.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "纱窗");
            SetPriceSetting.Instance.SP_SWING.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "电动双开");
            SetPriceSetting.Instance.SP_SLIDING.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "电动推拉");
            SetPriceSetting.Instance.SP_CLOSER.Text = DatabaseHelper.Instance.GetSingleValueAsString("设置单价表", "闭门器");
         
        }

        // 静态属性，用于获取单例实例
        public static SetPricePresenter Instance
        {
            get
            {
                return _instance;
            }
        }
        public void BindEvents()
        {
            SetPriceSetting.Instance.SP_BTN_UPDATE.Click += UpdateSetPriceToDataBase;
            SetPriceSetting.Instance.SP_BTN_LOAD.Click += LoadTextBox;

        }

        private void LoadTextBox(object sender, EventArgs e)
        {
            LoadTextBox();
            MessageBox.Show
             ("读取价格完成！");
        }

        private void UpdateSetPriceToDataBase(object sender, EventArgs e)
        {
            DatabaseHelper.Instance.UpdateSetPriceTable(
                Convert.ToDecimal(SetPriceSetting.Instance.SP_POWDER.Text),
                  Convert.ToDecimal(SetPriceSetting.Instance.SP_GOLD.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_BRONZE.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_METAL_SHEET.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_PLASITC.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_GALSS.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_CURVE.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_NORMAL_LOCK.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_FINGER_PRINT_LOCK.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_CODE_LOCK.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_CLOSER.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_DOORINDOOR.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_SCREEN.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_SWING.Text),
   Convert.ToDecimal(SetPriceSetting.Instance.SP_SLIDING.Text)

                );


            MessageBox.Show
             ("更新价格完成！");
        }

    
      

       
      

 
     
     
  
    }
}
