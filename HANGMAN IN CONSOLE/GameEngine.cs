using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANGMAN_IN_CONSOLE
{
    class GameEngine
    {
        int healthPoints = 6, intTime;
        String capital, country, unknownCapital, checkedLetters, stringTime, playerName;
        string[] allCityCountryPairs = System.IO.File.ReadAllLines("countries_and_capitals.txt.txt");
        Leaderboard leaderboard = new Leaderboard("Leaderboard.txt");
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan time;
        
        public void countTime()
        {
            stopWatch.Stop();
            time = stopWatch.Elapsed;
            stringTime = (time.Minutes + " min and " + time.Seconds + " sec.");
            intTime = time.Minutes * 60 + time.Seconds;
        }

        public void run()
        {
            Random random = new Random();
            String selectedPair;
            int lokalizationOfSeparator, levelsFinished = 0, numberOfTries;
            Boolean isLevelCompleted, isHintVisable;
            char userInput;
            do
            {

                stopWatch.Reset();
                stopWatch.Start();
                numberOfTries = 0;
                healthPoints = 6;
                unknownCapital = "";
                isLevelCompleted = isHintVisable = false;
                checkedLetters = "";

                selectedPair = allCityCountryPairs[random.Next(Constants.numberOfCities)];
                for (lokalizationOfSeparator = 0; lokalizationOfSeparator < selectedPair.Length; lokalizationOfSeparator++)
                {
                    if (selectedPair[lokalizationOfSeparator] == '|') break;
                }
                country = selectedPair.Substring(0, lokalizationOfSeparator - 1);
                capital = selectedPair.Substring(lokalizationOfSeparator + 2, selectedPair.Length - lokalizationOfSeparator - 2);
                for (int i = 0; i < capital.Length; i++) unknownCapital += "_";
                do
                {
                    userInput = Display.gameScreen(healthPoints, unknownCapital, levelsFinished, checkedLetters, isHintVisable, country);
                    if (userInput >= 'A' && userInput <= 'Z' || userInput >= 'a' && userInput <= 'z')
                    {
                        if (capital.ToUpper().Contains(Char.ToUpper(userInput)))
                        {
                            if (!unknownCapital.ToUpper().Contains(Char.ToUpper(userInput))) numberOfTries++;
                            for (int i = 0; i < capital.Length; i++)
                            {
                                if (capital[i].Equals(Char.ToLower(userInput)) || capital[i].Equals(Char.ToUpper(userInput)))
                                {
                                    unknownCapital = unknownCapital.Insert(i, capital[i].ToString());
                                    unknownCapital = unknownCapital.Remove(i + 1, 1);
                                }
                            }
                        }
                        else if (!checkedLetters.Contains(Char.ToLower(userInput)) && !checkedLetters.Contains(Char.ToUpper(userInput)))
                        {
                            checkedLetters += userInput;
                            healthPoints--;
                            numberOfTries++;
                        }
                    }
                    else if (userInput == '.') isHintVisable = true;
                    else if (userInput == ',')
                    {
                        if (Display.getPlayersSentence().ToUpper().Equals(capital.ToUpper())) isLevelCompleted = true;
                        else
                        {
                            healthPoints -= 2;
                            numberOfTries += 2;
                        }

                    }
                    else if (userInput == '0') Environment.Exit(0);
                    if (!unknownCapital.Contains("_") || unknownCapital == capital.Replace(" ", "_")) isLevelCompleted = true;
                    if (isLevelCompleted)
                    {
                        countTime();
                        do
                        {
                            userInput = Display.victoryScreen(numberOfTries, stringTime, capital, country, leaderboard.leaderboardData);
                        } while (Char.ToUpper(userInput) != 'Y' && Char.ToUpper(userInput) != 'N' && Char.ToUpper(userInput) != ';');
                        if (Char.ToUpper(userInput) == 'Y') levelsFinished++;
                        else if (Char.ToUpper(userInput) == ';')
                        {
                            levelsFinished++;
                            playerName = Console.ReadLine();
                            if (playerName.Length > 8) playerName = playerName.Substring(0, 8);
                            for (int i=0;  playerName.Length < 8; playerName += " ") ; // :P 
                            DateTime currentDateTime = DateTime.Now;
                            leaderboard.addPlayer(playerName, currentDateTime.ToString("dd.MM.yyyy HH:mm"), intTime, numberOfTries, capital);
                            leaderboard.refreshLeaderboard("Leaderboard.txt");

                        }
                        else Environment.Exit(0);
                    }

                } while (healthPoints > 0 && !isLevelCompleted);
                if (healthPoints <= 0)
                {
                    do
                    {
                        countTime();
                        userInput = Display.failureScreen(capital, country);
                    } while (char.ToUpper(userInput) != 'Y' && char.ToUpper(userInput) != 'N');
                    if (char.ToUpper(userInput) == 'Y')
                    {
                        healthPoints = 1; //Program will go trough a next requirement and will restart game
                        levelsFinished = 0;
                    }
                    else if (char.ToUpper(userInput) == 'N') Environment.Exit(0);
                }
            } while (healthPoints > 0);
        }
    }
}
