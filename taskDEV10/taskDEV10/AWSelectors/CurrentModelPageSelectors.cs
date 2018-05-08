namespace taskDEV10.AWSelectors
{
    public class CurrentModelPageSelectors
    {
        public string PageNumbers;
        public string Offers;
        public string NextPageButton;
        public string PreviousPageButton;
        public string CurrentPageString;

        public CurrentModelPageSelectors()
        {
            PageNumbers = "//div[@class='pages-numbers']/ul/li/a"; //Need .Text to get the number
            Offers = "//div[@class='listing-wrap']/div[@class='listing-item']";
            NextPageButton = "//li[@class='pages-arrows-item'][2]";
            PreviousPageButton = "//li[@class='pages-arrows-item'][1]";
            CurrentPageString = "//li[@class='pages-arrows-index']";
        }
    }
}
