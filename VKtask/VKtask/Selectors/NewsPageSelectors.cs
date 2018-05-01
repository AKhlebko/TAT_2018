using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class NewsPageSelectors
    {
        public readonly string TextForNewPostForm;
        public readonly string SendTextPost;

        public NewsPageSelectors()
        {
            TextForNewPostForm = "//div[@id='post_field']";
            SendTextPost = "//div[@class='addpost_button_wrap']";
        }
    }
}
