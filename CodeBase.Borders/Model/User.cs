using System;
using System.ComponentModel.DataAnnotations;

namespace CodeBase.Borders.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
