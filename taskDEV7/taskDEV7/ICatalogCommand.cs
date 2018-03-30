namespace DEV_7
{
    public interface ICatalogCommand<T>
    {
        T execute();
    }
}