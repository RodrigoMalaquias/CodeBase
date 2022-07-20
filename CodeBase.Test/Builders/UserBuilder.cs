using CodeBase.Borders.Model;
using System;

namespace CodeBase.Test.Builders
{
    public class UserBuilder
    {
        private readonly User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder AddGuid(Guid id)
        {
            user.Id = id;
            return this;
        }

        public UserBuilder AddAge(int age)
        {
            user.Age = age;
            return this;
        }

        public UserBuilder AddName(string name)
        {
            user.Name = name;
            return this;
        }

        public User Build() => user;
    }
}
