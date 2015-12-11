using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanCP330
{
    class Program
    {
        //Number of failed attempts
        public static int lives = 5;
        //Total amount of won games
        public static int totalwins = 0;
        //Total amount of loss games
        public static int totalloses = 0;
        //wordbanks
        static string[] names = { "jade", "Mathew", "Michael" };
        static string[] places = { "Nipigon","Chicago","Vancouver" };
        static string[] colors = { "red","blue","purple" };
        static string[] custom = { };       
        public static List<string> nameslist = new List<string>(names);
        public static List<string> placeslist = new List<string>(places);
        public static List<string> colorslist = new List<string>(colors);
        public static List<string> customlist = new List<string>(custom);

        static void Main(string[] args)
        {
            //The intro
            Console.Title = "Hangman(CP330)";
            Console.WriteLine("--Intro stuff here--");
            Console.Read();
            //The menu
            string input = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Command");
                Console.WriteLine("1.Start New Game");
                Console.WriteLine("2.Create Custom Wordlist");
                Console.WriteLine("3.Scoreboard");
                Console.WriteLine("4.Exit");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        SelectCategory();
                        break;
                    case "2":
                        Console.Clear();
                        CreateList();
                        break;
                    case "3":
                        Console.Clear();
                        Scoreboard();
                        break;
                    case "4":
                        break;
                }
            } while (input != "4");
        }
        static void CreateList()
        {
            Console.WriteLine("Input the word you would like to add to the custom list");
            string input = Console.ReadLine();
            customlist.Add(input);
            Console.WriteLine("{0} was added to the custom list!", input);
            Console.WriteLine("Press ENTER to go back...");
            Console.Read();
            Console.Clear();
        }
        static void SelectCategory()
        {
            string input = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Please Select a Category or return to menu.");
                Console.WriteLine("1.Names");
                Console.WriteLine("2.Places");
                Console.WriteLine("3.Colors");
                Console.WriteLine("4.Custom");
                Console.WriteLine("5.return to menu");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        NewGame1();
                        break;
                    case "2":
                        Console.Clear();
                        NewGame2();
                        break;
                    case "3":
                        Console.Clear();
                        NewGame3();
                        break;
                    case "4":
                        Console.Clear();
                        NewGame4();
                        break;
                    case "5":
                        break;
                }
            } while (input != "5");
        }
        static void Scoreboard()
        {
            string input = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter command");
                Console.WriteLine("1.Check Total Wins");
                Console.WriteLine("2.Check Total Loses");
                Console.WriteLine("3.Return to main menu");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Total Wins = {0}", totalwins);
                        Console.WriteLine("Press ENTER to go back...");
                        Console.Read();                
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Total Loses = {0}", totalloses);
                        Console.WriteLine("Press ENTER to go back...");
                        Console.Read();
                        break;
                    case "3":
                        break;
                }
            } while (input != "3");
        }
        static void NewGame1()
        {
            int goback = 0;
            do
            {
                Random random = new Random((int)DateTime.Now.Ticks);

                string wordToGuess = nameslist[random.Next(0, nameslist.Count)].ToString();
                string wordToGuessUppercase = wordToGuess.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                for (int i = 0; i < wordToGuess.Length; i++)
                    displayToPlayer.Append('-');

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                bool won = false;
                int lettersRevealed = 0;

                string input;
                char guess;
                string solve;

                while (!won && lives > 0)
                {
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.Write("Guess a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];
                    solve = input;

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }

                    if (wordToGuessUppercase == solve)
                    {
                        Console.WriteLine("You solved the word!");
                        won = true;
                        totalwins++;
                    }
                    else if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                        lives--;
                    }
                    Console.WriteLine("  ");
                }
                if (won)
                Console.WriteLine("You won!");
                else
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
                totalloses++;
                Console.Clear();
            } while (goback != 1);
        }
        static void NewGame2()
        {
            int goback = 0;
            do
            {
                Random random = new Random((int)DateTime.Now.Ticks);

                string wordToGuess = placeslist[random.Next(0, placeslist.Count)].ToString();
                string wordToGuessUppercase = wordToGuess.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                for (int i = 0; i < wordToGuess.Length; i++)
                    displayToPlayer.Append('-');

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                bool won = false;
                int lettersRevealed = 0;

                string input;
                char guess;
                string solve;

                while (!won && lives > 0)
                {
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.Write("Guess a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];
                    solve = input;

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }

                    if (wordToGuessUppercase == solve)
                    {
                        Console.WriteLine("You solved the word!");
                        won = true;
                        totalwins++;
                    }
                    else if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                        lives--;
                    }
                    Console.WriteLine("  ");
                }

                if (won)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
                totalloses++;
                Console.Clear();
            } while (goback != 1);
        }
        static void NewGame3()
        {
            int goback = 0;
            do
            {
                Random random = new Random((int)DateTime.Now.Ticks);

                string wordToGuess = colorslist[random.Next(0, colorslist.Count)].ToString();
                string wordToGuessUppercase = wordToGuess.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                for (int i = 0; i < wordToGuess.Length; i++)
                    displayToPlayer.Append('-');

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                bool won = false;
                int lettersRevealed = 0;

                string input;
                char guess;
                string solve;

                while (!won && lives > 0)
                {
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.Write("Guess a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];
                    solve = input;

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        Console.WriteLine("  ");
                        continue;
                    }

                    if (wordToGuessUppercase == solve)
                    {
                        Console.WriteLine("You solved the word!");
                        won = true;
                        totalwins++;
                    }
                    else if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                        lives--;
                    }
                    Console.WriteLine("  ");
                }

                if (won)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
                totalloses++;
                Console.Clear();
            } while (goback != 1);
        }
        static void NewGame4()
        {
            try
            {
                int goback = 0;
            do
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                
                    string wordToGuess = customlist[random.Next(0, customlist.Count)].ToString();
                    string wordToGuessUppercase = wordToGuess.ToUpper();
                    StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                    for (int i = 0; i < wordToGuess.Length; i++)
                        displayToPlayer.Append('-');

                    List<char> correctGuesses = new List<char>();
                    List<char> incorrectGuesses = new List<char>();

                    bool won = false;
                    int lettersRevealed = 0;

                    string input;
                    char guess;
                    string solve;

                    while (!won && lives > 0)
                    {
                        Console.WriteLine("Current word: " + displayToPlayer);
                        Console.Write("Guess a letter: ");

                        input = Console.ReadLine().ToUpper();
                        guess = input[0];
                        solve = input;

                        if (correctGuesses.Contains(guess))
                        {
                            Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                            continue;
                        }
                        else if (incorrectGuesses.Contains(guess))
                        {
                            Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                            continue;
                        }
                        if (wordToGuessUppercase == solve)
                        {
                            Console.WriteLine("You solved the word!");
                            won = true;
                            totalwins++;
                        }
                        else if (wordToGuessUppercase.Contains(guess))
                        {
                            correctGuesses.Add(guess);

                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuessUppercase[i] == guess)
                                {
                                    displayToPlayer[i] = wordToGuess[i];
                                    lettersRevealed++;
                                }
                            }

                            if (lettersRevealed == wordToGuess.Length)
                                won = true;
                        }
                        else
                        {
                            incorrectGuesses.Add(guess);

                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                        }

                        Console.WriteLine("  ");
                    }

                    if (won)
                        Console.WriteLine("You won!");
                    else
                        Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                    Console.Write("Press anything to continue...");
                    Console.ReadLine();
                    goback = 1;
                    lives = 5;
                    Console.Clear();
                } while (goback != 1);
            }
            catch
            {
                Console.WriteLine("There is no words in the custom list,");
                Console.WriteLine("please try adding some and try again");
                Console.WriteLine("Press anything to continue...");
                Console.ReadKey();
                Console.Clear();
            };
        }
    }
}
