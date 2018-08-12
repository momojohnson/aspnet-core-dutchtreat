using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
    public class NullMailService : ImailService
    {
    private readonly ILogger<NullMailService> _logger;
    public NullMailService(ILogger<NullMailService> logger)
    {
        _logger = logger;
    }
        public void SendMail(string to, string from, string subject, string body)
        {
            _logger.LogInformation($"To{to} from:{from} subject{subject} body: {body}");
        }
    }
}