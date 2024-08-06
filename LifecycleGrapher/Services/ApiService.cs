using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LifecycleGrapher.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _apiUser;
        private readonly string _apiPasswd;

        public string Endpoint {
            get { return _endpoint; }
        }

        public ApiService(string endpoint, string apiUser, string apiPasswd, string objectName)
        {
            _httpClient = new HttpClient();
            _endpoint = $"{endpoint}/api-v2.2/{objectName.ToLower()}/describe";
            _apiUser = apiUser;
            _apiPasswd = apiPasswd;

            var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_apiUser}:{_apiPasswd}"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
        }

        public string GetData()
        {
            var response = _httpClient.GetStringAsync(_endpoint).Result;
            return response;
        }
    }
}
