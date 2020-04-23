using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Game
{
    class Player
    {
		private string name;
		private int wins;

		public int winAccess
		{
			get { return wins; }
			set { wins = value; }
		}


		public string nameAccess
		{
			get { return name; }
			set { name = value; }
		}

		// No input parameters required, returns String value of either Rock, Paper
		// or Scissors randomly
		public string choosePlay()
		{
			Random rand = new Random(); // instansiates the Random Class
			int choice = rand.Next(3); // generates random nubmer of 0, 1 or 2
			switch(choice){ // returns Rock, Paper, or Scissors according to input random number
				case 0:
					return "Rock";
				case 1:
					return "Paper";
				case 2:
					return "Scissor";
			}
			return "";
		}
	}
}
