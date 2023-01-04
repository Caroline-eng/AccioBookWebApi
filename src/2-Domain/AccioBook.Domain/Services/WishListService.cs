using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class WishListService : DatabaseService<WishList>, IWishListService
    {
        public WishListService(IWishListRepository repository) : base(repository)
        {

        }
    }
}
