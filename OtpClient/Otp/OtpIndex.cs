
using Newtonsoft.Json;
using OtpClient.Modals;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OtpClient
{
    public class OtpIndex
    {
        ClientData _client;
        public OtpIndex(ClientData client)
        {
            _client = client;

        }

        public async Task SendMessage(object data)
        {

            var ser = JsonConvert.SerializeObject(data);
            SendModal modal = null;
            try
            {
                modal = JsonConvert.DeserializeObject<SendModal>(ser);
            }
            catch (Exception ext)
            {

            }
            if (modal != null && modal.Messages.Count > 0 && !string.IsNullOrEmpty(modal.Messages[0].Recipient))
            {
                var result = await SendMessage(modal);

            }
            var client = ClientData.BeforeSend(_client);

        }
        public async Task<HttpResponseMessage> SendMessage(SendModal modal)
        {
            var client = ClientData.BeforeSend(_client);
            var result = await ClientData.PostAsync(client, "/api/otp/SendMessage", modal);
            return result;
        }
        public async Task SendOtp(string PhoneNumber)
        {
            var client = ClientData.BeforeSend(_client);
            var result = await ClientData.GetAsync(client, _client.BaseUrl() + "/api/otp/SendOtp?phoneNumber=" + PhoneNumber);

        }
        public async Task<bool> CheckOtp(CheckOtpModal model)
        {
            var client = ClientData.BeforeSend(_client);
            var response = await ClientData.PostAsync(client, _client.BaseUrl() + "/api/CheckOtp", model);
            return true''
        }
        public async Task<bool> CheckOtp(string phoneNumber, string otp, string token)
        {
            CheckOtpModal otpModal = new CheckOtpModal() { Otp = otp, PhoneNumber = phoneNumber, Token = token };
            return await CheckOtp(otpModal);
        }
    }
}
