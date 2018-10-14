using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework4
{
    class Program
    {
        

        static void Main(string[] args)
        {

            SeedDatabase();

        }
                
        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                
                
                try
                {

                    
                    db.Database.EnsureCreated();

                    if(!db.Students.Any() && !db.Teams.Any())
                
                    {
                        

                        IList<Student> studentList = new List<Student>() { 
                            new Student() { StudentId = 1, FirstName = "Laith",LastName = "Alfaloujeh", Email= "alaith@buffs.wtamu.edu",  Role = "Sophomore", Age = 18, TeamId = 1, },
                            new Student() { StudentId = 2, FirstName = "Mekkala",LastName = "Bourapa", Email = "bmekkala@buffs.wtamu.edu", Role = "Junior", Age = 19, TeamId = 2, },
                            new Student() { StudentId = 3, FirstName = "Charles ",LastName = "Coufal",  Email = "ccharles@buffs.wtamu.edu", Role = "Senior", Age = 20, TeamId = 3, },
                            new Student() { StudentId = 4, FirstName = "John",LastName = "Cunningham",  Email = "cjohn@buffs.wtamu.edu", Role = "Sophomore", Age =18, TeamId = 4, },
                            new Student() { StudentId = 5, FirstName = "Michael",LastName = "Hayes",  Email = "hmichael@buffs.wtamu.edu", Role = "Junior", Age = 19,TeamId = 1, },
                            new Student() { StudentId = 6, FirstName = "Aaron",LastName = "Hebert",  Email = "haaron@buffs.wtamu.edu", Role = "Senior", Age = 20,TeamId = 2, },
                            new Student() { StudentId = 7, FirstName = "Yi",LastName = "Ji",  Email = "jyi@buffs.wtamu.edu", Role = "Sophomore", Age = 18, TeamId = 3, },
                            new Student() { StudentId = 8, FirstName = "Todd",LastName = "Kile",  Email = "ktodd@buffs.wtamu.edu", Role = "Junior", Age =19, TeamId = 4, },
                            new Student() { StudentId = 9, FirstName = "Mara",LastName = "Kinoff",  Email = "kmara@buffs.wtamu.edu", Role = "Senior ", Age = 20, TeamId = 1, },
                            new Student() { StudentId= 10, FirstName = "Cesareo",LastName = "Lona",  Email = "lceasa@buffs.wtamu.edu", Role = "Sophomore", Age = 18, TeamId = 2, },
                            new Student() { StudentId= 11, FirstName = "Michael",LastName = "Matthews",  Email = "mmichael@buffs.wtamu.edu", Role = "Junior", Age = 19, TeamId = 3, },
                            new Student() { StudentId= 12, FirstName = "Mason",LastName = "McCollum",  Email = "mmason@buffs.wtamu.edu", Role = "Senior", Age = 20, TeamId = 4, },
                            new Student() { StudentId= 13, FirstName = "Alexander",LastName = "McDonald",  Email = "mcalex@buffs.wtamu.edu", Role = "Sophomore", Age = 18, TeamId = 1, },
                            new Student() { StudentId= 14, FirstName = "Phelps",LastName = "Merrell",  Email = "mphelps@buffs.wtamu.edu", Role = "Junior", Age = 19, TeamId = 2, },
                            new Student() { StudentId= 15, FirstName = "Quan",LastName = "Nguyen",  Email = "nquan@buffs.wtamu.edu", Role = "Senior", Age = 20, TeamId = 3, },
                            new Student() { StudentId= 16, FirstName = "Alexander",LastName = "Roder",  Email = "ralex@buffs.wtamu.edu", Role = "Sophomore", Age = 18, TeamId = 4, },
                            new Student() { StudentId= 17, FirstName = "Amy",LastName = "Saysouriyosack",  Email = "samy@buffs.wtamu.edu", Role = "Junior", Age = 19, TeamId = 1, },
                            new Student() { StudentId= 18, FirstName = "Claudia",LastName = "Silva",  Email = "sclaudia@buffs.wtamu.edu", Role = "Senior", Age = 20, TeamId = 2, },
                    
                        };  

                        db.Students.AddRange(studentList);

                        IList<Team> teamList = new List<Team>()
                        {
                            new Team() { TeamId = 1, Name = "Honey", Description = " We will do our best for your project", },
                            new Team() { TeamId = 2, Name = "Big bear", Description = " The best team ever"},
                            new Team() { TeamId = 3, Name = "Green World", Description = " Client happy, we are happy",},
                            new Team() { TeamId = 4, Name = "Cookie monster", Description = " Do the best for you",},
                        };

                        db.Teams.AddRange(teamList);

                        db.SaveChanges();

                       
                    }
                    else
                    {
                   

                    // Search    

                    // Search student not Sophomore
                    Console.WriteLine("***************STUDENT WHO NOT SOPHOMORE************");
                    var studentNotSophomore = db.Students.Where(s => s.Role != "Sephomore");
                    foreach(Student s in studentNotSophomore)
                    {
                        Console.WriteLine (s);
                    }

                    // Search for student name starts with A
               
                    var studentFirstLetterA = from s in db.Students
                                                where s.FirstName.StartsWith("A")
                                                select s;
                    Console.WriteLine("************STUDENT NAME START WITH A*************");
                    foreach(Student s in studentFirstLetterA)
                    {
                        
                        Console.WriteLine(s);
                    }

                    //search for student name John
                    var studentJohn = from s in db.Students
                                            where s.FirstName == "John"
                                            select s;
                    Console.WriteLine("**************STUDENT NAME JOHN**************");
                    foreach(Student s in studentJohn)
                    {
                        Console.WriteLine(s);
                    }

                    // search Client in Cs organization
                    Console.WriteLine("*************CLEINT IN CS ORGANIZATION**************");
                    var clientInOrganTwo = from c in db.Clients
                                    where c.OrganizationId == 2
                                    select c;
                    foreach(Client c in clientInOrganTwo)
                    {
                        Console.WriteLine(c);
                    }

                    // search Client Last name Robinson
                    Console.WriteLine("*************Client ID number 5***************");
                    var clientIdFive = db.Clients.Where(c => c.ClientId == 5 ).FirstOrDefault();
                    Console.WriteLine(clientIdFive);

                    //Sort

                    // show student sort by First name
                    Console.WriteLine("*************SORTED BY FIRST NAME DESCENDING**************");
                    var sortFirstName = db.Students.OrderByDescending(s => s.FirstName);
                    foreach(Student s in sortFirstName)
                    {
                        
                        Console.WriteLine(s);
                    }

                    // show client sort by Last name 
                    Console.WriteLine("**************SORTED BY LAST NAME***************");
                    var sortLastNameClient = from c in db.Clients orderby c.LastName select c;
                    foreach(Client c in sortLastNameClient)
                    {
                        Console.WriteLine(c);
                    }

                    // show client by organization
                    Console.WriteLine("*************SORTED BY CLIENT ORGANIZATION************");
                    var clientOrgan = db.Clients.GroupBy(c => c.OrganizationId);
                    foreach(var organ in clientOrgan)
                    {
                        Console.WriteLine($"Organization: {organ.Key}");
                        foreach(Client c in organ)
                        {
                            Console.WriteLine(c);
                        }
                    }

                    // show student by role Sophomore, Junior, Senior
                    Console.WriteLine("*************SORTED BY STUDENT ROLE************");
                    var studentRole = db.Students.GroupBy(s => s.Role);
                    foreach(var roleG in studentRole)
                    {
                        Console.WriteLine($"Role: {roleG.Key}");
                        foreach(Student s in roleG)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    // Group

                    // show students group by class role 
                    Console.WriteLine("*************GROUP BY ROEL AND LAST NAME************");
                    var groupRoleSortL = db.Students.GroupBy(s => s.Role);
                    foreach(var roleGroup in groupRoleSortL)
                    {
                        Console.WriteLine($"Role Group: {roleGroup.Key}");

                        foreach(Student s in roleGroup)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    // show students group by team 
                    Console.WriteLine("*************GROUP BY TEAM************");
                    var groupByTeam = from s in db.Students group s by s.TeamId;
                    foreach(var teamG in groupByTeam)
                    {
                        Console.WriteLine($"Team: {teamG.Key}");
                        foreach(Student s in teamG)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    // Group cleint by last name
                    Console.WriteLine("*************GROUP BY LAST NAME************");
                    var groupByLastName = from c in db.Clients group c by c.LastName;
                    foreach(var lastGroup in groupByLastName)
                    {
                        Console.WriteLine($"Last Name: {lastGroup.Key}");
                        {
                            foreach(Client c in lastGroup)
                            {
                                Console.WriteLine(c);
                            }
                        }
                    }   
 
                }
                
                    db.Database.EnsureCreated();

                    if( !db.Clients.Any() && !db.Organizations.Any())
                
                    {

                        IList<Client> ClientList = new List<Client>(){
                            new Client() {ClientId = 1, FirstName = " Megan ", LastName = " White ", Email = " mwhite@cis.com ", OrganizationId = 1 ,},
                            new Client() {ClientId = 2, FirstName = " Robert ", LastName = " Williams ", Email = " wrobert@gmail.com", OrganizationId = 2 ,},
                            new Client() {ClientId = 3, FirstName = " Kylie ", LastName = " Hart ", Email = " hkylie@wtamu.edu", OrganizationId = 1 ,},
                            new Client() {ClientId = 4, FirstName= " Mason ", LastName = " Fox ", Email = " Fmason@cis.com", OrganizationId = 2 ,},
                            new Client() {ClientId = 5, FirstName = " Samantha ", LastName = " Robinson", Email = " rsamantha@gmail.com", OrganizationId = 1 ,},
                            new Client() {ClientId = 6, FirstName = " Kendel ", LastName = " Hart", Email = " kenheart@cis.com", OrganizationId = 1 ,},
                            new Client() {ClientId = 7, FirstName = " Kim ", LastName = " Thompson", Email = " thompsomk@gmail.com", OrganizationId = 2 ,},
                            new Client() {ClientId = 8, FirstName = " Kristal ", LastName = " Robinson", Email = " robink@gmail.com", OrganizationId = 1 ,},
                            new Client() {ClientId = 9, FirstName = " Aaron ", LastName = " Johnson", Email = " johnsona@yahoo.com", OrganizationId = 2 ,},
                        };

                        db.Clients.AddRange(ClientList);


                        IList<Organization> OrganList = new List<Organization>()
                        {
                            new Organization () {OrganizationId =1, Name = " CIS", About = "We are CIS Squad",},
                            new Organization () {OrganizationId =2, Name = " CS", About = "WE are CS Crew",},
                        };

                        db.Organizations.AddRange(OrganList);

                        db.SaveChanges();

                       
                    }
                    else
                    {
                        //Console.WriteLine("We have database");
                   
                    }
            }    


                
                
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }
    }
}

                
        