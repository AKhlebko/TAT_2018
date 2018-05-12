namespace DEV_7
{
    /// <summary>
    /// Command for reloading storage data
    /// </summary>
    class StorageReloader : IStorageCommand<bool>
    {
        private Storage storage;

        public StorageReloader()
        {
            storage = null;
        }

        /// <summary>
        /// Storage setter
        /// </summary>
        /// <param name="pStorage">
        /// Storage to set
        /// </param>
        public void SetStorage(Storage pStorage)
        {
            this.storage = pStorage;
        }                  

        public bool Execute(Car car)
        {
            storage.ReloadCars();
            return true;
        }
    }
}
