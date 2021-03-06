﻿
using Microsoft.AspNetCore.Http;
using System;

namespace MyShop.Basket.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context; 

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserIdentity()
        {
            return _context.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User.FindFirst("preferred_username").Value;
        }
    }
}
