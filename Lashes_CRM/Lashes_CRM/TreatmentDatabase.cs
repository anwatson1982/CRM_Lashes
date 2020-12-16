using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lashes_CRM
{
    class TreatmentDatabase
    {
        public static void LoadLashData(String fileName, List<TreatmentData>treatments)
        {
            _treatments = Utilities.XMLLoad<TreatmentData>(fileName, Treatments);
        }
        private static TreatmentData _treatments;

        public static TreatmentData Treatments
        {
            get { return _treatments; }
            set { _treatments = value; }
        }
    }
}
