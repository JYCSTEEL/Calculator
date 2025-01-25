using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public static class ViewMGR
    {
        public static void OnlyShowColumnsByNames(DataGridView dataGridView, List<string> names)
        {
            // 遍历所有列
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                // 判断列标题是否包含 names 中的任意值
                bool shouldShow = false;
                foreach (string name in names)
                {
                    if (column.HeaderText==name)
                    {
                        shouldShow = true;
                        break; // 如果找到匹配项，停止内部循环
                    }
                }

                // 根据判断结果设置列的可见性
                column.Visible = shouldShow;
            }
        }



        public static CalculatorProduct GetSelectedCalculatorProduct(DataGridView dataGridView)
        {
            // 检查是否有选中行
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return null;
            }

            // 获取选中的行（第一行）
            DataGridViewRow selectedRow = dataGridView.CurrentRow;

            // 创建 CalculatorProduct 实例
            CalculatorProduct product = new CalculatorProduct
            {
                Material = selectedRow.Cells["材料"].Value.ToString(),
                Type = selectedRow.Cells["类型"].Value.ToString(),

                UnitPrice = Convert.ToDecimal(selectedRow.Cells["单价"].Value),
                DesignQty = Convert.ToDecimal(selectedRow.Cells["花样数量"].Value),
                SinglePrice = Convert.ToDecimal(selectedRow.Cells["单个产品价格"].Value),
                Qty = Convert.ToDecimal(selectedRow.Cells["产品数量"].Value),
                TotalPrice = Convert.ToDecimal(selectedRow.Cells["总共价格"].Value),

                WidthOrLength = Convert.ToDecimal(selectedRow.Cells["长度或宽度"].Value),
                WidthOrLengthFeet = Convert.ToDecimal(selectedRow.Cells["长度或宽度英尺"].Value),
                HeightOrDeepth = Convert.ToDecimal(selectedRow.Cells["高度或深度"].Value),
                HeightOrDeepthFeet = Convert.ToDecimal(selectedRow.Cells["高度或深度英尺"].Value),
                Sqft = Convert.ToDecimal(selectedRow.Cells["平方英尺"].Value),

                Property = new ProductProperty
                {
                    ProductName = selectedRow.Cells["名称"].Value.ToString(),
                    DesignPrice = Convert.ToDecimal(selectedRow.Cells["花样价格"].Value),
                    IsPowder = Convert.ToBoolean(selectedRow.Cells["烤漆"].Value),
                    IsGold = Convert.ToBoolean(selectedRow.Cells["金色"].Value),
                    IsBronze = Convert.ToBoolean(selectedRow.Cells["古铜色"].Value),
                    HasMetalSheet = Convert.ToBoolean(selectedRow.Cells["铁板"].Value),
                    HasPlastic = Convert.ToBoolean(selectedRow.Cells["胶板"].Value),
                    HasGlass = Convert.ToBoolean(selectedRow.Cells["玻璃"].Value),
                    HasCurved = Convert.ToBoolean(selectedRow.Cells["弧形"].Value),
                    HasLock = Convert.ToBoolean(selectedRow.Cells["有锁"].Value),
                    NormalLock = Convert.ToBoolean(selectedRow.Cells["普通锁"].Value),
                    FingerLock = Convert.ToBoolean(selectedRow.Cells["指纹锁"].Value),
                    CodeLock = Convert.ToBoolean(selectedRow.Cells["密码锁"].Value),
                    HasPole = Convert.ToBoolean(selectedRow.Cells["有柱子"].Value),
                    HasCloser = Convert.ToBoolean(selectedRow.Cells["有闭门器"].Value),
                    HasDoorInDoor = Convert.ToBoolean(selectedRow.Cells["门中门"].Value),
                    HasScreen = Convert.ToBoolean(selectedRow.Cells["纱窗"].Value),
                    HasAutoSwing = Convert.ToBoolean(selectedRow.Cells["电动双开"].Value),
                    HasAutoSliding = Convert.ToBoolean(selectedRow.Cells["电动推拉"].Value),
                    PolePrice = Convert.ToDecimal(selectedRow.Cells["柱子价格"].Value),
                    PoleQty = Convert.ToDecimal(selectedRow.Cells["柱子数量"].Value)
                }

            };

            return product;
        }

        public static Product GetSelectedProduct(DataGridView dataGridView)
        {
            // 检查是否有选中行
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return null;
            }

            // 获取选中的行（第一行）
            DataGridViewRow selectedRow = dataGridView.CurrentRow;

            // 创建 CalculatorProduct 实例
            Product product = new Product
            {
                Material = selectedRow.Cells["材料"].Value.ToString(),
                Type = selectedRow.Cells["类型"].Value.ToString(),
                UnitPrice = Convert.ToDecimal(selectedRow.Cells["单价"].Value)

            };

            return product;
        }
        public static CustomizedProduct GetSelectedCustomizedProduct(DataGridView dataGridView)
        {
            // 检查是否有选中行
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何一行数据！");
                return null;
            }

            // 获取选中的行（第一行）
            DataGridViewRow selectedRow = dataGridView.CurrentRow;
            // 创建 CalculatorProduct 实例
            CustomizedProduct product = new CustomizedProduct
            {
                Material = selectedRow.Cells["材料"].Value.ToString(),
                Type = selectedRow.Cells["类型"].Value.ToString(),
                UnitPrice = Convert.ToDecimal(selectedRow.Cells["单价"].Value),

                Property = new ProductProperty
                {
                    ProductName = selectedRow.Cells["名称"].Value.ToString(),
                    DesignPrice = Convert.ToDecimal(selectedRow.Cells["花样价格"].Value),
                    IsPowder = Convert.ToBoolean(selectedRow.Cells["烤漆"].Value),
                    IsGold = Convert.ToBoolean(selectedRow.Cells["金色"].Value),
                    IsBronze = Convert.ToBoolean(selectedRow.Cells["古铜色"].Value),
                    HasMetalSheet = Convert.ToBoolean(selectedRow.Cells["铁板"].Value),
                    HasPlastic = Convert.ToBoolean(selectedRow.Cells["胶板"].Value),
                    HasGlass = Convert.ToBoolean(selectedRow.Cells["玻璃"].Value),
                    HasCurved = Convert.ToBoolean(selectedRow.Cells["弧形"].Value),
                    HasLock = Convert.ToBoolean(selectedRow.Cells["有锁"].Value),
                    NormalLock = Convert.ToBoolean(selectedRow.Cells["普通锁"].Value),
                    FingerLock = Convert.ToBoolean(selectedRow.Cells["指纹锁"].Value),
                    CodeLock = Convert.ToBoolean(selectedRow.Cells["密码锁"].Value),
                    HasPole = Convert.ToBoolean(selectedRow.Cells["有柱子"].Value),
                    HasCloser = Convert.ToBoolean(selectedRow.Cells["有闭门器"].Value),
                    HasDoorInDoor = Convert.ToBoolean(selectedRow.Cells["门中门"].Value),
                    HasScreen = Convert.ToBoolean(selectedRow.Cells["纱窗"].Value),
                    HasAutoSwing = Convert.ToBoolean(selectedRow.Cells["电动双开"].Value),
                    HasAutoSliding = Convert.ToBoolean(selectedRow.Cells["电动推拉"].Value),
                    PolePrice = Convert.ToDecimal(selectedRow.Cells["柱子价格"].Value),
                    PoleQty = Convert.ToDecimal(selectedRow.Cells["柱子数量"].Value)
                }
            };

            return product;
        }

        /// <summary>
        /// 获得选中的名字 
        /// </summary>
        /// <param name="checkedListBox"></param>
        /// <returns></returns>
        public static List<string> GetCheckedNamesFromCheckedListBox(CheckedListBox checkedListBox)
        {
            // 获取所有被选中的项的文本
            List<string> selectedTexts = new List<string>();

            foreach (string  item in checkedListBox.CheckedItems)
            {
                selectedTexts.Add(item);

            }



            return selectedTexts;
        }

        /// <summary>
        /// 获得所有数据库中 某表 的 所有列名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetAllColumnsNamesFromDatabase(string tableName)
        {
            List<string> controlTexts = new List<string>();

            controlTexts = DatabaseHelper.Instance.GetTableColumnNames(tableName);

            return controlTexts;
        }

        public static void IniatialCheckedListBox(string table, CheckedListBox checkedListBox)
        {
            List<string> strings = new List<string>();
            strings = GetAllColumnsNamesFromDatabase(table);
            // 清空现有项
            checkedListBox.Items.Clear();

            // 添加新的项
            checkedListBox.Items.AddRange(strings.ToArray());
        

        }
        public static void SelectAllCheckedListBox(CheckedListBox checkedListBox)
        {
         
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }

            checkedListBox.SelectedIndex = 0;
        }
        public static void UnSelectAllCheckedListBox( CheckedListBox checkedListBox)
        {

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);

            }

            checkedListBox.SelectedIndex = -1;
        }
    }
}