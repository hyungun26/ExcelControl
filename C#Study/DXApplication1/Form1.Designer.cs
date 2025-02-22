using System;
using System.Drawing;
using System.IO;
using System.Linq;
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

        
        private void ClearAllTextBoxesWithLinq()
        {
            var excludedNames = new[] { "searchPath", "range" }; // 모드변경시 초기화 하지 않는 textBox
            this.Controls.OfType<TextBox>().Where(tb => !excludedNames.Contains(tb.Name)).ToList().ForEach(tb => tb.Clear());
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
            this.range = new System.Windows.Forms.TextBox();
            this.voltage = new System.Windows.Forms.TextBox();
            this.excution = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.T_voltage = new System.Windows.Forms.TextBox();
            this.Target_V = new System.Windows.Forms.Label();
            this.V = new System.Windows.Forms.Label();
            this.ampere = new System.Windows.Forms.TextBox();
            this.A = new System.Windows.Forms.Label();
            this.T_ampere = new System.Windows.Forms.TextBox();
            this.Target_A = new System.Windows.Forms.Label();
            this.modeSelect = new System.Windows.Forms.ComboBox();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1064, 21);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(123, 33);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "SearchFile";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // range
            // 
            this.range.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.range.Location = new System.Drawing.Point(892, 217);
            this.range.Margin = new System.Windows.Forms.Padding(4);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(60, 33);
            this.range.TabIndex = 5;
            this.range.Text = "0.1";
            this.range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.range.TextChanged += new System.EventHandler(this.range_TextChanged);
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
            this.voltage.Visible = false;
            // 
            // excution
            // 
            this.excution.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(953, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 37);
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
            // T_voltage
            // 
            this.T_voltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_voltage.Location = new System.Drawing.Point(531, 158);
            this.T_voltage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.T_voltage.Name = "T_voltage";
            this.T_voltage.Size = new System.Drawing.Size(170, 33);
            this.T_voltage.TabIndex = 2;
            this.T_voltage.TextChanged += new System.EventHandler(this.T_voltage_TextChanged);
            this.T_voltage.Visible = false;
            // 
            // Target_V
            // 
            this.Target_V.AutoSize = true;
            this.Target_V.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Target_V.Location = new System.Drawing.Point(711, 155);
            this.Target_V.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Target_V.Name = "Target_V";
            this.Target_V.Size = new System.Drawing.Size(120, 37);
            this.Target_V.TabIndex = 8;
            this.Target_V.Text = "Target V";
            this.Target_V.Visible = false;
            // 
            // V
            // 
            this.V.AutoSize = true;
            this.V.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.V.Location = new System.Drawing.Point(471, 151);
            this.V.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.V.Name = "V";
            this.V.Size = new System.Drawing.Size(34, 37);
            this.V.TabIndex = 9;
            this.V.Text = "V";
            this.V.Visible = false;
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
            // A
            // 
            this.A.AutoSize = true;
            this.A.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A.Location = new System.Drawing.Point(471, 213);
            this.A.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(35, 37);
            this.A.TabIndex = 9;
            this.A.Text = "A";
            // 
            // T_ampere
            // 
            this.T_ampere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T_ampere.Location = new System.Drawing.Point(531, 217);
            this.T_ampere.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.T_ampere.Name = "T_ampere";
            this.T_ampere.Size = new System.Drawing.Size(170, 33);
            this.T_ampere.TabIndex = 4;
            this.T_ampere.TextChanged += new System.EventHandler(this.T_ampere_TextChanged);
            // 
            // Target_A
            // 
            this.Target_A.AutoSize = true;
            this.Target_A.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Target_A.Location = new System.Drawing.Point(711, 217);
            this.Target_A.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Target_A.Name = "Target_A";
            this.Target_A.Size = new System.Drawing.Size(121, 37);
            this.Target_A.TabIndex = 8;
            this.Target_A.Text = "Target A";
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
            this.modeSelect.SelectedIndex = 0;
            this.modeSelect.SelectedIndexChanged += new System.EventHandler(this.modeSelect_SelectedIndexChanged);
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rangeLabel.Location = new System.Drawing.Point(51, 15);
            this.rangeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(112, 37);
            this.rangeLabel.TabIndex = 6;
            this.rangeLabel.Text = "Mode : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 533);
            this.Controls.Add(this.modeSelect);
            this.Controls.Add(this.A);
            this.Controls.Add(this.V);
            this.Controls.Add(this.Target_A);
            this.Controls.Add(this.Target_V);
            this.Controls.Add(this.T_ampere);
            this.Controls.Add(this.T_voltage);
            this.Controls.Add(this.rangeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excution);
            this.Controls.Add(this.ampere);
            this.Controls.Add(this.voltage);
            this.Controls.Add(this.range);
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
        private Button excution;
        private TextBox range;
        private TextBox searchPath;

        private TextBox voltage;
        private TextBox ampere;
        private TextBox T_voltage;
        private TextBox T_ampere;

        private ComboBox modeSelect;

        private Label label1;
        private Label label2;
        private Label V;
        private Label Target_V;
        private Label A;
        private Label Target_A;
        private Label rangeLabel;
    }
}

