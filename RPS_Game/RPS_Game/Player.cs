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

		public string choosePlay()
		{
			Random rand = new Random(); // instansiates the Random Class
			int choice = rand.Next(3);
			switch(choice){
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
