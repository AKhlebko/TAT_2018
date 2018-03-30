namespace DEV_7
{
    /// <summary>
    /// Command for adding new car into the storage
    /// </summary>
    class StorageCarProducer : IStorageCommand<bool>
    {
        private Storage storage;
        private Car carToProduce;

        public StorageCarProducer()
        {
            storage = null;
            carToProduce = null;
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

        /// <summary>
        /// Car to produce setter
        /// </summary>
        /// <param name="pCar">
        /// car for adding to the storage
        /// </param>
        public void SetCarToProduce(Car pCar)
        {
            this.carToProduce = pCar;
        }

        public bool Execute()
        {
            storage.ProduceCar(carToProduce);
            return true;
        }
    }
}
