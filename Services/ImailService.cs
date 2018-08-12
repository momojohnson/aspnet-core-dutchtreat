namespace DutchTreat.Services
{
    public interface ImailService
    {
         void SendMail(string to, string from, string subject, string body);
    }
}