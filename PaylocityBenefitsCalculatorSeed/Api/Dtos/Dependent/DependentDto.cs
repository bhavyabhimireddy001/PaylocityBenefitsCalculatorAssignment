using Api.Models;

namespace Api.Dtos.Dependent;

// Defines a DTO for Dependents
public class DependentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Relationship Relationship { get; set; }
    public string RelationshipDisplayText { get; set; }
}
