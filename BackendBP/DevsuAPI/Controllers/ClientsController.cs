using Application.DTOs;
using Application.Features.Clients.Commands.CreateClient;
using Application.Features.Clients.Commands.UpdateClient;
using Application.Features.Clients.Queries.GetClientById;
using Application.Features.Clients.Queries.GetClients;
using Persistence.Models;

namespace DevsuAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        var result = await _mediator.Send(new GetClientsQuery());

        if (!result.Success) return StatusCode(500, result.Message);
        if (result.Result == null)
        {
            return Ok("No existen clientes para mostrar");
        }
        return Ok(result.Result);
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(int id)
    {
        var result = await _mediator.Send(new GetClientByIdQuery(id));

        if (!result.Success)
        {
            if (string.IsNullOrEmpty(result.Message)) return BadRequest(result.Errors);
            return StatusCode(500, result.Message);
        }

        if (result.Result == null)
        {
            return Ok("No existen clientes para mostrar");
        }
        return Ok(result.Result);
    }

    //PUT: api/Clients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(ClientDTO client)
    {
        var result = await _mediator.Send(new UpdateClientCommand(client));

        if (result.Success) return CreatedAtAction("PostClient", new { id = result.Result }, client);
        if (string.IsNullOrEmpty(result.Message)) return BadRequest(result.Errors);
        return StatusCode(500, result.Message);
    }

    // POST: api/Clients
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ClientDTO>> PostClient(ClientDTO client)
    {
        var result = await _mediator.Send(new CreateClientCommand(client));

        if (result.Success) return CreatedAtAction("PostClient", new { id = result.Result }, client);
        if (string.IsNullOrEmpty(result.Message)) return BadRequest(result.Errors);
        return StatusCode(500, result.Message);
    }

    //// DELETE: api/Clients/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteClient(int id)
    //{
    //    if (_context.Clients == null)
    //    {
    //        return NotFound();
    //    }
    //    var client = await _context.Clients.FindAsync(id);
    //    if (client == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Clients.Remove(client);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool ClientExists(int id)
    //{
    //    return (_context.Clients?.Any(e => e.ClientId == id)).GetValueOrDefault();
    //}
}
