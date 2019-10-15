using ArchitectProject.ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectProject.UI.Web.Services.Profile
{
    public class ProfileManager
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IdentityUser _currentUser;

        public ProfileManager(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ApplicationUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

                return (ApplicationUser)_currentUser;
            }
        }

        public bool IsHasPassword(ApplicationUser user)
        {
            return _userManager.HasPasswordAsync(user).Result;
        }

        public bool IsEmailConfirmed(ApplicationUser user)
        {
            return _userManager.IsEmailConfirmedAsync(user).Result;
        }
    }
}
