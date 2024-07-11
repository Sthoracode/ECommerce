using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class SlideShowRepository :  RepositoryBase<SlideShow>, ISlideShowRepository
    {
        public SlideShowRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public SlideShow GetSlideShowWithhAllImages(string name)
        {
            return _appDbContext.SlideShows.Include(s => s.Photos).FirstOrDefault(s => s.Name == name);
        }
    }
}
