using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class FriendsPageSelectors
    {
        public readonly string FriendsInfo;

        public FriendsPageSelectors()
        {
            FriendsInfo = "//div[@class='friends_user_info']";
        }
    }
}
