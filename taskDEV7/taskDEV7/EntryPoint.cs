namespace DEV_7
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            Storage storage = new Storage();

            SimilarCarsToBuyGetter similarCarsToBuyGetter = new SimilarCarsToBuyGetter(catalog);
            CarInStorageChecker carInStorageChecker = new CarInStorageChecker();
            carInStorageChecker.SetStorage(storage);
            CarFromStorageDeleter carFromStorageDeleter = new CarFromStorageDeleter();
            carFromStorageDeleter.SetStorage(storage);
            StorageCarProducer storageCarProducer = new StorageCarProducer();
            storageCarProducer.SetStorage(storage);
            StorageSaver storageSaver = new StorageSaver();
            storageSaver.SetStorage(storage);
            StorageReloader storageReloader = new StorageReloader();
            storageReloader.SetStorage(storage);

            ConsoleMenu menu = new ConsoleMenu();
            menu.CheckIsCarInStorageCommand = carInStorageChecker;
            menu.DeleteCarInStorageCommand = carFromStorageDeleter;
            menu.GetSimilarCarsCommand = similarCarsToBuyGetter;
            menu.StorageCarProduceCommand = storageCarProducer;
            menu.StorageSaveCommand = storageSaver;
            menu.StorageReloader = storageReloader;
            menu.Work();
        }
    }
}
