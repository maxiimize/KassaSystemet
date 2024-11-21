using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class CheckoutProduct
    {
        public Products Product { get; set; }
        public decimal AmountOfProduct { get; set; }

        public CheckoutProduct(Products product, decimal amountOfProduct)
        {
            Product = product;
            AmountOfProduct = amountOfProduct;
        }

        public decimal TotalPrice => Product.ProductPrice * AmountOfProduct;
    }
}
