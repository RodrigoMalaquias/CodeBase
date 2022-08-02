namespace CodeBase.Borders.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
