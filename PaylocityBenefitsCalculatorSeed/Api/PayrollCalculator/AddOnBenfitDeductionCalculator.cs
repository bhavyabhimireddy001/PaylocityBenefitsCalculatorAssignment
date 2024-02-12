using Api.Dtos.Employee;

namespace Api.PayrollCalculator
{
    // AddOnBenfitDeductionCalculator to calculate extra 2% incur if total salary per annum is greater than 80000
    public class AddOnBenfitDeductionCalculator : BasePayrollDeductionCalculator
    {
        const int NumberOfBiWeeksInYear = 26;
        const int HoursPerBiWeek = 80;
        public override decimal CalculateDeduction(EmployeeHoursDTO employeeDTO)
        {
            decimal totalAnnualEarnings = 0;
            totalAnnualEarnings = employeeDTO.SalaryPerHour * NumberOfBiWeeksInYear * HoursPerBiWeek;

            return totalAnnualEarnings > 80000 ?( (0.02m * totalAnnualEarnings)/26 ) : 0;
        }
    }

}
