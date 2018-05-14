using MongoDB.Bson;
using System.Collections.Generic;

namespace Agent
{
    public class BlackList
    {
        public ObjectId _id { get; set; }
        public List<string> Websites { get; set; }
        public List<string> Apps { get; set; }
    }
}
