using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SunsetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunsetHotel
{
    public class SunsetHub:Hub
    {
        private readonly UserManager<AppUser> _userManager;

        public SunsetHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectionId = Context.ConnectionId;
                var result = _userManager.UpdateAsync(user).Result;
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectionId = null;
                var result = _userManager.UpdateAsync(user).Result;
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
