using System;
using System.Linq;

namespace BudgetOOP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set your income with TaxesINC - it calculates your (Income, TaxRate, TaxDeduction(if any)
            TaxesINC taxesMainJob = new TaxesINC(16111.27m, 36.00m, 7100.00m);
            decimal FreelanceJob = 200.00m * 6m;
            TaxesINC taxesFreelanceJob = new TaxesINC(FreelanceJob, 36.00m, 0.00m);
            decimal apartmentSecurity = 1059.00m;
            decimal sideIncome = 8700.00m;

            //Calculate total income after taxes added non taxed income + other incomes.
            decimal totalInc = taxesMainJob.UpdatedIncome + taxesFreelanceJob.UpdatedIncome + apartmentSecurity + sideIncome;

            //Create a budget with income
            Budget budget = new Budget(totalInc);

            //Add expenses (ExpenseName, ExpenseAmunt)
            budget.AddExpense("Rent", 10400m);
            budget.AddExpense("Groceries", 2000m);
            budget.AddExpense("Other; loan, newspaper, streaming, etc.", 4000m);

            
            Console.WriteLine($"This is your total income: {Math.Round(totalInc,2)}");
            //This will check if an expense for groceries exist, else just print your total
            int groceriesIndex = -1;
            foreach (var expense in budget.ExpenseTotal)
            {
                if (expense.ExpenseName == "Groceries")
                {
                    groceriesIndex = budget.ExpenseTotal.FindIndex(expense => expense.ExpenseName == "Groceries");
                    break;
                }
            }

            if (groceriesIndex != -1)
            {
                Console.WriteLine($"This is your remaing income after all expenses: {Math.Round(budget.CalculateRemainingIncomeAfterExpense(), 2)} kr");
                Console.WriteLine($"Transfer this to your budgets account: {Math.Round(budget.ExpenseTotal.Sum(expense => expense.ExpenseAmount)
                            - budget.ExpenseTotal[groceriesIndex].ExpenseAmount, 2)}");
                Console.WriteLine($"This goes to food: {budget.ExpenseTotal[groceriesIndex].ExpenseAmount}");
            }
            else
            {
                Console.WriteLine($"This is your remaing income after all expenses: {Math.Round(budget.CalculateRemainingIncomeAfterExpense(), 2)} kr");
                Console.WriteLine($"Transfer this to your budgets account: {Math.Round(budget.ExpenseTotal.Sum(expense => expense.ExpenseAmount), 2)}");
            }

            Console.WriteLine($"This is how much you can spend on savings, {Math.Round(budget.CalculateSavings().Item2, 2)} kr goes to stocks: {Math.Round(budget.CalculateSavings().Item1, 2)} kr");
            Console.WriteLine($"By the end of the day, you'll have {budget.AmountLeftToSpend} kr left to spend on anything");
        }
    }
}