using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class Shop
    {
        public Inventory inventory;
        public List<Customer> customers;
        public List<Order> orders;

        public Shop()
        {
            inventory = new Inventory();
            customers = new List<Customer>();
            orders = new List<Order>();
        }




        public void Addcustomer(Customer c)
        {
            customers.Add(c);
            Console.WriteLine("Customer Added ");
        }



        public void Updatecustomer(string Newcustomername, string Newphonenumber, int Newage , string Newaddress)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customername == Newcustomername)
                {
                    customers[i].phonenumber = Newphonenumber;
                    customers[i].age = Newage;
                    customers[i].address = Newaddress;

                    Console.WriteLine("Customer updated successfully!");
                    return;

                }
            }
            Console.WriteLine("Product Not Found !");
        }



        public void Showcustomers()
        {
            if (customers.Count == 0)
            {

                Console.WriteLine("No customer found");

            }
            else { Console.WriteLine("list of Customer");

                for (int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine("Customer " + (i + 1) + ":");
                    Console.WriteLine("Name: " + customers[i].Customername);
                    Console.WriteLine("Phone: " + customers[i].phonenumber);
                    Console.WriteLine("Age: " + customers[i].age);
                    Console.WriteLine("Address: " + customers[i].address);
                    Console.WriteLine();


                }
            }
        }
        public void ShowOrder()
        {
            if (orders == null || orders.Count == 0)
            {
                Console.WriteLine("No orders found!");
                return;
            }

            Console.WriteLine("\n----- ORDER HISTORY -----");

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine("Order No: " + (i + 1));
                Console.WriteLine("Customer Name: " + orders[i].customer.Customername);

                for (int j = 0; j < orders[i].Items.Count; j++)
                {
                    Console.WriteLine("Product Name: " + orders[i].Items[j].Product.productname);
                    Console.WriteLine("Quantity: " + orders[i].Items[j].quantity);
                    Console.WriteLine("Item Total: " + orders[i].Items[j].total());
                }

                Console.WriteLine("Order Total: " + orders[i].Totalamount());
                Console.WriteLine("-----------------------------");
            }
        }










        public Customer FindCustomer(string name)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customername == name)
                {
                    return customers[i];
                }
            }
            return null; 
        }

        public void CreateSale()
        {
            Console.Write("Enter customer name: ");
            string cname = Console.ReadLine();

            Customer c = null;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].Customername == cname)
                {
                    c = customers[i];
                    break;
                }
            }

            if (c == null)
            {
                Console.WriteLine("New customer! Please enter details:");
                Console.Write("Phone: ");
                string phone = Console.ReadLine();
                Console.Write("Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Address: ");
                string address = Console.ReadLine();

                c = new Customer(cname, phone, age, address);
                customers.Add(c);
            }

            Order order = new Order(c);

            while (true)
            {
                Console.Write("Enter product name (or type 'done' to finish): ");
                string pname = Console.ReadLine();

                if (pname.ToLower() == "done")
                {
                    break;
                }


                Product foundProduct = null;
                for (int i = 0; i < inventory.products.Count; i++)
                {
                    if (inventory.products[i].productname == pname)
                    {
                        foundProduct = inventory.products[i];
                        break;
                    }
                }

                if (foundProduct == null)
                {
                    Console.WriteLine("Product not found!");
                }
                else
                {
                    Console.Write("Enter quantity: ");
                    double qty = Convert.ToDouble(Console.ReadLine());

               
                    Product copy = new Product(foundProduct.productname, foundProduct.purchaseprice, foundProduct.saleprice, foundProduct.discount);

                    OrderItem item = new OrderItem(copy, qty);
                    order.AddItem(item);
                }
            }

            orders.Add(order);
            Console.WriteLine("Order created successfully!");
            Console.WriteLine("Total Amount: " + order.Totalamount());
        }


    }
}
