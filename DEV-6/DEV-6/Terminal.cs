using System;

namespace DEV_6
{
    /// <summary>
    /// class for changing commands executors
    /// and for executing commands
    /// </summary>
    public class Terminal
    {
        private ICommand commander;

        public void DoCommand()
        {
            if (commander != null)
            {
                commander.Execute();
            }
            else
            {
                throw new ArgumentNullException("Commander can't be null.");
            }
        }

        internal void setCommand(ICommand commander)
        {
            this.commander = commander;
        }
    }
}
