using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Data.Repositories.Interfaces;
using LoginApp.Model;
using LoginApp.Utils.Services.Interfaces;

namespace LoginApp.Utils.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private User? _currentUser;

        public User? CurrentUser
        {
            get { return _currentUser; }
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string email, string password)
        {
            User? user = _userRepository.GetByEmailAndPassword(email, password);
            if (user != null)
            {
               _currentUser = user;
            }
            
            return user != null;
        }

    }
}
