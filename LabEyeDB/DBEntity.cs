using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEyeDB
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
