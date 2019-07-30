using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApp.Models.User;

namespace TodoApp.Services
{
    public interface IAuthyService
    {
        Task<string> registerUserAsync(UserRegister user);

    }

    public class AuthyService : IAuthyService
    {
        private readonly IHttpClientFactory ClientFactory;
        private readonly HttpClient client;

        public AuthyService(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
            client = ClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.authy.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("user-agent", "Twilio Account Security C# Sample");

            // Get Authy API Key from Configuration
            client.DefaultRequestHeaders.Add("X-Authy-API-Key", "jc7pNcU9IDdFShAnUnsgaDeqWVnsIFZa");
        }

        public async Task<string> registerUserAsync(UserRegister user)
        {
            var userRegData = new Dictionary<string, string>() {
                { "email", user.Email },
                { "country_code", user.CountryCode },
                { "cellphone", user.PhoneNumber }
            };
            var userRegRequestData = new Dictionary<string, object>() { };
            userRegRequestData.Add("user", userRegData);
            var encodedContent = new FormUrlEncodedContent(userRegData);

            var result = await client.PostAsJsonAsync("/protected/json/users/new", userRegRequestData);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsAsync<Dictionary<string, object>>();

            return JObject.FromObject(response["user"])["id"].ToString();
        }
    }
}
