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
        public decimal Savings
		{ get; set; }
        public decimal RemainingIncomeAfterExpenses
        { get; set; }
        public decimal AmountLeftToSpend
        { get; set; }

        public decimal CalculateRemainingIncomeAfterExpense()
        {
            decimal totalExpenses = ExpenseTotal.Sum(expense => expense.ExpenseAmount);
			return Income - totalExpenses;
        }

		public decimal CalculateSavings()
		{
	        return RemainingIncomeAfterExpenses % AmountLeftToSpend;
		}

        public Budget(decimal income, List<Expense> expensesList, decimal amountLeftToSpend = 3000.00m)
        {
            Income = income;
            ExpenseTotal = expensesList;
            RemainingIncomeAfterExpenses = CalculateRemainingIncomeAfterExpense();
            AmountLeftToSpend = amountLeftToSpend;
            Savings = CalculateSavings();
        }
    }
}

