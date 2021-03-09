using ExcelDataReader;
using System;
using System.Data;
using System.IO;

namespace RAMDesktopUI.Utilities
{
    public static class ExcelCSVHelper
    {
        public static DataSet GetDataSetFromFile(string filePath)
        {
            DataSet result = null;
            try
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateCsvReader(stream))
                        {
                            result = reader.AsDataSet();
                        }
                    }
                    else
                    {
                        // Auto-detect format, supports:
                        //  - Binary Excel files (2.0-2003 format; *.xls)
                        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            result = reader.AsDataSet();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if (Logger.LogError(ex, LogAction.LogAndShow))
                    throw;
            }
            return result;
        }
    }
}
