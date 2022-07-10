using System.ComponentModel.DataAnnotations;

namespace CodeBase.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
