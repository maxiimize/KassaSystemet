using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class PrintReceipts
    {
        public List<CheckoutProduct> Products { get; set; } = new List<CheckoutProduct>();
        public decimal TotalCost => Products.Sum(product => product.TotalPrice); //Beräknar totalen för alla produkter i köpet.


        public void AddProduct(Products product, decimal amountOrWeight)
        {
            Products.Add(new CheckoutProduct(product, amountOrWeight));
        }

        public void PrintReceipt(int separator, params IPrintReceipts[] printers)
        {
            List<string> receiptLines = new List<string> { $"KVITTO   {DateTime.Now:yyyy-MM-dd HH:mm:ss}" };

            foreach (CheckoutProduct product in Products)
            {
                string line = $"{product.Product.ProductName} {product.AmountOfProduct} x {product.Product.ProductPrice} = {product.TotalPrice}kr";
                receiptLines.Add(line);
            }
            receiptLines.Add($"Totalt: {TotalCost}kr");

            // Skriv ut med alla tillhandahållna skrivare
            foreach (var printer in printers)
            {
                printer.Print(receiptLines);
            }
        }

    }
}
