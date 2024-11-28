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
                    Console.WriteLine("\nFelaktig inmatning:");
                }
                else if (userChoice == 1)
                {
                    HandleProducts handleProducts = new HandleProducts();
                    string filePath = "../../../Products.txt";
                    handleProducts.LoadProducts(filePath);

                    int amountOfReceipts = Receipts.ReadAmountOfReceipts();

                    Console.WriteLine("Startar ny försäljning...");
                    PrintReceipts newCheckout = new PrintReceipts();
                    bool checkoutRunning = true;

                    while (checkoutRunning)
                    {

                        Console.WriteLine($"Ange produktID och mängd av produkt, t.ex. '300 2' (eller skriv 'PAY' för att betala):");
                        string inputCheckout = Console.ReadLine();
                        string[] userInputs = inputCheckout.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        if (userInputs.Length == 1 && userInputs[0].ToUpper() == "PAY")
                        {

                            amountOfReceipts++;
                            Receipts.SaveAmountOfReceipts(amountOfReceipts);

                            string folderPath = "../../../../NyttKassasystemUtanMergeKonflikt/Kvitton";
                            string filePathReceipt = Path.Combine(folderPath, $"RECEIPT_{DateTime.Now:yyyy-MM-dd}.txt");

                            IPrintReceipts consolePrinter = new ConsolePrintReceipts();
                            IPrintReceipts filePrinter = new FilePrintReceipts(filePathReceipt);

                            newCheckout.PrintReceipt(amountOfReceipts, consolePrinter, filePrinter);

                            Console.WriteLine("\nBetalning mottagen. Kvitto har sparats.\n");
                            checkoutRunning = false;
                        }
                        else if (userInputs.Length == 2)
                        {
                            try
                            {
                                int productId = int.Parse(userInputs[0]);
                                decimal amount = decimal.Parse(userInputs[1]);

                                Products product = handleProducts.GetProductById(productId);

                                if (product != null)
                                {
                                    newCheckout.AddProduct(product, amount);
                                    Console.WriteLine($"{product.ProductName} har lagts till i försäljningen.");
                                }
                                else
                                {
                                    Console.WriteLine("Produkten kunde inte hittas. Kontrollera ProduktID.");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Felaktig inmatning. ProduktID måste vara ett heltal och mängd ett nummer (använd ',' för decimal).");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
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
                    Console.WriteLine("Stänger program. . .");
                    running = false;
                }
            }
        }

    }
}

