using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask
{
    public class Selectors
    {
        public static readonly string LoginInputForm = "//input[@placeholder='Phone or email'][@name='email']";
        public static readonly string LoginPasswordForm = "//input[@placeholder='Password'][@name='pass']";
        public static readonly string LoginPushButton = "//button[@id='index_login_button']";
        public static readonly string LoginPushButtonFailedPage = "//button[@id='login_button']";
    
        public static readonly string LogOutMenu = "//a[@id='top_profile_link']";
        public static readonly string LogOutButton = "//a[@id='top_logout_link']";

        public static readonly string LMessageButton = "//li[@id='l_msg']";
        public static readonly string LFriendsButton = "//li[@id='l_fr']";
        public static readonly string LCommunitiesButton = "//li[@id='l_gr']";
        public static readonly string LPhotosButton = "//li[@id='']";
        public static readonly string LButton = "//li[@id='l_ph']";
        public static readonly string LAudiosButton = "//li[@id='l_aud']";
        
        public static readonly string DialogSearchForm = "//input[@id='im_dialogs_search'][@placeholder='Search']";
        public static readonly string ResultDialogs = "//ul[@id='im_dialogs']";
        public static readonly string SearchConfirmed = "//li[@class='im-search-results-head']";

        public static readonly string TextForNewPostForm = "//div[@id='post_field']";
        public static readonly string SendTextPost = "//div[@class='addpost_button_wrap']";

        public static readonly string ShuffleAndPlayMusicButton = "//button[@class='audio_page__shuffle_all_button']";

        public static readonly string SendMessageButton = "//*[@id='content']/div/div[1]/div[3]/div[3]/div[4]/div[3]/div[3]/div[1]/button";
    }
}
