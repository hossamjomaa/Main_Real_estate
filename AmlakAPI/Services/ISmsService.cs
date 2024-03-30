

using SMS = SMSGlobal.Response.SMS;

namespace AmlakAPI.Services
{
    public interface ISmsService
    {
        Task<bool> SendSmS(string destination, string message);
    }
}
