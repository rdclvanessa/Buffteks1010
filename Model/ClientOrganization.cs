using System;

namespace BuffTeksIn1010
{
    public class ClientOrganization
    {
    public int ClientID { get; set; }
    public int OrganizationID { get; set; }
    public Client Client { get; set; }
    public Organization Organization { get; set; }
    }
}
