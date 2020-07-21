using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Identity.Helpers
{
    public sealed class Token
    {
        public int Id { get; }
        public string UserName { get; }
        public string AuthToken { get; }
        public string RefreshToken { get; }
        public int ExpiresIn { get; }

        public Token(int id,string userName, string authToken, int expiresIn, string refreshToken)
        {
            Id = id;
            UserName = userName;
            AuthToken = authToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
        }
    }
}
