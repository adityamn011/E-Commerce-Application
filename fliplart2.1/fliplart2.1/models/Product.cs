using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace fliplart2._1.models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        [Required]
        public string product_name { set; get; }
        public string product_description { set; get; }
        public int price { set; get; }

        [ForeignKey("User")]
        public string email { set; get; }
        
        public User User { set; get; }
        
    }
}
