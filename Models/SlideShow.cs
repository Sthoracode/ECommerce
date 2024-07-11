using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SlideShow
    {
        [Key]
        public int SlideShowId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
    }
}
