using DevExpress.Data.TreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        float Voltage = 0;
        float Current = 0;
        float Length = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = searchPath.Text;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    //ProcessStartInfo info = new ProcessStartInfo();
                    //Process.Start(filePath, fileContent);
                    searchPath.Text = filePath;
                }
            }
        }

        private bool IsEnterPressed = false;        

        private float TextBoxOnce(System.Windows.Forms.TextBox textBox) //Enter float값을 입력 받았을때 딱 한번만 동작
        {
            float num = 0;
            textBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter && IsEnterPressed)
                {                     
                    num = float.Parse(textBox.Text);
                    textBox.Clear();                    
                    IsEnterPressed = false;
                }
            };

            IsEnterPressed = true;
            return num;
        }


        //TextBox는 자기 안에 문자가 추가/제거 즉 변화가 생길때 마다 작동한다.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(textBox1);
        }

        private void ampere_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(ampere);
        }
        private void Tampere_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(Tampere);
        }

        private void voltage_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(voltage);
        }

        private void Tvoltage_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(Tvoltage);
        }

        private void excution_Click_1(object sender, EventArgs e)
        {
            float first = float.Parse(Tvoltage.Text) + float.Parse(textBox1.Text) * 0.01f * float.Parse(voltage.Text);
            float second = float.Parse(Tvoltage.Text) - float.Parse(textBox1.Text) * 0.01f * float.Parse(voltage.Text);

            ExcelTest ex = new ExcelTest();
            ex.ExcelControl(searchPath.Text, first, second);
        }

        private void modeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control.SetSelectMode(modeSelect.Text);
            Console.WriteLine(modeSelect.Text);
        }
    }
}
