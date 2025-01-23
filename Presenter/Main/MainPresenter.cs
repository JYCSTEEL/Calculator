using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace 计价器
{
    public class MainPresenter
    {
        public MainView View { get=> MainView.Instance; }
        private BasicPresenter BasicSetUpPresenter;
        private CustomizedPresenter CustomizedPresenter;
        private CalculatorPresenter CalculatorPresenter;
        private SetPricePresenter SetPricePresenter;
        private DatabaseHelper DatabaseHelper;

        public MainPresenter(MainView mainView)
        {
            IniatializeNumberTextBox();

            DatabaseHelper = DatabaseHelper.Instance;
            BasicSetUpPresenter = BasicPresenter.Instance;
            CustomizedPresenter = CustomizedPresenter.Instance;
            CalculatorPresenter = CalculatorPresenter.Instance;
            SetPricePresenter = SetPricePresenter.Instance;

            EventPublisher.OnProductListChangedEvent += CalculatorRefresher.Instance.LoadType;
            BindEvents();
            ConfigureDataGridView(BasicSetting.Instance.DATAVIEW);
            ConfigureDataGridView(CustomizedSetting.Instance.DATAVIEW);
            ConfigureDataGridView(CalculatorSetting.Instance.DATAVIEW);


        }

        public void BindEvents()
        {

            BasicSetting.Instance.DATAVIEW.CellClick += BasicRefresher.Instance.LoadSelectedRow;
            BasicSetting.Instance.BTN_NEW_PRODUCT_TYPE.Click += BasicRefresher.Instance.LoadData;
            BasicSetting.Instance.BTN_UPDATE_UNIT_PRICE.Click += BasicRefresher.Instance.LoadData;
            BasicSetting.Instance.BTN_DELETE_PRODUCT_TYPE.Click += BasicRefresher.Instance.LoadData;

            BasicSetting.Instance.BTN_NEW_PRODUCT_TYPE.Click += BasicRefresher.Instance.ReFreshDataGridView;
            BasicSetting.Instance.BTN_UPDATE_UNIT_PRICE.Click += BasicRefresher.Instance.ReFreshDataGridView;
            BasicSetting.Instance.BTN_DELETE_PRODUCT_TYPE.Click += BasicRefresher.Instance.ReFreshDataGridView;

            BasicSetting.Instance.RB_IS_IRON.CheckedChanged += BasicRefresher.Instance.LoadData;
            BasicSetting.Instance.RB_IS_STAINLESS.CheckedChanged += BasicRefresher.Instance.LoadData;
            BasicSetting.Instance.CB_PRODUCT_TYPE.SelectedIndexChanged += BasicRefresher.Instance.RefreshUnitPrice;


            BasicSetting.Instance.TB_BASIC_PRICE.KeyPress += TextBox_KeyPress;
            BasicSetting.Instance.TB_NEW_PRODUCT_UNIT_PRICE.KeyPress += TextBox_KeyPress;
            ////不输入默认为0
            ///
            BasicSetting.Instance.TB_BASIC_PRICE.Leave += TextBox_Leave;
            BasicSetting.Instance.TB_NEW_PRODUCT_UNIT_PRICE.Leave += TextBox_Leave;

           
            BasicSetting.Instance.BTN_NEW_PRODUCT_TYPE.Click += CustomizedPresenter.Instance.UpdateProductPrice;
            BasicSetting.Instance.BTN_UPDATE_UNIT_PRICE.Click += CustomizedPresenter.Instance.UpdateProductPrice;
            BasicSetting.Instance.BTN_DELETE_PRODUCT_TYPE.Click += CustomizedPresenter.Instance.UpdateProductPrice;
            BasicSetting.Instance.BTN_NEW_PRODUCT_TYPE.Click += CustomizedRefresher.Instance.LoadData;
            BasicSetting.Instance.BTN_UPDATE_UNIT_PRICE.Click += CustomizedRefresher.Instance.LoadData;
            BasicSetting.Instance.BTN_DELETE_PRODUCT_TYPE.Click += CustomizedRefresher.Instance.LoadData;

            //

            CustomizedSetting.Instance.BTN_ADD.Click += CustomizedRefresher.Instance.LoadData;
            CustomizedSetting.Instance.BTN_UPDATE.Click += CustomizedRefresher.Instance.LoadData;
            CustomizedSetting.Instance.BTN_DELETE.Click += CustomizedRefresher.Instance.LoadData;

            CustomizedSetting.Instance.BTN_ADD.Click += CalculatorRefresher.Instance.LoadData;
            CustomizedSetting.Instance.BTN_UPDATE.Click += CalculatorRefresher.Instance.LoadData;
            CustomizedSetting.Instance.BTN_DELETE.Click += CalculatorRefresher.Instance.LoadData;
            CustomizedSetting.Instance.BTN_ADD.Click += CustomizedRefresher.Instance.ReFreshDataGridView;
            CustomizedSetting.Instance.BTN_UPDATE.Click += CustomizedRefresher.Instance.ReFreshDataGridView;
            CustomizedSetting.Instance.BTN_DELETE.Click += CustomizedRefresher.Instance.ReFreshDataGridView;


            CustomizedSetting.Instance.MATERIAL.SelectedValueChanged += CustomizedRefresher.Instance.LoadType;
            CustomizedSetting.Instance.TYPE.SelectedValueChanged += CustomizedRefresher.Instance.LoadName;
            CustomizedSetting.Instance.CB_NAME.SelectedValueChanged += CustomizedRefresher.Instance.LoadProperty;

            CustomizedSetting.Instance.DESIGN_PRICE.KeyPress += TextBox_KeyPress;
            CustomizedSetting.Instance.POLE_PRICE.KeyPress += TextBox_KeyPress;
            CustomizedSetting.Instance.POLE_QTY.KeyPress += TextBox_KeyPress;
            ////不输入默认为0
            CustomizedSetting.Instance.DESIGN_PRICE.Leave += TextBox_Leave;
            CustomizedSetting.Instance.POLE_PRICE.Leave += TextBox_Leave;
            CustomizedSetting.Instance.POLE_QTY.Leave += TextBox_Leave;


            CustomizedSetting.Instance.CheckListBoxCustomized.SelectedValueChanged += CustomizedRefresher.Instance.ReFreshDataGridView;

            CustomizedSetting.Instance.CP_SELECT_ALL.CheckedChanged += CustomizedSelectAllCheckedList;
            CustomizedSetting.Instance.DATAVIEW.CellClick += CustomizedRefresher.Instance.LoadSelectedRow;

            CalculatorSetting.Instance.CC_MATERIAL.SelectedValueChanged += CalculatorRefresher.Instance.LoadType;
            CalculatorSetting.Instance.CC_TYPE.SelectedValueChanged += CalculatorRefresher.Instance.LoadName;
            CalculatorSetting.Instance.PRODUCT_NAME.SelectedValueChanged += CalculatorRefresher.Instance.LoadProperty;

            CalculatorSetting.Instance.BTN_ADD.Click += CalculatorRefresher.Instance.ReFreshDataGridView;
            CalculatorSetting.Instance.BTN_UPDATE.Click += CalculatorRefresher.Instance.ReFreshDataGridView;
            CalculatorSetting.Instance.BTN_DELETE.Click += CalculatorRefresher.Instance.ReFreshDataGridView;

            CalculatorSetting.Instance.WIDE_LENGTH.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.HEIGHT_DEEPTH.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.DESIGN_PRICE.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.POLE_QTY.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.POLE_PRICE.KeyPress += TextBox_KeyPress;
            CalculatorSetting.Instance.PRODUCT_QTY.KeyPress += TextBox_KeyPress;
            ////不输入默认为0

            CalculatorSetting.Instance.WIDE_LENGTH.Leave += TextBox_Leave;
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.Leave += TextBox_Leave;
            CalculatorSetting.Instance.HEIGHT_DEEPTH.Leave += TextBox_Leave;
            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Leave += TextBox_Leave;
            CalculatorSetting.Instance.DESIGN_PRICE.Leave += TextBox_Leave;
            CalculatorSetting.Instance.POLE_QTY.Leave += TextBox_Leave;
            CalculatorSetting.Instance.POLE_PRICE.Leave += TextBox_Leave;
            CalculatorSetting.Instance.PRODUCT_QTY.Leave += TextBox_Leave;

            CalculatorSetting.Instance.UNIT_PRICE.Leave += TextBox_Leave;

            CalculatorSetting.Instance.CheckListBoxCalculator.SelectedValueChanged += CalculatorRefresher.Instance.ReFreshDataGridView;
            CalculatorSetting.Instance.CC_SELECT_ALL.CheckedChanged += CalculatorSelectAllCheckedList;

            CalculatorSetting.Instance.DATAVIEW.CellClick += CalculatorRefresher.Instance.LoadSelectedRow;
        }

        private void CalculatorSelectAllCheckedList(object sender, EventArgs e)
        {
            if (CalculatorSetting.Instance.CC_SELECT_ALL.Checked)
            {

                ViewMGR.SelectAllCheckedListBox(CalculatorSetting.Instance.CheckListBoxCalculator);

            }
            else
            {
                ViewMGR.UnSelectAllCheckedListBox(CalculatorSetting.Instance.CheckListBoxCalculator);
            }
        }

        private void CustomizedSelectAllCheckedList(object sender, EventArgs e)
        {
          
            if (CustomizedSetting.Instance.CP_SELECT_ALL.Checked)
            {

                ViewMGR.SelectAllCheckedListBox(CustomizedSetting.Instance.CheckListBoxCustomized);
            }
            else
            {
                ViewMGR.UnSelectAllCheckedListBox(CustomizedSetting.Instance.CheckListBoxCustomized);
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否为数字或控制键（如退格键）
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // 禁止非数字输入
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // 如果输入框为空或仅包含空格，设置为默认值 0
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        private void IniatializeNumberTextBox()
        {
            BasicSetting.Instance.TB_BASIC_PRICE.Text = "0";
            BasicSetting.Instance.TB_NEW_PRODUCT_UNIT_PRICE.Text = "0";
            CustomizedSetting.Instance.DESIGN_PRICE.Text = "0";
            CustomizedSetting.Instance.POLE_PRICE.Text = "0";
            CustomizedSetting.Instance.POLE_QTY.Text = "0";
            CalculatorSetting.Instance.WIDE_LENGTH.Text = "0";
            CalculatorSetting.Instance.WIDE_LENGTH_FEET.Text = "0";
            CalculatorSetting.Instance.HEIGHT_DEEPTH.Text = "0";
            CalculatorSetting.Instance.HEIGHT_DEEPTH_FEET.Text = "0";
            CalculatorSetting.Instance.DESIGN_PRICE.Text = "0";
            CalculatorSetting.Instance.POLE_QTY.Text = "0";
            CalculatorSetting.Instance.POLE_PRICE.Text = "0";
            CalculatorSetting.Instance.PRODUCT_QTY.Text = "0";


            CalculatorSetting.Instance.SQFT.Text = "0";
            CalculatorSetting.Instance.DESIGN_QTY.Text = "0";
            CalculatorSetting.Instance.SINGLE_PRICE.Text = "0";
            CalculatorSetting.Instance.TOTAL_PRICE.Text = "0";
            CalculatorSetting.Instance.ALL_TOTAL_PRICE.Text = "0";
            CalculatorSetting.Instance.UNIT_PRICE.Text = "0";
        }
        private void ConfigureDataGridView(DataGridView dataGridView)
        {
            // 1. 设置只能选择一行
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false; // 禁用多选

            // 2. 设置列头颜色
            dataGridView.EnableHeadersVisualStyles = false; // 禁用系统样式
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // 背景色
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // 前景色（文字颜色）
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold); // 字体加粗

            // 3. 禁止列头选中样式变化
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            // 4. 隐藏行头
            dataGridView.RowHeadersVisible = false;

            // 5. 设置列宽自适应
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 6. 禁用用户调整列宽
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }

            // 7. 禁用用户调整行高
            dataGridView.AllowUserToResizeRows = false;

            // 8. 禁止单元格编辑
            dataGridView.ReadOnly = true;

            // 9. 禁止用户通过点击修改内容
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView.AllowUserToAddRows = false;

        }
    
    
    }
}
