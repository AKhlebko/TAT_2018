namespace DEV_7
{
    public interface IStorageCommand<T>
    {
        T Execute();
    }
}