using Api.Dtos.Employee;

namespace Api.PayrollCalculator
{
    // For each dependent we have to deduct 600 monthly which is 300 biweekly
    public class DependentsBenfitDeductionCalculator : BasePayrollDeductionCalculator
    {
        const decimal BiWeeklyCostPerDependent = 300;
        public override decimal CalculateDeduction(EmployeeHoursDTO employeeDTO)
        {
            return employeeDTO.Dependents.Count() * BiWeeklyCostPerDependent;
        }

    }
}
