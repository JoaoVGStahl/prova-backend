using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class ServiceBase<E> where E : class
    {
        private readonly DbContext _ctx;
        private readonly int itemsPerPage = 10;

        public ServiceBase(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Pagination<E>> ListItemsAsync(int page)
        {
            var totalItems = await _ctx.Set<E>().CountAsync();
            var items = await _ctx.Set<E>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return new Pagination<E>()
            {
                HasNext = totalItems > page * itemsPerPage,
                TotalCount = totalItems,
                Items = items
            };
        }
    }
}
