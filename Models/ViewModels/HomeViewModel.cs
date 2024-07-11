namespace ECommerce.Models.ViewModels
{
    public class HomeViewModel
    {
        public SlideShow SlideShow { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
