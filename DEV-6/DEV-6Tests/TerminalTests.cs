using NUnit.Framework;
using System;
using DEV_6;

namespace DEV_6Tests
{
    [TestFixture]
    class TerminalTests
    {
        [Test]
        public void DoCommand_CommanderNull_ExceptionRaised()
        {
            // Arrange
            Terminal terminal = new Terminal();

            // Assert
            Assert.Throws<ArgumentNullException>(() => terminal.DoCommand());
        }
    }
}
