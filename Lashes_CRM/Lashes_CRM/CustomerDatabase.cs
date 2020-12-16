using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Lashes_CRM
{
    public static class CustomerDatabase
    {

        public static void Load(String fileName, List<Customer>cutomers)
        {
            _customers = Utilities.XMLLoad<List<Customer>>(fileName, Customers);
           // TreatmentData x = Utilities.XMLLoad<TreatmentData>("anotherfilename");

         /*   if (File.Exists(fileName))
            {
                Console.WriteLine($"Loading database...");
                StreamReader xmlDatabase = new StreamReader(fileName);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                List<Customer> CustomerLists = (List<Customer>)serializer.Deserialize(xmlDatabase);
                _customers = CustomerLists;
                xmlDatabase.Close();
                return true;
            }
            else
            {
                Console.WriteLine($"No file found... creating database...");
                XmlSerializer xs = new XmlSerializer(typeof(List<Customer>));
                TextWriter txtWriter = new StreamWriter(fileName);
                xs.Serialize(txtWriter, _customers);
                return false;
            }
         */
        }

        public static bool Save(String fileName)
        {
            return false;
        }

        private static List<Customer> _customers;

        public static List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }
        /*      public static List<Customer> FindByName(String name)
               {
                   name = "test";
                   return name;
               } */

    }
}
