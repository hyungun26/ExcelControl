using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.SpreadsheetSource;
using DevExpress.SpreadsheetSource.Implementation;
using DevExpress.XtraExport.Implementation;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace DXApplication1
{
    internal class ExcelTest
    {
        //기능을 전부 구현후 winform형식에 버튼으로 제어하는 기능을 만들면 괜찮을지도...?
        Excel.Application excelApp = new Excel.Application();//엑셀 app 객체
        
        //깃허브를 사용하면 파일 위치가 변경되기 때문에 바꿔 주어야 한다.
        Excel.Workbook workbook;
        Excel.Worksheet ws;
        Range findCell;
        public Excel.Axis Vaxis;
        public Excel.Axis Caxis;
        public void ExcelControl(string path, string mode, float first, float first_range, float second, float second_range)
        {
            try
            {
                excelApp.Visible = true; // 엑셀을 켜서 작동하는지 육안으로 확인하기 위한 코드 true면 엑셀을 켜서 동작을 보여줌
                workbook = excelApp.Workbooks.Open(path);
                ws = workbook.Sheets[1] as Excel.Worksheet; // as 는 안전한 형변환으로 변환이 안되면 예외를 묻지 않고 null값을 넣는다.

                findCell = ws.Cells[2, 10];

                //엑셀은 비어있는 값을 null로 비교해야한다.
                
                int a = 2;
                while (findCell.Value == null)
                {
                    a++;
                    findCell = ws.Cells[a, 10];
                }

                int save = a + 1; //모드 들어가서 찍는 첫번째 데이터 뺀 값

                string s = (string)findCell.Value;
                //Control.SetSelectMode(s); // 모드에 따라 처리해야할 부분이 있으면 사용할 코드

                while (findCell.Value != null) 
                {
                    a++;
                    findCell = ws.Cells[a + 1, 10];
                }

                ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
                ChartObject chartObj = chartObjs.Add(100, 50, 380, 250); // 위치와 크기 지정
                Chart chart = chartObj.Chart;

                // 차트 데이터 설정
                Range chartRange1 = ws.get_Range($"K{save}", $"K{a}");
                Range chartRange2 = ws.get_Range($"M{save}", $"M{a}");
                //chart.SetSourceData(chartRange1, chartRange2);

                // 차트 유형 설정 (꺾은선형 그래프)
                chart.ChartType = XlChartType.xlLine;
                chart.ChartArea.Border.Color = ColorTranslator.ToOle(Color.FromArgb(217, 217, 217)); // RGB color

                Excel.SeriesCollection seriesCollection = chart.SeriesCollection();

                var yAxis = chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                yAxis.HasMajorGridlines = true;

                var MajorGridlines = yAxis.MajorGridlines;
                MajorGridlines.Border.Color = ColorTranslator.ToOle(Color.FromArgb(217, 217, 217));


                Excel.Series Voltage = seriesCollection.NewSeries(); // 첫 번째 데이터 계열
                Voltage.Values = chartRange1;
                Voltage.Name = "Voltage";

                Excel.Series Current = seriesCollection.NewSeries(); // 두 번째 데이터 계열
                Current.Values = chartRange2;
                Current.Name = "Current";

                // 주축
                Voltage.Format.Line.Weight = 2.25f; // 선 굵기
                Voltage.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                Excel.Axis Vaxis = chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary); //Excel.XlAxisGroup.Primary 첫번째 축을 의미 
                Vaxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                // 보조 축
                Current.Format.Line.Weight = 2.25f; 
                Current.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                Excel.Axis Caxis = chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlSecondary); //Excel.XlAxisGroup.xlSecondary 두번째 축을 의미 
                Caxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse; //테두리 없앰

                string str;
                if(s.Contains("Dis"))
                {
                    str = "DisCharge";
                    // 스케일 범위
                    if (mode == "CC")
                    {
                        Caxis.MaximumScale = -second + second_range;
                        Caxis.MinimumScale = -second - second_range;
                    }
                    else if (mode == "CCCV")
                    {
                        //그래프를 추가로 생성할 시 고민 해봐야함
                        //Vaxis.MaximumScale = first + first_range;
                        //Vaxis.MinimumScale = first - first_range;
                        //Caxis.MaximumScale = second + second_range;
                        //Caxis.MinimumScale = second - second_range;
                    }
                    else if (mode == "CPCV")
                    {
                        Caxis.MaximumScale = -second + second_range;
                        Caxis.MinimumScale = -second - second_range;
                    }
                    else
                    {
                        MessageBox.Show("모드 설정이 비정상 입니다.");
                    }
                }
                else
                {
                    str = "Charge";
                    // 스케일 범위
                    if (mode == "CC")
                    {
                        Caxis.MaximumScale = second + second_range;
                        Caxis.MinimumScale = second - second_range;
                    }
                    else if (mode == "CCCV")
                    {
                        //그래프를 추가로 생성할 시 고민 해봐야함
                        //Vaxis.MaximumScale = first + first_range;
                        //Vaxis.MinimumScale = first - first_range;
                        //Caxis.MaximumScale = second + second_range;
                        //Caxis.MinimumScale = second - second_range;
                    }
                    else if (mode == "CPCV")
                    {
                        Caxis.MaximumScale = second + second_range;
                        Caxis.MinimumScale = second - second_range;
                    }
                    else
                    {
                        MessageBox.Show("모드 설정이 비정상 입니다.");
                    }
                }
                

                Excel.Axis xAxis = chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                // 계열 제목 // CP 모드일때 2번째 축 이름이 Power여야 하기 때문에 변경 해야함
                chart.HasLegend = true;
                chart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;

                // 차트 제목 설정
                chart.HasTitle = true;
                chart.ChartTitle.Text = str + mode; // + "1-1"; 이런거 넣으면 좋을듯 한데 고민좀 해봅시다
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); //비상!
            }
            //workbook.SaveAs("C:\\Users\\lg\\Desktop\\Excel Test\\시험 데이터\\d.scv"); // 끝에 내가 파일명을 지정해주면 됨
            
            //ExcelControlExit();
        }

        public void ExcelControlExit()
        {
            excelApp.Quit(); //메모리 해제 같은데 100% 되는진 모르겠음 // X눌러 정상 종료하면 메모리 해제됨 debug걸려서 정상 종료 못하면 메모리에 할당되어있음  
            //ReleaseExcelObject(excelApp);            
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        #region 스트레이지 패턴 적용 전 코드
        public interface IAxisStrategy
        {
            void ConfigureAxes(Axis Vaxis, Axis Caxis, double first, double second, double firstRange, double secondRange);
        }

        public class CCCVAxisStrategy : IAxisStrategy
        {
            //CCCV모드는 그래프를 3개 그려야 한다.
            public void ConfigureAxes(Axis Vaxis, Axis Caxis, double first, double second, double firstRange, double secondRange)
            {
                Vaxis.MaximumScale = first + firstRange;
                Vaxis.MinimumScale = first - firstRange;

                //Caxis.MaximumScale = second + secondRange;
                //Caxis.MinimumScale = second - secondRange;
            }
        }

        public class CCModeStrategy : IAxisStrategy
        {
            public void ConfigureAxes(Axis Vaxis, Axis Caxis, double first, double second, double firstRange, double secondRange)
            {
                Caxis.MaximumScale = second + secondRange;
                Caxis.MinimumScale = second - secondRange;
            }
        }

        public class CPCVModeStrategy : IAxisStrategy
        {
            public void ConfigureAxes(Axis Vaxis, Axis Caxis, double first, double second, double firstRange, double secondRange)
            {
                Caxis.MaximumScale = second + secondRange;
                Caxis.MinimumScale = second - secondRange;
            }
        }
        #endregion
    }
}
