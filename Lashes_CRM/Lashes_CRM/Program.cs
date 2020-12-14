using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lashes_CRM
{
    class Program
    {

        static void Main(string[] args)
        {
            // if adding customer
            // list of customer is empty new user obj gets client id 0
            // list is not empty 
            var customersDatabase = new List<Customer>();
            //var highestID = customers.Max(f => f.CustomerID);
            var customerToEdit = customersDatabase.Find(f => f.CustomerID == 0);
            int inputMain = 0;
            int searchDisplayNo = 0;
            //customers.OrderBy( b => b.date)
            string FirstNameInput = "";
            string SurNameInput = "";
            string Email = "";
            string PhoneNo = "";
            bool continueProgram = true;
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

            while (continueProgram)
            {
                MainDisplay();
                //  string userInput = Console.ReadLine();
                while (!int.TryParse(Console.ReadLine(), out inputMain))
                {
                    UserInputValidationError();
                }
                while (inputMain > 3)
                {
                    UserInputValidationError();
                    while (!int.TryParse(Console.ReadLine(), out inputMain))
                    {
                        UserInputValidationError();
                    }
                }
                CustomerDatabase.Load(Configuration.FileLocation);
                customersDatabase = CustomerDatabase.Customers;

                //If Statement to check if XML file exists or not if it does exist load data into customers list if it does not exist create the document 
                /* if (File.Exists(Configuration.FileLocation))
                 {

                     customersDatabase = CustomerDatabase.Load(Configuration.FileLocation);
                 }
                 else
                 {
                     Console.WriteLine($"File does not exist");
                     var DbFile = new System.IO.StreamWriter(Configuration.FileLocation);
                     DbFile.Close();
                 }*/
                //Add Customer Option
                if (inputMain == 1)
                {
                    Console.Clear();
                    //User Input screen, user asked to Enter first name Surname, Email Address and Phone Number
                    // AddUserInput(SurNameInput, Email, PhoneNo);
                    Console.WriteLine($"Enter first name");
                    FirstNameInput = Console.ReadLine();
                    Console.WriteLine($"Enter surname name");
                    SurNameInput = Console.ReadLine();
                    Console.WriteLine($"Enter phone number name");
                    PhoneNo = Console.ReadLine();
                    Console.WriteLine($"Enter email address name");
                    Email = Console.ReadLine();
                    bool ValidateEmail = Validate(Email);
                    while (ValidateEmail == false)
                    {
                        EmailValidationError();
                        Email = Console.ReadLine();
                        ValidateEmail = Validate(Email);
                    }
                    //Setting class peratmeters 
                    Customer customer1 = new Customer()
                    {
                        FirstName = FirstNameInput,
                        LastName = SurNameInput,
                        PhoneNumber = PhoneNo,
                        EmailAddress = Email
                    };

                    Console.WriteLine(customer1);
                    //Adding new Customer to Database         
                    customersDatabase.Add(customer1);
                    //Write Customer data to xml document
                    XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
                    TextWriter txtWriter = new StreamWriter(Configuration.FileLocation);
                    xs.Serialize(txtWriter, customersDatabase);
                    txtWriter.Close();
                }
                //Search Option
                if (inputMain == 2)
                {
                    Console.Clear();
                    SearchDisplay();
                    // int searchDisplayNo = SearchDisplayOption();

                    while (!int.TryParse(Console.ReadLine(), out searchDisplayNo))
                    {
                        UserInputValidationError();
                        // searchDisplayNo = SearchDisplayOption();
                    }
                    while (searchDisplayNo > 1)
                    {
                        UserInputValidationError();
                        while (!int.TryParse(Console.ReadLine(), out searchDisplayNo))
                        {
                            UserInputValidationError();
                        }
                        //  searchDisplayNo = SearchDisplayOption();
                    }
                    if (searchDisplayNo == 1)
                    {

                        Console.WriteLine($"Enter name (first name or surname of user you would like to search for");
                        string nameSearch = Console.ReadLine();
                        var mc = new Customer();
                        // string CustomerFullName = mc.FullName;
                        var searchCustomerName = customersDatabase.FindAll(x => x.FullName.Contains(nameSearch));
                        foreach (Customer customerFound in searchCustomerName)
                            Console.WriteLine(customerFound);
                    }
                }
                if (inputMain == 3)
                {
                    Console.Clear();
                    EditDisplay();
                    string editInput = Console.ReadLine();
                }
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
            Console.WriteLine($"Press 1 to search Name of customer");
        }
        /*  public static int SearchDisplayOption()
          {
              string searchUserInput = Console.ReadLine();
              int searchUserDisplayNo = Int32.Parse(searchUserInput);
              return searchUserDisplayNo;
          } */
        /// <summary>
        /// Validates Email address from user input an forces user to input correct email format 
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns>True or False if email adress is in correct format</returns>
        public static bool Validate(string EmailAddress)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(EmailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }
        /// <summary>
        /// Sends Error message if user Email inout is incorrect 
        /// </summary>
        public static void EmailValidationError()
        {
            Console.WriteLine($"Please enter a valid Email Address");
        }
        /// <summary>
        /// Sends error message if user enters invalid input and asks them to re enter selection
        /// </summary>
        public static void UserInputValidationError()
        {
            Console.WriteLine($"Invalid input");
            Console.WriteLine($"Please enter a number between 1 and 3");
        }
    }
}