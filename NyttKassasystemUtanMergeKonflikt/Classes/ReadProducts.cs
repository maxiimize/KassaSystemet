using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class ReadProducts
    {

        public List<string> ProductsFromFile { get; set; }

        public ReadProducts()
        {
            ProductsFromFile = new List<string>();
        }

        public void LoadFile(string filePath)
        {
            ProductsFromFile = new List<string>(File.ReadAllLines(filePath));
        }
    }
}
