/*
 RPS - An uber simple Rock, paper, scissors game. 
    Copyright (C) 2012  TyA <tya.wiki@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Threading;

public class Game
{
	static string move;
	
	static void Main() {
		bool result = false; // defaults to false, changes in loop. 
		// give them 3 tries to insert a valid character (r, p, or s in any case)
		for (int i = 0; i < 3; i++) { 
			try {
				result = Game.gameStart();
				break; // breaks the for loop
			} 
			catch (Exception e) { //catches the error as variable e
				Console.WriteLine("ERROR: " + e.Message); 
				Console.WriteLine(""); // pretty new line so everything won't get gumbled together
			}
		}
		
		if (result) {
			int win = Game.Continue();
			/*
				0 = lose
				1 = win
				2 = tie
			*/
			if (win == 1) {
				Console.WriteLine("You win!");
			} else if (win == 0) {
				Console.WriteLine("You lose.");
			} else {
				Console.WriteLine("Tie!");
			}
			
		}
		// if run not in cmd, won't close until told to so you can read your result
		Console.Write("Press any key to exit."); 
		Console.ReadKey(); // reads one key
	}
	
	public static bool gameStart() {
		Console.WriteLine("Welcome to RPS!");
		Console.Write("Rock!");
		Thread.Sleep(500);
		Console.Write( " ... Paper!");
		Thread.Sleep(500);
		Console.Write( " ... Scissors!");
		Thread.Sleep(500);
		Console.WriteLine(" ... Shoot!");
		
		Console.Write("What do you play? R, P, or S?  ");
		string line = (Console.ReadLine()).ToLower();
		
		if (line == "s" || line == "r" || line == "p") {
			move = line; // valid move
			return true;
		} else {
			throw new Exception("Invalid character"); // invalid move
		}
		
	}
	
	public static int Continue() {
		Random random = new Random();
		int compMove = random.Next(2);
		switch(compMove) {
			case 0:
				Console.WriteLine("The computer played rock!");
				break;
			case 1:
				Console.WriteLine("The computer played paper!");
				break;
			case 2:
				Console.WriteLine("The computer played scissors!");
				break;
			default:
				Console.WriteLine("I have no idea what's going on.");
				break;
		}
		// tie
		if (((compMove == 2) && (move == "s")) || ((compMove == 1) && (move == "p")) || ((compMove == 0) && (move == "r"))) {
			return 2;
		}
		
		switch (move) {
			case "p":
				if (compMove == 0) {
					Console.WriteLine("Paper beats rock!");
					return 1;
				} else {
					Console.WriteLine("Paper loses to scissors.");
					return 0;
				}
			
			case "r":
				if (compMove == 1) {
					Console.WriteLine("Rock loses to paper.");
					return 0;
				} else {
					Console.WriteLine("Rock beats scissors!");
					return 1;
				}
			
			case "s":
				if (compMove == 0) {
					Console.WriteLine("Scissors lose to rock.");
					return 0;
				} else {
					Console.WriteLine("Scissors beats paper!");
					return 1;
				}
				
			default:
				Console.WriteLine("I have no idea what is going on.");
				return 0;
		}
	}
}
