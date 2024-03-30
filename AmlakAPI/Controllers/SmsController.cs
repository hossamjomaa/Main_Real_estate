using AmlakAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmlakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;


        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("SendSms", Name = "SendSms")]
        
        public async Task<IActionResult> SendSms(SmsMessage message)
        {
            if (message.Key != "Amlak@123")
            {
                return BadRequest("Invalid Key");
            }

            
            var result = await _smsService.SendSmS(message.Number, message.Message).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
