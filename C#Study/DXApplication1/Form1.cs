using DevExpress.Data.TreeList;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraSplashScreen;
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
using TextBox = System.Windows.Forms.TextBox;

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
            //this.Load += Form1_Load;
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

        private float TextBoxOnce(TextBox textBox) //Enter float값을 입력 받았을때 딱 한번만 동작
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

        private void IntOnly(TextBox textBox)
        {
            // 현재 TextBox의 텍스트를 가져옵니다.
            string currentText = textBox.Text;

            // 숫자만 남기고 나머지 문자는 제거합니다.
            string filteredText = new string(currentText.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // 필터링된 텍스트를 다시 TextBox에 설정합니다.
            if (currentText != filteredText)
            {
                textBox.Text = filteredText;

                // 커서 위치를 마지막으로 이동 (입력 중 커서가 맨 앞으로 가는 문제 해결)
                textBox.SelectionStart = textBox.Text.Length;
            }
        }


        //TextBox는 자기 안에 문자가 추가/제거 즉 변화가 생길때 마다 작동한다.
        private void range_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(range);
        }

        private void ampere_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(ampere);
            IntOnly(ampere);
        }
        private void T_ampere_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(T_ampere);
            IntOnly(T_ampere);
        }

        private void voltage_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(voltage);
            IntOnly(voltage);
        }

        private void T_voltage_TextChanged(object sender, EventArgs e)
        {
            TextBoxOnce(T_voltage);
            IntOnly(T_voltage);
        }

        float targetValue;
        float rangeValue;

        private void excution_Click_1(object sender, EventArgs e)
        {
            
            ExcelTest ex = new ExcelTest();
            //Power는 예외로 두고 일단 테스트
            ex.ExcelControl(searchPath.Text, modeSelect.Text, target_Value(T_voltage), range_Value(voltage, range), target_Value(T_ampere), range_Value(range, ampere));
        }





        private float target_Value(TextBox textBox1)
        {
            return targetValue = float.Parse(textBox1.Text);
        }
        private float range_Value(TextBox textBox1, TextBox textBox2)
        {
            return rangeValue = float.Parse(textBox1.Text) * 0.01f * float.Parse(textBox2.Text);
        }



        private void modeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllTextBoxesWithLinq();
            switch (modeSelect.Text)
            {
                case "CC":
                    CCModeUI();
                    break;
                case "CCCV":
                    CCCVModeUI();
                    break;
                case "CPCV":
                    CPCVModeUI();
                    break;
                case "Pattern":
                    PatternModeUI();
                    break;
                default:
                    MessageBox.Show("모드 설정이 비정상 입니다.");
                    break;
            }
        }

        private void CCModeUI()
        {
            voltage.Visible = false;
            T_voltage.Visible = false;
            V.Visible = false;
            Target_V.Visible = false;
            ampere.Visible = true;
            T_ampere.Visible = true;
            A.Visible = true;
            Target_A.Visible = true;
            Spec.Location = new Point(211, 150);
        }
        private void CCCVModeUI()
        {
            voltage.Visible = true;
            T_voltage.Visible = true;
            V.Visible = true;
            Target_V.Visible = true;
            ampere.Visible = true;
            T_ampere.Visible = true;
            Target_A.Text = "Target A";
            A.Visible = true;
            A.Text = "A";
            Target_A.Visible = true;
            Spec.Location = new Point(211, 100);
        }
        private void CPCVModeUI()
        {
            voltage.Visible = true;
            T_voltage.Visible = true;
            V.Visible = true;
            Target_V.Visible = true;
            ampere.Visible = true;
            T_ampere.Visible = true;
            Target_A.Text = "Target P";
            A.Visible = true;
            A.Text = "P";
            Target_A.Visible = true;
            Spec.Location = new Point(211, 100);
        }
        private void PatternModeUI()
        {
            MessageBox.Show("아직 구현안했슴다!");
            //일단 보류
        }

        private void Form1_Load(object sender, EventArgs e) // form이 실행되면 최초 한번 실행하는 곳
        {
            modeSelect.Text = "CC"; // 초기 모드를 설정 (필요에 따라 변경 가능)
            modeSelect_SelectedIndexChanged(sender, e); // 모드 변경 메서드 호출
        }
    }
}
