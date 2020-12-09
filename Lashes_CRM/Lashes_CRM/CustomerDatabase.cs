using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Lashes_CRM
{
    public static class CustomerDatabase
    {
        public static bool Load(String fileName)
        {
            if (File.Exists(fileName))
            {
                return true;
            }
            else
                return false;
        }
        public static List<Customer> LoadDatabase()
        {
            Console.WriteLine($"Loading database...");
            StreamReader xmlDatabase = new StreamReader(Configuration.FileLocation);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            List<Customer> CustomerList = (List<Customer>)serializer.Deserialize(xmlDatabase); 
            xmlDatabase.Close();
            return CustomerList;
        }
   
        public static bool Save(String fileName)
        {
            return false;
        }

        private static List<Customer> _customers;

        public static List<Customer>  Customers
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
