using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop_Management_System
{
    internal class Inventory
    {
        public List<Product> products;



        public Inventory()
        {
            products = new List<Product>();
        }


        public void AddProduct(Product p)
        {

            products.Add(p);

        }


        public void AvailableProducts()
        {

            if (products.Count == 0)
            {
                Console.WriteLine("NO PRODUCTS AVAILABLE !");
            }
            else
            {

                Console.WriteLine("--- List of Products ---");
                Console.WriteLine();
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine("Product " + (i + 1));
                    Console.WriteLine("Name " + products[i].productname);
                    Console.WriteLine("Purchase Price " + products[i].purchaseprice);
                    Console.WriteLine("Sales Price " + products[i].saleprice);
                    Console.WriteLine("Discount " + products[i].discount);
                }

            }
        }

        public  void updateProduct(string productname, double newPurchase, double newSale, double newDiscount)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].productname == productname)
                {
                    products[i].purchaseprice = newPurchase;
                    products[i].saleprice = newSale;
                    products[i].discount = newDiscount;

                    Console.WriteLine("Product updated successfully!");
                    return;

                }
            }
            Console.WriteLine("Product Not Found !");
        }



        public void RemoveProduct(string productname)
        {
            for (int i = 0; i < products.Count; i++)
            {if(products[i].productname == productname)
                {
                    products.RemoveAt(i);
                    Console.WriteLine("Product removed successfully!");
                    return;
            }else
            {
                Console.WriteLine("Product not found !");
            }
                }
        }



    }
}

