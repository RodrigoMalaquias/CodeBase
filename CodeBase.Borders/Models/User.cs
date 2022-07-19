namespace CodeBase.Borders.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
