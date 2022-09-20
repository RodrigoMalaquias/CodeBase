namespace CodeBase.Test.Builders
{
    using CodeBase.Borders.Models;
    using System;

    class ProductBuilder
    {
        private readonly Product _product;

        public ProductBuilder()
        {
            _product = new Product();
        }

        public ProductBuilder AddGuid(Guid id)
        {
            _product.Id = id;
            return this;
        }

        public ProductBuilder AddName(string name)
        {
            _product.Name = name;
            return this;
        }

        public ProductBuilder AddPrice(double price)
        {
            _product.Price = price;
            return this;
        }

        public Product Build() => _product;
    }
}
