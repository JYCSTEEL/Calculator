using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public  class Controls
    {
        protected MainView mainView;
        public Controls()
        {
            mainView = MainView.Instance;
            Iniatialize();
        }
   

        private void Iniatialize()
        {
            List<ComboBox> controls = GetAllComboBoxes( mainView.MadecimalabControl);
            IniatializeComboBox(controls);
        }

        private void IniatializeComboBox(List<ComboBox> combobox) { 
        
            foreach (ComboBox c in combobox)
            {

                c.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private List<ComboBox> GetAllComboBoxes(Control parent)
        {
            List<ComboBox> comboBoxes = new List<ComboBox>();

            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBoxes.Add(comboBox);
                }

                // 如果控件是容器控件，递归检查子控件
                if (control.HasChildren)
                {
                    comboBoxes.AddRange(GetAllComboBoxes(control));
                }
            }

            return comboBoxes;
        }

        public void Clear(Control control)
        {
            Type type = control.GetType();
            if (type == typeof (TextBox))
            {
                control.Text = "";
            }else if(type == typeof(ComboBox)){
                ComboBox cb = (ComboBox) control;
                cb.SelectedIndex = 0;
            }else if (type == typeof(RadioButton))
            {
                RadioButton rb = (RadioButton) control;
                rb.Checked = false;
            }
            else if (type == typeof(CheckBox))
            {
                CheckBox cb = (CheckBox)control;
                cb.Checked = false;
            }
        }
      
    }
}
