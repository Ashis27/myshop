using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyShop.Identity.Domain;
using MyShop.Identity.Helpers;
using MyShop.Identity.Infrastructure;
using MyShop.Identity.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.CommandHandlers.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Token>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserQueries _userQueries;
        private readonly IJwtAuthServices _jwtAuthServices;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginUserCommandHandler(IPasswordHasher<User> passwordHasher, IUserRepository userRepository,
            IUserQueries userQueries, IJwtAuthServices jwtAuthServices)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userQueries = userQueries;
            _jwtAuthServices = jwtAuthServices;
        }

        public async Task<Token> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueries.GetUserByEmail(request.UserNamne);

            if (user == null || !user.ValidatePassword(request.Password, _passwordHasher))
            {
                throw new IdentityDomainException("Invalid credentials.");
            }

            Token token = await _jwtAuthServices.GenerateEncodedJWTAsync(user.Id.ToString(), user.Email, "User");

            return token;
        }
    }
}
