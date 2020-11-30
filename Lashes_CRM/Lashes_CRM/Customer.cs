using System;
using System.Linq;
namespace Lashes_CRM
{
    public class Customer
    {
       
       public int CustomerID;
       public string FirstName;
       public String LastName;
       public string PhoneNumber;
       public string EmailAddress;
       public DateTime date;
       public string LashType;
       public string LashSize;
       public string TreatmentType;
       public bool ActiveUser;
       public bool SubscriberList;

        public Customer()
        {
            date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{CustomerID} - {FirstName} - {LastName} - {EmailAddress} - {PhoneNumber}";
        }
    }
}
