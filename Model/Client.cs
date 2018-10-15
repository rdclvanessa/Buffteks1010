using System;

namespace BuffTeksIn1010
{
    public class Client
    {
        //Client ID
        public int ClientID{get;set;}
        public string ClientFName{get; set;}
        //last name
        public string ClientLName{get; set;}
        //phone
        public string ClientPhone{get; set;}
        //email
        public string ClientEmail{get; set;}
        //organization
        public string OrganizationID{get; set;}
        
        public override string ToString()
        {
            return this.ClientFName + " " + this.ClientLName;
        } 
    }
       
}