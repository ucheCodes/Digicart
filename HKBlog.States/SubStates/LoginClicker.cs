using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class LoginClicker
    {
        public bool ShowLogin { get; } = false;
        public bool ShowSignup { get; } = false;
        public LoginClicker(bool showLogin, bool showSignup)
        {
            ShowLogin = showLogin;
            ShowSignup = showSignup;
        }
    }
}
