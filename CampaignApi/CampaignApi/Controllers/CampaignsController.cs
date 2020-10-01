using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CampaignApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly CampaignService _campaignService;

        public CampaignsController(CampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public ActionResult<List<Campaign>> Get()
        {
            var list = _campaignService.GetList();

            return list;
        }

        [HttpGet("{id:length(24)}", Name = "GetCampaign")]
        public ActionResult<Campaign> GetById(string id)
        {
            var campaign = _campaignService.GetById(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return campaign;
        }

        [HttpGet("customer/{customer_id:length(24)}", Name = "GetCampaignByCustomer")]
        public ActionResult<List<Campaign>> GetByCustomerId(string customer_id)
        {
            var campaign = _campaignService.GetByCustomerId(customer_id);

            if (campaign == null)
            {
                return NotFound();
            }

            return campaign;
        }

        [HttpPost]
        public ActionResult<Campaign> Create(Campaign campaign)
        {
            _campaignService.Create(campaign);

            return CreatedAtRoute("CreateCampaign", new { id = campaign.Id.ToString() }, campaign);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Campaign customerIn)
        {
            var campaign = _campaignService.GetById(id);

            if (campaign == null)
            {
                return NotFound();
            }

            _campaignService.Update(id, customerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var campaign = _campaignService.GetById(id);

            if (campaign == null)
            {
                return NotFound();
            }

            _campaignService.Remove(campaign.Id);

            return NoContent();
        }
    }
}