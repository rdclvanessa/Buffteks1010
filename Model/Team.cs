using System;

namespace BuffTeksIn1010
{
    public class Team
    {
        public int TeamID{ get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public override string ToString()
        {
            return $"{TeamName} - {TeamDescription}";
        }

    }
}