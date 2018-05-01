using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class LogOutMenuSelectors
    {
        public readonly string OpenMenu;
        public readonly string LogOutButton;

        public LogOutMenuSelectors()
        {
            OpenMenu = "//a[@id='top_profile_link']";
            LogOutButton = "//a[@id='top_logout_link']";
        }
    }
}
