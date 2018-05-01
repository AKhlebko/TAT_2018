using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class Selector
    {
        public static AudiosPageSelectors AudiosPage = new AudiosPageSelectors();
        public static DialogsPageSelectors DialogsPage = new DialogsPageSelectors();
        public static LeftMenuButtonsSelectors LeftMenuButtons = new LeftMenuButtonsSelectors();
        public static LoginFailedPageSelectors LoginFailedPage = new LoginFailedPageSelectors();
        public static LoginPageSelectors LoginPage = new LoginPageSelectors();
        public static LogOutMenuSelectors LogOutMenuSelectors = new LogOutMenuSelectors();
        public static NewsPageSelectors NewsPage = new NewsPageSelectors();
        public static FriendsPageSelectors FriendsPage = new FriendsPageSelectors();
        public static ProfilePageSelectors ProfilePage = new ProfilePageSelectors();
    }
}
