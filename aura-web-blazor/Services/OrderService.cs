using aura_web_blazor.Data.Models;
using Newtonsoft.Json;

namespace aura_web_blazor.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;

        public List<DetaletEFaturimit>? detaletEFaturimit;

        public OrderService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<List<DetaletEFaturimit>> GetOrders()
        {
            //var httpRequestMessage = new HttpRequestMessage(
            //HttpMethod.Get,
            //"https://localhost:7174/api/Order")
            //{

            //};
            //var httpClient = _httpClientFactory.CreateClient();
            //var httpResponseMessage = await httpClient.GetAsync("api/Order");

            //if (httpResponseMessage.IsSuccessStatusCode)
            //{
            //    using var contentStream =
            //        await httpResponseMessage.Content.ReadAsStreamAsync();

            //    detaletEFaturimit = await JsonSerializer.DeserializeAsync
            //        <IEnumerable<DetaletEFaturimit>>(contentStream);
            //}

            //return detaletEFaturimit;
            
            var json = httpClient.GetAsync("api/Order").Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<DetaletEFaturimit>>(json);
        }

    }
}
