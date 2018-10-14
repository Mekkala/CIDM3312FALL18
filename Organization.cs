using System;

namespace Homework4
{
    public class Organization
    {
        //Pk
        //ID
        public int OrganizationId {get; set;}
        //Name
        public string Name {get; set;}
        
        public string About {get; set;}

        public override string ToString()
        {
            return $"{Name} {About}";
        }
        
        
    }
}