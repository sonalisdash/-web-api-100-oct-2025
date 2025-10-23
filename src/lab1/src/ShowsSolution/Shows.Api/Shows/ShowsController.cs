using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shows.Api.Shows.Entities;
using Shows.Api.Shows.Models;
using Marten;

namespace Shows.Api.Shows;
public class ShowsController(IDocumentSession session) : ControllerBase
{ 

    [HttpPost("/api/shows")]
    public async Task<ActionResult> AddShowsAsync(
    [FromBody] ShowCreateModel model
    )

    {
        
        var entity = new ShowEntity
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            StreamingService = model.StreamingService,
            CreatedAt= model.CreatedAt
        };
        return Ok(model);

        //session.Store(entity);
        //await session.SaveChangesAsync();

        //var response = new ShowDetailsModel
        //{
        //    Id = entity.Id,
        //    Name = entity.Name,
        //    Description = entity.Description,
        //    StreamingService = entity.StreamingService,
        //    CreatedAt=entity.CreatedAt
        //};


        //return StatusCode(201, response);
    }

    [HttpGet("/api/shows")]
    public async Task<ActionResult> GetAllShowsAsync()
    {
        var shows = await session.Query<ShowEntity>()
            .OrderBy(v => v.Name).ToListAsync();

        //var response = new ShowsSummaryModelCollection<ShowSummaryItem>();

        //response.Data = shows.Select(v => new ShowSummaryItem
        //{
        //    Id = v.Id,
        //    Name = v.Name,
        //}).ToList();

        //return Ok(response);
        return Ok(shows);
    }

    // GET 
    [HttpGet("/shows/{id:guid}")]
    public async Task<ActionResult> GetVendorByIdAsync(Guid id)
    {
        var shows = await session.Query<ShowEntity>()
            .Where(v => v.Id == id)
            .SingleOrDefaultAsync();
        if (shows == null)
        {
            return NotFound();
        }
        else
        {
            var response = new ShowDetailsModel
            {
                Id = shows.Id,
                Name = shows.Name,
                Description= shows.Description,
                StreamingService=shows.StreamingService
            };
            return Ok(response);
        }
    }



}
