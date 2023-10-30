using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services;

public class DeliveryFeeService : IDeliveryFeeService
{
    public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
    {
        var cliente = new RestClient("https://api.myorg.com");
        var request = new RestRequest()
            .AddJsonBody(new
            {
                ZipCode = zipCode
            });
        var response = await cliente.PostAsync<decimal>(request);
        return response < 5 ? 5 : response;
    }
}