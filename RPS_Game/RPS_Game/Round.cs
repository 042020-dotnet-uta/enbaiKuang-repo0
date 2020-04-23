using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Round
    {
        public string p1Choice { get; set; }
        public string p2Choice { get; set; }
        public Player Winner { get ; set; }

        private int getChoice(string choice) {
            if (choice == "Rock") return 0;
            else if (choice == "Paper") return 1;
            else return 2;
            
        }

        public bool isWinner() {
            return !(Winner == null);
        }

        public void play(Player p1, Player p2) {
            p1Choice = p1.choosePlay();
            p2Choice = p2.choosePlay();
        }
        public void findWinner(Player p1, Player p2) {
            int win = getChoice(p1Choice) - getChoice(p2Choice) + 2;
            if (win == 0 || win == 3) Winner = p1;
            else if (win == 1 || win == 4) Winner = p2;
            else Winner = null;
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
