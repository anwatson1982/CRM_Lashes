using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Lashes_CRM
{
    class Program
    {
        public static object XmlSerializer { get; private set; }
        public static object Database { get; private set; }

        static void Main(string[] args)
        {
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

            Console.WriteLine($"Enter first name");
            string FirstNameInput = Console.ReadLine();

            Console.WriteLine($"Enter surname name");
            string SurNameInput = Console.ReadLine();


            Customer customer1 = new Customer() { FirstName = FirstNameInput, LastName = SurNameInput };
            Console.WriteLine(customer1);
            

            //Write Customer date to xml document 

            
            Customer Database = new Customer();
            XmlSerializer xs = new XmlSerializer(typeof(Customer));
            TextWriter txtWriter = new StreamWriter(@"C:\Database.xml");
            xs.Serialize(txtWriter, Database);
            txtWriter.Close();
        }
    }
}
