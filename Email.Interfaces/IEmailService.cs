namespace Email.Interfaces
{
    public interface IEmailService
    {
        Task Send(string address, string subject, string body);
    }
}
