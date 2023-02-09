using AutoMapper;
using Management.Application.Specializations.Commands.CommandTypes;
using Management.Application.Specializations.Queries.QueriesTypes;
using Management.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Management.WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class SpecializationsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SpecializationsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets the list of specializations
    /// </summary>
    /// <remarks>
    /// GET-request for getting all specializations
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="204">No content (specializations are absent)</response>
    /// <returns>
    /// List of specializations
    /// </returns>

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<SpecializationDto>>> GetAll()
    {
        var specializations = await _mediator.Send(new GetAllSpecializationsQuery());
        if (specializations is not null)
        {
            var specializationsDto = new List<SpecializationDto>();
            foreach (var specialization in specializations)
            {
                specializationsDto.Add(_mapper.Map<SpecializationDto>(specialization));
            }
            return Ok(specializationsDto);
        }
        else
        {
            return NoContent();
        }
    }

    /// <summary>
    /// Gets specialization by id
    /// </summary>
    /// <remarks>
    /// GET-request for specialization by id
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="400">Bad request (no specialization with such id)</response>
    /// <returns>
    /// Specialization with requested id 
    /// </returns>
    /// <param name="id">Specialization id</param>

    [HttpGet("{id}")]
    public async Task<ActionResult<SpecializationDto>> GetSpecialization(int id)
    {
        var query = new GetSpecializationQuery
        {
            SpecializationId = id
        };
        var specialization = await _mediator.Send(query);
        if (specialization is not null)
        {
            var specializationDto = _mapper.Map<SpecializationDto>(specialization);
            return Ok(specializationDto);
        }
        else
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Creates specialization
    /// </summary>
    /// <remarks>
    /// POST-request for creating specialization entity
    /// </remarks>
    /// <response code="201">Specialization created</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Created specialization 
    /// </returns>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<SpecializationDto>> CreateSpecialization([FromForm] CreateSpecializationCommand command)
    {
        var specialization = await _mediator.Send(command);
        if (specialization is not null)
        {
            var specializationReturn = _mapper.Map<SpecializationDto>(specialization);
            return Created($"/services/{specialization.SpecializationId}", specializationReturn);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Updates specialization
    /// </summary>
    /// <remarks>
    /// PUT-request for updating specialization entity
    /// </remarks>
    /// <response code="200">Specialization updated</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Updated specialization
    /// </returns>

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<SpecializationDto>> UpdateSpecialization([FromForm] UpdateSpecializationCommand command)
    {
        var specialization = await _mediator.Send(command);
        if (specialization is not null)
        {
            var specializationResult = _mapper.Map<SpecializationDto>(specialization);
            return Ok(specializationResult);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Deletes specialization
    /// </summary>
    /// <remarks>
    /// DELETE-request for updating specialization entity
    /// </remarks>
    /// <response code="200">Specialization deleted</response>
    /// <response code="400">Specialization not found</response>
    /// <returns>
    /// Deleted specialization
    /// </returns>

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<SpecializationDto>> DeleteSpecialization(int id)
    {
        var command = new DeleteSpecializationCommand
        {
            SpecializationId = id
        };
        var specialization = await _mediator.Send(command);
        if (specialization is not null)
        {
            var specializationResult = _mapper.Map<SpecializationDto>(specialization);
            return Ok(specializationResult);
        }
        else
        {
            return BadRequest();
        }
    }
}
