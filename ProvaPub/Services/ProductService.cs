using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : ServiceBase<Product>
    {
        public ProductService(TestDbContext ctx) : base(ctx)
        {

        }

        public async Task<Pagination<Product>> ListProductsAsync(int page) => await ListItemsAsync(page);
    }
}
