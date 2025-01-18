using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            List<string> productTypes = DatabaseHelper.Instance.GetAllProductTypes();

            // 清空下拉框并加载新数据
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Clear();
            BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.AddRange(productTypes.ToArray());

            // 默认选择第一项（如果有数据）
            if (BasicSetUp.Instance.CB_PRODUCT_TYPE.Items.Count > 0)
            {
                BasicSetUp.Instance.CB_PRODUCT_TYPE.SelectedIndex = 0;
            }
            string type = BasicSetUp.Instance.CB_PRODUCT_TYPE.Text;
            string price = DatabaseHelper.Instance.GetUnitPriceByType(type).ToString();
            BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text = price;

        }
        private int VerifyInput(string type, string unitPriceInput)
        {
            int number = 0;
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return number;
            }
            // 检查单价是否为有效的数字
            if (!int.TryParse(unitPriceInput, out  number))
            {
                MessageBox.Show("单价必须是一个有效的整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return number;
            }

            if (number <= 0)
            {
                MessageBox.Show("单价必须大于 0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return number;
            }
            return number;
        }
        public void BindEvents()
        {
            BasicSetUp.Instance.BTN_NEW_PRODUCT_TYPE.Click += BTN_NEW_PRODUCT_TYPE_Click;
            BasicSetUp.Instance.BTN_UPDATE_UNIT_PRICE.Click += BTN_UPDATE_UNIT_PRICE_Click;
            BasicSetUp.Instance.BTN_DELETE_PRODUCT_TYPE.Click += BTN_DELETE_PRODUCT_TYPE_Click;
            BasicSetUp.Instance.BTN_NEW_PRODUCT_TYPE.Click += LoadData;
            BasicSetUp.Instance.BTN_UPDATE_UNIT_PRICE.Click += LoadData;
            BasicSetUp.Instance.BTN_DELETE_PRODUCT_TYPE.Click += LoadData;

        }

        private void LoadData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BTN_UPDATE_UNIT_PRICE_Click(object sender, EventArgs e)
        {
            string material = BasicSetUp.Instance.RB_IS_IRON.Text;

            string type = BasicSetUp.Instance.CB_PRODUCT_TYPE.Text;
            string price = BasicSetUp.Instance.TB_BASIC_UNIT_PRICE.Text;
            int unitPrice = VerifyInput( type, price);

            DatabaseHelper.Instance.UpdateProductPrice(material, type, unitPrice);
        }

        private void BTN_DELETE_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {

            string material = BasicSetUp.Instance.RB_IS_IRON.Text;

            string type = BasicSetUp.Instance.CB_PRODUCT_TYPE.Text;
            DatabaseHelper.Instance.DeleteProduct(material, type);
        }

        private void BTN_NEW_PRODUCT_TYPE_Click(object sender, EventArgs e)
        {
            bool isIron = BasicSetUp.Instance.IsIronSelected;

            string material = BasicSetUp.Instance.RB_IS_IRON.Text;
            if (!isIron)
            {
                 material = BasicSetUp.Instance.RB_IS_STAINLESS.Text;
            }

            string type = BasicSetUp.Instance.TB_NEW_PRODUCT_TYPE.Text;
            string unitPriceInput = BasicSetUp.Instance.TB_NEW_PRODUCT_UNIT_PRICE.Text;
            int unitPrice = VerifyInput( type, unitPriceInput);

            // 调用数据库助手的插入方法
            DatabaseHelper.Instance.InsertProduct(material, type, unitPrice);
        }
    }
}
