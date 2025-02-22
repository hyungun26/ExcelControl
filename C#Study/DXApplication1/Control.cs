using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
        Form1 formChange = new Form1();
        public void SetSelectMode(string mode)
        {
            switch (mode)
            {
                case "CC":
                    break;
                case "CCCV":
                    break;
                case "CPCV":
                    break;
                case "Pattern":
                    break;
                default: MessageBox.Show("모드 설정이 비정상 입니다.");
                    break;
            }
        }
    }
}
