using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class LoginFailedPageSelectors
    {
        public readonly string LoginInputForm;
        public readonly string LoginPasswordForm;
        public readonly string LoginPushButtonFailedPage;

        public LoginFailedPageSelectors()
        {
            LoginInputForm = "//input[@placeholder='Phone or email'][@name='email']";
            LoginPasswordForm = "//input[@placeholder='Password'][@name='pass']";
            LoginPushButtonFailedPage = "//button[@id='login_button']";
        }
    }
}
