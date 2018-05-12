using System;

namespace DEV_6
{
    /// <summary>
    /// Class implements command interface and
    /// counts average price of one type's items in the storage
    /// </summary>
    class AveragePriceInTypeCounter : ICommand
    {
        private Storage storage;

        public AveragePriceInTypeCounter(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Method for command execution
        /// counts and prints average price of one input type's items in the storage
        /// </summary>
        public void Execute()
        {
            Console.Write("Input type's name to calculate average price: ");
            string typeName = Console.ReadLine();
            float averagePrice = storage.GetAverageTypePrice(typeName);
            if (averagePrice != -1)
            {
                Console.WriteLine($"Average {typeName}'s price in the storage is {averagePrice}.");
            }
            else
            {
                Console.WriteLine($"There is no type {typeName} in the storage.");
            }
        }
    }
}
