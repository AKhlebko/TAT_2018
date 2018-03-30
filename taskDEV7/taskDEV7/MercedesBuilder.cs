namespace DEV_7
{
    /// <summary>
    /// Mercedes builder
    /// </summary>
    class MercedesBuilder : CarBuilder
    {                                      
        public override Car Create()
        {
            return new Mercedes();
        }
    }
}
