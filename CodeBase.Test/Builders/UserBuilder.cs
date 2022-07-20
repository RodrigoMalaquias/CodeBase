namespace CodeBase.Test.Builders
{
    using Borders.Models;
    using System;

    public class UserBuilder
    {
        private readonly User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public UserBuilder AddGuid(Guid id)
        {
            _user.Id = id;
            return this;
        }

        public UserBuilder AddAge(int age)
        {
            _user.Age = age;
            return this;
        }

        public UserBuilder AddName(string name)
        {
            _user.Name = name;
            return this;
        }

        public User Build() => _user;
    }
}
