using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    internal class Control
    {
        public static void SetSelectMode(string mode)
        {
            switch (mode)
            {
                case "Charge CC":
                    //여기서 맥시멈 미니멈 값을 변경 해주어야함
                    break;
                case "DisCharge CC":
                    //주석 테스트
                    break;
                case "Charge CP":
                    break;
                case "DisCharge CP":
                    break;
                default: MessageBox.Show("모드 설정이 비정상 입니다.");
                    break;
            }
        }
    }
}
