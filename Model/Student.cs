using System;

namespace BuffTeksIn1010
{
    public class Student
    {
        //PK
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public short Age {get; set; }
        public string StudentLastName { get; set; }
        public string Class { get; set; }
        public string Taken { get; set; }

        //FK
        public int TeamID {get; set;}

        public override string ToString()
        {
            return $"{StudentName} - {Taken}";
        }

    }
        // public override string ToString()
        // {

        //     string output = $"{this.FName} - {this.LName}";
        //     //return this.FName + " " + this.LName;
        //     return output;
        // }
    }
