using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Model;

namespace LoginApp.Utils.Services.Interfaces
{
    public interface IUserService
    {
        public User? CurrentUser { get; }
        public bool Login(string email, string password);
    }
}
