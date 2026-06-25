using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Management_System
{
    internal class Filehandling
    {
     
        public static List<string> ReadFromFile(string path)
        {
            List<string> lines = new List<string>();

            if (File.Exists(path))
            {
                StreamReader fileReader = new StreamReader(path);
                string record;

              
                while ((record = fileReader.ReadLine()) != null)
                {
                    lines.Add(record);
                }

                fileReader.Close();
            }
            else
            {
                Console.WriteLine("File not found: " + path);
            }

            return lines;
        }

        
        public static void WriteToFile(string path, List<string> lines)
        {
            StreamWriter fileWriter = new StreamWriter(path, false); 

            for (int i = 0; i < lines.Count; i++)
            {
                fileWriter.WriteLine(lines[i]);
            }

            fileWriter.Close();
        }

        
        public static void AppendToFile(string path, string line)
        {
            StreamWriter fileWriter = new StreamWriter(path, true); 
            fileWriter.WriteLine(line);
            fileWriter.Close();
        }






         public static List<Product> LoadProducts(string path)
        {
            List<Product> products = new List<Product>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line == "") continue;

                    string[] parts = line.Split('|');
                    if (parts.Length < 4) continue;

                    string name = parts[0];
                    int purchasePrice = int.Parse(parts[1]);
                    int salesPrice = int.Parse(parts[2]);
                    double discount = double.Parse(parts[3]);

                    Product p = new Product(name, purchasePrice, salesPrice, discount);
                    products.Add(p);
                }
            }

            return products;
        }

       
        public static void SaveProducts(string path, List<Product> products)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
                Product p = products[i];
                lines.Add(p.productname + "|" + p.purchaseprice + "|" + p.saleprice + "|" + p.discount);
            }

            File.WriteAllLines(path, lines);
        }

      
        public static List<Customer> LoadCustomers(string path)
        {
            List<Customer> customers = new List<Customer>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (line == "") continue;

                    string[] parts = line.Split('|');
                    if (parts.Length < 3) continue;

                  
                    string name = parts[0];
                    string phone = parts[1];
                    int age = int.Parse(parts[2]);
                    string address= parts[3];
                    Customer c = new Customer( name, phone,age, address);
                    customers.Add(c);
                }
            }

            return customers;
        }

        
        public static void SaveCustomers(string path, List<Customer> customers)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer c = customers[i];
                lines.Add( c.Customername + "|" + c.phonenumber);
            }

            File.WriteAllLines(path, lines);
        }

    }
}
    
