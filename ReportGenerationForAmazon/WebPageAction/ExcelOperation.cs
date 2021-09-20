using System.Data;
using System.IO;
using ExcelDataReader;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportGenerationForAmazon.Data;

namespace ReportGenerationForAmazon.WebPageAction
{
    public class ExcelOperation
    {
        public DataTable ExcelData(string filename)
        {
            //We Open the excel file by filestream
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            //Used for encoding the values in excel
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //ExcelPageFactory is used to read the data from excel
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //Asdataset is where datas in excel are converted into dataset within a table format
            DataSet set = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            //Used to set collection of tables to dataset
            DataTableCollection dataTable = set.Tables;
            //Here passing my sheet name
            DataTable dataTable1 = dataTable["Sheet1"];
            return dataTable1;
        }

        static List<DataCollection> Datas = new List<DataCollection>();
        public void PopulateFromExcel(string filename)
        {

            DataTable dataTable = ExcelData(filename);

            //Here we are using loop for to count row aand value
            for (int row = 1; row <= dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    DataCollection collections = new DataCollection()
                    {

                        rownumber = row,
                        //Getting the column name 
                        colname = dataTable.Columns[col].ColumnName,
                        //getting the column value 
                        colvalue = dataTable.Rows[row - 1][col].ToString()
                    };
                    Datas.Add(collections);
                }
            }
        }

        public string ReadData(int rowNumber, string ColumnName)
        {
            //Here we retrive the data from table by using the query
            string data = (from colData in Datas where colData.colname == ColumnName && colData.rownumber == rowNumber select colData.colvalue).SingleOrDefault();
            return data.ToString();
        }
    }
}
