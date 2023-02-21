using Microsoft.AspNetCore.Mvc;
using Management.WebApi.Models;
using MediatR;
using Management.Application.Services.Commands.CommandTypes;
using Management.Application.Services.Queries.QueriesTypes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Management.WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<ServicesController> _logger;
    public ServicesController(IMediator mediator, IMapper mapper, ILogger<ServicesController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Gets the list of services
    /// </summary>
    /// <remarks>
    /// GET-request for getting all services
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="204">No content (services are absent)</response>
    /// <returns>
    /// List of services
    /// </returns>


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAll()
    {
        _logger.LogInformation("Fetching all service models from the storage");

        var services = await _mediator.Send(new GetAllServicesQuery());
        if (services is not null)
        {
            var servicesDto = new List<ServiceDto>();
            foreach (var service in services)
            {
                servicesDto.Add(_mapper.Map<ServiceDto>(service));
            }
            return Ok(servicesDto);
        }
        else
        {
            _logger.LogInformation("Storage is empty");

            return NoContent();
        }
    }

    /// <summary>
    /// Gets service by id
    /// </summary>
    /// <remarks>
    /// GET-request for service by id
    /// </remarks>
    /// <response code="200">Success</response>
    /// <response code="400">Bad request (no service with such id)</response>
    /// <returns>
    /// Service with requested id 
    /// </returns>
    /// <param name="id">Service id</param>

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceDto>> GetService(int id)
    {
        _logger.LogInformation($"Fetching service model with id: {id} from the storage");
        
        var query = new GetServiceQuery
        {
            ServiceId = id
        };
        var service = await _mediator.Send(query);
        if (service is not null)
        {
            var serviceDto = _mapper.Map<ServiceDto>(service);
            return Ok(serviceDto);
        } 
        else
        {
            _logger.LogInformation($"No service with id: {id} in the storage");

            return BadRequest();
        }
    }

    /// <summary>
    /// Creates service
    /// </summary>
    /// <remarks>
    /// POST-request for creating service entity
    /// </remarks>
    /// <response code="201">Service created</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Created service 
    /// </returns>
   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceDto>> CreateService([FromForm] CreateServiceCommand command)
    {
        _logger.LogInformation($"Posting new service model to the storage");

        if (command == null)
            return BadRequest();

        var service = await _mediator.Send(command);
        if (service is not null)
        {
            var serviceReturn = _mapper.Map<ServiceDto>(service);
            return Created($"/services/{serviceReturn.ServiceId}", serviceReturn);
        }
        else
        {
            _logger.LogError($"Something went wrong while adding new service model to the storage");

            return BadRequest();
        }
    }

    /// <summary>
    /// Updates service
    /// </summary>
    /// <remarks>
    /// PUT-request for updating service entity
    /// </remarks>
    /// <response code="200">Service updated</response>
    /// <response code="400">Bad request</response>
    /// <returns>
    /// Updated service 
    /// </returns>

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceDto>> UpdateService([FromForm] UpdateServiceCommand command)
    {
        _logger.LogInformation($"Updating service model with id: {command.ServiceId} in the storage");

        if (command == null)
            return BadRequest();

        var service = await _mediator.Send(command);
        if (service is not null)
        {
            var serviceResult = _mapper.Map<ServiceDto>(service);
            return Ok(serviceResult);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Deletes service
    /// </summary>
    /// <remarks>
    /// DELETE-request for updating service entity
    /// </remarks>
    /// <response code="200">Service deleted</response>
    /// <response code="400">Service not found</response>
    /// <returns>
    /// Deleted
    /// service 
    /// </returns>

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<ServiceDto>> DeleteService(int id)
    {
        _logger.LogInformation($"Deleting service model with id: {id} in the storage");

        var command = new DeleteServiceCommand
        {
            ServiceId = id
        };
        var service = await _mediator.Send(command);
        if (service is not null)
        {
            var serviceResult = _mapper.Map<ServiceDto>(service);
            return Ok(service);
        }
        else
        {
            _logger.LogInformation($"There is no model with id: {id} in the storage for deleting");

            return BadRequest();
        }
    }
}
