using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class Receipts
    {
        private static string ReceiptsFilePath = "../../../amountOfReceipts.txt";

        private static string ReceiptsFolderPath = "../../../Kvitton";

        

        public static void SaveAmountOfReceipts(int amount)
        {
            File.WriteAllText(ReceiptsFilePath, amount.ToString());
        }

        public static int ReadAmountOfReceipts()
        {
            string content = File.ReadAllText(ReceiptsFilePath);
            int.TryParse(content, out int amount);
            return amount;
        }

        public static void EnsureReceiptsFolderExists()
        {
            if (!Directory.Exists(ReceiptsFolderPath))
            {
                Directory.CreateDirectory(ReceiptsFolderPath);
            }
        }
    }
}
