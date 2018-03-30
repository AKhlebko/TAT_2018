namespace DEV_7
{
    /// <summary>
    /// Command for saving storage data to a file with .json exstension
    /// </summary>
    class StorageSaver : IStorageCommand<bool>
    {
        private Storage storage;

        public StorageSaver()
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
        
        public bool Execute()
        {
            storage.SaveToJSON();
            return true;
        }
    }
}
