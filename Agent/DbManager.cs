using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Agent
{
    class DbManager
    {
        MongoClient client;
        public IMongoCollection<Workstations> collection;
        public IMongoDatabase db;
        


        public DbManager()
        {
            client = new MongoClient();
            db = client.GetDatabase("LabEyeDB"); 
        }

        public void Refresh()
        {
            collection = db.GetCollection<Workstations>("Workstations");
        }

        public void MakeNew(
            string workstationName, 
            string studentFirstAndLastName, 
            string hostName,
            string ipAdress,
            string userName,
            List<string> alertsList,
            List<string> appList)
            {
                Workstations newDocument = new Workstations
                {
                    WorkstationName = workstationName,
                    StudentFirstAndLastName = studentFirstAndLastName,
                    HostName = hostName,
                    IPAdress = ipAdress,
                    UserName = userName,
                    Alerts = alertsList,
                    Apps = appList
                };
                
                collection.InsertOne(newDocument);
        }

        public void ShowDB() //do poprawy
        {
            collection = db.GetCollection<Workstations>("Workstations");
            var documents = collection.Find(FilterDefinition<Workstations>.Empty).ToList();
            
        }

        public void UpdateOne(string fieldToUpdate, string newValue, string workstationName)
        {
            var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == workstationName );
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
            collection.UpdateOne(filter, update);
        }

        public long UpdateMany(string fieldToUpdate, string newValue, string workstationName)
        {
            var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == workstationName);
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
            var result =  collection.UpdateMany(filter, update);

            return result.ModifiedCount; 
        }

        public void DeleteOne(string filteredField, string value)
        {
            var filter = Builders<Workstations>.Filter.Eq(filteredField, value);
            collection.DeleteOne(filter);
        }
        public long DeleteMany(string filteredField, string value)
        {
            var filter = Builders<Workstations>.Filter.Eq(filteredField, value);
            var result = collection.DeleteMany(filter);

            return result.DeletedCount;
        }

        public bool CheckIfExsists(string workstationName, string userName) //returns true if exists and false if it's not
        {
            var query =
                collection.AsQueryable()
                .Count(w => w.WorkstationName == workstationName && w.UserName == userName);

            if (query > 0) return true;
            return false;
        }

    }
}