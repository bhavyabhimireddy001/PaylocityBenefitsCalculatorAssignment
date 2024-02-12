using Api.Dtos.Employee;
using Api.Models;
using Api.Dtos.Dependent;
using Microsoft.OpenApi.Extensions;

namespace Api.Repository
{
    // Implements the IEmployeeRepository interface, defining methods for working with Employee data.
    public class EmployeeRepository : IEmployeeRepository
    {
        // Adds a new Employee along with their Dependents to the database.
        public void AddEmployee(EmployeeDto employee)
        {
            using (var _context = new PaylocityBenefitsContext())
            {
                List<Dependent> _dependents = new List<Dependent>();

                // Check if the incoming EmployeeDto has dependents and if the count is greater than 0.
                if (employee.Dependents != null && employee.Dependents.Count > 0)
                {
                    foreach(DependentDto dependent in employee.Dependents)
                    {
                        // Create a new Dependent entity for each DependentDto and add it to the list.
                        _dependents.Add(
                             new Dependent()
                             {
                                FirstName =  dependent.FirstName,
                                LastName = dependent.LastName,
                                DateOfBirth = dependent.DateOfBirth,
                                RelationShipId = (int) dependent.Relationship
                             });
                    }
                }
                // Create a new Employee entity, populate it with data from the EmployeeDto,
                // and add it to the Employees DbSet.
                _context.Employees.Add(new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    SalaryPerHour = employee.SalaryPerHour,
                    Dependents = _dependents

                });
               
                _context.SaveChanges();
            }
        }

        // Retrieves all Employee records from the database, along with their Dependents.
        public List<EmployeeDto> GetAllEmployees()
        {
            using (var _context = new PaylocityBenefitsContext())
            {
                // Query the Employees DbSet to select and transform each Employee entity into an EmployeeDto.
                return _context.Employees
                     .Select(x => new EmployeeDto
                     {
                         EmployeeID = x.Id,
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         DateOfBirth = x.DateOfBirth,
                         SalaryPerHour = x.SalaryPerHour,

                         // For each Employee, transform their Dependents into a list of DependentDto objects.
                         Dependents = x.Dependents.Select(d => new DependentDto
                         {
                             FirstName = d.FirstName,
                             LastName = d.LastName,
                             DateOfBirth = d.DateOfBirth,
                             RelationshipDisplayText = d.RelationShip.Name

                         }).ToList()
                     })
                     .ToList();
            }
        }

        
    }
}
