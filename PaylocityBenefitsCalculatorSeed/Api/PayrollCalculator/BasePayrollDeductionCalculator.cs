using Api.Dtos.Employee;

namespace Api.PayrollCalculator
{
    // state and federal tax deductions with 8% state tax and 10% federal tax per paycheck
    public abstract class BasePayrollDeductionCalculator
    {
        const decimal StateIncomeTaxPercentage = 0.08M;
        public abstract decimal CalculateDeduction(EmployeeHoursDTO employeeDTO);

        public decimal CalculateStateTax(decimal totalEarnings)
        {
            return totalEarnings * StateIncomeTaxPercentage;
        }

        const decimal FederalIncomeTaxPercentage = 0.1M;
        public decimal CalculateFederalTax(decimal totalEarnings)
        {
            return totalEarnings * FederalIncomeTaxPercentage;
        }
    }
}
