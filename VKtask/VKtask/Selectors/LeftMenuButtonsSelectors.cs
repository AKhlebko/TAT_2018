using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class LeftMenuButtonsSelectors
    {
        public readonly string LMessageButton;
        public readonly string LFriendsButton;
        public readonly string LCommunitiesButton;
        public readonly string LPhotosButton;
        public readonly string LButton;
        public readonly string LAudiosButton;
        public readonly string LProfile;

        public LeftMenuButtonsSelectors()
        {
            LMessageButton = "//li[@id='l_msg']";
            LFriendsButton = "//li[@id='l_fr']";
            LCommunitiesButton = "//li[@id='l_gr']";
            LPhotosButton = "//li[@id='']";
            LButton = "//li[@id='l_ph']";
            LAudiosButton = "//li[@id='l_aud']";
            LProfile = "//li[@id='l_pr']";
        }
    }
}
