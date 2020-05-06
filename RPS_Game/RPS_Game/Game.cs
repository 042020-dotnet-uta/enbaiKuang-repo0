using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    public class Game
    {
        public Game() { 
            round = new List<Round>();
        }
        public int GameId { set; get; }
        private List<Round> round = new List<Round>();// instantiatiate the round List

        public Player player1;

        public Player Player1
        {
            get { return player1; }
            set { 
                player1 = value;
                Console.WriteLine("Enter Player1 Name: "); //prompts user to input player 1 name
                player1.nameAccess = Console.ReadLine();  //takes input from user and stores it as player 1 name
            }
        }

        private Player player2;

        public Player Player2
        {
            get { return player2; }
            set { 
                player2 = value;
                Console.WriteLine("Enter Player2 Name: "); //prompts user to input player 1 name
                player2.nameAccess = Console.ReadLine();  //takes input from user and stores it as player 1 name
            }
        }

        public void playGame()
        {
            Player1 = new Player(); // creates player 1 and two
            Player2 = new Player();
            //var services = new ServiceCollection();
            //ConfigureServices(services);

            while (true)
            {  // while loop keeps game going until there is a winner

                Round newRound = new Round(); // creates new Game
                newRound.play(Player1, Player2); //play round and generate choices for both players
                newRound.findWinner(Player1, Player2); // finds and records winner for current round
                round.Add(newRound); //add current round to List for storage


              // conditions check to see if a player has won,checks if p1 or p2 has more than 2 wins.
            if (Player1.winAccess > 1 || Player2.winAccess > 1)
                {
                    print(); // print record of each round
                    findWinner(); // find and print the winner
                    return; //ends program
                }
            }
        }

        //No input parameters, used to print all rounds within the List of rounds
        public void print() { 
            int i = 0;
            foreach (Round element in round) {
                i++; // increments round number
                Console.Write($"Round {i} - {player1.nameAccess} chose " +
                    $"{element.p1Choice}, {player1.nameAccess} chose " +
                    $"{element.p1Choice}. "); // prints the information of each round accordingly
                if (element.isWinner()) // checks if there is a winner
                {
                    Console.WriteLine($"- { element.Winner.nameAccess}");
                }
                else { // no winner means a tie
                    Console.WriteLine(" Resulting in a tie");
                }
                
            }
        }
        // No input parameters, finds and prints the winner of the game
        public void findWinner() {  
            // num ties are found by subtrating player 1 wins and player 2 wins from total rounds
            int ties = round.Count - Player1.winAccess - Player2.winAccess;
            if (Player1 .winAccess > 1)
            {    // print results and message stating player 1 wins
                Console.WriteLine($"{Player1.nameAccess} Wins {Player1.winAccess} - " +
                    $"{Player2.winAccess } with {ties} ties.");
            }
            else
            { // print results and message staring player 2 wins
                Console.WriteLine($"{Player2.nameAccess} Wins {Player2.winAccess} - " +
                    $"{Player1.winAccess } with {ties} ties.");
            }
        }
    }
}

