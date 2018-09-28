using System;

namespace project_name
{
    class Program
    {
        public static void Main(string[] args)
        {
            #if (DEBUG)
                Console.WriteLine("DEBUG");
            #elif (RELEASE)
                Console.WriteLine("RELEASE");
            #endif
        }
    }
}