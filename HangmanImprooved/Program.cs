using System;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Chair", "Table", "Phone", "Laptop", "Bicycle", "Paper", "Notebook", "Keyboard", "Screen", "Television",
                "Pillow", "Blanket", "Towel", "Toothbrush", "Toothpaste", "Shampoo", "Conditioner", "Mirror", "Camera", "Sunglasses", "Jacket",
                "Shoes", "Watch", "Plate", "Flower", "Guitar", "Bottle", "Window", "Candle", "Basket", "Folder", "Folder", "Wallet",
                "Potato", "Orange", "Coffee", "Bottle", "Camera", "Rocket", "Hammer", "Cactus", "Cookie"  };
            Hangman hangman = new Hangman(words);

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Guess the word:");
            Console.WriteLine(hangman.GetWordStatus());

            // Hangman Loop

            while (!hangman.IsGameOver())
            {
                Console.Write("Enter a letter: ");
                char letter = Console.ReadLine()[0];

                if (!hangman.IsLetter(letter))
                {
                    Console.WriteLine("Invalid input. Please enter a letter.");
                    continue;
                }

                if (hangman.IsAlreadyGuessed(letter))
                {
                    Console.WriteLine($"You've already guessed '{letter}'.");
                    continue;
                }

                if (hangman.IsCorrectGuess(letter))
                {
                    Console.WriteLine($"'{letter}' is in the word!");
                    Console.WriteLine(hangman.GetHangmanStatus());
                }
                else
                {
                    Console.WriteLine($"Sorry, '{letter}' is not in the word.");
                    Console.WriteLine(hangman.GetHangmanStatus());
                }

                Console.WriteLine(hangman.GetWordStatus());
            }

            if (hangman.IsWordGuessed())
            {
                Console.WriteLine("Congratulations! You guessed the word!");
            }
            else
            {
                Console.WriteLine("Sorry, you've run out of guesses. The word was: " + hangman.GetCorrectWord());
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}