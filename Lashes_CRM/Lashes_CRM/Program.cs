using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace Lashes_CRM
{
    class Program
    {
        public static object ExceptionLogger { get; private set; }

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
            var fileLocation = @"C:\Database.xml";
            string FirstNameInput = "";
            string SurNameInput = "";
            string Email = "";
            string PhoneNo = "";

            //Lists going to be added to XML files then added to configuration class
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

            Console.WriteLine($"Press 1 to add a customer");
            Console.WriteLine($"Press 2 to search for a Customer");
            Console.WriteLine($"Press 3 to edit a Customer details");
            string userInput = Console.ReadLine();
            int inputMain = Int32.Parse(userInput);


            if (inputMain == 1)
            {
                //If Statement to check if XML file exists or not if it does exist load data into customers list if it does not exist create the document 
                if (File.Exists(fileLocation))
                {
                    Console.WriteLine($"File Exist");
                    StreamReader xmlDatabase = new StreamReader(fileLocation);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                    List<Customer> CustomerList = (List<Customer>)serializer.Deserialize(xmlDatabase);
                    Console.WriteLine(CustomerList.Count);
                    customers = CustomerList;
                    xmlDatabase.Close();
                }
                else
                {
                    Console.WriteLine($"File does not exist");
                    var DbFile = new System.IO.StreamWriter(fileLocation);
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
                //Setting class peratmeters 
                Customer customer1 = new Customer() { FirstName = FirstNameInput, LastName = SurNameInput, ActiveUser = UserActive, PhoneNumber = PhoneNo, EmailAddress = Email };
                Console.WriteLine(customer1);
                //Adding new Customer to Database         
                customers.Add(customer1);
                customers.Add(new Customer() { FirstName = "John" });
                //Write Customer data to xml document
                XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
                TextWriter txtWriter = new StreamWriter(fileLocation);
                xs.Serialize(txtWriter, customers);
                txtWriter.Close();
            }
            if (inputMain == 2)
            {
                Console.WriteLine($"Press 1 to search First Name");
                Console.WriteLine($"Press 2 to search Surname Name");
                Console.WriteLine($"Press 3 to search email address");
            }
            if (inputMain == 3)
            {
                Console.WriteLine($"Enter name of user you would like to Edit");
            }
        }
    }
}
