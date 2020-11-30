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


            // look if the xml file exists -- DONE
            // doesent empty list  -- DONE

            //iif it exists - load from xml to customers list -- DONE

            // if adding customer
            // list of customer is empty new user obj gets client id 0
            // list is not empty 



            var customers = new List<Customer>();

            //var highestID = customers.Max(f => f.CustomerID);

            var customerToEdit = customers.Find(f => f.CustomerID == 0);

            //customers.OrderBy( b => b.date)

            bool UserActive = false;
            var fileLocation = @"C:\Database.xml";
            var SearchCustomerFirstName = "";
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

            MainDisplay();
            string userInput = Console.ReadLine();
            int inputMain = Int32.Parse(userInput);



            //If Statement to check if XML file exists or not if it does exist load data into customers list if it does not exist create the document 
            if (File.Exists(fileLocation))
            {
                Console.WriteLine($"File Exist");
                StreamReader xmlDatabase = new StreamReader(fileLocation);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                List<Customer> CustomerList = (List<Customer>)serializer.Deserialize(xmlDatabase);
                customers = CustomerList;
                xmlDatabase.Close();
            }
            else
            {
                Console.WriteLine($"File does not exist");
                var DbFile = new System.IO.StreamWriter(fileLocation);
                DbFile.Close();
            }
            if (inputMain == 1)
            {
                Console.Clear();
                //User Input screen, user asked to Enter first name Surname, Email Address and Phone Number
                AddUserInput(FirstNameInput, SurNameInput, Email, PhoneNo);
                //Setting class peratmeters 
                Customer customer1 = new Customer() { FirstName = FirstNameInput, LastName = SurNameInput, ActiveUser = UserActive, PhoneNumber = PhoneNo, EmailAddress = Email };
                Console.WriteLine(customer1);
                //Adding new Customer to Database         
                customers.Add(customer1);
                //Write Customer data to xml document
                XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
                TextWriter txtWriter = new StreamWriter(fileLocation);
                xs.Serialize(txtWriter, customers);
                txtWriter.Close();
            }
            if (inputMain == 2)
            {
                Console.Clear();
                SearchDisplay();
                int searchDisplayNo = SearchDisplayOption();

                if (searchDisplayNo == 1)
                {

                    List<Customer> customerSearchList = new List<Customer>();

                    Console.WriteLine($"Enter first name of user you would like to search for");
                    string firstNameSearch = Console.ReadLine();
                    IEnumerable<Customer> customerQuery =
                     from customerFound in customers
                     where customerFound.FirstName == firstNameSearch
                     select customerFound;
                    foreach (Customer customerFound in customerQuery)
                    {
                        Console.WriteLine(customerFound);
                    }
                    Console.WriteLine($"The End");
                }
                if (searchDisplayNo == 2)
                {
                    Console.WriteLine($"Enter first name of user you would like to search for");
                    string lastNameSearch = Console.ReadLine();
                     var searchCustomerLastName =  customers.FindAll(x => x.LastName.Contains(lastNameSearch));
                    foreach (Customer customerFound in searchCustomerLastName)
                    Console.WriteLine(customerFound);
                }
                if (searchDisplayNo == 3)
                {
                    Console.WriteLine($"Enter first name of user you would like to search for");
                    string firstNameSearch = Console.ReadLine();

                }
            }
            if (inputMain == 3)
            {
                Console.Clear();
                EditDisplay();
                string editInput = Console.ReadLine();
            }

        }
        /// <summary>
        /// Main screen Display giving 3 options for the user
        /// </summary>
        public static void MainDisplay()
        {
            Console.WriteLine($"Press 1 to add a customer");
            Console.WriteLine($"Press 2 to search for a Customer");
            Console.WriteLine($"Press 3 to edit a Customer details");
        }
        /// <summary>
        /// Edit user display giving user options to edit a customers details 
        /// </summary>
        public static void EditDisplay()
        {
            Console.WriteLine($"Enter name of user you would like to Edit");
        }
        /// <summary>
        /// Allows user to search customer details giving them the option to search for first name surname or email adress 
        /// </summary>
        public static void SearchDisplay()
        {
            Console.WriteLine($"Press 1 to search First Name");
            Console.WriteLine($"Press 2 to search Surname Name");
            Console.WriteLine($"Press 3 to search email address");

        }
        public static int SearchDisplayOption()
        {
            string searchUserInput = Console.ReadLine();
            int searchUserDisplayNo = Int32.Parse(searchUserInput);
            return searchUserDisplayNo;
        }
        /// <summary>
        /// Display When Add customer is selected from main option screen
        /// </summary>
        /// <param name="FirstName">FirstNameInput</param>
        /// <param name="SurName">SurNameInput</param>
        /// <param name="EmailAddress">Email</param>
        /// <param name="PhoneNumber">PhoneNo</param>
        public static void AddUserInput(string FirstName, string SurName, string EmailAddress, string PhoneNumber)
        {
            Console.WriteLine($"Enter first name");
            FirstName = Console.ReadLine();
            Console.WriteLine($"Enter surname name");
            SurName = Console.ReadLine();
            Console.WriteLine($"Enter email address");
            EmailAddress = Console.ReadLine();
            Console.WriteLine($"Enter Phone Number");
            PhoneNumber = Console.ReadLine();
        }
    }
}
