using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Path { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("SlideShow")]
        public int? SlideShowId { get; set; }

        public SlideShow SlideShow { get; set; }
        public Product Product { get; set; }
    }
}
