using MongoDB.Bson;
using System.Collections.Generic;

namespace Agent
{
    public class Workstations
    {
        public ObjectId _id { get; set; }
        public string WorkstationName { get; set; }
        public string StudentFirstAndLastName { get; set; }
        public string StudentID { get; set; }
        public string HostName { get; set; }
        public string IPAdress { get; set; }
        public string UserName { get; set; }
        public List<string> Alerts { get; set; }
        public List<string> Apps { get; set; }

    } 
}
