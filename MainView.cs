using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计价器
{
    public partial class MainView : Form
    {
        public string ProductType { get=> comboBoxProduct.Text; set=> comboBoxProduct.Text = value; }
        public int UnitPrice { get => Convert.ToInt32( textBoxUnitPrice.Text); set => textBoxUnitPrice.Text = value.ToString(); }
        public int LengthWidthInch { get => Convert.ToInt32(textBoxLengthWidth.Text); set => textBoxLengthWidth.Text = value.ToString(); }
        public int LengthWidthFeet { get => Convert.ToInt32(textBoxLengthWidthFeet.Text); set => textBoxLengthWidthFeet.Text = value.ToString(); }
        public int HeightDeepthInch { get => Convert.ToInt32(textBoxHeightDeepth.Text); set => textBoxHeightDeepth.Text = value.ToString(); }
        public int HeightDeepthFeet { get => Convert.ToInt32(textBoxHeightDeepthFeet.Text); set => textBoxHeightDeepthFeet.Text = value.ToString(); }
        public int Sqft { get => Convert.ToInt32(textBoxSqft.Text); set => textBoxSqft.Text = value.ToString(); }
        public int PoleQty { get => Convert.ToInt32(textBoxPoleQty.Text); set => textBoxPoleQty.Text = value.ToString(); }
        public int DesignUnitPrice { get => Convert.ToInt32(textBoxDesignUnitPrice.Text); set => textBoxDesignUnitPrice.Text = value.ToString(); }
        public int PredictDesignQty { get => Convert.ToInt32(textBoxPredictQtyOfDesign.Text); set => textBoxPredictQtyOfDesign.Text = value.ToString(); }
        public bool HasPole { get => checkBoxPole.Checked; set => checkBoxPole.Checked = value; }
        public bool IsPowderCoating { get => checkBoxPowderCoating.Checked; set => checkBoxPowderCoating.Checked = value; }
        public bool IsBronze { get => checkBoxBronze.Checked; set => checkBoxBronze.Checked = value; }
        public bool IsGold { get => checkBoxGold.Checked; set => checkBoxGold.Checked = value; }
        public bool HasGlass { get => checkBoxGlass.Checked; set => checkBoxGlass.Checked = value; }
        public bool HasScreen { get => checkBoxScreen.Checked; set => checkBoxPole.Checked = value; }
        public bool HasPlastic { get => checkBoxPlastic.Checked; set => checkBoxPlastic.Checked = value; }
        public bool HasMetalSheet { get => checkBoxMetalSheet.Checked; set => checkBoxMetalSheet.Checked = value; }
        public bool HasCurve { get => checkBoxCurve.Checked; set => checkBoxCurve.Checked = value; }
        public bool HasCloser { get => checkBoxCloser.Checked; set => checkBoxCloser.Checked = value; }

        public bool HasLock { get => checkBoxHasLock.Checked; set => checkBoxHasLock.Checked = value; }
        public bool IsNormalLock { get => checkBoxNormalLock.Checked; set => checkBoxNormalLock.Checked = value; }

        public bool IsCodeLock { get => checkBoxCodeLock.Checked; set => checkBoxCodeLock.Checked = value; }

        public bool IsFingerPrintLock { get => checkBoxFingerPrintLock.Checked; set => checkBoxFingerPrintLock.Checked = value; }





        public MainView()
        {
            InitializeComponent();
        }

    }
}
