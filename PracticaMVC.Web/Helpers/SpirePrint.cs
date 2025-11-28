using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PracticaMVC.EN;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace PracticaMVC.Web.Helpers
{
    public static class SpirePrint
    {
        public static DBResponse<byte[]> ExportarReporteConciliacionPlacas(string PathArchivo_, string PathPlantilla_, string version, string Filtros)
        {
            var dbResponse = new DBResponse<byte[]>();
            var PathArchivo = version == "x" ? PathArchivo_ + "x" : PathArchivo_;
            var PathPlantilla = version == "x" ? PathPlantilla_ + "x" : PathPlantilla_;
            //if (File.Exists(PathArchivo))
            //{
            //    File.Delete(PathArchivo);
            //}
            File.Copy(PathPlantilla, PathArchivo, true);

            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(PathPlantilla, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
                file.Close();
            }

            ISheet excelSheet = hssfwb.GetSheetAt(0);
            IRow rowExcel = excelSheet.GetRow(0);

            IRow rowTitle = excelSheet.GetRow(3);
            ICell cellTitle = rowTitle.GetCell(1);
            cellTitle.SetCellValue(Filtros);

            IRow rowHour = excelSheet.GetRow(2);
            ICell cellHour = rowHour.GetCell(19);
            cellHour.SetCellValue(DateTime.Now.ToString("hh:mm"));

            IRow rowDate = excelSheet.GetRow(3);
            ICell cellDate = rowDate.GetCell(19);
            cellDate.SetCellValue(DateTime.Now.ToString("dd/MM/yyyy"));

            var workbook = new Workbook();
            workbook.LoadFromFile("spire.xls");

            return dbResponse;

        }
    }
}