namespace 计价器
{
    partial class MainView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLengthWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeightDeepth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSqft = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCalculate = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPredictQtyOfDesign = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxDesignUnitPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxHeightDeepthFeet = new System.Windows.Forms.TextBox();
            this.textBoxLengthWidthFeet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPoleQty = new System.Windows.Forms.TextBox();
            this.checkBoxFingerPrintLock = new System.Windows.Forms.CheckBox();
            this.checkBoxCodeLock = new System.Windows.Forms.CheckBox();
            this.checkBoxNormalLock = new System.Windows.Forms.CheckBox();
            this.checkBoxCloser = new System.Windows.Forms.CheckBox();
            this.checkBoxDoorInDoor = new System.Windows.Forms.CheckBox();
            this.checkBoxCurve = new System.Windows.Forms.CheckBox();
            this.checkBoxPole = new System.Windows.Forms.CheckBox();
            this.checkBoxMetalSheet = new System.Windows.Forms.CheckBox();
            this.checkBoxPlastic = new System.Windows.Forms.CheckBox();
            this.checkBoxScreen = new System.Windows.Forms.CheckBox();
            this.checkBoxGlass = new System.Windows.Forms.CheckBox();
            this.checkBoxGold = new System.Windows.Forms.CheckBox();
            this.checkBoxBronze = new System.Windows.Forms.CheckBox();
            this.checkBoxPowderCoating = new System.Windows.Forms.CheckBox();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.checkBoxHasLock = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.tabPageCalculate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品";
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(76, 6);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(49, 20);
            this.comboBoxProduct.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "宽度/长度";
            // 
            // textBoxLengthWidth
            // 
            this.textBoxLengthWidth.Location = new System.Drawing.Point(76, 60);
            this.textBoxLengthWidth.Name = "textBoxLengthWidth";
            this.textBoxLengthWidth.Size = new System.Drawing.Size(48, 21);
            this.textBoxLengthWidth.TabIndex = 3;
            // 
            // textBoxHeightDeepth
            // 
            this.textBoxHeightDeepth.Location = new System.Drawing.Point(76, 87);
            this.textBoxHeightDeepth.Name = "textBoxHeightDeepth";
            this.textBoxHeightDeepth.Size = new System.Drawing.Size(48, 21);
            this.textBoxHeightDeepth.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "高度/深度";
            // 
            // textBoxSqft
            // 
            this.textBoxSqft.Location = new System.Drawing.Point(76, 114);
            this.textBoxSqft.Name = "textBoxSqft";
            this.textBoxSqft.ReadOnly = true;
            this.textBoxSqft.Size = new System.Drawing.Size(48, 21);
            this.textBoxSqft.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "平方英尺";
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.Location = new System.Drawing.Point(76, 32);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.ReadOnly = true;
            this.textBoxUnitPrice.Size = new System.Drawing.Size(48, 21);
            this.textBoxUnitPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "每平方单价";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCalculate);
            this.tabControl.Controls.Add(this.tabPageSetting);
            this.tabControl.Location = new System.Drawing.Point(12, 7);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 431);
            this.tabControl.TabIndex = 10;
            // 
            // tabPageCalculate
            // 
            this.tabPageCalculate.Controls.Add(this.groupBox3);
            this.tabPageCalculate.Controls.Add(this.groupBox2);
            this.tabPageCalculate.Controls.Add(this.groupBox1);
            this.tabPageCalculate.Controls.Add(this.label12);
            this.tabPageCalculate.Controls.Add(this.textBoxPredictQtyOfDesign);
            this.tabPageCalculate.Controls.Add(this.label11);
            this.tabPageCalculate.Controls.Add(this.textBoxDesignUnitPrice);
            this.tabPageCalculate.Controls.Add(this.label10);
            this.tabPageCalculate.Controls.Add(this.label8);
            this.tabPageCalculate.Controls.Add(this.label9);
            this.tabPageCalculate.Controls.Add(this.textBoxHeightDeepthFeet);
            this.tabPageCalculate.Controls.Add(this.textBoxLengthWidthFeet);
            this.tabPageCalculate.Controls.Add(this.label7);
            this.tabPageCalculate.Controls.Add(this.label6);
            this.tabPageCalculate.Controls.Add(this.textBoxPoleQty);
            this.tabPageCalculate.Controls.Add(this.checkBoxPole);
            this.tabPageCalculate.Controls.Add(this.comboBoxProduct);
            this.tabPageCalculate.Controls.Add(this.textBoxUnitPrice);
            this.tabPageCalculate.Controls.Add(this.label1);
            this.tabPageCalculate.Controls.Add(this.label5);
            this.tabPageCalculate.Controls.Add(this.label2);
            this.tabPageCalculate.Controls.Add(this.textBoxSqft);
            this.tabPageCalculate.Controls.Add(this.textBoxLengthWidth);
            this.tabPageCalculate.Controls.Add(this.label4);
            this.tabPageCalculate.Controls.Add(this.label3);
            this.tabPageCalculate.Controls.Add(this.textBoxHeightDeepth);
            this.tabPageCalculate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalculate.Name = "tabPageCalculate";
            this.tabPageCalculate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalculate.Size = new System.Drawing.Size(768, 405);
            this.tabPageCalculate.TabIndex = 0;
            this.tabPageCalculate.Text = "计算器";
            this.tabPageCalculate.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "预计个数";
            // 
            // textBoxPredictQtyOfDesign
            // 
            this.textBoxPredictQtyOfDesign.Location = new System.Drawing.Point(76, 195);
            this.textBoxPredictQtyOfDesign.Name = "textBoxPredictQtyOfDesign";
            this.textBoxPredictQtyOfDesign.ReadOnly = true;
            this.textBoxPredictQtyOfDesign.Size = new System.Drawing.Size(48, 21);
            this.textBoxPredictQtyOfDesign.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "花样单价";
            // 
            // textBoxDesignUnitPrice
            // 
            this.textBoxDesignUnitPrice.Location = new System.Drawing.Point(76, 168);
            this.textBoxDesignUnitPrice.Name = "textBoxDesignUnitPrice";
            this.textBoxDesignUnitPrice.Size = new System.Drawing.Size(48, 21);
            this.textBoxDesignUnitPrice.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "根";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "尺";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "尺";
            // 
            // textBoxHeightDeepthFeet
            // 
            this.textBoxHeightDeepthFeet.Location = new System.Drawing.Point(166, 87);
            this.textBoxHeightDeepthFeet.Name = "textBoxHeightDeepthFeet";
            this.textBoxHeightDeepthFeet.Size = new System.Drawing.Size(48, 21);
            this.textBoxHeightDeepthFeet.TabIndex = 28;
            // 
            // textBoxLengthWidthFeet
            // 
            this.textBoxLengthWidthFeet.Location = new System.Drawing.Point(166, 60);
            this.textBoxLengthWidthFeet.Name = "textBoxLengthWidthFeet";
            this.textBoxLengthWidthFeet.Size = new System.Drawing.Size(48, 21);
            this.textBoxLengthWidthFeet.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(131, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "英寸";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "英寸";
            // 
            // textBoxPoleQty
            // 
            this.textBoxPoleQty.Location = new System.Drawing.Point(76, 141);
            this.textBoxPoleQty.Name = "textBoxPoleQty";
            this.textBoxPoleQty.Size = new System.Drawing.Size(48, 21);
            this.textBoxPoleQty.TabIndex = 24;
            // 
            // checkBoxFingerPrintLock
            // 
            this.checkBoxFingerPrintLock.AutoSize = true;
            this.checkBoxFingerPrintLock.Location = new System.Drawing.Point(85, 46);
            this.checkBoxFingerPrintLock.Name = "checkBoxFingerPrintLock";
            this.checkBoxFingerPrintLock.Size = new System.Drawing.Size(60, 16);
            this.checkBoxFingerPrintLock.TabIndex = 23;
            this.checkBoxFingerPrintLock.Text = "指纹锁";
            this.checkBoxFingerPrintLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxCodeLock
            // 
            this.checkBoxCodeLock.AutoSize = true;
            this.checkBoxCodeLock.Location = new System.Drawing.Point(151, 46);
            this.checkBoxCodeLock.Name = "checkBoxCodeLock";
            this.checkBoxCodeLock.Size = new System.Drawing.Size(60, 16);
            this.checkBoxCodeLock.TabIndex = 22;
            this.checkBoxCodeLock.Text = "机械锁";
            this.checkBoxCodeLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxNormalLock
            // 
            this.checkBoxNormalLock.AutoSize = true;
            this.checkBoxNormalLock.Location = new System.Drawing.Point(19, 46);
            this.checkBoxNormalLock.Name = "checkBoxNormalLock";
            this.checkBoxNormalLock.Size = new System.Drawing.Size(60, 16);
            this.checkBoxNormalLock.TabIndex = 21;
            this.checkBoxNormalLock.Text = "普通锁";
            this.checkBoxNormalLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxCloser
            // 
            this.checkBoxCloser.AutoSize = true;
            this.checkBoxCloser.Location = new System.Drawing.Point(19, 20);
            this.checkBoxCloser.Name = "checkBoxCloser";
            this.checkBoxCloser.Size = new System.Drawing.Size(60, 16);
            this.checkBoxCloser.TabIndex = 20;
            this.checkBoxCloser.Text = "闭门器";
            this.checkBoxCloser.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoorInDoor
            // 
            this.checkBoxDoorInDoor.AutoSize = true;
            this.checkBoxDoorInDoor.Location = new System.Drawing.Point(85, 20);
            this.checkBoxDoorInDoor.Name = "checkBoxDoorInDoor";
            this.checkBoxDoorInDoor.Size = new System.Drawing.Size(60, 16);
            this.checkBoxDoorInDoor.TabIndex = 19;
            this.checkBoxDoorInDoor.Text = "门中门";
            this.checkBoxDoorInDoor.UseVisualStyleBackColor = true;
            // 
            // checkBoxCurve
            // 
            this.checkBoxCurve.AutoSize = true;
            this.checkBoxCurve.Location = new System.Drawing.Point(21, 64);
            this.checkBoxCurve.Name = "checkBoxCurve";
            this.checkBoxCurve.Size = new System.Drawing.Size(48, 16);
            this.checkBoxCurve.TabIndex = 18;
            this.checkBoxCurve.Text = "弧形";
            this.checkBoxCurve.UseVisualStyleBackColor = true;
            // 
            // checkBoxPole
            // 
            this.checkBoxPole.AutoSize = true;
            this.checkBoxPole.Location = new System.Drawing.Point(20, 143);
            this.checkBoxPole.Name = "checkBoxPole";
            this.checkBoxPole.Size = new System.Drawing.Size(48, 16);
            this.checkBoxPole.TabIndex = 17;
            this.checkBoxPole.Text = "大柱";
            this.checkBoxPole.UseVisualStyleBackColor = true;
            // 
            // checkBoxMetalSheet
            // 
            this.checkBoxMetalSheet.AutoSize = true;
            this.checkBoxMetalSheet.Location = new System.Drawing.Point(21, 42);
            this.checkBoxMetalSheet.Name = "checkBoxMetalSheet";
            this.checkBoxMetalSheet.Size = new System.Drawing.Size(48, 16);
            this.checkBoxMetalSheet.TabIndex = 16;
            this.checkBoxMetalSheet.Text = "铁板";
            this.checkBoxMetalSheet.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlastic
            // 
            this.checkBoxPlastic.AutoSize = true;
            this.checkBoxPlastic.Location = new System.Drawing.Point(87, 42);
            this.checkBoxPlastic.Name = "checkBoxPlastic";
            this.checkBoxPlastic.Size = new System.Drawing.Size(48, 16);
            this.checkBoxPlastic.TabIndex = 15;
            this.checkBoxPlastic.Text = "胶板";
            this.checkBoxPlastic.UseVisualStyleBackColor = true;
            // 
            // checkBoxScreen
            // 
            this.checkBoxScreen.AutoSize = true;
            this.checkBoxScreen.Location = new System.Drawing.Point(151, 20);
            this.checkBoxScreen.Name = "checkBoxScreen";
            this.checkBoxScreen.Size = new System.Drawing.Size(48, 16);
            this.checkBoxScreen.TabIndex = 14;
            this.checkBoxScreen.Text = "纱窗";
            this.checkBoxScreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxGlass
            // 
            this.checkBoxGlass.AutoSize = true;
            this.checkBoxGlass.Location = new System.Drawing.Point(141, 42);
            this.checkBoxGlass.Name = "checkBoxGlass";
            this.checkBoxGlass.Size = new System.Drawing.Size(48, 16);
            this.checkBoxGlass.TabIndex = 13;
            this.checkBoxGlass.Text = "玻璃";
            this.checkBoxGlass.UseVisualStyleBackColor = true;
            // 
            // checkBoxGold
            // 
            this.checkBoxGold.AutoSize = true;
            this.checkBoxGold.Location = new System.Drawing.Point(87, 20);
            this.checkBoxGold.Name = "checkBoxGold";
            this.checkBoxGold.Size = new System.Drawing.Size(48, 16);
            this.checkBoxGold.TabIndex = 12;
            this.checkBoxGold.Text = "金色";
            this.checkBoxGold.UseVisualStyleBackColor = true;
            // 
            // checkBoxBronze
            // 
            this.checkBoxBronze.AutoSize = true;
            this.checkBoxBronze.Location = new System.Drawing.Point(141, 20);
            this.checkBoxBronze.Name = "checkBoxBronze";
            this.checkBoxBronze.Size = new System.Drawing.Size(48, 16);
            this.checkBoxBronze.TabIndex = 11;
            this.checkBoxBronze.Text = "古铜";
            this.checkBoxBronze.UseVisualStyleBackColor = true;
            // 
            // checkBoxPowderCoating
            // 
            this.checkBoxPowderCoating.AutoSize = true;
            this.checkBoxPowderCoating.Location = new System.Drawing.Point(21, 20);
            this.checkBoxPowderCoating.Name = "checkBoxPowderCoating";
            this.checkBoxPowderCoating.Size = new System.Drawing.Size(48, 16);
            this.checkBoxPowderCoating.TabIndex = 10;
            this.checkBoxPowderCoating.Text = "烤漆";
            this.checkBoxPowderCoating.UseVisualStyleBackColor = true;
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(768, 405);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "基础设置";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasLock
            // 
            this.checkBoxHasLock.AutoSize = true;
            this.checkBoxHasLock.Location = new System.Drawing.Point(19, 20);
            this.checkBoxHasLock.Name = "checkBoxHasLock";
            this.checkBoxHasLock.Size = new System.Drawing.Size(48, 16);
            this.checkBoxHasLock.TabIndex = 36;
            this.checkBoxHasLock.Text = "有锁";
            this.checkBoxHasLock.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHasLock);
            this.groupBox1.Controls.Add(this.checkBoxNormalLock);
            this.groupBox1.Controls.Add(this.checkBoxCodeLock);
            this.groupBox1.Controls.Add(this.checkBoxFingerPrintLock);
            this.groupBox1.Location = new System.Drawing.Point(262, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 75);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "锁相关";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCloser);
            this.groupBox2.Controls.Add(this.checkBoxScreen);
            this.groupBox2.Controls.Add(this.checkBoxDoorInDoor);
            this.groupBox2.Location = new System.Drawing.Point(262, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 49);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "门相关";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxGold);
            this.groupBox3.Controls.Add(this.checkBoxPowderCoating);
            this.groupBox3.Controls.Add(this.checkBoxPlastic);
            this.groupBox3.Controls.Add(this.checkBoxBronze);
            this.groupBox3.Controls.Add(this.checkBoxGlass);
            this.groupBox3.Controls.Add(this.checkBoxCurve);
            this.groupBox3.Controls.Add(this.checkBoxMetalSheet);
            this.groupBox3.Location = new System.Drawing.Point(262, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 93);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "通用";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainView";
            this.Text = "计价器";
            this.tabControl.ResumeLayout(false);
            this.tabPageCalculate.ResumeLayout(false);
            this.tabPageCalculate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLengthWidth;
        private System.Windows.Forms.TextBox textBoxHeightDeepth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSqft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCalculate;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.CheckBox checkBoxPole;
        private System.Windows.Forms.CheckBox checkBoxMetalSheet;
        private System.Windows.Forms.CheckBox checkBoxPlastic;
        private System.Windows.Forms.CheckBox checkBoxScreen;
        private System.Windows.Forms.CheckBox checkBoxGlass;
        private System.Windows.Forms.CheckBox checkBoxGold;
        private System.Windows.Forms.CheckBox checkBoxBronze;
        private System.Windows.Forms.CheckBox checkBoxPowderCoating;
        private System.Windows.Forms.TextBox textBoxPoleQty;
        private System.Windows.Forms.CheckBox checkBoxFingerPrintLock;
        private System.Windows.Forms.CheckBox checkBoxCodeLock;
        private System.Windows.Forms.CheckBox checkBoxNormalLock;
        private System.Windows.Forms.CheckBox checkBoxCloser;
        private System.Windows.Forms.CheckBox checkBoxDoorInDoor;
        private System.Windows.Forms.CheckBox checkBoxCurve;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxHeightDeepthFeet;
        private System.Windows.Forms.TextBox textBoxLengthWidthFeet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxDesignUnitPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPredictQtyOfDesign;
        private System.Windows.Forms.CheckBox checkBoxHasLock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

