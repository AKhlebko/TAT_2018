namespace taskDEV10.AVLocators
{
    /// <summary>
    /// Selectors used in this homework
    /// </summary>
    public class Locators
    {
        public static string PageNumbers = "//div[@class='pages-numbers']/ul/li/a"; //Need .Text to get the number
        public static string Offers = "//div[@class='listing-wrap']/div[@class='listing-item']";
        public static string NextPageButton = "//li[@class='pages-arrows-item'][2]";
        public static string PreviousPageButton = "//li[@class='pages-arrows-item'][1]";
        public static string CurrentPageString = "//li[@class='pages-arrows-index']";

        public static string Models = @"//ul[@class='brandslist']/li";

        public static string Brands = "//ul[@class='brandslist']/li";
        public static string BrandsAmount = "//ul[@class='brandslist']/li/a/small";
        public static string BrandsLinks = "//ul[@class='brandslist']/li/a";
        public static string ShowAll = "//p[@class='brands-all']";
    }
}
