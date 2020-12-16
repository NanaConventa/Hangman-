using System;

namespace HANGMAN_IN_CONSOLE
{
    static class Display
    {
        static public char gameScreen(int healthPoints, String unkownCapital, int levelsPassed, 
            String alreadyTriedLetters, Boolean isHintVisable, String country)
        {
            Console.Clear();
            alreadyTriedLetters = alreadyTriedLetters.ToUpper();
            Console.Write($"\t\t\t\t\t  HP : {healthPoints}  \n");
            Console.Write("Capital:  ");
            for (int i = 0; i < unkownCapital.Length; i++)
            {
                Console.Write(unkownCapital[i] + " ");
            }
            Console.Write("\n\n\n\nThe letters which are already checked: ");
            for (int i = 0; i < alreadyTriedLetters.Length; i++)
            {
                Console.Write(alreadyTriedLetters[i] + " ");
            }
            Console.Write("\n\nTap the letter on the keyboard to check if the password\ncontains it or push" +
                " , to write the whole sentence.\n\n");
            if (healthPoints == 1)
            {
                Console.Write("\n\nDo you want a hint? Push . :)\n");
                if (isHintVisable)
                {
                    Console.Write("\n@The city you are looking for is the capital of " + country + "\n\n");
                }
            }
            Console.SetCursorPosition(0, 28);
            Console.Write("current level : " + (levelsPassed + 1) + "\t\tPush '0' to exit");
            drawHangMan(healthPoints);
            Console.SetCursorPosition(0, 16);
            return Program.getUserInput();

        }
        static public String getPlayersSentence()
        {
            Console.SetCursorPosition(0, 18);
            Console.Write("Remember, if you are wrong, your guess will cost you 2 lifes(letters)");
            Console.SetCursorPosition(0, 16);
            Console.Write("The city hiden behind password is: ");
            return Console.ReadLine();
        }
        static public char victoryScreen(int numberOfTries, string time, String capital, String country, String[] leaderboard)
        {
            Console.Clear();
            Console.WriteLine("Victory! " + capital + " is the capital of " + country);
            Console.Write("Would you like to restart the program?" + "\n(Y)Yes, (N)Quit");
            Console.Write("\n\n\n\n\nYour stats:\nYou guessed the capital after " + numberOfTries +  " letters.\nIt took you: " + time);
            drawLeaderboard(leaderboard, 0, 16);
            Console.SetCursorPosition(0, 14);
            Console.Write("If you want to be remembered in the leaderboard, please push ; and leave your name : ");
            return Program.getUserInput();
        }
        static public void drawLeaderboard(String[] leadeboard, int positionX, int positionY)
        {
            Console.SetCursorPosition(0 + positionX, positionY - 2);
            Console.Write("@NAME@          @DATE@    @TIME@@LETTERS@ @CAPITAL@");
        for (int i = 0; i<leadeboard.Length; i++)
            {
                Console.SetCursorPosition(0 + positionX, i + positionY);
                Console.WriteLine(leadeboard[i]);
            }
        }
        static public char failureScreen(String capital, String country)
        {
            Console.Clear();
            Console.WriteLine("You have lost! Remember, this game is created to practice your knowledge" +
                "\nso please be patient and improve your skill.\n\nWould you like to restart the program?" +
                "\n(Y)Yes, (N)Quit");
            drawHangMan(0);
            Console.SetCursorPosition(0, 29);
            Console.Write("The correct answer: " + capital + " is the capital of " + country);
            Console.SetCursorPosition(0, 16);
            return Program.getUserInput();
        }
        static public char helloScreen(Boolean flag)
        {
            Console.Clear();
            if (flag == true)
            {
                Console.Write("\n\n\t @\t\t\t\t\t\t\t\t\t\t\t   @" +
                    "\n\t@@@\t\t\t\t\t\t\t\t\t\t\t  @@@" +
                    "\n\t @\t\t\t\t\t\t\t\t\t\t\t   @" +
                    "\n\n\n\n" +
                    "\n\t\t@@@  @@@      @\t      @@@   @@@  @@@@@@@@@    @@@@@@@@@        @       @@@   @@@" +
                    "\n\t\t@@@  @@@     @@@      @@@   @@@  @@@    @@    @@ @@@ @@       @@@      @@@   @@@" +
                    "\n\t\t@@@  @@@    @@@@@     @@@@  @@@\t @@@     @    @@ @@@ @@      @@@@@     @@@@  @@@" +
                    "\n\t\t@@@  @@@    @@@@@     @@@@@ @@@  @@@         @@@ @@@ @@@     @@@@@     @@@@@ @@@" +
                    "\n\t\t@@@  @@@   @@@ @@@    @@@ @@@@@\t @@@         @@  @@@  @@    @@@ @@@    @@@ @@@@@" +
                    "\n\t\t@@@@@@@@   @@@ @@@    @@@  @@@@  @@@         @@  @@@  @@    @@@ @@@    @@@  @@@@" +
                    "\n\t\t@@@  @@@   @@   @@@   @@@   @@@  @@@  @@@@   @@  @@@  @@    @@@  @@@   @@@   @@@" +
                    "\n\t\t@@@  @@@   @@@@@@@@   @@@   @@@  @@@   @@@   @@  @@@  @@    @@@@@@@@   @@@   @@@" +
                    "\n\t\t@@@  @@@  @@@   @@@@  @@@   @@@  @@@    @@  @@@  @@@  @@@  @@@   @@@@  @@@   @@@" +
                    "\n\t\t@@@  @@@  @@@   @@@@  @@@   @@@  @@@@@@@@@  @@@  @@@  @@@  @@@   @@@@  @@@   @@@" +
                    "\n\n\n\n\t @\t\t\t\t\t\t\t\t\t\t\t   @" +
                    "\n\t@@@\t\t\t\t\t\t\t\t\t\t\t  @@@" +
                    "\n \t @\t\t\t\t\t\t\t\t\t\t\t   @");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Welcome in the Hangman Game!\n\nChoose an option by pushing the correct" +
                " button:\n\n1. Start the new game\n2. Leaderboard\n3. Close the program");
            return Program.getUserInput();
        }
        static public void drawHangMan(int remaindedHealthPoints)
        {
            if (remaindedHealthPoints <= 5) {
                Console.SetCursorPosition(79, 13);
                Console.Write("______||_____");
                Console.SetCursorPosition(78, 14);
                Console.Write("/      ||     \\");
                Console.SetCursorPosition(77, 15);
                Console.Write("/       ||      \\");
            }
            if (remaindedHealthPoints <= 4)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(85, 12-i);
                    Console.Write("||");
                }
            }
            if (remaindedHealthPoints <= 3)
            {
                Console.SetCursorPosition(85, 2);
                Console.Write("____________________,");
                Console.SetCursorPosition(85, 3);
                Console.Write("||------------------|");
            }
            if (remaindedHealthPoints <= 2)
            {
                Console.SetCursorPosition(102, 8);
                Console.Write("/|\\");
                Console.SetCursorPosition(101, 9);
                Console.Write("/ | \\");
                Console.SetCursorPosition(103, 10);
                Console.Write("|");
                Console.SetCursorPosition(102, 11);
                Console.Write("_|_");
            }
            if (remaindedHealthPoints <= 1)
            {
                Console.SetCursorPosition(101, 12);
                Console.Write("/   \\");
                Console.SetCursorPosition(100, 13);
                Console.Write("/	  \\");
            }
            if (remaindedHealthPoints == 0)
            {
                Console.SetCursorPosition(102, 4);
                Console.Write("|");
                Console.SetCursorPosition(102, 5);
                Console.Write("|__,");
                Console.SetCursorPosition(102, 6);
                Console.Write("|xx|");
                Console.SetCursorPosition(102, 7);
                Console.Write("|_@|");
            }






        }
    }
}
