
using OtpClient.Modals;

namespace OtpClient.Configs
{
    public class ConfigIndex
    {
        ClientData _client;
        public ConfigIndex(ClientData clientData)
        {
            _client = clientData;
            ClientData.AddConfig(null);
        }
        
        public ProjectConfig Config
        {
            get; set;
        }

    }
}
