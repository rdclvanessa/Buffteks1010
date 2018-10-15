using System;

namespace BuffTeksIn1010
{
    public class StudentTeam
    {
        public int StudentID { get; set; }
        public int TeamID {get; set; }

        public Team Team { get; set;}
        public Student Student { get; set; }
        
    }
}