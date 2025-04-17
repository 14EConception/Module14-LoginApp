using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Model;
using LoginApp.Utils;
using LoginApp.Utils.Services.Interfaces;

namespace LoginApp.ViewModel
{
    internal class WelcomeViewModel : BaseViewModel
    {
        private readonly IUserService _userService;

        public string WelcomeMessage 
        { get 
            {
                User? user = _userService.CurrentUser;
                if (user != null)
                {
                    return $"Bienvenue, {user.Email}!";
                }
                else
                {
                    return "Bienvenue";
                }
            } 
        }

        public WelcomeViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
