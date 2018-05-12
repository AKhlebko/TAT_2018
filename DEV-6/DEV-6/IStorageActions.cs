using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_6
{
    interface IStorageActions
    {
        bool AddItems(string typeName, SaleItem items);
        int GetTypesNumber();
        int GetItemsNumber();
        float GetAveragePrice();
        float GetAverageTypePrice(string typeName);
    }
}
