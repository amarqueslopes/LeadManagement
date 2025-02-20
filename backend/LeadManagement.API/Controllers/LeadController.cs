using LeadManagement.Domain.Models;
using LeadManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ILeadService _leadService;

    public LeadsController(ILeadService leadService)
    {
        _leadService = leadService;
    }

    // GET: api/Leads/Invited
    [HttpGet("Invited")]
    public async Task<ActionResult<IEnumerable<Lead>>> GetInvitedLeads()
    {
        var leads = await _leadService.GetLeadsByStatusAsync("Invited");
        return Ok(leads);
    }

    // GET: api/Leads/Accepted
    [HttpGet("Accepted")]
    public async Task<ActionResult<IEnumerable<Lead>>> GetAcceptedLeads()
    {
        var leads = await _leadService.GetLeadsByStatusAsync("Accepted");
        return Ok(leads);
    }

    // PUT: api/Leads/Accept/5
    [HttpPut("Accept/{id}")]
    public async Task<IActionResult> AcceptLead(int id)
    {
        try
        {
            await _leadService.AcceptLeadAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // PUT: api/Leads/Decline/5
    [HttpPut("Decline/{id}")]
    public async Task<IActionResult> DeclineLead(int id)
    {
        try
        {
            await _leadService.DeclineLeadAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
