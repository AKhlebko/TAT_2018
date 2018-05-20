using System;

namespace DEV_6
{
    /// <summary>
    /// Class implements command interface and 
    /// counts average price of the items in the storage
    /// </summary>
    class AveragePriceCounter : ICommand
    {
        private Storage storage;

        public AveragePriceCounter(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Method for command execution
        /// counts and prints average price of items in the storage
        /// </summary>
        public void Execute()
        {
            float averagePrice = storage.GetAveragePrice();
            Console.WriteLine($"Average price in the storage = {averagePrice}");
        }
    }
}
