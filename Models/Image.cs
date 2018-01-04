using System.ComponentModel.DataAnnotations;

namespace api_thinkaboutitbc.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        
        public byte[] FullImage { get; set; }

        public byte[] ThumbnailImage { get; set; }
    
    
    }
}