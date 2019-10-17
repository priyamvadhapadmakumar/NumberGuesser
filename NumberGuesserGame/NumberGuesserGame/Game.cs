using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuesserGame
{
    class Game
    {
        static void Main()
        {
            GetAppInfo(); // Get the application info
            GreetUser(); //Greets the user
            MainGame();//Plays the game
            return;
        }

        //Gets the app info
        static void GetAppInfo()
        {
            //Setting app variables
            string appName = "Number Guesser Game";
            string appVersion = "1.0";
            string appAuthor = "Priyamvadha Padmakumar";

            //Header Formatting
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} : Version {1}. Designed by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }

        // Greets the user
        static void GreetUser()
        {
            //Get user's name
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();

            //Welcome the user to play a game
            Console.WriteLine("Hey {0}, let's play a game!", userName);
        }

        //Prints color message
        static void PrintColorMsg(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void PlayAgain(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                MainGame();
            }
            else if (answer == "N")
            {
                ThankYou();
            }
            else
            {
                ThankYou();
            }
        }

        static void ThankYou()
        {
            Console.WriteLine("Thanks for playing");
        }

        static void MainGame()
        {
            while (true)
            {
                //Create a new random object and initialize it as correct number
                Random random = new Random();
                int correctNumber = random.Next(1, 10);

                //Initialize guess number
                int guessNumber = 0;

                //Ask the user to guess number
                Console.WriteLine("Here's the deal. You have 3 chances to guess the right number between 1 and 10. GO!!!!");

                //logic
                int counter = 3;
                for (int i = 0; i < counter; i++)
                {
                    if (guessNumber != correctNumber)
                    {
                        //get user input number
                        string input = Console.ReadLine();

                        //Make sure the user enters a number
                        if (!int.TryParse(input, out guessNumber))
                        {
                            PrintColorMsg(ConsoleColor.Red, "Please enter a valid number between 1 to 10");
                            continue;
                        }
                        else
                        {
                            //Parse to integer and save it to guesNumber
                            guessNumber = int.Parse(input);

                            //When the guessed number is not correct
                            PrintColorMsg(ConsoleColor.Red, "Wrong Number. Please try again!");
                            continue;
                        }
                    }
                    else if (guessNumber == correctNumber)
                    {
                        //When user guessed the correct number
                        PrintColorMsg(ConsoleColor.Green, "CORRECT!! You guessed it right!!");
                        PlayAgain("Do yo want to try again? [Y or N]");
                    }
                }

                PlayAgain("You have reached the maximum number of tries. Do yo want to try again? [Y or N]");

            }
        }
    }
}
