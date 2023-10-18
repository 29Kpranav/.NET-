using DataAccess.Data;
using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace IdentityServer.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ApplicationDbContext dbContext;

        public CoffeeShopService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeShops = await (from shop in dbContext.CoffeeShop 
                                    select new CoffeeShopModel()
                                    {
                                        Id = shop.Id,
                                        Name = shop.Name,
                                        OpeningHours = shop.OpeningHours,
                                        Address = shop.Address,
                                    }).ToListAsync();
            return coffeShops; 
        }
         
    }
}
