using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
//namespace IOFIleStream

namespace HANGMAN_IN_CONSOLE
{
    class Program
    {

        static public char getUserInput()
        {
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }

        static void Main(string[] args)
        {
            char userInput;
            Boolean flag = true; // flag decides if program displays the opening HANGMAN graphic again when player will missclick input
     //       DateTime currentDateTime = DateTime.Now;
     //       Console.Write(currentDateTime);
            do
            {
                userInput = Display.helloScreen(flag);
                flag = false;
                switch (userInput)
                {
                    case '1': //Start a New Game
                        GameEngine game = new GameEngine();
                        game.run();
                        break;
                    case '2': //List of the Best players
                        Console.WriteLine("Case 2");
                        Leaderboard leaderboard = new Leaderboard("Leaderboard.txt");
                        Console.Clear();
                        Display.drawLeaderboard(leaderboard.leaderboardData, 0, 2);
                        Console.Write("\n\nPush any button to continue...");
                        Console.ReadKey();
                        break;
                    case '3': //Swithing off the program
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (userInput != '1' && userInput != '3');
            Console.ReadKey();

        }
    }
}
