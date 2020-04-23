using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    class Program{
        static void Main(string[] args){
            Game rps = new Game(); // creates new Game
            rps.Player1 = new Player(); // creates player 1 and two
            rps.Player2 = new Player();            

            while (true){  // while loop keeps game going until there is a winner
                Round newRound = new Round(); // starts new round
                newRound.play(rps.Player1,rps.Player2); //play round and generate choices for both players
                newRound.findWinner(rps.Player1 , rps.Player2); // finds and records winner for current round
                rps.addRound(newRound); //add current round to List for storage
                // conditions check to see if a player has won,checks if p1 or p2 has more than 2 wins.
                if (rps.Player1.winAccess > 1 || rps.Player2.winAccess > 1){
                    rps.print(); // print record of each round
                    rps.findWinner(); // find and print the winner
                    return; //ends program
                }
            }
        }
    }
}