using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using System.Security.Cryptography.Xml;

namespace Api.Repository
{
    // Defines a repository class for dependents that implements the IDependentsRepository interface.
    public class DependentsRepository : IDependentsRepository
    {
        // Method to get all dependents from the database.
        public List<DependentDto> GetAllDependents()
        {
            using (var _context = new PaylocityBenefitsContext())
            {
                // Queries the Employees DbSet to select employee data and project it into EmployeeDto objects.
                // Within this projection, it also transforms the collection of Dependents related to each employee
                // into a collection of DependentDto objects.
                var employees = _context.Employees
                     .Select(x => new EmployeeDto
                     {
                         // For each employee, selects and transforms their dependents into DependentDto objects.
                         Dependents = x.Dependents.Select(d => new DependentDto
                         {
                             FirstName = d.FirstName,
                             LastName = d.LastName,
                             DateOfBirth = d.DateOfBirth,
                             RelationshipDisplayText = d.RelationShip.Name

                         }).ToList()
                     })
                     .ToList();
                // This is effectively creating a list of all dependents across all employees.
                return employees.SelectMany(x => x.Dependents).ToList();
            }
        }
    }
}
