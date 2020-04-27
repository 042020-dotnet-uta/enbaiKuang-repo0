using System;

namespace CodingChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sweet = 0; //counters for how many times each condition appears
            int salty = 0;
            int overlap = 0;

            for (int i = 0; i < 100; i++) {
                if ((i % 3 == 0) && (i % 5 == 0)) // check for overlap first
                {
                    Console.WriteLine("sweet'nSalty");
                    overlap++;
                }
                else if (i % 3 == 0) // check for sweet condition
                {
                    Console.WriteLine("sweet");
                    sweet++;
                }
                else if (i % 5 == 0) { // check for salty condition
                    Console.WriteLine("salty");
                    salty++;
                }
                else{ // print current number if no conditions are met
                    Console.WriteLine(i);
                }
            }
            // print total cases of each
            Console.WriteLine($"Sweets: {sweet}  Saltys: {salty}  sweet'nSaltys: {overlap}");
        }
    }
}
