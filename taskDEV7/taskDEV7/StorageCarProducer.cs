namespace DEV_7
{
    /// <summary>
    /// Command for adding new car into the storage
    /// </summary>
    class StorageCarProducer : IStorageCommand<bool>
    {
        private Storage storage;

        public StorageCarProducer()
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

        public bool Execute(Car carToProduce)
        {
            storage.ProduceCar(carToProduce);
            return true;
        }
    }
}
