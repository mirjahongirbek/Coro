using OtpClient.Modals;

namespace OtpClient
{
    public interface IClient
    {
        void AddHeader(string key, string value);
        int Timer { get; set; }
        ProjectConfig Config { get; }
    }
}
