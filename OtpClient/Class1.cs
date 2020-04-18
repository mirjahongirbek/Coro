using OtpClient.Modals;

namespace OtpClient
{
    public class Client : IClient
    {
        private ClientData _clientData;
        public Client(string url, string projectName, string password)
        {
            _clientData = new ClientData();


        }
        public OtpIndex Message { get; }

        public void AddHeader(string key, string value)
        {
            _clientData.Headers.Add(key, value);
        }
        public ProjectConfig Config { get; }
        public int Timer { get; set; } = 20000;

    }
}
