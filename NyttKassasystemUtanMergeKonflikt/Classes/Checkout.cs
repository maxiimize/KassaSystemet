using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class Checkout
    {
        public List<CheckoutProduct> Products { get; set; } = new List<CheckoutProduct>();
        public decimal TotalCost => Products.Sum(product => product.TotalPrice); //Beräknar totalen för alla produkter i köpet.

        private static int amountOfReceipts = 0;



        public void AddProduct(Products product, decimal amountOrWeight)
        {
            Products.Add(new CheckoutProduct(product, amountOrWeight));
        }

        public void PrintReceipt(int separator)
        {

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string folderPath = Path.Combine("../../../../NyttKassasystemUtanMergeKonflikt/Kvitton");
            string filePath = Path.Combine(folderPath, $"RECEIPT_{currentDate}_{separator}.txt");


            List<string> receiptLines = new List<string> { $"KVITTO   {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}" };

            foreach (CheckoutProduct product in Products)
            {
                string line = $"{product.Product.ProductName} {product.AmountOfProduct} x {product.Product.ProductPrice} = {product.TotalPrice}kr";
                receiptLines.Add(line);
            }
            receiptLines.Add($"Totalt: {TotalCost}kr");

            // Skriv till konsolen
            foreach (string line in receiptLines)
            {
                Console.WriteLine(line);
            }

            // Skriv till en unik textfil
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in receiptLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Kvittot har sparats till {filePath}");
        }
    }
}
