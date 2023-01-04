using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        public WishListRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
