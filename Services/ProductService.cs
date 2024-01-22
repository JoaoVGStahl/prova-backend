using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : ServiceBase<Product>
    {
        TestDbContext _ctx;
        private readonly int itemsPerPage = 10;

        public ProductService(TestDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public Pagination<Product> ListProducts(int page)
        {
            return ListItems(page);
        }
    }
}
