namespace DEV_7
{
    /// <summary>
    /// Lada objects builder
    /// </summary>
    class LadaBuilder : CarBuilder
    {
        public override Car Create()
        {
            return new Lada();
        }
    }
}
