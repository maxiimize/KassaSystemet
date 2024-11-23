using NyttKassasystemUtanMergeKonflikt.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt
{
    internal interface ICheckoutInterface
    {
        public static void StartCheckout(int amountOfReceipts)
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
                    Receipts.SaveAmountOfReceipts(amountOfReceipts);
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

                        Products product = Products.GetProductById(productId); //Tar fram rätt produkt beroende på produktid

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
    }
}
//Använd denna för att göra 2st klasser för checkout. En för start och en för avslut.
