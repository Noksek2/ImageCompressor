
namespace ImageCompressor
{
    partial class ImageCompressor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            numericScroll = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            comboRotation = new System.Windows.Forms.ComboBox();
            comboFlip = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            buttonPath = new System.Windows.Forms.Button();
            textBoxPath = new System.Windows.Forms.TextBox();
            checkBoxFolder = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            checkBox_suffix = new System.Windows.Forms.CheckBox();
            textBox_outputfolder = new System.Windows.Forms.TextBox();
            textBox_suffix = new System.Windows.Forms.TextBox();
            checkBoxDelorg = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            buttonSaveMode = new System.Windows.Forms.Button();
            radioMsgshow = new System.Windows.Forms.RadioButton();
            radioMsgerror = new System.Windows.Forms.RadioButton();
            radioMsgnone = new System.Windows.Forms.RadioButton();
            groupBox3 = new System.Windows.Forms.GroupBox();
            numericWidth = new System.Windows.Forms.NumericUpDown();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            numericRatioH = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            numericRatioW = new System.Windows.Forms.NumericUpDown();
            radioRatio = new System.Windows.Forms.RadioButton();
            radioSize = new System.Windows.Forms.RadioButton();
            label5 = new System.Windows.Forms.Label();
            numericHeight = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            comboStretch = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            buttonBg = new System.Windows.Forms.Button();
            label11 = new System.Windows.Forms.Label();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)numericScroll).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericRatioH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRatioW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(453, 545);
            button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(319, 52);
            button1.TabIndex = 0;
            button1.Text = "Open && Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "to PNG*", "to JPG", "to BMP", "to WebP" });
            comboBox1.Location = new System.Drawing.Point(86, 33);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(171, 33);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 38);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 25);
            label2.TabIndex = 3;
            label2.Text = "Format";
            // 
            // numericScroll
            // 
            numericScroll.Location = new System.Drawing.Point(341, 33);
            numericScroll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            numericScroll.Maximum = new decimal(new int[] { 98, 0, 0, 0 });
            numericScroll.Minimum = new decimal(new int[] { 55, 0, 0, 0 });
            numericScroll.Name = "numericScroll";
            numericScroll.Size = new System.Drawing.Size(87, 31);
            numericScroll.TabIndex = 5;
            numericScroll.Value = new decimal(new int[] { 85, 0, 0, 0 });
            numericScroll.ValueChanged += numericScroll_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(267, 33);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 25);
            label3.TabIndex = 6;
            label3.Text = "Quality";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboRotation);
            groupBox1.Controls.Add(comboFlip);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(numericScroll);
            groupBox1.Location = new System.Drawing.Point(16, 23);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Size = new System.Drawing.Size(454, 132);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Image Option";
            // 
            // comboRotation
            // 
            comboRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRotation.FormattingEnabled = true;
            comboRotation.Items.AddRange(new object[] { "0 deg", "90 deg", "180 deg ", "270(-90) deg" });
            comboRotation.Location = new System.Drawing.Point(86, 75);
            comboRotation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboRotation.Name = "comboRotation";
            comboRotation.Size = new System.Drawing.Size(171, 33);
            comboRotation.TabIndex = 23;
            comboRotation.SelectedIndexChanged += comboRotation_SelectedIndexChanged;
            // 
            // comboFlip
            // 
            comboFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboFlip.FormattingEnabled = true;
            comboFlip.Items.AddRange(new object[] { "none", "X flip", "Y flip" });
            comboFlip.Location = new System.Drawing.Point(323, 75);
            comboFlip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboFlip.Name = "comboFlip";
            comboFlip.Size = new System.Drawing.Size(105, 33);
            comboFlip.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(277, 80);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(40, 25);
            label7.TabIndex = 25;
            label7.Text = "Flip";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 80);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(80, 25);
            label6.TabIndex = 24;
            label6.Text = "Rotation";
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.Location = new System.Drawing.Point(11, 617);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            textBox1.Size = new System.Drawing.Size(757, 261);
            textBox1.TabIndex = 9;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.Control;
            button2.Location = new System.Drawing.Point(614, 890);
            button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(153, 38);
            button2.TabIndex = 10;
            button2.Text = "Clear message";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.White;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            button3.ForeColor = System.Drawing.SystemColors.ControlText;
            button3.Location = new System.Drawing.Point(11, 890);
            button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(146, 38);
            button3.TabIndex = 11;
            button3.Text = "Program Info";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // buttonPath
            // 
            buttonPath.Location = new System.Drawing.Point(644, 90);
            buttonPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonPath.Name = "buttonPath";
            buttonPath.Size = new System.Drawing.Size(100, 42);
            buttonPath.TabIndex = 12;
            buttonPath.Text = "Set path";
            buttonPath.UseVisualStyleBackColor = true;
            buttonPath.Click += button4_Click;
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new System.Drawing.Point(7, 93);
            textBoxPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.ReadOnly = true;
            textBoxPath.Size = new System.Drawing.Size(623, 31);
            textBoxPath.TabIndex = 14;
            // 
            // checkBoxFolder
            // 
            checkBoxFolder.AutoSize = true;
            checkBoxFolder.Location = new System.Drawing.Point(13, 153);
            checkBoxFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxFolder.Name = "checkBoxFolder";
            checkBoxFolder.Size = new System.Drawing.Size(149, 29);
            checkBoxFolder.TabIndex = 7;
            checkBoxFolder.Text = "Output folder";
            checkBoxFolder.UseVisualStyleBackColor = true;
            checkBoxFolder.CheckedChanged += checkBoxFolder_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxOverwrite);
            groupBox2.Controls.Add(checkBox_suffix);
            groupBox2.Controls.Add(textBox_outputfolder);
            groupBox2.Controls.Add(textBox_suffix);
            groupBox2.Controls.Add(checkBoxDelorg);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(buttonSaveMode);
            groupBox2.Controls.Add(textBoxPath);
            groupBox2.Controls.Add(checkBoxFolder);
            groupBox2.Controls.Add(buttonPath);
            groupBox2.Location = new System.Drawing.Point(16, 275);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Size = new System.Drawing.Size(761, 247);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Path option";
            // 
            // checkBoxOverwrite
            // 
            checkBoxOverwrite.AutoSize = true;
            checkBoxOverwrite.BackColor = System.Drawing.Color.Transparent;
            checkBoxOverwrite.ForeColor = System.Drawing.Color.DarkRed;
            checkBoxOverwrite.Location = new System.Drawing.Point(541, 157);
            checkBoxOverwrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxOverwrite.Name = "checkBoxOverwrite";
            checkBoxOverwrite.Size = new System.Drawing.Size(208, 29);
            checkBoxOverwrite.TabIndex = 22;
            checkBoxOverwrite.Text = "Allow file overwriting";
            checkBoxOverwrite.UseVisualStyleBackColor = false;
            checkBoxOverwrite.CheckedChanged += checkBoxOverwrite_CheckedChanged;
            // 
            // checkBox_suffix
            // 
            checkBox_suffix.AutoSize = true;
            checkBox_suffix.Location = new System.Drawing.Point(11, 192);
            checkBox_suffix.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            checkBox_suffix.Name = "checkBox_suffix";
            checkBox_suffix.Size = new System.Drawing.Size(203, 29);
            checkBox_suffix.TabIndex = 21;
            checkBox_suffix.Text = "Suffix of output files";
            checkBox_suffix.UseVisualStyleBackColor = true;
            checkBox_suffix.CheckedChanged += checkBox_suffix_CheckedChanged;
            // 
            // textBox_outputfolder
            // 
            textBox_outputfolder.Location = new System.Drawing.Point(219, 152);
            textBox_outputfolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox_outputfolder.MaxLength = 10;
            textBox_outputfolder.Name = "textBox_outputfolder";
            textBox_outputfolder.Size = new System.Drawing.Size(134, 31);
            textBox_outputfolder.TabIndex = 20;
            textBox_outputfolder.Text = "res";
            // 
            // textBox_suffix
            // 
            textBox_suffix.Enabled = false;
            textBox_suffix.Location = new System.Drawing.Point(219, 190);
            textBox_suffix.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox_suffix.MaxLength = 10;
            textBox_suffix.Name = "textBox_suffix";
            textBox_suffix.Size = new System.Drawing.Size(134, 31);
            textBox_suffix.TabIndex = 18;
            textBox_suffix.Text = "(1)";
            textBox_suffix.TextChanged += textBox2_TextChanged;
            textBox_suffix.KeyPress += textBox2_KeyPress;
            // 
            // checkBoxDelorg
            // 
            checkBoxDelorg.AutoSize = true;
            checkBoxDelorg.BackColor = System.Drawing.Color.RosyBrown;
            checkBoxDelorg.ForeColor = System.Drawing.Color.DarkRed;
            checkBoxDelorg.Location = new System.Drawing.Point(541, 192);
            checkBoxDelorg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxDelorg.Name = "checkBoxDelorg";
            checkBoxDelorg.Size = new System.Drawing.Size(181, 29);
            checkBoxDelorg.TabIndex = 17;
            checkBoxDelorg.Text = "Delete origin files";
            checkBoxDelorg.UseVisualStyleBackColor = false;
            checkBoxDelorg.CheckedChanged += checkBoxDelorg_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 48);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 25);
            label1.TabIndex = 16;
            label1.Text = "Save mode";
            // 
            // buttonSaveMode
            // 
            buttonSaveMode.Location = new System.Drawing.Point(117, 37);
            buttonSaveMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonSaveMode.Name = "buttonSaveMode";
            buttonSaveMode.Size = new System.Drawing.Size(104, 47);
            buttonSaveMode.TabIndex = 15;
            buttonSaveMode.Text = "Auto";
            buttonSaveMode.UseVisualStyleBackColor = true;
            buttonSaveMode.Click += buttonSaveMode_Click;
            // 
            // radioMsgshow
            // 
            radioMsgshow.AutoSize = true;
            radioMsgshow.Checked = true;
            radioMsgshow.Location = new System.Drawing.Point(9, 30);
            radioMsgshow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioMsgshow.Name = "radioMsgshow";
            radioMsgshow.Size = new System.Drawing.Size(104, 29);
            radioMsgshow.TabIndex = 17;
            radioMsgshow.TabStop = true;
            radioMsgshow.Text = "Show all";
            radioMsgshow.UseVisualStyleBackColor = true;
            // 
            // radioMsgerror
            // 
            radioMsgerror.AutoSize = true;
            radioMsgerror.Location = new System.Drawing.Point(114, 30);
            radioMsgerror.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioMsgerror.Name = "radioMsgerror";
            radioMsgerror.Size = new System.Drawing.Size(119, 29);
            radioMsgerror.TabIndex = 19;
            radioMsgerror.Text = "Only error";
            radioMsgerror.UseVisualStyleBackColor = true;
            // 
            // radioMsgnone
            // 
            radioMsgnone.AutoSize = true;
            radioMsgnone.Location = new System.Drawing.Point(236, 30);
            radioMsgnone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            radioMsgnone.Name = "radioMsgnone";
            radioMsgnone.Size = new System.Drawing.Size(82, 29);
            radioMsgnone.TabIndex = 20;
            radioMsgnone.Text = "None";
            radioMsgnone.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioMsgshow);
            groupBox3.Controls.Add(radioMsgnone);
            groupBox3.Controls.Add(radioMsgerror);
            groupBox3.Location = new System.Drawing.Point(23, 528);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox3.Size = new System.Drawing.Size(331, 78);
            groupBox3.TabIndex = 21;
            groupBox3.TabStop = false;
            groupBox3.Text = "Message option";
            // 
            // numericWidth
            // 
            numericWidth.Location = new System.Drawing.Point(181, 142);
            numericWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            numericWidth.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new System.Drawing.Size(87, 31);
            numericWidth.TabIndex = 22;
            numericWidth.Value = new decimal(new int[] { 512, 0, 0, 0 });
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(numericRatioH);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(numericRatioW);
            groupBox4.Controls.Add(radioRatio);
            groupBox4.Controls.Add(radioSize);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(numericHeight);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(numericWidth);
            groupBox4.Location = new System.Drawing.Point(479, 23);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Size = new System.Drawing.Size(299, 242);
            groupBox4.TabIndex = 22;
            groupBox4.TabStop = false;
            groupBox4.Text = "Image Size Option";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(256, 82);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(27, 25);
            label12.TabIndex = 33;
            label12.Text = "%";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(254, 47);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(27, 25);
            label13.TabIndex = 32;
            label13.Text = "%";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericRatioH
            // 
            numericRatioH.Location = new System.Drawing.Point(181, 77);
            numericRatioH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            numericRatioH.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericRatioH.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericRatioH.Name = "numericRatioH";
            numericRatioH.Size = new System.Drawing.Size(69, 31);
            numericRatioH.TabIndex = 31;
            numericRatioH.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(153, 80);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(25, 25);
            label8.TabIndex = 30;
            label8.Text = "H";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(151, 45);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(29, 25);
            label9.TabIndex = 29;
            label9.Text = "W";
            // 
            // numericRatioW
            // 
            numericRatioW.Location = new System.Drawing.Point(181, 38);
            numericRatioW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            numericRatioW.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericRatioW.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericRatioW.Name = "numericRatioW";
            numericRatioW.Size = new System.Drawing.Size(69, 31);
            numericRatioW.TabIndex = 28;
            numericRatioW.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // radioRatio
            // 
            radioRatio.AutoSize = true;
            radioRatio.Checked = true;
            radioRatio.Location = new System.Drawing.Point(7, 43);
            radioRatio.Name = "radioRatio";
            radioRatio.Size = new System.Drawing.Size(139, 29);
            radioRatio.TabIndex = 27;
            radioRatio.TabStop = true;
            radioRatio.Text = "Ratio (100%)";
            radioRatio.UseVisualStyleBackColor = true;
            radioRatio.CheckedChanged += radioRatio_CheckedChanged;
            // 
            // radioSize
            // 
            radioSize.AutoSize = true;
            radioSize.Location = new System.Drawing.Point(7, 148);
            radioSize.Name = "radioSize";
            radioSize.Size = new System.Drawing.Size(135, 29);
            radioSize.TabIndex = 23;
            radioSize.Text = "Custom size";
            radioSize.UseVisualStyleBackColor = true;
            radioSize.CheckedChanged += radioSize_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(154, 180);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(25, 25);
            label5.TabIndex = 26;
            label5.Text = "H";
            label5.Click += label5_Click;
            // 
            // numericHeight
            // 
            numericHeight.Location = new System.Drawing.Point(181, 177);
            numericHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            numericHeight.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numericHeight.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new System.Drawing.Size(87, 31);
            numericHeight.TabIndex = 25;
            numericHeight.Value = new decimal(new int[] { 512, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(151, 145);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 25);
            label4.TabIndex = 24;
            label4.Text = "W";
            // 
            // comboStretch
            // 
            comboStretch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboStretch.FormattingEnabled = true;
            comboStretch.Items.AddRange(new object[] { "None", "StretchToFit" });
            comboStretch.Location = new System.Drawing.Point(86, 35);
            comboStretch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            comboStretch.Name = "comboStretch";
            comboStretch.Size = new System.Drawing.Size(171, 33);
            comboStretch.TabIndex = 26;
            comboStretch.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(13, 42);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(69, 25);
            label10.TabIndex = 27;
            label10.Text = "Stretch";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(buttonBg);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(comboStretch);
            groupBox5.Controls.Add(label10);
            groupBox5.Location = new System.Drawing.Point(16, 168);
            groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox5.Size = new System.Drawing.Size(454, 97);
            groupBox5.TabIndex = 28;
            groupBox5.TabStop = false;
            groupBox5.Text = "Stretch Option";
            // 
            // buttonBg
            // 
            buttonBg.Location = new System.Drawing.Point(359, 28);
            buttonBg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonBg.Name = "buttonBg";
            buttonBg.Size = new System.Drawing.Size(70, 48);
            buttonBg.TabIndex = 29;
            buttonBg.UseVisualStyleBackColor = true;
            buttonBg.Click += button4_Click_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(277, 42);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(79, 25);
            label11.TabIndex = 28;
            label11.Text = "BGColor";
            // 
            // ImageCompressor
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(789, 943);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ImageCompressor";
            Text = "ImageCompressor 0.2.3 (update 261114, by Noksek2)";
            Load += ImageConvert_Load;
            DragDrop += ImageConvert_DragDrop;
            DragEnter += ImageConvert_DragEnter;
            ((System.ComponentModel.ISupportInitialize)numericScroll).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericRatioH).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRatioW).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericScroll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.CheckBox checkBoxFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveMode;
        private System.Windows.Forms.RadioButton radioMsgshow;
        private System.Windows.Forms.RadioButton radioMsgerror;
        private System.Windows.Forms.RadioButton radioMsgnone;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericRatioW;
        private System.Windows.Forms.RadioButton radioRatio;
        private System.Windows.Forms.RadioButton radioSize;
        private System.Windows.Forms.CheckBox checkBoxDelorg;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboRotation;
		private System.Windows.Forms.ComboBox comboFlip;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_suffix;
		private System.Windows.Forms.TextBox textBox_outputfolder;
		private System.Windows.Forms.CheckBox checkBox_suffix;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;
        private System.Windows.Forms.NumericUpDown numericRatioH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboStretch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonBg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

