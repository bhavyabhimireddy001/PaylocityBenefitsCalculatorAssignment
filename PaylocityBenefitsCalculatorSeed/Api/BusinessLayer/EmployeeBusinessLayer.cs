using Api.Dtos.Employee;

namespace Api.BusinessLayer
{
    // Definition for a public class that implements the IEmployeeBusinessLayer interface.
    public class EmployeeBusinessLayer : IEmployeeBusinessLayer
    {
        // validates if employee has a spouse or domestic partner but not both
        public EmployeeValidationResultDTO ValidateEmployee(EmployeeDto emplopyeeDTO)
        {
            EmployeeValidationResultDTO result = new EmployeeValidationResultDTO() { isValidationSuccessfull = true, ErrorMessage = String.Empty };
            bool spouseExists = emplopyeeDTO.Dependents.Any(x => x.Relationship == Models.Relationship.Spouse);
            bool doemsticPartnerExists = emplopyeeDTO.Dependents.Any(x => x.Relationship == Models.Relationship.DomesticPartner);
            if(spouseExists && doemsticPartnerExists)
            {
                result.isValidationSuccessfull = false;
                result.ErrorMessage = "Spouse & Domestic partner exists for employee " + emplopyeeDTO.FirstName + " " + emplopyeeDTO.LastName + " validation fail.";
            }            
            return result;
        }
    }
}
