using System;
using System.Collections.Generic;
using System.Text;
using ExcelApp = Microsoft.Office.Interop.Excel;
using TodoApp.Interop.Services.DataSheetModels;
using System.Linq;

namespace TodoApp.Interop.Services.DatasheetServices
{
    public class BudgetDataSheet : DatasheetBaseService<BudgetModel>
    {
        private string msg;
        public override string InfoMsg => msg;

        /// <summary>
        /// Generates simple xslx file for budget.
        /// </summary>
        /// <param name="budget">Budget model.</param>
        /// <returns>If file was successfully generated returns 1 otherwise -1.</returns>
        /// <exception cref="ArgumentNullException">For null reference to object.</exception>
        
        public override int GenerateXslxFile(BudgetModel budget)
        {
            if (budget == null)
            {
                throw new ArgumentNullException(nameof(budget));
            }

            if (!budget.Incomes.Any())
            {
                msg = "No incomes found, cannot create a sheet.";
                return -1;
            }

            if (!budget.Expenses.Any())
            {
                msg = "No expenses found, cannot create a sheet.";
                return -1;
            }

            app.Visible = this.AppVisible;
            app.Workbooks.Add();

            // create a new worksheet
            ExcelApp.Worksheet worksheet = (ExcelApp.Worksheet)app.ActiveSheet;

            // create range for top columns and merge them
            ExcelApp.Range topRange = worksheet.get_Range("A2", "Z2");
            ExcelApp.Range expenseLabelRange = worksheet.get_Range("B6:G6");
            ExcelApp.Range incomesTitle = worksheet.get_Range("B8:C8");
            ExcelApp.Range expensesTitle = worksheet.get_Range("H8:I8");
            
            topRange.Merge(true);
            topRange.Value = budget.Title;
            expenseLabelRange.Merge(true);
            expenseLabelRange.Value = "All expenses";
            incomesTitle.Merge(true);
            expensesTitle.Merge(true);
            incomesTitle.Value = "Incomes";
            expensesTitle.Value = "Expenses";

            var startRow = 11;
            int itemNmb = 1;

            worksheet.Cells[10, "A"] = "No.";
            worksheet.Cells[10, "B"] = "Name";
            worksheet.Cells[10, "C"] = "Value";
            worksheet.Cells[10, "D"] = "Created at";

            worksheet.Cells[10, "G"] = "No.";
            worksheet.Cells[10, "H"] = "Name";
            worksheet.Cells[10, "I"] = "Value";
            worksheet.Cells[10, "J"] = "Created At";
            worksheet.Cells[10, "K"] = "Due date";

            foreach (var income in budget.Incomes)
            {
                worksheet.Cells[startRow, "A"] = itemNmb;
                worksheet.Cells[startRow, "B"] = income.Name;
                worksheet.Cells[startRow, "C"] = income.IncomeValue;
                worksheet.Cells[startRow, "D"] = income.CreatedAt;
                startRow++;
                itemNmb++;
            }
            
            startRow = 11;
            itemNmb = 1;

            foreach (var expense in budget.Expenses)
            {
                worksheet.Cells[startRow, "G"] = itemNmb;
                worksheet.Cells[startRow, "H"] = expense.Name;
                worksheet.Cells[startRow, "I"] = expense.ExpenseValue;
                worksheet.Cells[startRow, "J"] = expense.CreatedAt;
                worksheet.Cells[startRow, "K"] = expense.DueDate;
                startRow++;
                itemNmb++;
            }

            var endRowsIncomes = budget.Incomes.Count() + startRow;
            var endRowsExpenses = budget.Expenses.Count() + startRow;

            int summaryRow;

            if (endRowsExpenses > endRowsIncomes)
            {
                summaryRow = endRowsExpenses;
            }
            else
            {
                summaryRow = endRowsIncomes;
            }

            worksheet.Cells[summaryRow + 1, "B"] = "Total";
            worksheet.Cells[summaryRow + 2, "A"] = "Expenses";
            worksheet.Cells[summaryRow + 2, "B"] = budget.Expenses.Sum(x => x.ExpenseValue);
            worksheet.Cells[summaryRow + 3, "A"] = "Incomes";
            worksheet.Cells[summaryRow + 3, "B"] = budget.Incomes.Sum(x => x.IncomeValue);
            worksheet.Cells[summaryRow + 4, "A"] = "General";
            worksheet.Cells[summaryRow + 4, "B"] = budget.Incomes.Sum(x => x.IncomeValue) - budget.Expenses.Sum(x => x.ExpenseValue);

            this.ReleaseAppObject(worksheet);
            this.msg = "Report has been successfully generated";
            return 1;
        }

        protected override void ReleaseAppObject(object objectToRelease)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objectToRelease);
                msg = "Object [excel sheet] released.";
                objectToRelease = null;
            }
            catch
            {
                objectToRelease = null;
                msg = "Cannot release COM object [excel sheet].";
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
