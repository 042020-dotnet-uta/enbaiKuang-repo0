using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;

namespace CodingChallengeWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Clear(); // clear console screen for clarity
                Console.WriteLine("Please press appropriate key for your selection.\n1 Check if input is Even." +
                    "\n2 Get Multiplication Table of Input \n3 Shuffle two lists of objects\nESC Exit Program");
                ConsoleKey key = Console.ReadKey(true).Key; // stores user key stroke
                if (key == ConsoleKey.D1) // call functions according to key input
                {
                    isEven(); // 1 
                }
                else if (key == ConsoleKey.D2)
                {
                    MultTable(); // 2
                }
                else if (key == ConsoleKey.D3)
                {
                    Shuffle(); // 3
                }
                else if (key == ConsoleKey.Escape) {
                    return; // end program
                }
                else{ // invalid input
                    Console.WriteLine("Unrecognized Input, Press Enter to try again");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                }
            }
            
        }

        // takes user input and returns whether it is an even number or not
        public static void isEven() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Please enter a valid Integer, or type exit to return to main menu.");
                string input = Console.ReadLine(); // reads user input
                if (input.ToLower() == "exit") return; // exit to main menu if user typed in exit

                if (!int.TryParse(input, out int result)){// try to parse to int
                    Console.WriteLine(input + " is not a valid integer, please try again.");
                }
                else { // input is valid, check if even
                    if (result % 2 == 0){ // divisible by 2
                        Console.WriteLine(result + " is an even number.");
                    }
                    else Console.WriteLine(result + " is not an even number.");
                }
                Console.WriteLine("Press Enter to Continue"); // waits for user to press enter to continue
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            }
        }

        // takes input from user and prints out multiplication table accordingly, input must be int
        public static void MultTable() {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid Integer, or type exit to return to main menu.");
                string input = Console.ReadLine(); // read user input
                if (input.ToLower() == "exit") return;

                if (!int.TryParse(input, out int result)){
                    Console.WriteLine(input + " is not a valid integer, please try again.");
                }
                else{ // prints out result in nested for loop
                    for (int i = 1; i <= result; i++) {
                        for (int j = 1; j <= result; j++) {
                            Console.Write($"{i} X {j} = {i * j} ");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Press Enter to Continue");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter){ }
            }
        }

        // prompt user to enter two sets of objects to be stored in seperate lists, list are merged into one
        // and printed out
        public static void Shuffle(){
            while (true) {
                Console.Clear();
                Console.WriteLine("Press ESC to return to main menu or Enter to input the first 5 elements.");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) return; // return to main menu if esc is pressed

                List<Object> l1 = new List<Object>(); // lists to store input objects
                List<Object> l2 = new List<Object>();
                Console.WriteLine("Please enter the first 5 elements."); // promts user to input first 5 elements
                for (int i = 1; i < 5; i++) {
                    string input = Console.ReadLine();
                    if (input != "") { // stores input in list if not null
                        l1.Add(input);
                    }
                }

                Console.WriteLine("Please enter the next 5 elements."); // prompts user to input next 5 elemets
                for (int i = 0; i < 5; i++)
                {
                    string input = Console.ReadLine();
                    if (input != "")
                    {
                        l2.Add(input);
                    }
                }

                List<Object> merge = new List<Object>(); // list to store mergd data
                int tracker = 0; // tracker to track progress
                while (tracker < l1.Count && tracker < l2.Count) {
                    merge.Add(l1[tracker]); // add the data and increment tracker
                    merge.Add(l2[tracker]);
                    tracker++;
                }
                if (tracker < l1.Count){ // incase l1 and l2 are uneven
                    while (tracker < l1.Count) {
                        merge.Add(l1[tracker]); // adds rest of l1
                        tracker++;
                    }
                }
                if (tracker < l2.Count) { // adds rest of l2
                    while (tracker < l1.Count)
                    {
                        merge.Add(l1[tracker]);
                        tracker++;
                    }
                }
                foreach (Object element in merge) // prints each element in merged list
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter to Continue");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            }
        }
    }
}
