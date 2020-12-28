using System.Threading.Tasks;
using Convey.CQRS.Commands;
using IncidentReport.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace IncidentReport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DraftApplicationController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DraftApplicationController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(CreateDraftApplication command)
        {
            //lack of return id, don't want to waste time for testing 
            await _commandDispatcher.SendAsync(command);

            return Created("api/DraftApplication", null);
        }
        
        // //Just For simplify first test
        // [HttpGet]
        // public async Task<ActionResult> Get(CreateDraftApplication command)
        // {
        //     //lack of return id, don't want to waste time for testing 
        //     await _commandDispatcher.SendAsync(command);
        //
        //     return Created("api/DraftApplication", null);
        // }
    }
}