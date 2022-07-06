namespace Giraffe
{
    class Program
    {
        static void Main()
        {
            string[] wordArray = { "classroom", "love", "warning", "article", "exam", "thanks", "failure", "salad", "surgery", "context" };

            Random randomNumber = new Random();
            
            string guessWord = wordArray[randomNumber.Next(10)];
            string attemptWord = " ";
            bool gameActive = true;

            static void lengthCheck(string attemptWord, string guessWord)
            {
                if (attemptWord.Length == guessWord.Length)
                {
                    Console.WriteLine("The word to guess has " + attemptWord.Length + " letters in it!");
                }
                else if (attemptWord.Length > guessWord.Length)
                {
                    Console.WriteLine("The word to guess has less than " + attemptWord.Length + " letters in it!");
                }
                else if (attemptWord.Length < guessWord.Length)
                {
                    Console.WriteLine("The word to guess has more than " + attemptWord.Length + " letters in it!");
                }
            }

            static void lettersCheck(string attemptWord, string guessWord)
            {
                List<char> potentialLetters = new List<char>();

                for (int i = 0; i < guessWord.Length; i++)
                {
                    for (int j = 0; j < attemptWord.Length; j++)
                    {
                        if (guessWord[i] == attemptWord[j])
                        {
                            if (potentialLetters.Contains(guessWord[i]) == false)
                            {
                                potentialLetters.Add(guessWord[i]);
                            }
                        }

                    }
                }

                if (potentialLetters.Count == 0)
                {
                    Console.WriteLine("None of the letters entered are contained in the word to guess.");
                }
                else
                {
                    Console.Write("The word to guess contains ");
                    potentialLetters.ForEach(x => Console.Write(x + " "));
                    potentialLetters.Clear();
                    Console.Write("\n");
                }
            }

            Console.WriteLine("Welcome to the Guessing Game! Enter a string to guess a word!");
            while (gameActive)
            {
                try
                {
                    attemptWord = Console.ReadLine();
                    attemptWord = attemptWord.ToLower();

                    if (attemptWord == guessWord)
                    {
                        Console.WriteLine("Congratulations! You win!");
                        gameActive = false;
                        break;
                    }

                    lengthCheck(attemptWord, guessWord);
                    lettersCheck(attemptWord, guessWord);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
