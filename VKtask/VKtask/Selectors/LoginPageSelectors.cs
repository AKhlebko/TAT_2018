using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class LoginPageSelectors
    {
        public readonly string LoginInputForm;
        public readonly string LoginPasswordForm;
        public readonly string LoginPushButton;

        public LoginPageSelectors()
        {
            LoginInputForm = "//input[@placeholder='Phone or email'][@name='email']";
            LoginPasswordForm = "//input[@placeholder='Password'][@name='pass']";
            LoginPushButton = "//button[@id='index_login_button']";
        }
    }
}
