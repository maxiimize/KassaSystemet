using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class FilePrintReceipts : IPrintReceipts
    {
        private readonly string _filePath;

        public FilePrintReceipts(string filePath)
        {
            _filePath = filePath;
        }

        public void Print(List<string> receiptLines)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {

                foreach (string line in receiptLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.Write($"Kvittot har sparats till {_filePath}");
        } 
    }
}
