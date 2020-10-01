using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CampaignApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordService _recordService;

        public RecordsController(RecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpPost("{campaign_id:length(24)}/register/{user_id:length(24)}", Name = "UserRegister")]
        public ActionResult<Record> Register(string campaign_id, string user_id)
        {
            var record = new Record() { CampaignId = campaign_id, UserId = user_id, UserEntries = 1 };

            _recordService.Register(record);

            return CreatedAtRoute("UserRegister", new { id = record.Id.ToString() }, record);
        }

        [HttpGet("{campaign_id:length(24)}/top10")]
        public ActionResult<List<Record>> GetTop10(string campaign_id)
        {
            var list = _recordService.GetTop10(campaign_id);

            return list;
        }

        [HttpGet("{campaign_id:length(24)}")]
        public ActionResult<List<Record>> GetAll(string campaign_id)
        {
            var list = _recordService.GetAll(campaign_id);

            return list;
        }
    }
}