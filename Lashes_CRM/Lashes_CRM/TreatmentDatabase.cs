using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lashes_CRM
{
    class TreatmentDatabase
    {
        public static void LoadLashData(String fileName, List<string>treatments)
        {
            _treatments = Utilities.XMLLoad<List<string>>(fileName, Treatments);
        }
        private static List<string> _treatments;

        public static List<string> Treatments
        {
            get { return _treatments; }
            set { _treatments = value; }
        }
    }
}
