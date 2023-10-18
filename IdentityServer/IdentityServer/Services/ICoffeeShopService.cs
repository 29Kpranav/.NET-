using IdentityServer.Models;

namespace IdentityServer.Services
{
    public interface ICoffeeShopService
    {
        Task<List<CoffeeShopModel>> List();
    }
}
