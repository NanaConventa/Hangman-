using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANGMAN_IN_CONSOLE
{
    class Leaderboard
    {
        public string[] leaderboardData;
        public int[,] scoresOfPlayers;
        public int lokalizationOfSeparatorI, lokalizationOfSeparatorII, lokalizationOfSeparatorIII, separatorCounter;

        public Leaderboard(String nameOfFile)
        {
            scoresOfPlayers = new int[10, 2];
            separatorCounter = 0;
            leaderboardData = System.IO.File.ReadAllLines(nameOfFile);
            for (int i = 0; i < leaderboardData.Length; i++)
            {
                separatorCounter = 0;
                for (int j = 0; j < leaderboardData[i].Length; j++)
                {
                    if (leaderboardData[i][j] == '|' && separatorCounter < 1) separatorCounter++;
                    else if (leaderboardData[i][j] == '|' && separatorCounter == 1)
                    {
                        separatorCounter++;
                        lokalizationOfSeparatorI = j;
                        //  leaderboard[i].Substring(i+1, );
                        //  scoresOfPlayers[0,0] = ;
                    }
                    else if (leaderboardData[i][j] == '|' && separatorCounter == 2)
                    {
                        separatorCounter++;
                        lokalizationOfSeparatorII = j;
                    }
                    else if (leaderboardData[i][j] == '|' && separatorCounter == 3)
                    {
                        separatorCounter++;
                        lokalizationOfSeparatorIII = j;
                        break;
                    }
                }
                    scoresOfPlayers[i,0] = int.Parse(leaderboardData[i].Substring(lokalizationOfSeparatorI + 1, lokalizationOfSeparatorII-lokalizationOfSeparatorI - 1).Trim());
                    scoresOfPlayers[i,1] = int.Parse(leaderboardData[i].Substring(lokalizationOfSeparatorII + 1, lokalizationOfSeparatorIII - lokalizationOfSeparatorII - 1).Trim());
            }

        }
        public void addPlayer(String name, string date, int time, int numberOftries, String capital)
        {
            for (int i = 0; i<10; i++)
            {
                if (scoresOfPlayers[i, 1] > numberOftries || scoresOfPlayers[i, 1] == numberOftries && scoresOfPlayers[i, 0] > time)
                {
                    for (int j = 9; j>i; j--)
                    {
                        leaderboardData[j] = String.Copy(leaderboardData[j-1]);
                    }
                    leaderboardData[i] = name + " | " + date + " | " + time + " | " + numberOftries.ToString() + " | " + capital;
                    break;
                }

            }
        }
        public void refreshLeaderboard(String nameOfFile)
        {
            System.IO.File.WriteAllText(nameOfFile, string.Empty);
            System.IO.File.WriteAllLines(nameOfFile, leaderboardData);
        }
    }
}
