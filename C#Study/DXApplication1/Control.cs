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
        public static void SetSelectMode(string mode, float value, float persent)
        {
            //여기서 맥시멈 미니멈 값을 변경 해주어야함
            switch (mode)
            {
                case "Charge CC":
                    break;
                case "DisCharge CC":
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
