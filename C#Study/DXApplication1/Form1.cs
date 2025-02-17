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
                openFileDialog.InitialDirectory = "c:\\";
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
                    
                    Console.WriteLine(fileStream);
                    ProcessStartInfo info = new ProcessStartInfo();
                    Process.Start(filePath, fileContent);
                    textBox3.Text = filePath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelTest ex = new ExcelTest();
            ex.ExcelControl();
        }

        private bool IsEnterPressed = false;        

        private float TextBoxOnce(System.Windows.Forms.TextBox textBox)
        {
            float num= 0;
            textBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter && IsEnterPressed)
                {
                    Console.WriteLine(textBox.Name + " 값이 입력 되었습니다.");
                    num = Int32.Parse(textBox.Text);
                    textBox.Clear();
                    IsEnterPressed = false;
                }
            };

            IsEnterPressed = true;
            return num;
        }


        //TextBox는 자기 안에 문자가 추가/제거 즉 변화가 생길때 마다 작동한다.
        //Enter키를 누르면 딱 이 부분만 실행이 된다.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            ExcelTest excelTest = new ExcelTest();
            excelTest.Caxis.MaximumScale = TextBoxOnce(textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(textBox2);
        }
    }
}
