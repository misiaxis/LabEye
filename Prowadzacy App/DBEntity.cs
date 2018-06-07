using System.Collections.Generic;
using MongoDB.Bson;
using System;

namespace Prowadzacy_App
{
    /// <summary>
    /// Entity class of document Workstation
    /// </summary>
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
    /// <summary>
    /// Entity class of document Alert (inside Workstations)
    /// </summary>
    public class Alerts
    {
        public string AddDate { get; set; }
        public string StudentFirstAndLastName { get; set; }
        public string AlertName { get; set; }
        public ObjectId Link1 { get; set; }
        public ObjectId Link2 { get; set; }
        public ObjectId Link3 { get; set; }
    }

    /// <summary>
    /// Entity class of document BlackList
    /// </summary>
    public class BlackList
    {
        public ObjectId _id { get; set; }
        public List<string> Websites { get; set; }
        public List<string> Apps { get; set; }
    }

    /// <summary>
    /// Entity class of document AlertsHistory
    /// </summary>
    public class AlertsHistory
    {
        public string WorkstationName { get; set; }
        public string StudentFirstAndLastName { get; set; }
        public string AddDate { get; set; }
        public string AlertName { get; set; }
        public ObjectId Link1 { get; set; }
        public ObjectId Link2 { get; set; }
        public ObjectId Link3 { get; set; }
    }
}
