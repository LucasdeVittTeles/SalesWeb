using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRecordsController : ControllerBase
    {

        private readonly ISalesRecordService _salesRecordService;

        public SalesRecordsController(ISalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        [HttpGet("simpleSearch")]
        public async Task<ActionResult<List<SalesRecord>>> SimpleSearch(DateTime minDate, DateTime maxDate)
        {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return Ok(result);
        }

        [HttpGet("GroupingSearch")]
        public async Task<ActionResult<List<IGrouping<Department, SalesRecord>>>> GroupingSearch(DateTime minDate, DateTime maxDate)
        {
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return Ok(result);
        }
    }
}
