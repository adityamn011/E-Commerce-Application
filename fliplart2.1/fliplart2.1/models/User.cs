using System.ComponentModel.DataAnnotations;

namespace fliplart2._1.models
{
    public class User
    {
        [Key]
        public string email { set; get; }
        public string name { set; get;}
        public string password { set; get; }
    }
}
