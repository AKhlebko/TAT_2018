namespace DEV_7
{
    /// <summary>
    /// Class for building volvo class's object
    /// </summary>
    class VolvoBuilder : CarBuilder
    {
        public override Car Create()
        {
            return new Volvo();
        }
    }
}
                                                            