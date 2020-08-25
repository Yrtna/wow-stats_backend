using System;

namespace DebugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debug Started");
            
            ZonesTests.RunTests().Wait();
            
            Console.WriteLine("Debug Ended");
        }
    }
}