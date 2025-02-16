using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.SpreadsheetSource;
using DevExpress.SpreadsheetSource.Implementation;
using DevExpress.XtraExport.Implementation;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DXApplication1
{
    internal class ExcelTest
    {
        //기능을 전부 구현후 winform형식에 버튼으로 제어하는 기능을 만들면 괜찮을지도...?
        Excel.Application excelApp = new Excel.Application();//엑셀 app 객체
        
        string filePath = "C:\\Users\\hyung\\OneDrive\\바탕 화면\\개인적인 폴더\\TEST_250107_093444_39.CC충전(1~4ch)\\MC01Ch001[001]\\TEST_250122_131418.csv";
        Excel.Workbook workbook;
        Excel.Worksheet ws;
        Range findCell;
        public Excel.Axis Vaxis;
        public Excel.Axis Caxis;
        public void ExcelControl()
        {

            try
            {
                //excelApp.Visible = true; // 엑셀을 켜서 작동하는지 육안으로 확인하기 위한 코드 true면 엑셀을 켜서 동작을 보여줌
                workbook = excelApp.Workbooks.Open(filePath);

                ws = workbook.Sheets[1] as Excel.Worksheet; // as 는 안전한 형변환으로 변환이 안되면 예외를 묻지 않고 null값을 넣는다.
            }
            catch(Exception ex)
            {
                findCell = ws.Cells[2, 10];

                //엑셀은 비어있는 값을 null로 비교해야한다.

                int a = 2;
                while (findCell.Value != null)
                {
                    a++;
                    findCell = ws.Cells[a, 10];
                    Console.WriteLine("되는건가?");
                }

                int save = a;
                string s = (string)findCell.Value;

                Control.SetSelectMode(s); // 모드에 따라 처리해야할 부분이 있으면 사용할 코드

                while (findCell.Value == s) // Charge 모드 들어가서 찍는 첫번째 데이터 뺀 값
                {
                    a++;
                    findCell = ws.Cells[a + 1, 10];
                }

                ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
                ChartObject chartObj = chartObjs.Add(100, 50, 380, 250); // 위치와 크기 지정
                Chart chart = chartObj.Chart;

                // 차트 데이터 설정
                Range chartRange = ws.get_Range($"K{save}", $"L{a}");
                //Console.WriteLine($"K{save}" + $"L{a}");
                chart.SetSourceData(chartRange);

                // 차트 유형 설정 (꺾은선형 그래프)
                chart.ChartType = XlChartType.xlLine;

                Excel.SeriesCollection seriesCollection = chart.SeriesCollection();

                Excel.Series Voltage = seriesCollection.Item(1); // 첫 번째 데이터 계열 
                Voltage.Name = "Voltage";

                Excel.Series Current = seriesCollection.Item(2); // 두 번째 데이터 계열
                Current.Name = "Current";

                // 주축
                Voltage.Format.Line.Weight = 2.75f;
                Voltage.AxisGroup = Excel.XlAxisGroup.xlPrimary;
                Excel.Axis Vaxis = chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary); //Excel.XlAxisGroup.Primary 첫번째 축을 의미 
                Vaxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                // 보조 축
                Current.Format.Line.Weight = 2.75f; // 선 굵기
                Current.AxisGroup = Excel.XlAxisGroup.xlSecondary;
                Excel.Axis Caxis = chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlSecondary); //Excel.XlAxisGroup.xlSecondary 두번째 축을 의미 
                Caxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse; //테두리 없앰

                // 스케일 범위를 받아오는 걸로 하자
                Caxis.MinimumScale = 199.5;
                Caxis.MaximumScale = 200.5;

                Excel.Axis xAxis = chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                // 계열 제목 // CP 모드일때 2번째 축 이름이 Power여야 하기 때문에 변경 해야함
                chart.HasLegend = true;
                chart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;

                // 차트 제목 설정
                chart.HasTitle = true;
                chart.ChartTitle.Text = s; // + "1-1"; 이런거 넣으면 좋을듯 한데 고민좀 해봅시다

                //workbook.SaveAs("C:\\Users\\lg\\Desktop\\Excel Test\\시험 데이터\\d.scv"); // 끝에 내가 파일명을 지정해주면 됨
            }
            finally
            {
                ExcelControlExit();
            }
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
    }
}
