using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class OrderItem
    {
        public Product Product;
        public double discount;
        public double quantity;







        public  OrderItem(Product product, double quantity)
        {
            product = new Product(product.productname, product.purchaseprice, product.saleprice, product.discount);
            this.quantity = quantity;
        }
        public double total()
        {
            double discountedPrice = Product.saleprice - (Product.saleprice * discount);
            return discountedPrice * quantity;
        }


        public void  ShowOrderitems() {
        
        Console.WriteLine("Discount :"+discount);
        Console.WriteLine("Quantity :" + quantity);
        Console.WriteLine("Price of the item  :" + total());



        }
    }
}
