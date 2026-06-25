using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
   

    internal class Customer
    {
        public string Customername;
        public string phonenumber;
        public int age;
        public string address;



        public Customer(string Customername, string phonenumber,int age,string address) { 
        
        this.Customername = Customername;
        this.phonenumber = phonenumber;
        this.age = age;
        this.address = address; 
        }


        public void ShowCustomer()
        {
            Console.WriteLine("Name :" + Customername);
            Console.WriteLine("Phonenumber :" + phonenumber);
            Console.WriteLine("Age :" + age);
            Console.WriteLine("Address :" + address);
        }


        



    }

   
}
