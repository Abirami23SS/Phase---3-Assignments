using System;
using System.Collections.Generic;

namespace CafeteriaApplication
{
    public enum Gender{
        Select,Male,Female,Transgender
    }
    public class PersonalDetails
    {
        // •	Name
        // •	FatherName
        // •	Gender {Enum - Select, Male, Female, Transgender}
        // •	Mobile
        // •	MailID
        public string Name{get; set;}
        public string FatherName{get; set;}
        public Gender Gender{get; set;}
        public long Mobile{get; set;}
        public string MailID{get; set;}

        public PersonalDetails(string name,string fatherName,Gender gender,long mobile,string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            MailID=mailID;
        }

         public PersonalDetails()
        {
            
        }
    }
}