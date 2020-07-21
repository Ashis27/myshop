
using IdentityServer4.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyShop.Identity.ViewModels;
using System.Threading.Tasks;

namespace MyShop.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        //private readonly IOptionsSnapshot<AppSettings> _settings;
        //private readonly IRedirectService _redirectSvc;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IIdentityServerInteractionService interaction,
            IWebHostEnvironment environment, ILogger<HomeController> logger
          
            )
        {
            //IOptionsSnapshot<AppSettings> settings,IRedirectService redirectSvc
            _interaction = interaction;

            _environment = environment;
            _logger = logger;
            //_settings = settings;
            //_redirectSvc = redirectSvc;
        }

        public IActionResult Index()
        {
            if (_environment.IsDevelopment())
            {
                // only show in development
                return View();
            }

            _logger.LogInformation("Homepage is disabled in production. Returning 404.");
            return NotFound();
        }

        public IActionResult Index(string returnUrl)
        {
            return View();
        }

        //public IActionResult ReturnToOriginalApplication(string returnUrl)
        //{
        //    if (returnUrl != null)
        //        return Redirect(_redirectSvc.ExtractRedirectUriFromReturnUrl(returnUrl));
        //    else
        //        return RedirectToAction("Index", "Home");
        //}

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}