using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public static class DatagridviewMGR
    {
        public static void HideColumnsByNames(DataGridView dataGridView, DataTable yourDataSource, List<string> names)
        {
            dataGridView.DataSource = yourDataSource;


            // 遍历所有列，隐藏不需要的
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                foreach (string name in names)
                {
                    if (column.Name == name)
                    {
                        column.Visible = false; // 隐藏列
                    }
                }

            }

        }
        public static void HideColumnsByName(DataGridView dataGridView, DataTable yourDataSource, string name)
        {
            dataGridView.DataSource = yourDataSource;


            // 遍历所有列，隐藏不需要的
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {

                if (column.Name == name)
                {
                    column.Visible = false; // 隐藏列
                }


            }

        }


        public static void SetDataTableOnlyShow(DataGridView dataGridView, DataTable yourDataSource, params string[] names)
        {// 从原始 DataTable 创建一个新的包含特定列的 DataTable
            DataTable filteredTable = yourDataSource.DefaultView.ToTable(false, names);
            // 绑定到 DataGridView
            dataGridView.DataSource = filteredTable;


        }
    }
}
