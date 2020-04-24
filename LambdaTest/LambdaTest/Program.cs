using System;

namespace LambdaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<String, String, bool> isSame = (x, y) => x == y;
            Console.WriteLine("Comparing Rock and Paper: " + isSame("Rock", "Paper"));
            Console.WriteLine("Comparing Rock and Rock: " + isSame("Rock", "Rock"));
        }
    }
}
