using System;
using System.Linq;
using System.Collections.Generic;

namespace BuffTeksIn1010
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedDatabase();

            
            // BasicFiltersWithWhereQuerySyntax();            
            // BasicFiltersWithWhereMethodSyntax();
            GroupByQuerySyntax();
            GroupByMethodSyntax();
            OrderByMethodSyntax();            
            OrderByQuerySyntax();               
            // JoinMethodSyntax();            
            // JoinQuerySyntax();            
            // GroupJoinMethodSyntax();
            //FindByMethodSytax();            
            GroupJoinQuerySyntax();
            

        }

        public static void BasicFiltersWithWhereMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT FirstName 
                    FROM Students
                    WHERE Age >= 18 AND Age <= 20
                 */
                var filteredResult = db.Students.Where(s => s.Age >= 18 && s.Age <= 20).Select(s => s.StudentName);

               // PrintList(filteredResult);
            }
        }

        public static void BasicFiltersWithWhereQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT *
                    FROM Students
                    WHERE Age >= 18 AND Age <= 20
                 */                
                var filteredResult = from s in db.Students
                    where s.Age >= 18 && s.Age <= 20
                    select s.StudentName;

               // PrintList(filteredResult);
            }
        } 
        
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void GroupByMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
           
                // var groupedResult = db.Students.GroupBy(s => s.Age);

                // foreach (var ageGroup in groupedResult)
                // {
                //     Console.WriteLine($"Age Group: {ageGroup.Key}");

                //     foreach(Student s in ageGroup)
                //     {
                //         Console.WriteLine(s);
                //     }
                // }

                //var groupedResult = db.Students.ToList();
                var groupedResult = db.Students.GroupBy(s => s.Class);
                var notSenior = db.Students.Where(s => s.Class != "Senior");
                    foreach(Student s in notSenior)
                    {
                        
                        //Console.WriteLine(s);
                    }
            
              // PrintList(notSenior);
            }              
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void OrderByQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                var mNameGroup = from s in db.Students
                    where s.StudentName[0] <= 'M' select s;
                    foreach(Student s in mNameGroup)
                    {
                        //Console.WriteLine(s);
                    }
                //PrintList(mNameGroup);
            }            
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public static void OrderByMethodSyntax()
        // {
        //     using(var db = new AppDbContext())
        //     {
        //     var LNameGroup = db.Students.Where(s => s.StudentLastName[0] >= 'L');
            
        //             foreach(Student s in LNameGroup)
        //             {
        //                 if(s.StudentName.Length >= 6)
        //                 {
        //                    // Console.WriteLine(s);
        //                 }
        //             }
        //         //PrintList(LNameGroup);
        //     }   
        // }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void GroupByQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                var TakenCIDM = from s in db.Students
                                      where s.Taken == "Yes"
                                      select s;
                foreach(Student s in TakenCIDM)
                {
                    //Console.WriteLine(s);
                }
               //PrintList(TakenCIDM);                                      
            }               
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void OrderByMethodSyntax()
        {
        using(var db = new AppDbContext())
            {  
            var ClientOrgNameGroup = db.ClientOrganization.OrderBy(co => co.Client);
            
            Console.WriteLine(ClientOrgNameGroup);
                    // foreach(Organization co in ClientOrgNameGroup)
                    // {
                    //     Console.WriteLine(ClientOrgNameGroup);
                    //     //Console.WriteLine(co);
                    // }
               // PrintList(co);           
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                try
                {

                    //first, if it is there, delete it
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Students.Any() && !db.Teams.Any() && !db.ClientOrganization.Any() && !db.Clients.Any() && !db.Organizations.Any())
                    {
                        IList<Team> teamList = new List<Team>()
                        {
                            new Team() { TeamID = 1, TeamName = "Team Buffteks", TeamDescription="Nobody does it better"},
                            new Team() { TeamID = 2, TeamName = "Team ALPFA", TeamDescription="We will rock you"}
                        };

                        db.Teams.AddRange(teamList);

                        IList<Client> ClientList = new List<Client>()
                        {
                            new Client() { ClientID = 1, ClientFName = "Susan", ClientLName = "Gat", ClientEmail = "Sugat@email.com"},
                            new Client() { ClientID = 2, ClientFName = "Nicholas", ClientLName = "Iphone", ClientEmail = "NickiaPhone@email.com"},
                            new Client() { ClientID = 3, ClientFName = "Nala", ClientLName = "Sim", ClientEmail = "Simala@email.com"}
                        };

                        db.Clients.AddRange(ClientList);

                        IList<Organization> OrgList = new List<Organization>()
                        {
                            new Organization() { OrginizationID = 1, OrgName = "ALPFA", OrgEmail = "Alpfa@Alpha.org", OrgPhone = "555-555-5534"},
                            new Organization() { OrginizationID = 2, OrgName = "ENACTUS", OrgEmail = "Enactus@Enactus.org", OrgPhone = "555-555-5534"},
                            new Organization() { OrginizationID = 3, OrgName = "APA", OrgEmail = "Apa@Apa.org", OrgPhone = "555-555-5534"},
                        };

                        db.Organizations.AddRange(OrgList);

                        IList<ClientOrganization> COList = new List<ClientOrganization>()
                        {
                            new ClientOrganization() { ClientID = 1, OrganizationID = 1},
                            new ClientOrganization() { ClientID = 2, OrganizationID = 2},
                            new ClientOrganization() { ClientID = 3, OrganizationID = 3}

                        };

                        db.ClientOrganization.AddRange(COList);

                        IList<Student> studentList = new List<Student>() { 
                            new Student() 
                            { 
                            StudentID = 1, StudentName = "Laith", StudentLastName = "Alfaloujeh", Class = "Junior", Age = 20, Taken = "Yes", TeamID = 1},
                            new Student() 
                            { 
                            StudentID = 2, StudentName = "Mekkala", StudentLastName = "Bourapa", Class = "Senior",  Age = 21, Taken = "No", TeamID = 2 },
                            new Student() 
                            {
                            StudentID = 3, StudentName = "Charles", StudentLastName = "Coufal", Class = "Senior",  Age = 22, Taken = "No", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 4, StudentName = "John" , StudentLastName = "Cunningham", Class = "Senior", Age = 37, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 5, StudentName = "Michael" , StudentLastName = "Hayes", Class = "Junior", Age = 23, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 6, StudentName = "Aaron", StudentLastName = "Hebert", Class = "Senior",  Age = 22, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 7, StudentName = "Yi Fu", StudentLastName = "Ji", Class = "Junior",  Age = 24, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 8, StudentName = "Todd", StudentLastName = "Kile", Class = "Junior",  Age = 23, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 9, StudentName = "Mara", StudentLastName = "Kinoff", Class = "Senior",  Age = 21, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 10, StudentName = "Cesareo", StudentLastName = "Lona", Class = "Senior",  Age = 45, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 11, StudentName = "Michael", StudentLastName = "Matthews", Class = "Junior",  Age = 25, Taken = "No", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 12, StudentName = "Mason", StudentLastName = "McCollum", Class = "Junior",  Age = 25, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 13, StudentName = "Alexander", StudentLastName = "McDonald", Class = "Senior",  Age = 23, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 14, StudentName = "Phelps", StudentLastName = "Merrell", Class = "Senior",  Age = 20, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 15, StudentName = "Quan", StudentLastName = "Nguyen", Class = "Junior",  Age = 21, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            {
                            StudentID = 16, StudentName = "Alexander", StudentLastName = "Roder",  Class = "Junior",  Age = 22, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 17, StudentName = "Amy", StudentLastName = "Saysouriyosack", Class = "Junior", Age = 20, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 18, StudentName = "Claudia", StudentLastName = "Silva", Class = "Senior",  Age = 24, Taken = "No", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 19, StudentName = "Gabriela", StudentLastName = "Valenzuela", Class = "Senior",  Age = 21, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 20, StudentName = "Kayla", StudentLastName = "Washington", Class = "Senior",  Age = 22, Taken = "Yes", TeamID = 1 },
                            new Student() 
                            { 
                            StudentID = 21, StudentName = "Matthew", StudentLastName = "Webb", Class = "Senior", Age = 24, Taken = "Yes", TeamID = 2 },
                            new Student() 
                            { 
                            StudentID = 22, StudentName = "Cory", StudentLastName = "Willams", Class = "Junior",  Age = 21, Taken = "Yes", TeamID = 1 },
                        };  

                        db.Students.AddRange(studentList);

                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("We have existing records in the db");
                    }
                }
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }

        public static void JoinMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
                var innerJoin = db.Students.Join(                           //outer sequence
                                                 db.Teams,                  //inner sequence
                                                 s => s.TeamID,             //outer key
                                                 t => t.TeamID,             //inner key
                                                 (s, t) => new              //projection
                                                    {
                                                        StudentName = s.StudentName,
                                                        TeamName = t.TeamName,
                                                        TeamDescription = t.TeamDescription
                                                    }
                                                );

                var innerJoinOrdered = innerJoin.OrderBy(p => p.StudentName).ThenBy(p => p.TeamName);

                foreach(var s in innerJoinOrdered)
                {
                    //Console.WriteLine($"{s.StudentName} is on {s.TeamName} - {s.TeamDescription}");
                }
            }             
        }

        public static void JoinQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
                var innerJoin = from s in db.Students //outer sequence
                                    join t in db.Teams
                                    on s.TeamID equals t.TeamID
                                    select new {
                                        StudentName = s.StudentName,
                                        TeamName = t.TeamName,
                                        TeamDescription = t.TeamDescription
                                    };

                var innerJoinOrdered = from p in innerJoin
                                       orderby p.StudentName
                                       select p;

                foreach(var s in innerJoinOrdered)
                {
                    //Console.WriteLine($"{s.StudentName} is on {s.TeamName} - {s.TeamDescription}");
                }
            }                   
        }

        public static void GroupJoinMethodSyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupJoin = db.Teams.GroupJoin(
                                db.Students,
                                t => t.TeamID,
                                s => s.TeamID,
                                (t, gs) => new
                                {
                                    Students = gs,
                                    TeamName = t.TeamName
                                });

                foreach (var p in groupJoin)
                {
                    //Console.WriteLine($"Group: {p.TeamName}");

                    foreach(var s in p.Students)
                    {
                        //Console.WriteLine(s);
                    }
                }
                //PrintList(groupedResult);
            }              
        } 

        public static void GroupJoinQuerySyntax()
        {
            using(var db = new AppDbContext())
            {
           
                var groupJoin = from t in db.Teams
                                    join s in db.Students
                                    on t.TeamID equals s.TeamID
                                    into studentGroup
                                    select new 
                                    {
                                        Students = studentGroup,
                                        TeamName = t.TeamName
                                    };

                foreach (var p in groupJoin)
                {
                   // Console.WriteLine($"Group: {p.TeamName}");

                    foreach(var s in p.Students)
                    {
                        //Console.WriteLine(s);
                    }
                }
                //PrintList(groupedResult);
            }              
        }         

        public static void PrintList(IEnumerable<Object> list)
        {
            foreach(var s in list)
            {
               // Console.WriteLine(s);
            }
        }
    }
}