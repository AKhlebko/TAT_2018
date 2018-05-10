namespace taskDEV10.AWSelectors
{
    /// <summary>
    /// Selectors for main av.by's page
    /// </summary>
    public class MainPageSelectors
    {
        public string Brands;
        public string BrandsAmount;
        public string BrandsLinks;
        public string ShowAll;

        public MainPageSelectors()
        {
            Brands = "//ul[@class='brandslist']/li";
            BrandsAmount = "//ul[@class='brandslist']/li/a/small";
            BrandsLinks = "//ul[@class='brandslist']/li/a";
            ShowAll = "//p[@class='brands-all']";
        }
    }
}
