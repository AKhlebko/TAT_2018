using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Command for getting similar cars for futher choosing
    /// </summary>
    class SimilarCarsToBuyGetter : ICatalogCommand<List<Car>>
    {
        private Catalog catalog;
        private Car userChoice;

        public SimilarCarsToBuyGetter(Catalog catalog)
        {
            this.catalog = catalog;
        }

        public void setUserChoice(Car userChoice)
        {
            this.userChoice = userChoice;
        }

        public List<Car> execute()
        {
            return catalog.GetSimilarToBuy(userChoice);
        }
    }
}
