using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop_Management_System
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            string productFile = "products.txt";
            string customerFile = "customers.txt";
            string orderFile = "orders.txt";

            Shop shop = new Shop();


            shop.inventory.products = Filehandling.LoadProducts(productFile);
            shop.customers = Filehandling.LoadCustomers(customerFile);






            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("-----  MAIN MENU  -----");
                Console.WriteLine();
                Console.WriteLine("1.PRODUCT  MANAGEMENT ");
                Console.WriteLine("2.CUSTOMER MANAGEMENT ");
                Console.WriteLine("3.CREATE NEW SALES  ");
                Console.WriteLine("4.VIEW ORDER HISTORY ");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Choose your option");
                choice = int.Parse(Console.ReadLine());



                if (choice == 1)
                {

                    Console.WriteLine("1.Add product");
                    Console.WriteLine("2.Update product");
                    Console.WriteLine("3.Delete product");
                    Console.WriteLine("4.View product");
                    Console.WriteLine("Choose your option");
                    int choicep = int.Parse(Console.ReadLine());


                    if (choicep == 1)
                    {
                        // Add product 

                        Console.WriteLine("Enter the product name");
                        string n = Console.ReadLine();

                        Console.WriteLine("Enter the product purchase price ");
                        int purchase = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the product sales price ");
                        int sale = int.Parse(Console.ReadLine());



                        Console.WriteLine("Enter the discount ");
                        double disc = double.Parse(Console.ReadLine());


                        Product p = new Product(n, purchase, sale, disc);
                        shop.inventory.AddProduct(p);
                        Filehandling.SaveProducts(productFile, shop.inventory.products);
                        Console.WriteLine("Product added successfully!");


                    }
                    else if (choicep == 2)
                    {
                        // update product

                        Console.WriteLine("Enter the product name to update");
                        string pname= Console.ReadLine();

                        Console.WriteLine("Enter the purchase  price ");
                        double pprice= double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the sale  price ");
                        double sprice = double.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the discount ");
                        double dis = double.Parse(Console.ReadLine());


                        shop.inventory.updateProduct(pname, pprice, sprice, dis);
                        Filehandling.SaveProducts(productFile, shop.inventory.products);
                    }



                    else if (choicep == 3)
                    {

                        //Delete product


                        Console.WriteLine("Enter the product name to delete");
                        string pname  = Console.ReadLine();

                        int Count=shop.inventory.products.Count();

                        for(int i=0; i < Count; i++)
                        {
                            if (shop.inventory.products[i].productname == pname)
                            {
                                shop.inventory.products.RemoveAt(i);
                                Filehandling.SaveProducts(productFile, shop.inventory.products);
                                Console.WriteLine("Products deleted Successfully !");
                                return;
                            }
                        }Console.WriteLine("Product Not Found !");
                     

                       

                    }
                    else if (choicep == 4)
                    {
                        // view product 
                        Console.WriteLine("Enter the product name to view");
                        string pname = Console.ReadLine();

                        for (int i = 0; i < shop.inventory.products.Count(); i++) { 
                        
                        if(shop.inventory.products[i].productname == pname)
                            {

                                shop.inventory.products[i].Showproducts();
                            }
                            Filehandling.SaveProducts(productFile, shop.inventory.products);


                        }
                    }

                }


                else if (choice == 2)
                {

                    Console.WriteLine("1.Add Customers");
                    Console.WriteLine("2.Update Customer details");
                    Console.WriteLine("3.Delete Customers");
                    Console.WriteLine("4.View Customer Record");
                    Console.WriteLine("Choose Your Option ");
                    int choiceC = int.Parse(Console.ReadLine());

                    if (choiceC == 1)
                    {

                        // add Customer     

                        Console.WriteLine("Enter the Customer name to add");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter the phone number ");
                        string phonenumber = Console.ReadLine();

                        Console.WriteLine("Enter the age of customer ");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the address ");
                        string address = Console.ReadLine();

                        Customer c=new Customer(name, phonenumber, age,address);
                        Filehandling.SaveCustomers(customerFile, shop.customers);
                        shop.customers.Add(c);

                    }
                    else if (choiceC == 2)
                    {
                        //update customer detail
                        Console.WriteLine("Enter the Customer name to add");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter the phone number ");
                        string phonenumber = Console.ReadLine();

                        Console.WriteLine("Enter the age of customer ");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the address ");
                        string address = Console.ReadLine();

                        shop.Updatecustomer(name, phonenumber, age,address);
                        Filehandling.SaveCustomers(customerFile, shop.customers);
                    }
                    else if (choiceC == 3)
                    {


                        //delete customer
                        Console.WriteLine("Enter the Customer name to delete");
                        string pname = Console.ReadLine();

                        int Count = shop.customers.Count();

                        for (int i = 0; i < Count; i++)
                        {
                            if (shop.customers[i].Customername == pname)
                            {
                                shop.customers.RemoveAt(i);
                                Filehandling.SaveCustomers(customerFile, shop.customers);
                                Console.WriteLine("Customer deleted Successfully !");
                                break;
                            }
                        }
                        Console.WriteLine("Customer Not Found !");

                    }
                    else if (choiceC == 4)
                    {

                        //view customer record

                        shop.Showcustomers();
                        {
                            Console.WriteLine("Invalid choice!");
                        }
                        Filehandling.SaveCustomers(customerFile, shop.customers);


                    }
                }


               else  if (choice == 3)
                {
                    //create new sales 

                    shop.CreateSale();
                    Filehandling.SaveCustomers(customerFile, shop.customers);

                }
                else if (choice == 4)
                {

                    //view order history 

                    shop.ShowOrder();
                    Filehandling.SaveCustomers(customerFile, shop.customers);
                }
              
                else if   (choice==5) {

                    Console.WriteLine("Exiting program ");
                
                
                
                }else { Console.WriteLine("Invalid Input"); }
            }
        }
    }
}
