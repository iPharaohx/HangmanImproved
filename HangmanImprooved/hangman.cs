using System.Text;

namespace HangmanGame
{
    class Hangman

    {
        //Constants

        private string[] words;
        private string selectedWord;
        private List<char> guessedLetters;
        private int wrongGuesses;
        private const int maxWrongGuesses = 6;

        public Hangman(string[] words)
        {
            this.words = words;
            selectedWord = GetRandomWord();
            guessedLetters = new List<char>();
            wrongGuesses = 0;
        }

        // Game over method
        public bool IsGameOver()
        {
            return wrongGuesses >= maxWrongGuesses || IsWordGuessed();
        }

        // Check if guessed letter is in the word and incriment wrong guesses.

        public bool IsCorrectGuess(char letter)
        {
            bool correctGuess = selectedWord.Contains(letter);
            if (correctGuess)
            {
                guessedLetters.Add(letter);
            }
            else
            {
                wrongGuesses++;
            }
            return correctGuess;
        }

        // Catching Expections
        // If the letter has already being guessed;

        public bool IsAlreadyGuessed(char letter)
        {
            return guessedLetters.Contains(letter);
        }

        // If the input was not a letter;

        public bool IsLetter(char letter)
        {
            return char.IsLetter(letter);
        }
        // Shows the Random word with unguessed letters as "_"
        public string GetWordStatus()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char letter in selectedWord)
            {
                if (guessedLetters.Contains(letter))
                {
                    sb.Append($"{letter} ");
                }
                else
                {
                    sb.Append("_ ");
                }
            }
            return sb.ToString();
        }

        // Printing the hangman

        public string GetHangmanStatus()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" _____");
            sb.AppendLine("|     |");
            if (wrongGuesses > 0)
            {
                sb.AppendLine("|     O");
            }
            if (wrongGuesses > 1)
            {
                sb.AppendLine("|     |");
            }
            if (wrongGuesses > 2)
            {
                sb.AppendLine("|    /|\\");
            }
            if (wrongGuesses > 3)
            {
                sb.AppendLine("|     |");
            }
            if (wrongGuesses > 4)
            {
                sb.AppendLine("|    / \\");
            }
            sb.AppendLine("|");
            sb.AppendLine("|");
            sb.AppendLine("=========");
            return sb.ToString();

        }
        // Generating the random word from the list
        private string GetRandomWord()
        {
            Random random = new Random();
            return words[random.Next(words.Length)];
        }
        // Check if all the characters in the selected word have been guessed.
        public bool IsWordGuessed()
        {
            foreach (char letter in selectedWord)
            {
                if (!guessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
        // Shows the correct word if the player hasnt guessed all the letters.
        public string GetCorrectWord()
        {
            return selectedWord;
        }
    }
}
