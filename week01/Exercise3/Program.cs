using System;

class Program
{
    static void Main(string[] args)
    {
     
        Random random = new Random();
        int magicNumber = random.Next(1, 101);

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I have selected a number between 1 and 100. Try to guess it.");

        int guess = 0; 

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out guess))
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}
