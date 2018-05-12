using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_6
{
    /// <summary>
    /// Class implements command interface and 
    /// counts average price of the items in the storage
    /// through execute method
    /// </summary>
    class ItemsCounter : ICommand
    {
        private Storage storage;

        public ItemsCounter(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Method for command execution
        /// counts and prints number of items in the storage
        /// </summary>
        public void Execute()
        {
            long itemsNum = storage.GetItemsNumber();
            Console.WriteLine($"Right now there are {itemsNum} in the storage.");
        }
    }
}
