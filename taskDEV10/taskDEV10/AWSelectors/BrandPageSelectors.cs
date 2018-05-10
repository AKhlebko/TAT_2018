namespace taskDEV10.AWSelectors
{
    /// <summary>
    /// Selectors for chosen brand page
    /// </summary>
    public class BrandPageSelectors
    {
        public string Models;

        public BrandPageSelectors()
        {
            Models = @"//ul[@class='brandslist']/li";
        }
    }
}
