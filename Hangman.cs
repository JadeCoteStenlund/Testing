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
        static string[] places = { "Nipigon", "Chicago", "Vancouver" };
        static string[] colors = { "red", "blue", "purple" };
        static string[] custom = { };
        public static List<string> nameslist = new List<string>(names);
        public static List<string> placeslist = new List<string>(places);
        public static List<string> colorslist = new List<string>(colors);
        public static List<string> customlist = new List<string>(custom);

        static void Main(string[] args)
        {
            //The intro
            Console.Title = "Hangman(CP330)";
            Console.WriteLine("Hangman(CP330) Basic Overview");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("The Rules of hangman are very simple.");
            Console.WriteLine("You start with 5 lives and you will lose a life for every wrong guess or solve");
            Console.WriteLine("There is a hidden word that will need to be uncovered");
            Console.WriteLine("letter by letter or with a solve.");
            Console.WriteLine("The game will continue until you solve the word or lose all your lives");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Press Enter to continue to the main menu...");
            Console.Read();
            //The menu
            string input = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose a option from the list");
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
            int repeat = 0;
            Console.WriteLine("Input the word you would like to add to the custom list");
            string input = Console.ReadLine();
            if (input.All(char.IsLetter) && string.IsNullOrEmpty(input) == false)
            {
                customlist.Add(input);
                Console.WriteLine("{0} was added to the custom list!", input);
                Console.WriteLine("Press ENTER to go back...");
                repeat++;
                Console.Read();
            }
            else
                Console.WriteLine("Only letter input is accepted");
            Console.WriteLine("Press ENTER to go back...");
            Console.Read();
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
                Console.WriteLine("3.Reset");
                Console.WriteLine("4.Return to main menu");
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
                        Console.Clear();
                        Console.WriteLine("The total wins and losses has been reset");
                        totalwins = 0;
                        totalloses = 0;
                        Console.WriteLine("Press ENTER to go back...");
                        Console.Read();
                        break;
                    case "4":
                        break;
                }
            } while (input != "4");
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
                int waiting;
                bool gomenu = false;

                while (!won && lives > 0 && !gomenu)
                {

                    Console.WriteLine("The Category is Names");
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.WriteLine("Type -MENU to return at any time");
                    Console.Write("Guess a letter or type -SOLVE to solve the word: ");

                    input = Console.ReadLine().ToUpper();
                    solve = input;
                    waiting = 0;

                    if (string.IsNullOrEmpty(input) == false && input.All(char.IsLetter))
                    {
                        guess = Convert.ToChar(input[0]);

                        if (input.Length > 1)
                        {
                            Console.WriteLine("  ");
                            Console.WriteLine("You can only guess one letter at a time unless you type '-SOLVE'");
                            Console.WriteLine("Please guess again...");
                        }
                        else if (correctGuesses.Contains(guess))
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
                            {
                                won = true;
                                totalwins++;
                            }
                        }
                        else
                        {
                            incorrectGuesses.Add(guess);
                            Console.WriteLine("  ");
                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                            Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                        }
                        Console.WriteLine("  ");
                    }
                    else if (input == "-MENU")
                    {
                        Console.Clear();
                        gomenu = true;

                    }
                    else if (input == "-SOLVE")
                    {
                        Console.WriteLine("  ");
                        Console.WriteLine("Please input your solve attempt");
                        do
                        {
                            string solveinput = Console.ReadLine().ToUpper();
                            if (solveinput == wordToGuessUppercase)
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("You solved the word!");
                                won = true;
                                totalwins++;
                                waiting++;
                            }
                            else
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("Your solve attempt was incorrect!");
                                lives--;
                                Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                                Console.WriteLine("  ");
                                waiting++;
                            }
                        } while (waiting != 1);
                    }
                    else if (string.IsNullOrEmpty(input) == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Only letters are available for input, please try again");
                        Console.WriteLine(" ");
                    }
                }
                if (won)
                {
                    Console.WriteLine("You won!");
                }
                if (gomenu)
                    Console.WriteLine("Going back to menu");
                else if (lives == 0)
                {
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                    totalloses++;
                }
                else
                    Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
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
                int waiting;
                bool gomenu = false;

                while (!won && lives > 0 && !gomenu)
                {

                    Console.WriteLine("The Category is Places");
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.WriteLine("Type -MENU to return at any time");
                    Console.Write("Guess a letter or type -SOLVE to solve the word: ");

                    input = Console.ReadLine().ToUpper();
                    solve = input;
                    waiting = 0;

                    if (string.IsNullOrEmpty(input) == false && input.All(char.IsLetter))
                    {
                        guess = Convert.ToChar(input[0]);

                        if (input.Length > 1)
                        {
                            Console.WriteLine("  ");
                            Console.WriteLine("You can only guess one letter at a time unless you type '-SOLVE'");
                            Console.WriteLine("Please guess again...");
                        }
                        else if (correctGuesses.Contains(guess))
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
                            {
                                won = true;
                                totalwins++;
                            }
                        }
                        else
                        {
                            incorrectGuesses.Add(guess);
                            Console.WriteLine("  ");
                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                            Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                        }
                        Console.WriteLine("  ");
                    }
                    else if (input == "-MENU")
                    {
                        Console.Clear();
                        gomenu = true;

                    }
                    else if (input == "-SOLVE")
                    {
                        Console.WriteLine("  ");
                        Console.WriteLine("Please input your solve attempt");
                        do
                        {
                            string solveinput = Console.ReadLine().ToUpper();
                            if (solveinput == wordToGuessUppercase)
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("You solved the word!");
                                won = true;
                                totalwins++;
                                waiting++;
                            }
                            else
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("Your solve attempt was incorrect!");
                                lives--;
                                Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                                Console.WriteLine("  ");
                                waiting++;
                            }
                        } while (waiting != 1);
                    }
                    else if (string.IsNullOrEmpty(input) == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Only letters are available for input, please try again");
                        Console.WriteLine(" ");
                    }
                }
                if (won)
                {
                    Console.WriteLine("You won!");
                }
                if (gomenu)
                    Console.WriteLine("Going back to menu");
                else if (lives == 0)
                {
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                    totalloses++;
                }
                else
                    Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
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
                int waiting;
                bool gomenu = false;

                while (!won && lives > 0 && !gomenu)
                {

                    Console.WriteLine("The Category is Colors");
                    Console.WriteLine("Current word: " + displayToPlayer);
                    Console.WriteLine("Type -MENU to return at any time");
                    Console.Write("Guess a letter or type -SOLVE to solve the word: ");

                    input = Console.ReadLine().ToUpper();
                    solve = input;
                    waiting = 0;

                    if (string.IsNullOrEmpty(input) == false && input.All(char.IsLetter))
                    {
                        guess = Convert.ToChar(input[0]);

                        if (input.Length > 1)
                        {
                            Console.WriteLine("  ");
                            Console.WriteLine("You can only guess one letter at a time unless you type '-SOLVE'");
                            Console.WriteLine("Please guess again...");
                        }
                        else if (correctGuesses.Contains(guess))
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
                            {
                                won = true;
                                totalwins++;
                            }
                        }
                        else
                        {
                            incorrectGuesses.Add(guess);
                            Console.WriteLine("  ");
                            Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                            lives--;
                            Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                        }
                        Console.WriteLine("  ");
                    }
                    else if (input == "-MENU")
                    {
                        Console.Clear();
                        gomenu = true;

                    }
                    else if (input == "-SOLVE")
                    {
                        Console.WriteLine("  ");
                        Console.WriteLine("Please input your solve attempt");
                        do
                        {
                            string solveinput = Console.ReadLine().ToUpper();
                            if (solveinput == wordToGuessUppercase)
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("You solved the word!");
                                won = true;
                                totalwins++;
                                waiting++;
                            }
                            else
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("Your solve attempt was incorrect!");
                                lives--;
                                Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                                Console.WriteLine("  ");
                                waiting++;
                            }
                        } while (waiting != 1);
                    }
                    else if (string.IsNullOrEmpty(input) == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Only letters are available for input, please try again");
                        Console.WriteLine(" ");
                    }
                }
                if (won)
                {
                    Console.WriteLine("You won!");
                }
                if (gomenu)
                    Console.WriteLine("Going back to menu");
                else if (lives == 0)
                {
                    Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                    totalloses++;
                }
                else
                    Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                goback = 1;
                lives = 5;
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
                    int waiting;
                    bool gomenu = false;

                    while (!won && lives > 0 && !gomenu)
                    {

                        Console.WriteLine("The Category is a Custom list");
                        Console.WriteLine("Current word: " + displayToPlayer);
                        Console.WriteLine("Type -MENU to return at any time");
                        Console.Write("Guess a letter or type -SOLVE to solve the word: ");

                        input = Console.ReadLine().ToUpper();
                        solve = input;
                        waiting = 0;

                        if (string.IsNullOrEmpty(input) == false && input.All(char.IsLetter))
                        {
                            guess = Convert.ToChar(input[0]);

                            if (input.Length > 1)
                            {
                                Console.WriteLine("  ");
                                Console.WriteLine("You can only guess one letter at a time unless you type '-SOLVE'");
                                Console.WriteLine("Please guess again...");
                            }
                            else if (correctGuesses.Contains(guess))
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
                                {
                                    won = true;
                                    totalwins++;
                                }
                            }
                            else
                            {
                                incorrectGuesses.Add(guess);
                                Console.WriteLine("  ");
                                Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                                lives--;
                                Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                            }
                            Console.WriteLine("  ");
                        }
                        else if (input == "-MENU")
                        {
                            Console.Clear();
                            gomenu = true;

                        }
                        else if (input == "-SOLVE")
                        {
                            Console.WriteLine("  ");
                            Console.WriteLine("Please input your solve attempt");
                            do
                            {
                                string solveinput = Console.ReadLine().ToUpper();
                                if (solveinput == wordToGuessUppercase)
                                {
                                    Console.WriteLine("  ");
                                    Console.WriteLine("You solved the word!");
                                    won = true;
                                    totalwins++;
                                    waiting++;
                                }
                                else
                                {
                                    Console.WriteLine("  ");
                                    Console.WriteLine("Your solve attempt was incorrect!");
                                    lives--;
                                    Console.WriteLine("You have lost 1 life, you have {0} left", lives);
                                    Console.WriteLine("  ");
                                    waiting++;
                                }
                            } while (waiting != 1);
                        }
                        else if (string.IsNullOrEmpty(input) == false)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Only letters are available for input, please try again");
                            Console.WriteLine(" ");
                        }
                    }
                    if (won)
                    {
                        Console.WriteLine("You won!");
                    }
                    if (gomenu)
                        Console.WriteLine("Going back to menu");
                    else if (lives == 0)
                    {
                        Console.WriteLine("You lost! It was '{0}'", wordToGuess);
                        totalloses++;
                    }
                    else
                        Console.WriteLine("Press ENTER to continue...");
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
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                Console.Clear();
            };
        }
    }
}

