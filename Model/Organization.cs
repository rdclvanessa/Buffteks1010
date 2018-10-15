using System;

namespace BuffTeksIn1010
{
    public class Organization
    {
        //Client ID
        public int ClientID{get;set;}
        //project list
        public int OrginizationID{get; set;}
        public string OrgName{get; set;}
        //phone
        public string OrgPhone{get; set;}
        //email
        public string OrgEmail{get; set;}

        public override string ToString()
        {
            return this.OrgName + " " + this.ClientID;
        } 
    }
       
}