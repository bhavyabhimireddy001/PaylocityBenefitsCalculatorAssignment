using Api.BusinessLayer;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private IDependentsRepository _dependentsRepository;

    private readonly ILogger<DependentsController> _logger;

    public DependentsController(IDependentsRepository dependentsRepository,ILogger<DependentsController> logger)
    {
        _dependentsRepository = dependentsRepository;
        _logger = logger;
    }

    // Action method to get a specific dependent by their ID.
    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<DependentDto>>> Get(int id)
    {
        var result = new ApiResponse<DependentDto>();
        try
        {
            DependentDto dependent = _dependentsRepository.GetAllDependents().Where(x => x.Id == id).FirstOrDefault();

            if(dependent == null)
            {
                result = new ApiResponse<DependentDto>
                {
                    Message = "Depenents not found."
                };
            }

            result = new ApiResponse<DependentDto>
            {
                Data = dependent,
                Success = true,
                Message = "Depenent retrieved sucessfully."
            };


        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in Dependents controller Get By Id", ex);
            result = new ApiResponse<DependentDto>
            {
                Error = "An error occured. If the problem persists, please contact admin.",
            };

        }
        return result;
    }

    // Action method to get all dependents.
    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<DependentDto>>>> GetAll()
    {
        var result = new ApiResponse<List<DependentDto>>();
        try
        {
            List<DependentDto> dependents = _dependentsRepository.GetAllDependents();
            result = new ApiResponse<List<DependentDto>>
            {
                Data = dependents,
                Success = true,
                Message = "Depenents retrieved sucessfully."
            };


        }
        catch (Exception ex)
        {
            _logger.LogError("Error occured in Dependents controller GetAll", ex);
            result = new ApiResponse<List<DependentDto>>
            {
                Error = "An error occured. If the problem persists, please contact admin.",
            };


        }
        return result;
    }
}
