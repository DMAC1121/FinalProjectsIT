
using System;
using System.Linq;

class Hangman
{
    static void Main(string[] args)
    {
       
        string[] words = { "manqana", "wyali", "saxli", "magida", "burti", "wigni", "kedeli", "velosipedi", "karebi", "karada" };
        string wordToGuess = words[new Random().Next(words.Length)];    // sityvebis masividan randomad irchevs sityvas
       
        
        char[] guessedLetters = new char[wordToGuess.Length];
        int attempts = 6;

        Console.WriteLine(wordToGuess);

        Console.WriteLine("gamoicanit sityva:");

       
        
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i] = '_';                    //  sityva davfarot "_" simboloebit
            Console.Write("_ ");
        }
        Console.WriteLine();



        while (attempts > 0)
        {
            Console.WriteLine($"dagrchat  {attempts}  mcedloba ");
            Console.Write("gamoicanit aso-bgera: ");
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!char.IsLetter(guess))   // vamowmebt momxmarebils shemoyvanil simbolos aris tu ara aso-bgera
            {
                Console.WriteLine("sheiyvanet mxolod aso bgera ! ");
                continue;
            }

            if (wordToGuess.Contains(guess))    //  tu gamoicno aso  mashin  "_"  simbolo chanacvldeba swori asoti
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedLetters[i] = guess;
                    }
                }
            }
            else
            {
                Console.WriteLine("ver gamoicanit aso-bgera");
                attempts--;
            }

            Console.WriteLine(string.Join(" ", guessedLetters));
            

            if (!guessedLetters.Contains('_'))    // tu "_"  simboloebi agar darcha mashin sityva gamoicno 
            {
                Console.WriteLine("tqven sworad gamoicanit sityva");
                return;
            }
        }

        Console.WriteLine("samwuxarod meti cdis ufleba ar gaqvt. gamosacnobi sityva iyo -- " + wordToGuess);
    }
}


