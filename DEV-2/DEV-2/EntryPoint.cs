using System;
using System.Text;

namespace TaskDEV2
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder(Console.ReadLine());
            OnlyEvenPositionCharsString evener = new OnlyEvenPositionCharsString(str);
            evener.LeaveOnlyEvenPositionChars();
        }
    }
}
