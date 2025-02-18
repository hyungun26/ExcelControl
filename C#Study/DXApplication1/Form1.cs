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
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = textBox3.Text;
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
                    textBox3.Text = filePath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelTest ex = new ExcelTest();
            ex.ExcelControl(textBox3.Text);
        }

        private bool IsEnterPressed = false;        

        private float TextBoxOnce(System.Windows.Forms.TextBox textBox) //Enter float값을 입력 받았을때 딱 한번만 동작
        {
            float num = 0;
            textBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter && IsEnterPressed)
                {                     
                    num = Int32.Parse(textBox.Text);
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
            ExcelTest excelTest = new ExcelTest();
            excelTest.Caxis.MaximumScale = TextBoxOnce(textBox4) + TextBoxOnce(textBox1) * 0.01 * TextBoxOnce(textBox2);
            excelTest.Caxis.MinimumScale = TextBoxOnce(textBox4) - TextBoxOnce(textBox1) * 0.01 * TextBoxOnce(textBox2);
            Console.WriteLine($"MximumScale : {excelTest.Caxis.MaximumScale} + MinimumScale : {excelTest.Caxis.MinimumScale}");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
