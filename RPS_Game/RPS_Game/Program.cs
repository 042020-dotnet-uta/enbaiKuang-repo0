using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    class Program{
        static void Main(string[] args){
            Game rps = new Game();
            rps.Player1 = new Player();
            rps.Player2 = new Player();            

            while (true){
                Round newRound = new Round();
                newRound.play(rps.Player1,rps.Player2);
                newRound.findWinner(rps.Player1 , rps.Player2);
                rps.addRound(newRound);
                // conditions check to see if a player has won,checks if p1 or p2 has more than 2 wins.
                if (rps.Player1.winAccess > 1 || rps.Player2.winAccess > 1){
                    rps.print();
                    rps.findWinner();
                    return; //ends program
                }
            }
        }
    }
}