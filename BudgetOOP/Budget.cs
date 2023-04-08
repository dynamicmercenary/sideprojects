using System;
using System.Xml.Linq;

namespace BudgetOOP
{
	public class Budget
	{
		public decimal Income
		{ get; set; }
        public List<Expense> ExpenseTotal
		{ get; set; }
        public decimal AmountLeftToSpend
        { get; set; }

        public decimal CalculateRemainingIncomeAfterExpense()
        {
            decimal totalExpenses = ExpenseTotal.Sum(expense => expense.ExpenseAmount);
			return Income - totalExpenses;
        }

		public (decimal, decimal) CalculateSavings()
		{
            decimal investing = 2000m;
            decimal savings = (CalculateRemainingIncomeAfterExpense() - AmountLeftToSpend) - investing;
            if (savings > 0m)
            {
                return (savings, investing);
            }
            else if (savings <= 0m && (savings+investing) > 0m)
            {
                return (savings + investing, 0m);
            }
            else
            {
                return (0m, 0m);
            }

            
		}

        public void AddExpense(string expenseName, decimal expenseAmount)
        {
            ExpenseTotal.Add(new Expense(expenseName, expenseAmount));
        }

        public Budget(decimal income, decimal amountLeftToSpend = 3000.00m)
        {
            ExpenseTotal = new List<Expense>();
            Income = income;
            AmountLeftToSpend = amountLeftToSpend;
        }
    }
}

