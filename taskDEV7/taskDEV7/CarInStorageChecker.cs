namespace DEV_7
{
    /// <summary>
    /// Command for checking does the storage contain car
    /// </summary>
    class CarInStorageChecker : IStorageCommand<bool>
    {
        private Storage storage;
        private Car carToFind;

        public CarInStorageChecker()
        {
            storage = null;
            carToFind = null;
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

        /// <summary>
        /// Car to find setter
        /// </summary>
        /// <param name="userChoice">
        /// car to find
        /// </param>
        public void SetCarToFind(Car userChoice)
        {
            carToFind = userChoice;
        }

        public bool Execute()
        {
            return storage.IsInStorage(carToFind);
        }
    }
}
