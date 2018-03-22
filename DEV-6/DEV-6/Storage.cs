using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DEV_6
{
    /// <summary>
    /// Class for storing SaleItems and for interacting with them
    /// </summary>
    public class Storage
    {
        private Dictionary<string, List<SaleItem>> itemTypes;

        public Storage()
        {
            itemTypes = new Dictionary<string, List<SaleItem>>();
        }

        /// <summary>
        /// Items returns number of types in the storage
        /// </summary>
        /// <returns>
        /// Number of types in the storage
        /// </returns>
        public int GetTypesNumber()
        {
            return itemTypes.Count;
        }

        /// <summary>
        /// Returns number of items in the store
        /// </summary>
        /// <returns>
        /// Returns number of items in the store
        /// </returns>
        public int GetItemsNumber()
        {
            int response = 0;
            foreach (KeyValuePair<string, List<SaleItem>> type in itemTypes)
            {
                foreach (SaleItem item in type.Value)
                {
                    response += item.Count;
                }
            }
            return response;
        }

        /// <summary>
        /// Returns average price of all items in the storage
        /// </summary>
        /// <returns>
        /// Returns average price of all items in the storage
        /// </returns>
        public float GetAveragePrice()
        {
            float averagePrice = 0;
            foreach (List<SaleItem> type in itemTypes.Values)
            {
                float bufferPrice = 0;
                foreach (SaleItem item in type)
                {
                    bufferPrice += item.Price;
                }
                averagePrice += (bufferPrice / type.Count);
            }
            return averagePrice / itemTypes.Count;
        }

        /// <summary>
        /// Returns average price of all items of input type in the storage
        /// </summary>
        /// <param name="typeName">
        /// name of the type to calculate averagetype
        /// </param>
        /// <returns>
        /// Returns average price of all items of input type in the storage
        /// or, if there are no items of input type, -1
        /// </returns>
        public float GetAverageTypePrice(string typeName)
        {
            float averagePrice = 0;
            if (!itemTypes.ContainsKey(typeName)) return -1;
            foreach (SaleItem prod in itemTypes[typeName])
            {
                averagePrice += prod.Price;
            }
            averagePrice /= itemTypes[typeName].Count;
            return averagePrice;
        }

        /// <summary>
        /// Add items into the storage
        /// SingleResponsability violated because of
        /// the nessesity of interacting with user.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type to add items in
        /// </param>
        /// <param name="items">
        /// Object with items to add
        /// </param>
        public bool AddItems(string typeName, SaleItem items)
        {
            if (Regex.IsMatch(typeName, @"[\\/:*?<>|]+") || (typeName.Length == 0))
            {
                throw new FormatException("Invalid string format.");
            }
            else if (items.Price <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName: "Numbers can't be below or equal zero.");
            }
            else if (itemTypes.ContainsKey(typeName))
            {
                itemTypes[typeName].Add(items);
            }
            else
            {
                itemTypes[typeName] = new List<SaleItem>();
                AddToExsisting(itemTypes[typeName], items);
            }
            return true;
        }

        private void AddToExsisting(List<SaleItem> list, SaleItem items)
        {
            foreach (SaleItem prod in list)
            {
                if (prod.Name == items.Name && prod.Price == items.Price)
                {
                    prod.Count += items.Count;
                    return;
                }
            }
            list.Add(items);
        }
    }
}
