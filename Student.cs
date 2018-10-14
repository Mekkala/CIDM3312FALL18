using System;

namespace Homework4
{
    public class Student
    {
        //PK
        // Student Id
        public int StudentId {get; set;}
        //First Name
        public string FirstName {get; set;}
        //Last Name
        public string LastName {get; set;}
        // Email
        public string Email {get; set;}

        public int Age {get; set;}
       
        //Role
        public string Role {get;set;}

        //FK
        // Team id
        public int TeamId {get; set;}

        public override string ToString()
        {
            return $"{FirstName} {LastName} ";
        }

    }
    
}