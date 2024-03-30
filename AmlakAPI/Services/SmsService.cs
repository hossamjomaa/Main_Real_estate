


using SMS = SMSGlobal.Response.SMS;

namespace AmlakAPI.Services
{
    public class SmsService : ISmsService
    {
        public async Task<bool> SendSmS(string destination, string message)
        {
            var client = new Client(new Credentials("ef0267d1baf3a0871cf43eb526080215", "c8520c8e2c4687f957ac5f2ed92eb319"));

            var response = await client.SMS.SMSSend(new
            {
                origin = "WISDOMTECH",
                destination,
                message
            });

            return response.statuscode == 200;
        }
    }
}
