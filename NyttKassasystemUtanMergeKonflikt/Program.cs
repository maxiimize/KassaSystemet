using NyttKassasystemUtanMergeKonflikt.Classes;

namespace NyttKassasystemUtanMergeKonflikt
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            Receipts.EnsureReceiptsFolderExists();

            


            //Välkomstmeddelande
            Console.WriteLine($"Hej och välkommen till Kassystemet Maximus Ultimatus!\n");

            PrintReceipts checkout = null;
            bool running = true;
            

            while (running)
            {
                Console.WriteLine("Skriv in antingen 1 eller 2 och sedan Enter för att ta dig vidare.\n1. Ny kund\n2. Stäng program");
                string input = Console.ReadLine();

                //Kontrollerar det användare anger är null, ogiltigt eller varken 1 eller 2
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int userChoice) || (userChoice != 1 && userChoice != 2))
                {
                    Console.WriteLine("Felaktig inmatning. Försök igen att ange antingen 1 eller 2 innan du trycker på Enter.");
                }
                else if (userChoice == 1)
                {
                    CheckoutStart.Checkout();
                }
                else //Stänger programmet
                {
                    Console.WriteLine("Stänger program. . ."); //Avslutar kassasystemet
                    running = false;
                }
            }
        }

    }
}

