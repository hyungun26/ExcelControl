using System;
using System.Drawing;
using System.Windows.Forms;

namespace DXApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.voltage = new System.Windows.Forms.TextBox();
            this.excution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tvoltage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ampere = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tampere = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modeSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1064, 17);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(123, 46);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "SearchFile";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(892, 217);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 33);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "0.05";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // voltage
            // 
            this.voltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.voltage.Location = new System.Drawing.Point(312, 158);
            this.voltage.Margin = new System.Windows.Forms.Padding(4);
            this.voltage.Name = "voltage";
            this.voltage.Size = new System.Drawing.Size(149, 33);
            this.voltage.TabIndex = 1;
            this.voltage.TextChanged += new System.EventHandler(this.voltage_TextChanged);
            // 
            // excution
            // 
            this.excution.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excution.Location = new System.Drawing.Point(1066, 450);
            this.excution.Margin = new System.Windows.Forms.Padding(4);
            this.excution.Name = "excution";
            this.excution.Size = new System.Drawing.Size(154, 44);
            this.excution.TabIndex = 6;
            this.excution.Text = "Execution";
            this.excution.UseVisualStyleBackColor = true;
            this.excution.Click += new System.EventHandler(this.excution_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(963, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "±%";
            // 
            // searchPath
            // 
            this.searchPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchPath.CausesValidation = false;
            this.searchPath.Location = new System.Drawing.Point(312, 21);
            this.searchPath.Margin = new System.Windows.Forms.Padding(4);
            this.searchPath.Name = "searchPath";
            this.searchPath.ReadOnly = true;
            this.searchPath.Size = new System.Drawing.Size(742, 33);
            this.searchPath.TabIndex = 2;
            this.searchPath.TabStop = false;
            this.searchPath.Text = "U:\\2차 전지 사업팀\\SW Project\\프로젝트별 시험데이터\\4. BPJT-24-0008 에너테크_16CH_Cell\\TestLog_ch01~0" +
    "4\\TEST_250107_093444_39.CC충전(1~4ch)\\MC01Ch001[001]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(304, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Spec";
            // 
            // Tvoltage
            // 
            this.Tvoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tvoltage.Location = new System.Drawing.Point(531, 158);
            this.Tvoltage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Tvoltage.Name = "Tvoltage";
            this.Tvoltage.Size = new System.Drawing.Size(170, 33);
            this.Tvoltage.TabIndex = 2;
            this.Tvoltage.TextChanged += new System.EventHandler(this.Tvoltage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(711, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Target V";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "V";
            // 
            // ampere
            // 
            this.ampere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ampere.Location = new System.Drawing.Point(312, 217);
            this.ampere.Margin = new System.Windows.Forms.Padding(4);
            this.ampere.Name = "ampere";
            this.ampere.Size = new System.Drawing.Size(149, 33);
            this.ampere.TabIndex = 3;
            this.ampere.TextChanged += new System.EventHandler(this.ampere_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(471, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "A";
            // 
            // Tampere
            // 
            this.Tampere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tampere.Location = new System.Drawing.Point(531, 217);
            this.Tampere.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Tampere.Name = "Tampere";
            this.Tampere.Size = new System.Drawing.Size(170, 33);
            this.Tampere.TabIndex = 4;
            this.Tampere.TextChanged += new System.EventHandler(this.Tampere_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(711, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 37);
            this.label6.TabIndex = 8;
            this.label6.Text = "Target A";
            // 
            // modeSelect
            // 
            this.modeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelect.FormattingEnabled = true;
            this.modeSelect.Items.AddRange(new object[] {
            "CC",
            "CCCV",
            "CPCV",
            "Pattern"});
            this.modeSelect.Location = new System.Drawing.Point(160, 21);
            this.modeSelect.Margin = new System.Windows.Forms.Padding(4);
            this.modeSelect.Name = "modeSelect";
            this.modeSelect.Size = new System.Drawing.Size(132, 33);
            this.modeSelect.TabIndex = 7;
            this.modeSelect.SelectedIndexChanged += new System.EventHandler(this.modeSelect_SelectedIndexChanged);
            this.modeSelect.SelectedIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(51, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 37);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mode : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 533);
            this.Controls.Add(this.modeSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tampere);
            this.Controls.Add(this.Tvoltage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excution);
            this.Controls.Add(this.ampere);
            this.Controls.Add(this.voltage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchButton);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Form1.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "Form1";
            this.Text = "ExcelControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button searchButton;
        private TextBox textBox1;
        private TextBox voltage;
        private Button excution;
        private Label label1;
        private TextBox searchPath;
        private Label label2;
        private TextBox Tvoltage;
        private Label label3;
        private Label label4;
        private TextBox ampere;
        private Label label5;
        private TextBox Tampere;
        private Label label6;
        private ComboBox modeSelect;
        private Label label7;
    }
}

