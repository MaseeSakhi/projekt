
class Program
{
    static void Main()
    {
        int guess;
        int min = 0;
        int max = 500;
        Random rnd = new Random();
        int number = rnd.Next(min, max + 1);
        int guesses = 0;
        string filePath = "guesses.txt";

        // Begrüßungsnachricht
        Console.WriteLine("Willkommen beim Zahlenratespiel!");
        Console.WriteLine("Versuche, die zufällig generierte Zahl zwischen {0} und {1} zu erraten.", min, max);
        Console.WriteLine();

        // Versuche aus vorherigen Spielen anzeigen
        if (File.Exists(filePath))
        {
            Console.WriteLine("Versuche aus vorherigen Spielen:");
            Console.WriteLine(File.ReadAllText(filePath));
            Console.WriteLine();
        }

        do
        {
            Console.Write("Gebe deine Zahl zwischen {0} und {1} ein: ", min, max);
            guess = Convert.ToInt32(Console.ReadLine());
            guesses += 1;

            if (guess == number)
            {
                Console.WriteLine("RICHTIG! Die Zahl war " + number);
                Console.WriteLine("Du hast {0} Versuche gebraucht!", guesses);

                // Versuche in Datei speichern
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine("Zahl: {0}, Versuche: {1}", number, guesses);
                }
            }
            else if (guess > number)
            {
                Console.WriteLine("Die Zahl ist kleiner als " + guess);
            }
            else if (guess < number)
            {
                Console.WriteLine("Die Zahl ist größer als " + guess);
            }

            Console.WriteLine();
        }
        while (guess != number);
    }
}
