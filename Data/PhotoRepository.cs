using ECommerce.Models;

namespace ECommerce.Data
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoReposiory
    {
        public PhotoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
