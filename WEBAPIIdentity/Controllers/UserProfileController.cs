using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBAPIIdentity.Models;

namespace WEBAPIIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController( UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }

        [HttpGet]
        [Authorize]
        //GET : api/UserProfile/GetUserProfile

        public async Task<Object> GetUserProfile()
        {
            string userID = User.Claims.First(c => c.Type == "UserID").Value;
            var user =  await _userManager.FindByIdAsync(userID);
            return new
            {
                user.FullName,
                user.Email
            };
        }
    }
}