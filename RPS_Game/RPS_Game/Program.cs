using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RPS_Game
{
    class Program{
        static void Main(string[] args){
            Game rps = new Game(); // creates new Game
            rps.playGame(); // calls playGame method in Game class to start game
            }
        }
    }