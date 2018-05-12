using System;
using System.Text.RegularExpressions;

namespace DEV_6
{
    /// <summary>
    /// Class contains info about items
    /// </summary>
    public class SaleItem
    {
        private string itemName;
        private int number;
        private float price;

        public SaleItem(string pName, int pNumber, float pPrice)
        {
            if (Regex.IsMatch(pName, @"[\\/:*?<>|]+") || pName.Length == 0)
            {
                throw new FormatException("Invalid string format.");
            }
            else if (pPrice <= 0 || pNumber <= 0)
            {
                throw new ArgumentOutOfRangeException("Numbers can't be below or equal zero.");
            }
            itemName = pName;
            number = pNumber;
            price = pPrice;
        }

        /// <summary>
        /// SaleItem's name getter
        /// </summary>
        public string Name
        {
            get
            {
                return itemName;
            }
        }
        
        /// <summary>
        /// SaleItem's price getter
        /// </summary>
        public float Price
        {
            get
            {
                return price;
            }
        }
        
        /// <summary>
        /// SaleItem's number getter and setter
        /// when attempting to set checks whether number format is valid
        /// otherwise throws and exception
        /// </summary>
        public int Count
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0)
                {
                    number = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Can't be negative.");
                }
            }
        }

        public override string ToString()
        {
            return $"{number} of {itemName} with the {price:0.00} price";
        }
    }
}
