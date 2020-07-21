using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShop.CommonUtility.EvenLogContext;
using MyShop.CommonUtility.EvenLogContext.Services;
using MyShop.CommonUtility.EvenLogContext.Utilities;
using MyShop.Identity.Application.Domain;
using MyShop.Identity.Application.IntegrationEventHandlers;
using MyShop.Identity.Application.IntegrationEventHandlers.Events;
using MyShop.Identity.Helpers;
using MyShop.Identity.Infrastructure.Interfaces;
using MyShop.Identity.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure.Services
{
    public class LoginService : ILoginService<ApplicationUser>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationUserDBContext _context;
        private readonly UserContext _userContext;
        private readonly ILogger<LoginService> _logger;
        private readonly IIdentityIntegrationEventService _identityIntegrationEventService;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            ILogger<LoginService> logger, UserContext userContext, ApplicationUserDBContext context,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            IntegrationEventLogContext eventLogContext, IIdentityIntegrationEventService identityIntegrationEventService
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _userContext = userContext;
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _logger = logger;
            _identityIntegrationEventService = identityIntegrationEventService;
            _eventLogService = _integrationEventLogServiceFactory(_userContext.Database.GetDbConnection());
        }

        public async Task<ApplicationUser> FindByUserName(string user)
        {
            return await _userManager.FindByEmailAsync(user);
        }

        public async Task<bool> ValidateCredentials(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> SignUpAsync(RegisterViewModel model)
        {
            _logger.LogInformation("Initiatted Created user event with email {email}", model.Email);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            var userId = await _userManager.GetUserIdAsync(user);
            await AddRoles(user, null);

            var createUserIntegrationEvent = new CreateUserIntegrationEvent(new Guid(userId), model.FirstName, model.LastName);

            //await _identityIntegrationEventService.AddAndSaveEventAsync(createUserIntegrationEvent);

            await _identityIntegrationEventService.PublishThroughEventBusAsync(createUserIntegrationEvent);

            return result;
        }

        private async Task AddRoles(ApplicationUser user, List<string> roles)
        {
            if (roles != null && roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    if (!Role.Validate(role))
                    {
                        await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(JwtClaimTypes.Role, role));
                    }
                }
            }
        }

        public Task SignIn(ApplicationUser user)
        {
            return _signInManager.SignInAsync(user, true);
        }

        public Task SignInAsync(ApplicationUser user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            return _signInManager.SignInAsync(user, properties, authenticationMethod);
        }
    }
}
