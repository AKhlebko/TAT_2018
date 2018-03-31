using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Command for getting similar cars for futher choosing
    /// </summary>
    class SimilarCarsToBuyGetter : ICatalogCommand<List<Car>>
    {
        private Catalog catalog;

        public SimilarCarsToBuyGetter(Catalog catalog)
        {
            this.catalog = catalog;
        }

        public List<Car> execute(Car userChoice)
        {
            return catalog.GetSimilarToBuy(userChoice);
        }
    }
}
