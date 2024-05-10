using System;
using System.Collections.Generic;

namespace MetroCardApplication
{
    public class PersonalDetails
    {
        public string UserName{get; set;}
        public long PhoneNumber{get; set;}

        public PersonalDetails(string name,long phoneNumber)
        {
            UserName=name;
            PhoneNumber=phoneNumber;
        }
         public PersonalDetails()
        {
            
        }
    }
}