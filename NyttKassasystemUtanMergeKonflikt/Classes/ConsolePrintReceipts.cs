using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class ConsolePrintReceipts : IPrintReceipts
    {

        public void Print(List<string> receiptLines)
        {
            foreach (string line  in receiptLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
