using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEyeDB
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
            collection = db.GetCollection<Workstations>("Workstations");
        }

        public void MakeNew(
            string workstationName, 
            string studentFirstAndLastName, 
            string studentId,
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
                    StudentID = studentId,
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

        public void UpdateOne(string fieldToUpdate, string oldValue, string newValue)
        {
            var filter = Builders<Workstations>.Filter.Eq(fieldToUpdate, oldValue);
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
            collection.UpdateOne(filter, update);
        }

        public long UpdateMany(string fieldToUpdate, string oldValue, string newValue)
        {
            var filter = Builders<Workstations>.Filter.Eq(fieldToUpdate, oldValue);
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

    }
}