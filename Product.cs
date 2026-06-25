using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class Product
    {

        public string productname;
        public double purchaseprice;
        public double saleprice;
        public double discount;





        public Product(string productname, double purchaseprice,double saleprice,double discount)
        {
        
        this.productname = productname;
        this.purchaseprice = purchaseprice;
        this.saleprice = saleprice;
        this.discount = discount;
        
        
        
        
        }


        public void Showproducts()
        {
            Console.WriteLine("Productname :" + productname);
            Console.WriteLine("Purchaseprice :" + purchaseprice);
            Console.WriteLine("Saleprice :" + saleprice);
            Console.WriteLine("Discount :" + discount);

        }
    }
}
