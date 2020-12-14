using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Lashes_CRM
{
    public class Customer
    {

        public int CustomerID;
        public string FirstName;
        public String LastName = "";
        public string PhoneNumber;
        public string EmailAddress;
        public DateTime date;
        public string LashType;
        public List<string> LashSize;
        public string TreatmentType;
        public bool ActiveUser = true;
        private bool _subscriberList = true;


        //   [XmlIgnore]
        public string FullName
        {
              get { return FirstName + " " + LastName; }
        }
    
     //   public bool SubscriberList { get => _subscriberList; set => _subscriberList = value; }

     //   public Customer()
     //   {
     //       date = DateTime.Now;
      //  }

        public override string ToString()
        {
            return $"{CustomerID} - {FullName} - {EmailAddress} - {PhoneNumber}";
        }
    }
}
