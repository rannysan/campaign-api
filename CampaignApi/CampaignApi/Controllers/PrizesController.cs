using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CampaignApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizesController : ControllerBase
    {
        private readonly PrizeService _prizeService;

        public PrizesController(PrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        [HttpGet]
        public ActionResult<List<Prize>> Get()
        {
            var list = _prizeService.GetList();

            return list;
        }

        [HttpPost]
        public ActionResult<Prize> Create(Prize prize)
        {
            _prizeService.Create(prize);

            return CreatedAtRoute("CreateCampaign", new { id = prize.Id.ToString() }, prize);
        }
    }
}
