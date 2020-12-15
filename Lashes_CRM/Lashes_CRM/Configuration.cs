using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lashes_CRM
{
    class Configuration
    {
        //types of lashes and stuff
        public static string LashFileLocation = @"C:\Lashes.xml";
        public static string FileLocation = @"C:\Database.xml";
        /// <summary>
        /// Loads TreatmentData xml... checks if Lashes xml file exists if it does loads data from the xml to the -lashData list if it does not exist the file gets created 
        /// </summary>
        /// <param name="fileName">LashFileLocation</param>
        /// <returns>_LashData List</returns>
        public static bool LoadLashData(String fileName)
        {

            if (File.Exists(fileName))
            {
                Console.WriteLine($"Loading Lash database...");
                StreamReader xmlDatabase = new StreamReader(fileName);
                XmlSerializer serializer = new XmlSerializer(typeof(List<TreatmentData>));
                List<TreatmentData> lashDataList = (List<TreatmentData>)serializer.Deserialize(xmlDatabase);
                _lashData = lashDataList;
                xmlDatabase.Close();
                return true;
            }
            else
                Console.WriteLine($"No file found... creating Lash database...");
            XmlSerializer xs = new XmlSerializer(typeof(List<TreatmentData>));
            TextWriter txtWriter = new StreamWriter(fileName);
            xs.Serialize(txtWriter, _lashData);

            return false;
        }
        private static List<TreatmentData> _lashData;

        public static List<TreatmentData> LashData
        {
            get { return _lashData; }
            set { _lashData = value; }
        }
    }
}
