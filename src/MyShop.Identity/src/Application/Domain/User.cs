using Microsoft.AspNetCore.Identity;
using MyShop.CommonUtility.Types;
using MyShop.Identity.Application.DomainEventHandlers.UserCreated;
using MyShop.Identity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShop.Identity.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public string PasswordHash { get; private set; }


        public User(string email, string role, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email.ToLowerInvariant();

            if (!Helpers.Role.Validate(role))
            {
                throw new IdentityDomainException("Invalid role");
            }

            Role = role;

            AddUserDomainEvent();
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new IdentityDomainException("Password can not be empty");
            }

            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        private void AddUserDomainEvent()
        {
            this.AddDomainEvent(new UserCreatedDomainEvent(UId, this));
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
        {
            return passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
        }

    }
}
