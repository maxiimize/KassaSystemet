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
            
            int amountOfReceipts = Receipts.ReadAmountOfReceipts();

            Console.WriteLine("Startar ny försäljning...");

            
            PrintReceipts newCheckout = new PrintReceipts();

            
            bool checkoutRunning = true;
            while (checkoutRunning)
            {
                Console.WriteLine($"Ange produktID och mängd av produkt, t.ex. '300 2' (eller skriv 'PAY' för att betala):");
                string[] userInputs = Console.ReadLine().Split(" ");

                if (userInputs.Length == 1 && userInputs[0].ToUpper() == "PAY") 
                {
                    amountOfReceipts += 1; 
                    Receipts.SaveAmountOfReceipts(amountOfReceipts); 

                    
                    string folderPath = "../../../../NyttKassasystemUtanMergeKonflikt/Kvitton";
                    string filePath = Path.Combine(folderPath, $"RECEIPT_{DateTime.Now:yyyy-MM-dd}_{amountOfReceipts}.txt");

                    IPrintReceipts consolePrinter = new ConsolePrintReceipts();
                    IPrintReceipts filePrinter = new FilePrintReceipts(filePath);

                    
                    newCheckout.PrintReceipt(amountOfReceipts, consolePrinter, filePrinter);

                    
                    Console.WriteLine("\nBetalning mottagen.\nKommandon:\n<produktid> <antal/vikt>\nPAY");
                    checkoutRunning = false; 
                }
                else if (userInputs.Length == 2)
                {
                    try
                    {
                        int productId = int.Parse(userInputs[0]);
                        decimal productAmount = decimal.Parse(userInputs[1]);

                        
                        Products product = Products.GetProductById(productId);

                        if (product != null)
                        {
                            newCheckout.AddProduct(product, productAmount);
                            Console.WriteLine($"{product.ProductName} har lagts till i din försäljning.");
                        }
                        else
                        {
                            Console.WriteLine("Produkten kunde inte hittas. Kontrollera ProduktID.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Felaktig inmatning. Ange ProduktID som ett heltal och mängd som ett nummer med ',' för decimal.");
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


