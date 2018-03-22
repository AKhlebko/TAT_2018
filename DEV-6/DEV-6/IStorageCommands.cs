namespace DEV_6
{
    /// <summary>
    /// Interface with all commands needed for clear
    /// interacting with storage.
    /// </summary>
    public interface IStorageCommands
    {
        int CountTypes();
        int CountAll();
        float AveragePrice();
        float AveragePrice(string typeName);
        bool AddItems(string typeName, SaleItem items);
    }
}
