using ECommerce.Models;

namespace ECommerce.Data
{
    public interface ISlideShowRepository : IRepositoryBase<SlideShow>
    {
        SlideShow GetSlideShowWithhAllImages(string name);
    }
}
