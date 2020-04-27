using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace RPS_Game
{

    public class Round
    {
        public string p1Choice { get; set; }
        public string p2Choice { get; set; }
        public Player Winner { get ; set; }

        private readonly ILogger _logger;
        public Round(ILogger<Round> logger) {
            _logger = logger;
        }

        // Input parameter of string consisting of Rock, Paper or Scissors and will return
        // an int accordingly, will return Scissors for invalid strings to avoid exceptions
        private int getChoice(string choice) {
            _logger.LogInformation("Now we're getting player choice");
            if (choice == "Rock") return 0;
            else if (choice == "Paper") return 1;
            else return 2;
            
        }

        // No input parameter is required, returns  true if there is a Winner set
        public bool isWinner() {
            return !(Winner == null);
        }

        // Requires input parameter of two player objects, which will then record the
        // choice of Rock, Paper, or Scissors accordingly.
        public void play(Player p1, Player p2) {
            _logger.LogInformation("Each players assigned random choice");
            p1Choice = p1.choosePlay();
            p2Choice = p2.choosePlay();
        }

        // Requires input parameter of two player objects, these are used
        // to increment their win count accordingly
        public void findWinner(Player p1, Player p2) {
            _logger.LogInformation("Compares and decides winner of round");
            // win is used for switch statement and find out which player won
            int win = getChoice(p1Choice) - getChoice(p2Choice) + 2;

            if (win == 0 || win == 3) Winner = p1; // winner is set to p1 when win is 0 or 3
            else if (win == 1 || win == 4) Winner = p2; // winner set to p2 when win is 1 or 4
            else Winner = null; // null if tie

            switch (win)
            { //win is mostly unique varying with what each player picks
                case 0: //p1 rock p2 scissor p1 wins
                    p1.winAccess++;
                    break;
                case 1: // p1 lost since result is negative rock(0) - paper(1) or 1 - 2
                    p2.winAccess++;
                    break;
                case 2: // tie
                    break;
                case 3:// p1 wins as 1 - 0 or 2 - 1;
                    p1.winAccess++;
                    break;
                case 4://p1 scissor p2 rock p2 wins
                    p2.winAccess++;
                    break;
                default:
                    break;
            }
        }
    }
}
