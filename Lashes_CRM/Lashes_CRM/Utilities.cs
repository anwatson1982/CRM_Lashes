using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lashes_CRM
{
    public static class Utilities
    {
        public static T XMLLoad<T>(string fileName, T dataList)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"Loading database...");
                StreamReader xmlDatabase = new StreamReader(fileName);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T result = (T)serializer.Deserialize(xmlDatabase);
                //_customers = CustomerLists;
                xmlDatabase.Close();
                return result;
            }
            else
            {
                Console.WriteLine($"No file found.... Creating database");
                XmlSerializer xs = new XmlSerializer(typeof(T));
                TextWriter txtWriter = new StreamWriter(fileName);
                xs.Serialize(txtWriter, dataList);
                return dataList;
            }
        }
        public static T XMLSave<T>(string fileName, T dataList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            TextWriter txtWriter = new StreamWriter(fileName);
            xs.Serialize(txtWriter, dataList);
            txtWriter.Close();
            return dataList;
        }
    }
}
