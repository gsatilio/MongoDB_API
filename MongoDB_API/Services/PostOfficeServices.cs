using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using MongoDB_API.Models;
using System.Net.NetworkInformation;
using Newtonsoft.Json;

namespace MongoDB_API.Services
{
    public class PostOfficeServices
    {
        static readonly HttpClient address = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            string _url = "https://viacep.com.br/ws";
            AddressDTO address = new();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{_url}/{cep}/json/";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        address = JsonConvert.DeserializeObject<AddressDTO>(json);
                    }
                    else
                    {
                        address = null;
                        Console.WriteLine("Erro no consumo do WS CEP.");
                        Console.WriteLine(response.StatusCode);
                    }
                }
                return address;
            }
            catch
            {
                throw;
            }
        }
    }
}
