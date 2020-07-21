using MediatR;
using MyShop.Identity.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.CommandHandlers.LoginUser
{
    public class LoginUserCommand : IRequest<Token>
    {
        public string UserNamne { get; private set; }
        
        public string Password { get; private set; }

        public bool RememberMe { get; private set; }

        private LoginUserCommand() { }

        [JsonConstructor]
        public LoginUserCommand(string userName, string password, bool rememberMe)
        {
            UserNamne = userName;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
