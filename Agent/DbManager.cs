using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Agent
{
    public class DbManager
    {
        MongoClient client;
        public IMongoCollection<Workstations> workstationsCollection;
        public IMongoCollection<BlackList> blackListCollection;
        public IMongoDatabase db;
        public string connectionString;
        public string dbname;
        public MongoUrl mongoUrl;

        public DbManager()
        {
            client = new MongoClient();
            db = client.GetDatabase("LabEyeMongo");
            RefreshWorkstations();
            RefreshBlackList();
        }
        public void RefreshWorkstations() /// Gets Workstations collection
        {
            workstationsCollection = db.GetCollection<Workstations>("Workstations");
        }
        public void RefreshBlackList() /// Gets BlackList collection
        {
            blackListCollection = db.GetCollection<BlackList>("BlackList");
        }
        public void WorkstaionsMakeNew(
            string workstationName,
            string studentFirstAndLastName,
            string hostName,
            string ipAdress,
            string userName,
            List<Alerts> alertsList,
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
            workstationsCollection.InsertOne(newDocument);
        }
        public void WorkstationsMakeNew()
        {
            Workstations newDocument = new Workstations
            {
                WorkstationName = StationInformation.WorkstationName,
                StudentFirstAndLastName = StationInformation.StudentFirstAndLastName,
                HostName = StationInformation.HostName,
                IPAdress = StationInformation.IpAdress,
                UserName = StationInformation.Username,
                Alerts = new List<Alerts>(),
                Apps = new List<string>()
            };

            workstationsCollection.InsertOne(newDocument);
        }

        public List<Workstations> ShowWorkstationsCollection() /// Use to get Workstations collections
        {
            RefreshWorkstations();
            var documents = workstationsCollection.Find(FilterDefinition<Workstations>.Empty).ToList();
            return documents;
        }
        public List<BlackList> ShowBlackListCollection() /// Use to get Black list collections
        {
            RefreshBlackList();
            var documents = blackListCollection.Find(FilterDefinition<BlackList>.Empty).ToList();
            return documents;
        }
        public void UpdateOne(string fieldToUpdate, string newValue, string filterValue) /// Use to update one field in one document of Workstations collection
        {
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
                var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
                workstationsCollection.UpdateOne(filter, update);
        }
        public void UpdateOneBlackList(List<string> newBlackList, string listToUpdate) /// Use to update one Apps or Sites black list
        {
            var filter = Builders<BlackList>.Filter.Empty;
                var update = Builders<BlackList>.Update.Set(listToUpdate, newBlackList);
                blackListCollection.UpdateOne(filter, update);
        }
        public void UpdateOneList(string fieldToUpdate, List<Alerts> newList, string filterValue) /// Use to update one Apps or Sites black list
        {
            var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newList);
            workstationsCollection.UpdateOne(filter, update);
        }
        public void UpdateOneList(string fieldToUpdate, List<string> newList, string filterValue) /// Use to update one Apps or Sites black list
        {
            var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newList);
            workstationsCollection.UpdateOne(filter, update);
        }

        public long UpdateMany(string fieldToUpdate, string newValue, string workstationName) /// Updates many fields in Workstations collection
        {
            var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == workstationName);
            var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
            var result = workstationsCollection.UpdateMany(filter, update);

            return result.ModifiedCount;
        }
        public void DeleteOne(string filteredField, string value, int collection) /// Deletes one document in Workstations collection
        {
            if (collection == 0)
            {
                var filter = Builders<Workstations>.Filter.Eq(filteredField, value);
                workstationsCollection.DeleteOne(filter);
            }
            else if (collection == 1)
            {
                var filter = Builders<BlackList>.Filter.Eq(filteredField, value);
                blackListCollection.DeleteOne(filter);
            }
        }
        public long DeleteMany(string filteredField, string value) /// Deletes many documents in Workstasions collection
        {
            var filter = Builders<Workstations>.Filter.Eq(filteredField, value);
            var result = workstationsCollection.DeleteMany(filter);

            return result.DeletedCount;
        }
        public bool CheckIfExsists(string workstationName, string userName) //returns true if exists and false if it's not
        {
            var query =
                workstationsCollection.AsQueryable()
                .Count(w => w.WorkstationName == workstationName && w.UserName == userName);

            if (query > 0) return true;
            return false;
        }
        public bool CheckIfExsists(string workstationName) //returns true if exists and false if it's not
        {
            var query =
                workstationsCollection.AsQueryable()
                .Count(w => w.WorkstationName == workstationName);

            if (query > 0) return true;
            return false;
        }
        public List<Alerts> GetWorkstationAlertList() //returns true if exists and false if it's not
        {
            var query = from e in workstationsCollection.AsQueryable()
                        where e.WorkstationName == StationInformation.WorkstationName
                        select e.Alerts;
            List<Alerts> temp = new List<Alerts>();
            foreach (var l in query)
                temp = l;
            return temp;

        }
        public void UserLogout()
        {

        }
    }
}