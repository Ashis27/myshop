using MyShop.CommonUtility.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string ProfilePicURL { get; private set; }

        public string FileName { get; private set; }


        private readonly List<Address> _address;

        public IReadOnlyCollection<Address> Address => _address;

        protected User()
        {
            _address = new List<Address>();
        }

        [JsonConstructor]
        public User(Guid userId, string firstName, string lastName)
        {
            UId = userId;
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddNewAdress(Guid userId, string street, string city, string state, string country, string zipCode)
        {
            if (userId != null)
            {
                var address = new Address(userId, street, city, state, country, zipCode);
                _address.Add(address);
            }
        }
    }
}
