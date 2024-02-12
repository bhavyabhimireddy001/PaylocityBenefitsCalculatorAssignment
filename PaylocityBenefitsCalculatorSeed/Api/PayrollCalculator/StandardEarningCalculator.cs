using Api.Dtos.Employee;

namespace Api.PayrollCalculator
{// StandardEarningCalculatoris to calculate earnings which include both regular hours and overtime hours
    public class StandardEarningCalculator : BasePayrollEarningsCalculator
    {
        public override decimal CalculateEarnings(EmployeeHoursDTO employeeDTO)
        {

            decimal regularHourEarnings = employeeDTO.RegularHours * employeeDTO.SalaryPerHour;
            decimal overTimeEarnings = (employeeDTO.OverTimeHours.HasValue) ?
                employeeDTO.OverTimeHours.Value * employeeDTO.SalaryPerHour : 0;

            return regularHourEarnings + overTimeEarnings;
        }
    }
}
