using System;

namespace DEV_6
{
    /// <summary>
    /// Class implements command interface and 
    /// counts number of types in the storage
    /// through execute method
    /// </summary>
    class TypeCounter : ICommand
    {
        private Storage storage;

        public TypeCounter(Storage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Method for command execution
        /// counts and prints number of types in the storage
        /// </summary>
        public void Execute()
        {
            int typesNum = storage.GetTypesNumber();
            Console.WriteLine($"Right now there are {typesNum} types of products in the storage.");
        }
    }
}
