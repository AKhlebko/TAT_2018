using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKLoginAndLogOut
{
    public class Selectors
    {
        public static readonly string LoginFormSelector = @"//*[@name='login'][@id='index_login_form']";
        public static readonly string LoginInputForm = @"//input[@placeholder='Phone or email'][@name='email']";
        public static readonly string LoginPasswordForm = @"//input[@placeholder='Password'][@name='pass']";
        public static readonly string LoginPushButton = @"//button[@id='index_login_button']";

        public static readonly string LogOutMenu = @"//a[@id='top_profile_link']";
        public static readonly string LogOutButton = @"//a[@id='top_logout_link']";

        public static readonly string LMessageButton = @"//li[@id='l_msg']";
        public static readonly string UserInDialogFinder = @"//div[@class='ui_search_input_block']";
        public static readonly string UserSearchInputForm = @"//input[@class='ui_search_field _field']";
    }
}
