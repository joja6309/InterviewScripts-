﻿using System.IO;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml; 
using DocumentFormat.OpenXml.Office.Excel;
using Microsoft.Office.Interop.Excel; 

namespace WindowsWriteToExcelAPP
{
    public class ExcelDocument : IExcelDocument
    {
        private readonly string _filePath;

        public ExcelDocument(string filePath)
        {
            _filePath = filePath;

        }
        public void Update()
        {
            using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Open(_filePath, true))
            {
                // tell Excel to recalculate formulas next time it opens the doc
                excelDoc.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                excelDoc.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                excelDoc.WorkbookPart.Workbook.Save(); 
            }
        }
        private WorksheetPart GetWorksheetPart(SpreadsheetDocument excelDoc, string sheetName)
        {
            Sheet sheet = excelDoc.WorkbookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name == sheetName);
            if (sheet == null)
            {
                throw new ArgumentException(
                    String.Format("No sheet named {0} found in spreadsheet {1}", sheetName, _filePath), "sheetName");
            }
            return (WorksheetPart)excelDoc.WorkbookPart.GetPartById(sheet.Id);
        }

        /// <see cref="IExcelDocument.ReadCell" />
        public CellValue ReadCell(string sheetName, string cellCoordinates)
        {
            using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Open(_filePath, false))
            {
                Cell cell = GetCell(excelDoc, sheetName, cellCoordinates);
                return cell.CellValue;
            }
        }
        /// <see cref="IExcelDocument.InsertSharedStringItem(string, object)" />

        public void InsertText(string sheetName,Tuple<string, uint> cellCO ,string text)
        {
            
            // Open the document for editing.
            using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Open(_filePath, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = excelDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = excelDoc.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                WorksheetPart worksheetPart = GetWorksheetPart(excelDoc, sheetName);
                string column = cellCO.Item1;
                uint row = cellCO.Item2; 
                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(column, row, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }
        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        /// <see cref="IExcelDocument.UpdateCell" />
        public void UpdateCell(string sheetName, string cellCoordinates, object cellValue)
        {
            using (SpreadsheetDocument excelDoc = SpreadsheetDocument.Open(_filePath, true))
            {
                // tell Excel to recalculate formulas next time it opens the doc
                excelDoc.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                excelDoc.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;

                WorksheetPart worksheetPart = GetWorksheetPart(excelDoc, sheetName);
                Cell cell = GetCell(worksheetPart, cellCoordinates);
                cell.CellValue = new CellValue(cellValue.ToString());
                worksheetPart.Worksheet.Save();
            }
        }

        /// <summary>Refreshes an Excel document by opening it and closing in background by the Excep Application</summary>
        /// <see cref="IExcelDocument.Refresh" />
        public void Refresh()
        {
            var excelApp = new Application();
            var workbook = excelApp.Workbooks.Open(Path.GetFullPath(_filePath));
            workbook.Close(true);
            excelApp.Quit();
        }
        private Cell GetCell(SpreadsheetDocument excelDoc, string sheetName, string cellCoordinates)
        {
            WorksheetPart worksheetPart = GetWorksheetPart(excelDoc, sheetName);
            return GetCell(worksheetPart, cellCoordinates);
        }

        private Cell GetCell(WorksheetPart worksheetPart, string cellCoordinates)
        {
            int rowIndex = int.Parse(cellCoordinates.Substring(1));
            Row row = GetRow(worksheetPart, rowIndex);

            Cell cell = row.Elements<Cell>().FirstOrDefault(c => cellCoordinates.Equals(c.CellReference.Value));
            if (cell == null)
            {
                throw new ArgumentException(String.Format("Cell {0} not found in spreadsheet", cellCoordinates));
            }
            return cell;
        }

        private Row GetRow(WorksheetPart worksheetPart, int rowIndex)
        {
            Row row = worksheetPart.Worksheet.GetFirstChild<SheetData>().
                                    Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);
            if (row == null)
            {
                throw new ArgumentException(String.Format("No row with index {0} found in spreadsheet", rowIndex));
            }
            return row;
        }
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            var worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
    }
}
