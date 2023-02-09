using AutoMapper;
using Management.Application.ServiceCategories.Commands.CommandTypes;
using Management.Application.ServiceCategories.Queries.QueriesTypes;
using Management.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Management.WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class ServiceCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ServiceCategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets the list of service categories
    /// </summary>
    /// <remarks>
    /// GET-request for getting all service categories
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="204">No content (service cateries are absent)</response>
    /// <returns>
    /// List of service categories
    /// </returns>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<ServiceCategoryDto>>> GetAll()
    {
        var categories = await _mediator.Send(new GetAllServiceCategoriesQuery());
        if (categories is not null)
        {
            var categoriesDto = new List<ServiceCategoryDto>();
            foreach (var category in categories)
            {
                categoriesDto.Add(_mapper.Map<ServiceCategoryDto>(category));
            }
            return Ok(categoriesDto);
        }            
        else
        {
            return NoContent();
        }
    }

    /// <summary>
    /// Gets service category by id
    /// </summary>
    /// <remarks>
    /// GET-request for service category by id
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="400">Bad request (no service category with such id)</response>
    /// <returns>
    /// Service category with requested id 
    /// </returns>
    /// <param name="id">Service category id</param>

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceCategoryDto>> GetServiceCategory(int id)
    {
        var query = new GetServiceCategoryQuery
        {
            ServiceCategoryId = id
        };
        var category = await _mediator.Send(query);
        if (category is not null)
        {
            var categoryDto = _mapper.Map<ServiceCategoryDto>(category);
            return Ok(categoryDto);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Creates service category
    /// </summary>
    /// <remarks>
    /// POST-request for creating service category entity
    /// </remarks>
    /// <response code="201">Service category created</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Created service category 
    /// </returns>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceCategoryDto>> CreateServiceCategory([FromForm] CreateServiceCategoryCommand command)
    {
        var category = await _mediator.Send(command);
        if (category is not null)
        {
            var categoryReturn = _mapper.Map<ServiceCategoryDto>(category);
            return Created($"/services/{category.ServiceCategoryId}", categoryReturn); ;
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Updates service category
    /// </summary>
    /// <remarks>
    /// PUT-request for updating service category entity
    /// </remarks>
    /// <response code="200">Service category updated</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Updated service category
    /// </returns>

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceCategoryDto>> UpdateServiceCategory([FromForm] UpdateServiceCategoryCommand command)
    {
        var category = await _mediator.Send(command);
        if (category is not null)
        {
            var categoryResult = _mapper.Map<ServiceCategoryDto>(category);
            return Ok(categoryResult);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Deletes service category
    /// </summary>
    /// <remarks>
    /// DELETE-request for updating service category entity
    /// </remarks>
    /// <response code="200">Service category deleted</response>
    /// <response code="400">Service category not found</response>
    /// <returns>
    /// Deleted service category
    /// </returns>

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceCategoryDto>> DeleteServiceCategory(int id)
    {
        var command = new DeleteServiceCategoryCommand
        {
            ServiceCategoryId = id
        };
        var category = await _mediator.Send(command);
        if (category is not null)
        {
            var categoryResult = _mapper.Map<ServiceCategoryDto>(category);
            return Ok(categoryResult);
        }
        else
        {
            return BadRequest();
        }
    }
}
