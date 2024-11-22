using NyttKassasystemUtanMergeKonflikt.Classes;

namespace NyttKassasystemUtanMergeKonflikt
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            Receipts.EnsureReceiptsFolderExists();

            int amountOfReceipts = Receipts.ReadAmountOfReceipts();


            //Välkomstmeddelande
            Console.WriteLine($"Hej och välkommen till Kassystemet Maximus Ultimatus!\n");

            Checkout checkout = null;
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
                    Console.WriteLine("Startar ny försäljning. . .");
                    Checkout newCheckout = new Checkout();

                    bool checkoutRunning = true;
                    while (checkoutRunning)
                    {
                        Console.WriteLine($"Ange produktID och mängd av produkt, T.ex '300 2'(eller skriv 'PAY' för att betala):");
                        string[] userInputs = Console.ReadLine().Split(" ");

                        string pay = userInputs[0];

                        if (userInputs.Length == 1 && userInputs[0].ToUpper() == "PAY") //Kontrollerar om kunden endast anger ett kommando och om det är 'PAY'
                        {
                            amountOfReceipts += 1;
                            Receipts.SaveAmountAmountOfReceipts(amountOfReceipts);
                            newCheckout.PrintReceipt(amountOfReceipts);
                            Console.WriteLine("Betalning mottagen\nKommandon:\n<productid> <antal/vikt>\nPAY");
                            checkoutRunning = false; //Avslutar while loopen om kunden vill betala.
                        }


                        else if (userInputs.Length == 2)
                        {
                            try
                            {

                                int productId = int.Parse(userInputs[0]);
                                decimal productAmount = decimal.Parse(userInputs[1]);

                                Products product = GetProductById(productId); //Tar fram rätt produkt beroende på produktid

                                if (product != null)
                                {
                                    newCheckout.AddProduct(product, productAmount); //Lägger till produkt samt mängden av produkt
                                    Console.WriteLine($"{product.ProductName} har lagts till i din försäljning.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Felaktig inmatning. Ange ProduktID som heltal och mängd som ett nummer med ',' för decimal.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Felaktig inmatning. Ange antingen 'PAY' eller produktID och mängd.");
                        }
                    }
                }
                else //Stänger programmet
                {
                    Console.WriteLine("Stänger program. . ."); //Avslutar kassasystemet
                    running = false;
                }
            }
        }

        static Products GetProductById(int productId) //Metod för att kunna få fram relevant information om produkter utifrån produktid
        {
            if (productId == 100)
            {
                return new Products(100, "Kaffe", 44.95m);
            }
            else if (productId == 200)
            {
                return new Products(200, "Mjölk", 17.95m);
            }
            else if (productId == 300)
            {
                return new Products(300, "Bananer", 28);
            }

            return null;
        }

        
    }
}
