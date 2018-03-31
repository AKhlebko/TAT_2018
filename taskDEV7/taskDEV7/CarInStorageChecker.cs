namespace DEV_7
{
    /// <summary>
    /// Command for checking does the storage contain car
    /// </summary>
    class CarInStorageChecker : IStorageCommand<bool>
    {
        private Storage storage;

        public CarInStorageChecker()
        {
            storage = null;
        }
        
        /// <summary>
        /// Storage setter
        /// </summary>
        /// <param name="storage">
        /// storage to set
        /// </param>
        public void SetStorage(Storage storage)
        {
            this.storage = storage;
        }

        public bool Execute(Car carToFind)
        {
            return storage.IsInStorage(carToFind);
        }
    }
}
