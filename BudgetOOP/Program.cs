using System;

namespace BudgetOOP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Create a list of expenses
            List<Expense> expenses = new List<Expense>();

            // Add some expenses to the list
            expenses.Add(new Expense("Rent", 10494.03m));
            expenses.Add(new Expense("Groceries", 2000.00m));
            expenses.Add(new Expense("Other, utilities, loan, etc", 4304.22m));


            TaxesINC taxesMainJob = new TaxesINC(16111.27m, 36.00m, 7100.00m);
            decimal FreelanceJob = 200.00m * 7.5m;
            TaxesINC taxesFreelanceJob = new TaxesINC(FreelanceJob, 36.00m, 0.00m);
            decimal apartmentSecurity = 1059.00m;
            decimal sideIncome = 8700.00m;

            decimal totalInc = taxesMainJob.UpdatedIncome + taxesFreelanceJob.UpdatedIncome + apartmentSecurity + sideIncome;

            int groceriesIndex = expenses.FindIndex(expense => expense.ExpenseName == "Groceries");

            Budget budget = new Budget(totalInc, expenses);

            Console.WriteLine($"This is your total income: {Math.Round(totalInc,2)}");
            Console.WriteLine($"This is your remaing income after all expenses: {Math.Round(budget.RemainingIncomeAfterExpenses, 2)} kr");
            Console.WriteLine($"Transfer this to your budgets account: {Math.Round(expenses.Sum(expense => expense.ExpenseAmount) - expenses[groceriesIndex].ExpenseAmount, 2)}");
            Console.WriteLine($"This goes to food: {expenses[groceriesIndex].ExpenseAmount}");
            Console.WriteLine($"This is how much you can spend on savings, 2000 kr goes to stocks: {Math.Round(budget.Savings, 2)} kr");
            Console.WriteLine($"By the end of the day, you'll have {budget.AmountLeftToSpend} kr left to spend on anything");
        }
    }
}