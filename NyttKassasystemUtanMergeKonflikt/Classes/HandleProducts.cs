using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttKassasystemUtanMergeKonflikt.Classes
{
    internal class HandleProducts
    {

        private List<Products> products = new List<Products>();

        public void LoadProducts(string filePath)
        {
            string[] productsArray = File.ReadAllLines(filePath);

            foreach (string product in productsArray)
            {
                string[] productsSplit = product.Split('.');

                int productID = int.Parse(productsSplit[0].Trim());
                string productName = productsSplit[1].Trim();
                decimal productPrice = decimal.Parse(productsSplit[2]);
                string productPriceType = productsSplit[3].Trim();

                products.Add(new Products
                {
                    ProductId = productID,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductPriceType = productPriceType
                });
            }
        }


        public Products GetProductById(int id)
        {
            return products.Find(p => p.ProductId == id);
        }
    }
}
