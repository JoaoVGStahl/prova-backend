using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ServiceBase<E> where E : class
    {
        TestDbContext _ctx;
        private readonly int itemsPerPage = 10;

        public ServiceBase(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public Pagination<E> ListItems(int page)
        {
            return new Pagination<E>()
            {
                HasNext = false,
                TotalCount = itemsPerPage,
                Items = _ctx.Set<E>().Skip((page - 1) * itemsPerPage)
                                     .Take(itemsPerPage)
                                     .ToList()
            };
        }
    }
}
