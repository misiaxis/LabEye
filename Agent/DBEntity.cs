using System.Collections.Generic;
using MongoDB.Bson;
using System;

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
        public List<Alerts> Alerts { get; set; }
        public List<string> Apps { get; set; }
    }
    public class Alerts
    {
        public string AddDate { get; set; }
        public string StudentFirstAndLastName { get; set; }
        public string AlertName { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }

    }
}
