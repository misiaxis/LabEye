using System.Collections.Generic;
using MongoDB.Bson;

namespace Agent
{
    public class Workstations
    {
        public ObjectId _id { get; set; }
        public string WorkstationName { get; set; }
        public string StudentFirstAndLastName { get; set; }
        public string HostName { get; set; }
        public string IPAdress { get; set; }
        public string UserName { get; set; }
        public List<string> Alerts { get; set; }
        public List<string> Apps { get; set; }


    } 
}
