using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Player1 Name: ");
            String player1 = Console.ReadLine(); 
            Console.WriteLine("Enter Player2 Name: ");
            String player2 = Console.ReadLine();
            int p1 = 0;
            int p2 = 0;
            int ties = 0;
            int round = 0;
            List<string> resultsList = new List<string>();
            string[] rps = { "Rock", "Paper", "Scissor" };
            Random rand = new Random();

            while (true) { // 0 = rock, 1 = paper, 2 = scissor
                round++;
                int p1rand = rand.Next(3);
                int p2rand = rand.Next(3);

                int win = p1rand - p2rand + 2;
                string results = "Round " + round + " - " + player1 + " chose " + rps[p1rand];
                results +=  ", " + player2 + " chose " + rps[p2rand] + ". - ";
                switch (win){
                    case 0: //p1 rock p2 scissor p1 wins
                        p1++; 
                        break;
                    case 1: // p1 lost since result is negative rock(0) - paper(1) or 1 - 2
                        p2++;
                        break;
                    case 2: // tie
                        ties++;
                        break;
                    case 3:// p1 wins as 1 - 0 or 2 - 1;
                        p1++;
                        break;
                    case 4://p1 scissor p2 rock p2 wins
                        p2++;
                        break;
                    default:
                        break;
                }

                if (win == 2) // tie
                {
                    results += player1  + " and " + player2 + " ties.";
                }
                else if (win == 1 || win == 3) // player1 wins
                {
                    results += player1 + " wins.";
                }
                else { //player2 wins
                    results += player2 + " wins.";
                }

                resultsList.Add(results);
                if (p1 > 1 || p2 > 1) {
                    foreach (string element in resultsList){
                        Console.WriteLine(element);
                    }

                    if (p1 > 1)
                    {
                        Console.WriteLine($"{player1} Wins {p1} - {p2} with {ties} ties.");
                    }
                    else {
                        Console.WriteLine($"{player2} Wins {p2} - {p1} with {ties} ties.");
                    }
                    return;
                }
            }
            
        }
    }
}
