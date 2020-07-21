using MediatR;
using Microsoft.AspNetCore.Identity;
using MyShop.Identity.Application.Domain;
using MyShop.Identity.CommandHandlers.CreateUser;
using MyShop.Identity.Domain;
using MyShop.Identity.Infrastructure;
using MyShop.Identity.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Identity.CommandHandlers.SignUp
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQueries _userQueries;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IPasswordHasher<User> passwordHasher,
            IUserRepository userRepository, IUserQueries userQueries,UserManager<ApplicationUser> userManager)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userQueries = userQueries;
            _userManager = userManager;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        { 
            var user = await _userQueries.GetUserByEmail(request.Email);

            if (user != null)
            {
                throw new IdentityDomainException($"User already exist with {request.Email}");
            }

            var newUser = new User(request.Email, request.Role, request.FirstName, request.LastName);
            newUser.SetPassword(request.Password, _passwordHasher);

            await _userRepository.AddAsync(newUser);
            await _userRepository.UnitOfWork.SaveEntitiesAsync();

            return true;
        }
    }
}
