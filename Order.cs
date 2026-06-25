using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class Order
    {
        public Customer customer;
        public List<OrderItem> Items;




        public Order(Customer customer)
        {
            this.customer = customer;
        }


        public void AddItem(OrderItem item) { 
            Items.Add(item); }



        public double Totalamount()
        {
            double total = 0;
            for (int i = 0; i < Items.Count; i++) {

                total =total+ Items[i].total();
            }return total;
        }
        public void ShowOrder()
        {
            Console.WriteLine("Customer Name : " + customer.Customername);
            Console.WriteLine(" Total bill : " + Totalamount());
        }
    }
}
