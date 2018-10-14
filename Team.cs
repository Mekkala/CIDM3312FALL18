using System;

namespace Homework4
{
    public class Team
    {
        //Pk
        // Team Id
        public int TeamId {get; set;}
        //Studetn List
        public string Name {get; set;}

        public string Description {get; set;}

        public override string ToString()
        {
            return $"{Name} {Description}";
        }
        
    }
}