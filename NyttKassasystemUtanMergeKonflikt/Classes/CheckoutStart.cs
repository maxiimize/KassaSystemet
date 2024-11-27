using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class CheckoutStart

    {
        public static void Checkout()
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
                string input = Console.ReadLine();
                string[] userInputs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

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
    }
}


