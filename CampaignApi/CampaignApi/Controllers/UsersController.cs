using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserApi.Services;

namespace CampaignApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly RecordService _recordService;
        private readonly PrizeService _prizeService;

        public UsersController(UserService userService, RecordService recordService, PrizeService prizeService)
        {
            _userService = userService;
            _recordService = recordService;
            _prizeService = prizeService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetList()
        {
            var list = _userService.GetList();

            return list;
        }

        [HttpGet("registercount/{id:length(24)}")]
        public ActionResult<int> GetRegisterCount(string id)
        {
            var count = _recordService.UserRegisterCount(id);

            return count;
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> GetById(string id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            user = _userService.Create(user);

            return CreatedAtRoute("CreateUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPost("speciallink/{record_id:length(24)}")]
        public ActionResult<User> CreateWithSpecialLink(User user, string record_id)
        {
            _userService.Create(user);
            _recordService.AddEntry(record_id);

            return user;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User customerIn)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, customerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }

        [HttpGet("{id:length(24)}/prizes/{campaign_id:length(24)}")]
        public ActionResult<List<Prize>> GetListOfPrizes(string id, string campaign_id)
        {
             var position = _recordService.GetPosition(id, campaign_id);

            return _prizeService.GetListByPosition(position);
        }
    }
}
