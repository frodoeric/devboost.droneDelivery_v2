using System;

namespace devboost.Domain.Model
{
    public class User
    {
        public User(string userName, string paswword, string role)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Paswword = paswword;
            Role = role;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Paswword { get; private set; }
        public string Role { get; private set; }

        public bool SenhaEValida(string password)
        {
            return password == Paswword;
        }
    }
}
