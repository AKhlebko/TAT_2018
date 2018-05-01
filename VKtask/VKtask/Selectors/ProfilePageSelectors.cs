using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKtask.Selectors
{
    public class ProfilePageSelectors
    {
        public readonly string Status;
        public readonly string FullName;

        public ProfilePageSelectors()
        {
            Status = "//span[@class='current_text']";
            FullName = "//h2[@class='page_name']";
        }
    }
}
