using System;
using System.Text.RegularExpressions;

namespace DEV_6
{
    /// <summary>
    /// Class impliments IStorageCommands and makes requests. ConcreteCommand maker
    /// </summary>
    public class Terminal : IStorageCommands
    {
        private Storage storage;

        public Terminal(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Makes request into storage for adding items into typeName key
        /// </summary>
        /// <param name="typeName">
        /// Name of the type to add items
        /// </param>
        /// <param name="items">
        /// Items of this type
        /// </param>
        /// <returns>
        /// true if items where added
        /// false if they weren't
        /// </returns>
        public bool AddItems(string typeName, SaleItem items)
        {
            return storage.AddItems(typeName, items);
        }

        /// <summary>
        /// Makes request to the storage for getting 
        /// number of items in it.
        /// </summary>
        /// <returns>
        /// Number of items in the storage
        /// </returns>
        public int CountAll()
        {
            return storage.GetItemsNumber();
        }

        /// <summary>
        /// Makes request to the storage for getting 
        /// number of types stored in it.
        /// </summary>
        /// <returns>
        /// Number of types stored in the storage
        /// </returns>
        public int CountTypes()
        {
            return storage.GetTypesNumber();
        }

        /// <summary>
        /// Makes request to the storage for getting 
        /// average price of all items stored in it
        /// </summary>
        /// <returns>
        /// Average price of all items in it
        /// </returns>
        public float AveragePrice()
        {
            return storage.GetAveragePrice();
        }

        /// <summary>
        /// Makes request to the storage for getting 
        /// average price of all items of input type stored in it
        /// </summary>
        /// <param name="typeName">
        /// Name of the type
        /// </param>
        /// <returns>
        /// Average price of all the items of input type stored in the storage
        /// </returns>
        public float AveragePrice(string typeName)
        {
            return storage.GetAverageTypePrice(typeName);
        }
    }
}
