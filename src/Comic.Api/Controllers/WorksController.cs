using Comic.Api.Data;
using Comic.Api.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comic.Api.Controllers;

[ApiController]
[Route("works")]
public sealed class WorksController : ControllerBase
{
    private readonly AppDbContext _db;

    public WorksController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<Work>>> List(CancellationToken ct)
    {
        var items = await _db.Works.OrderBy(x => x.Id).ToListAsync(ct);

        return Ok(items);
    }

    public sealed record CreateWorkRequest(string Name, long? PublisherId);

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Work>> Create(
        [FromBody] CreateWorkRequest req,
        CancellationToken ct
    )
    {
        try
        {
            var work = new Work(req.Name, req.PublisherId);

            _db.Works.Add(work);
            await _db.SaveChangesAsync(ct);

            return Created($"/works/{work.Id}", work);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
