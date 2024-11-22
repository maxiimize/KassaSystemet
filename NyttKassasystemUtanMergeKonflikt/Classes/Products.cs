using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class Products
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }



        public Products(int productId, string productName, decimal productPrice)
        {
            ProductId = productId;
            ProductPrice = productPrice;
            ProductName = productName;

        }

        public static Products GetProductById(int productId) //Metod för att kunna få fram relevant information om produkter utifrån produktid
        {
            if (productId == 100)
            {
                return new Products(100, "Kaffe", 44.95m);
            }
            else if (productId == 200)
            {
                return new Products(200, "Mjölk", 17.95m);
            }
            else if (productId == 300)
            {
                return new Products(300, "Bananer", 28);
            }

            return null;
        }
    }
}
