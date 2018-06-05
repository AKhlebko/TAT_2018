using System;

namespace DEV_8
{
    /// <summary>
    /// Class for executing ICommand commands
    /// </summary>
    public class Terminal
    {
        public ICommand commandToExecute { get; set; }

        public void Execute()
        {
            try
            {
                commandToExecute.Execute();
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}