using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CartBusinessLogicLayer.ExternalServices
{
    public class ExternalCustomerServices : IExternalCustomerServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ExternalCustomerServices(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CustomerExistsAsync(int? id)
        {
            using var client = _httpClientFactory.CreateClient("customer");
            var response = await client.GetAsync($"customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else 
            {
                return false;
               
            }

        }
    }
}
