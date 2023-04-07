using System;
namespace BudgetOOP
{
	public class TaxesINC
	{
		public decimal Income
		{ get; set; }
		public decimal TaxRate
		{ get; set; }
		public decimal TaxDeduction
		{ get; set; }
		public decimal UpdatedIncome
		{ get; set; }

        public decimal CalculateBruttoInc()
        {
            decimal afterDanishAM = Income * 0.92m;
            decimal incomeAfterTaxDeduction = afterDanishAM - TaxDeduction;
            decimal incomeAfterTaxRate = incomeAfterTaxDeduction * 0.64m;
            return incomeAfterTaxRate+TaxDeduction;

        }

        public TaxesINC(decimal income, decimal taxRate, decimal deduction)
		{
			TaxRate = taxRate;
			TaxDeduction = deduction;
			Income = income;
			UpdatedIncome = CalculateBruttoInc();
		}

	}
}

