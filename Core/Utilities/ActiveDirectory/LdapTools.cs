using System.Net;
using System.Text;
using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Core.Utilities.ActiveDirectory
{
    public class LdapTools : ILdapTools
    {



        public LdapTools(IConfiguration configuration)
        {

        }


        private string GetToken(string sUserName, string sPassword)
        {
            var resourceAddress = "http://10.0.6.30:5000/api/Auth/token";

            using (var client = new WebClient())
            {
                var ClientData = new
                {
                    username = sUserName,
                    password = sPassword
                };

                var dataStringJson = JsonConvert.SerializeObject(ClientData);
                var response = "";
                client.Encoding = Encoding.UTF8;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                try
                {
                    response = client.UploadString(new Uri(resourceAddress), "POST", dataStringJson);
                    return response.ToString();
                }
                catch (WebException we)
                {
                    return we.Message;
                }

            }
        }

        public class HttpHelper
        {
            public static async Task<T> GetDataFromApi<T>(string url)
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync(url);
                    result.EnsureSuccessStatusCode();
                    string resultContentString = await result.Content.ReadAsStringAsync();
                    T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);
                    return resultContent;
                }
            }
        }


        public bool ValidateCredentials(string sUserName, string sPassword)
        {
            
            var url = "http://10.0.6.30:5000/api/Auth/loginldap";
            var ClientData = new
            {
                username = sUserName,
                password = sPassword
            };

            using (var client = new WebClient())
            {
               

                var dataStringJson = JsonConvert.SerializeObject(ClientData);
                var response = "";
                client.Encoding = Encoding.UTF8;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers.Add(HttpRequestHeader.From, dataStringJson);
                //client.Headers.Add(HttpRequestHeader.Authorization, "Bearer" + token);

                try
                {
                    response = client.UploadString(new Uri(url),dataStringJson);
                    var user = JsonConvert.DeserializeObject<User>(response);
                    if (user.UserName != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (WebException we)
                {
                    return false;
                }


            }



        }

    }
}