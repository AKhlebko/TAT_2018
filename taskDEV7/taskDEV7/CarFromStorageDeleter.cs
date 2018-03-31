namespace DEV_7
{
    /// <summary>
    /// Command for deleting cars from storage
    /// </summary>
    class CarFromStorageDeleter : IStorageCommand<bool>
    {
        private Storage storage;

        public CarFromStorageDeleter()
        {
            storage = null;
        }

        /// <summary>
        /// Method for setting storage to this command
        /// </summary>
        /// <param name="pStorage">
        /// storage to set
        /// </param>
        public void SetStorage(Storage pStorage)
        {
            storage = pStorage;
        }

        public bool Execute(Car carToDelete)
        {
            return storage.DeleteBoughtCar(carToDelete);
        }
    }
}
