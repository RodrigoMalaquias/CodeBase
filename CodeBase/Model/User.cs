using System.ComponentModel.DataAnnotations;

namespace CodeBase.Model
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
