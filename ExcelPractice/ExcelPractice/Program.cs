using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;


namespace ExcelPractice
{
    class Program
    {
        static void Main( string[] args )
        {
            using (var book = MyExcelBook.CreateBook("example.xlsx"))
            {
                book.CreateSheet("sheet1");
                book.CreateSheet("sheet2");
                book.Save();
            }
        }
    }

    public sealed class MyExcelBook : IDisposable
    {
        private MyExcelBook() {}
        public void Dispose() => _document?.Dispose();

        
        private SpreadsheetDocument _document;
        private WorkbookPart _workbookPart;
        private WorksheetPart _worksheetPart;
        private Sheets _sheets;

        /// <summary>
        /// ブックを作成する
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static MyExcelBook CreateBook(string filePath)
        {
            // Excelのドキュメントを新規に作成する
            var book = new MyExcelBook
            {
                _document = SpreadsheetDocument.Create(
                    filePath,
                    SpreadsheetDocumentType.Workbook)
            };

            // ドキュメントにワークブックを追加する
            book._workbookPart = book._document.AddWorkbookPart();
            book._workbookPart.Workbook = new Workbook();

            // ワークブックにシートの入れ物を追加する
            book._sheets = book._workbookPart.Workbook.AppendChild(new Sheets());
            return book;
        }

        /// <summary>
        /// シートを作成する
        /// </summary>
        /// <param name="sheetName"></param>
        public void CreateSheet(string sheetName)
        {
            // シート作成するための準備
            _worksheetPart = _workbookPart.AddNewPart<WorksheetPart>();
            _worksheetPart.Worksheet = new Worksheet(new SheetData());

            // シートを作成し追加する
            var max = (uint) (_sheets.Count() + 1);
            var sheet = new Sheet
            {
                Id = _workbookPart.GetIdOfPart(_worksheetPart),
                SheetId = max,
                Name = sheetName
            };
            _sheets.Append(sheet);
        }

        public void Save()
        {
            _workbookPart.Workbook.Save();
            _document.Close();
        }
    }
}
