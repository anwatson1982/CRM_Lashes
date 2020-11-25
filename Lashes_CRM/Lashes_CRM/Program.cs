using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace Lashes_CRM
{
    class Program
    {
        //public static object XmlSerializer { get; private set; }
        //public static object Database { get; private set; }

        static void Main(string[] args)
        {
       

            // look if the xml file exists
            // doesent empty list 

            //iif it exists - load from xml to customers list

            // if adding customer
            // list of customer is empty new user obj gets client id 0
            // list is not empty 

            

            var customers = new List<Customer>();

            //var highestID = customers.Max(f => f.CustomerID);

            var customerToEdit  = customers.Find(f => f.CustomerID == 0);

            //customers.OrderBy( b => b.date)
            
            bool UserActive = false;
            string FirstNameInput = "";
            string SurNameInput = "";
            string Email = "";
            string PhoneNo = "";
            List<string> LashType = new List<string>();
            LashType.Add("Russian");
            LashType.Add("Classic");

            List<string> TreatmentType = new List<string>();
            TreatmentType.Add("Full Set");
            TreatmentType.Add("Infills");

            List<string> LashSize = new List<string>();
            TreatmentType.Add("16");
            TreatmentType.Add("17");
            TreatmentType.Add("18");
            TreatmentType.Add("19");
            TreatmentType.Add("20");
            TreatmentType.Add("21");
            TreatmentType.Add("22");

            if (File.Exists(@"C:\Database.xml"))
            {
                Console.WriteLine($"File Exist");
                XmlSerializer Dbfile = new XmlSerializer(typeof(List<Customer>));
                Dbfile.Serialize(Console.Out, customers);
            }
            else
            {
                Console.WriteLine($"File does not exist");
                var DbFile = new System.IO.StreamWriter(@"C:\Database.xml");
                DbFile.Close();
            }



            Console.WriteLine($"Enter first name");
            FirstNameInput = Console.ReadLine();

            Console.WriteLine($"Enter surname name");
            SurNameInput = Console.ReadLine();

            Console.WriteLine($"Enter email address");
            Email = Console.ReadLine();

            Console.WriteLine($"Enter Phone Number");
            PhoneNo = Console.ReadLine();

    

            Customer customer1 = new Customer() { FirstName = FirstNameInput, LastName = SurNameInput, ActiveUser = UserActive, PhoneNumber = PhoneNo, EmailAddress = Email };
            Console.WriteLine(customer1);
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer1.LastName);

            customers.Add(customer1);
            customers.Add(new Customer() { FirstName = "John" });
           /// customer1 = new Customer(); 
           

            //Write Customer date to xml document 



            XmlSerializer xs = new XmlSerializer(typeof(List<Customer>)) ;
            TextWriter txtWriter = new StreamWriter(@"C:\Database.xml");
            xs.Serialize(txtWriter, customers);
            txtWriter.Close();          
        }
    }
}
