namespace CustomWindow
{
    partial class MainForm
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
            Button_Modify = new Button();
            TextBox_ModifyWidth = new TextBox();
            TextBox_ModifyHeight = new TextBox();
            TextBox_FileName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Button_Select = new Button();
            CheckBox_WithStartModify = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            CheckBox_AutoExit = new CheckBox();
            CheckBox_CenterScreen = new CheckBox();
            label3 = new Label();
            ComboBox_UseAPI = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            Button_StartModify = new Button();
            Button_SaveConfig = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Button_Modify
            // 
            Button_Modify.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button_Modify.FlatStyle = FlatStyle.System;
            Button_Modify.Location = new Point(252, 309);
            Button_Modify.Name = "Button_Modify";
            Button_Modify.Size = new Size(125, 44);
            Button_Modify.TabIndex = 0;
            Button_Modify.Text = "修改窗口";
            Button_Modify.UseVisualStyleBackColor = true;
            Button_Modify.Click += Button_Modify_Click;
            // 
            // TextBox_ModifyWidth
            // 
            TextBox_ModifyWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_ModifyWidth.Location = new Point(76, 3);
            TextBox_ModifyWidth.Margin = new Padding(0, 3, 3, 0);
            TextBox_ModifyWidth.Name = "TextBox_ModifyWidth";
            TextBox_ModifyWidth.Size = new Size(103, 27);
            TextBox_ModifyWidth.TabIndex = 1;
            TextBox_ModifyWidth.Text = "1920";
            // 
            // TextBox_ModifyHeight
            // 
            TextBox_ModifyHeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_ModifyHeight.Location = new Point(261, 3);
            TextBox_ModifyHeight.Margin = new Padding(0, 3, 0, 0);
            TextBox_ModifyHeight.Name = "TextBox_ModifyHeight";
            TextBox_ModifyHeight.Size = new Size(106, 27);
            TextBox_ModifyHeight.TabIndex = 2;
            TextBox_ModifyHeight.Text = "1080";
            // 
            // TextBox_FileName
            // 
            TextBox_FileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_FileName.Location = new Point(10, 36);
            TextBox_FileName.Name = "TextBox_FileName";
            TextBox_FileName.Size = new Size(333, 27);
            TextBox_FileName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 5);
            label1.Margin = new Padding(0, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 3;
            label1.Text = "窗口宽度:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(185, 5);
            label2.Margin = new Padding(3, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 4;
            label2.Text = "窗口高度:";
            // 
            // Button_Select
            // 
            Button_Select.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button_Select.FlatStyle = FlatStyle.System;
            Button_Select.Location = new Point(349, 36);
            Button_Select.Name = "Button_Select";
            Button_Select.Size = new Size(28, 28);
            Button_Select.TabIndex = 5;
            Button_Select.Text = "...";
            Button_Select.UseVisualStyleBackColor = true;
            Button_Select.Click += Button_Select_Click;
            // 
            // CheckBox_WithStartModify
            // 
            CheckBox_WithStartModify.AutoSize = true;
            CheckBox_WithStartModify.FlatStyle = FlatStyle.System;
            CheckBox_WithStartModify.Location = new Point(3, 3);
            CheckBox_WithStartModify.Name = "CheckBox_WithStartModify";
            CheckBox_WithStartModify.Size = new Size(175, 25);
            CheckBox_WithStartModify.TabIndex = 6;
            CheckBox_WithStartModify.Text = "启动时自动应用尺寸";
            CheckBox_WithStartModify.UseVisualStyleBackColor = true;
            CheckBox_WithStartModify.Click += CheckBox_Notice_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(CheckBox_WithStartModify);
            flowLayoutPanel2.Controls.Add(CheckBox_AutoExit);
            flowLayoutPanel2.Controls.Add(CheckBox_CenterScreen);
            flowLayoutPanel2.Location = new Point(10, 234);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(374, 69);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // CheckBox_AutoExit
            // 
            CheckBox_AutoExit.AutoSize = true;
            CheckBox_AutoExit.FlatStyle = FlatStyle.System;
            CheckBox_AutoExit.Location = new Point(184, 3);
            CheckBox_AutoExit.Name = "CheckBox_AutoExit";
            CheckBox_AutoExit.Size = new Size(145, 25);
            CheckBox_AutoExit.TabIndex = 7;
            CheckBox_AutoExit.Text = "修改后自动退出";
            CheckBox_AutoExit.UseVisualStyleBackColor = true;
            CheckBox_AutoExit.Click += CheckBox_Notice_Click;
            // 
            // CheckBox_CenterScreen
            // 
            CheckBox_CenterScreen.AutoSize = true;
            CheckBox_CenterScreen.FlatStyle = FlatStyle.System;
            CheckBox_CenterScreen.Location = new Point(3, 34);
            CheckBox_CenterScreen.Name = "CheckBox_CenterScreen";
            CheckBox_CenterScreen.Size = new Size(145, 25);
            CheckBox_CenterScreen.TabIndex = 8;
            CheckBox_CenterScreen.Text = "修改后居中窗口";
            CheckBox_CenterScreen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 10);
            label3.Name = "label3";
            label3.Size = new Size(219, 20);
            label3.TabIndex = 8;
            label3.Text = "设置修改的主程序路径或进程名";
            // 
            // ComboBox_UseAPI
            // 
            ComboBox_UseAPI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBox_UseAPI.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_UseAPI.FlatStyle = FlatStyle.System;
            ComboBox_UseAPI.FormattingEnabled = true;
            ComboBox_UseAPI.Items.AddRange(new object[] { "MoveWindow", "SetWindowPos" });
            ComboBox_UseAPI.Location = new Point(13, 170);
            ComboBox_UseAPI.Name = "ComboBox_UseAPI";
            ComboBox_UseAPI.Size = new Size(364, 28);
            ComboBox_UseAPI.TabIndex = 9;
            ComboBox_UseAPI.SelectedIndexChanged += ComboBox_UseAPI_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 76);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 10;
            label4.Text = "设置修改尺寸";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 147);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 11;
            label5.Text = "使用 Win32API 方案";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 211);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 12;
            label6.Text = "程序设置";
            // 
            // Button_StartModify
            // 
            Button_StartModify.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button_StartModify.FlatStyle = FlatStyle.System;
            Button_StartModify.Location = new Point(121, 309);
            Button_StartModify.Name = "Button_StartModify";
            Button_StartModify.Size = new Size(125, 44);
            Button_StartModify.TabIndex = 13;
            Button_StartModify.Text = "启动并修改";
            Button_StartModify.UseVisualStyleBackColor = true;
            Button_StartModify.Click += Button_StartModify_Click;
            // 
            // Button_SaveConfig
            // 
            Button_SaveConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Button_SaveConfig.FlatStyle = FlatStyle.System;
            Button_SaveConfig.Location = new Point(16, 314);
            Button_SaveConfig.Name = "Button_SaveConfig";
            Button_SaveConfig.Size = new Size(81, 35);
            Button_SaveConfig.TabIndex = 14;
            Button_SaveConfig.Text = "保存配置";
            Button_SaveConfig.UseVisualStyleBackColor = true;
            Button_SaveConfig.Click += Button_SaveConfig_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(TextBox_ModifyHeight, 3, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Controls.Add(TextBox_ModifyWidth, 1, 0);
            tableLayoutPanel1.Location = new Point(10, 99);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(367, 35);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 365);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(Button_SaveConfig);
            Controls.Add(Button_StartModify);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ComboBox_UseAPI);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(Button_Select);
            Controls.Add(TextBox_FileName);
            Controls.Add(Button_Modify);
            Name = "MainForm";
            Text = "自定义窗口 - CustomWindow";
            FormClosing += MainForm_FormClosing;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_Modify;
        private TextBox TextBox_ModifyWidth;
        private TextBox TextBox_ModifyHeight;
        private TextBox TextBox_FileName;
        private Label label1;
        private Label label2;
        private Button Button_Select;
        private CheckBox CheckBox_WithStartModify;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox CheckBox_AutoExit;
        private Label label3;
        private ComboBox ComboBox_UseAPI;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button Button_StartModify;
        private CheckBox CheckBox_CenterScreen;
        private Button Button_SaveConfig;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
