﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt
{
    internal interface IPrintReceipts
    {
        void Print(List<string> receiptLines);
    }
}
