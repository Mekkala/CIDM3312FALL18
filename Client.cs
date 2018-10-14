using System;

namespace Homework4
{
    public class Client
    {
        //Pk
        //ID
        public int ClientId {get; set;}
        //First Name
        public string FirstName {get; set;}
        //Last Name
        public string LastName {get; set;}
        //Email
        public string Email {get; set;}

        //Fk
        //Organization id
        public int OrganizationId {get; set;}

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}