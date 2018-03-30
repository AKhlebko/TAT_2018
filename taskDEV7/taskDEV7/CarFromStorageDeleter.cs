namespace DEV_7
{
    /// <summary>
    /// Command for deleting cars from storage
    /// </summary>
    class CarFromStorageDeleter : IStorageCommand<bool>
    {
        private Storage storage;
        private Car carToDelete;

        public CarFromStorageDeleter()
        {
            storage = null;
            carToDelete = null;
        }

        /// <summary>
        /// Method for setting storage to this command
        /// </summary>
        /// <param name="pStorage">
        /// storage to set
        /// </param>
        public void SetStorage(Storage pStorage)
        {
            this.storage = pStorage;
        }

        /// <summary>
        /// Method to set car to delete
        /// </summary>
        /// <param name="pCar">
        /// car to delete
        /// </param>
        public void SetCarToDelete(Car pCar)
        {
            this.carToDelete = pCar;
        }

        public bool Execute()
        {
            return storage.DeleteBoughtCar(carToDelete);
        }
    }
}
