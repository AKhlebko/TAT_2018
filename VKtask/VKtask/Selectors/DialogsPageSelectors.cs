namespace VKtask.Selectors
{
    public class DialogsPageSelectors
    {
        public readonly string DialogSearchForm;
        public readonly string ResultDialogs;
        public readonly string SearchConfirmed;
        public readonly string SendMessageButton;

        public DialogsPageSelectors()
        {
            DialogSearchForm = "//input[@id='im_dialogs_search'][@placeholder='Search']";
            ResultDialogs = "//ul[@id='im_dialogs']";
            SearchConfirmed = "//li[@class='im-search-results-head']";
            SendMessageButton = "//*[@id='content']/div/div[1]/div[3]/div[3]/div[4]/div[3]/div[3]/div[1]/button";
        }
    }
}
