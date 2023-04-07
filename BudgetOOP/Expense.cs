using System;
namespace BudgetOOP
{
    public class Expense
    {
        public string ExpenseName
        { get; set; }
        public decimal ExpenseAmount
        { get; set; }

        public Expense(string name, decimal amount)
        {
            ExpenseName = name;
            ExpenseAmount = amount;
        }

	}
}

