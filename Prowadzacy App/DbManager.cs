using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Forms;
using MongoDB.Bson;
using System.Drawing;
using MongoDB.Driver.GridFS;
using System.Text.RegularExpressions;
using System.IO;

namespace Prowadzacy_App
{
    /// <summary>
    /// Interaction logic for DBManager.cs
    /// </summary>
    public class DbManager
    {
        MongoClient client;
        public IMongoCollection<Workstations> workstationsCollection;
        public IMongoCollection<BlackList> blackListCollection;
        public IMongoCollection<AlertsHistory> alertHistoryCollection;
        private IMongoDatabase db;
        private string connectionString;
        private string dbname = "lab_eye_mongo";
        private MongoUrl mongoUrl;

        /// <summary>
        /// Constructor of class DbManager
        /// </summary>
        public DbManager()
        {
            try
            {
                using (StreamReader reader = new StreamReader("DbConfig.cfg"))
                {
                    string line;
                    List<string[]> lineValues = new List<string[]>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineValues.Add(line.Split(';'));
                    }
                    
                    client = new MongoClient(lineValues[2][1]);
                    db = client.GetDatabase(lineValues[1][1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd z połączeniem bazy danych. Treść błędu: /n /n" + ex);
                
            }
        }

        /// <summary>
        /// Getting current Workstations collection.
        /// </summary>
        private void RefreshWorkstations()
        {
            workstationsCollection = db.GetCollection<Workstations>("Workstations");
        }

        /// <summary>
        /// Getting current BlackList collection.
        /// </summary>
        private void RefreshBlackList()
        {
            blackListCollection = db.GetCollection<BlackList>("BlackList");
        }

        /// <summary>
        /// Getting current AlertsHistory collection.
        /// </summary>
        public void RefreshAlertsHistory()
        {
            alertHistoryCollection = db.GetCollection<AlertsHistory>("AlertsHistory");
        }

        /// <summary>
        /// Making new Workstations document if not exists
        /// </summary>
        /// <param name="workstationName">Name of workstation.</param>
        /// <param name="studentFirstAndLastName">Student first and last name.</param>
        /// <param name="hostName">Host name.</param>
        /// <param name="ipAdress">Local IP address.</param>
        /// <param name="userName">Logged user name.</param>
        /// <param name="alertsList">List of alerts.</param>
        /// <param name="appList">List of processes.</param>
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
            try
            {
                RefreshWorkstations();
                workstationsCollection.InsertOne(newDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania dokumentu do bazy danych. Treść błędu: /n /n" + ex);
            }
        }

        /// <summary>
        /// Making new Workstations document if not exists. AlertList and AppList empty.
        /// </summary>
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
            try
            {
                RefreshWorkstations();
                workstationsCollection.InsertOne(newDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania dokumentu do bazy danych. Treść błędu: /n /n" + ex);
            }
        }

        /// <summary>
        /// Adding alert to AllertsHistory collection for current workstation
        /// </summary>
        /// <param name="alert">Allert to history.</param>
        /// <param name="previousStudentName">First and last name of previous student</param>
        /// <param name="previousUserName">Previous user name</param>
        public void AlertHistoryMakeNew(Alerts alert)
        {
            Console.WriteLine("1");
            AlertsHistory newDocument = new AlertsHistory
            {
                WorkstationName = StationInformation.WorkstationName,
                StudentFirstAndLastName = alert.StudentFirstAndLastName,
                AddDate = alert.AddDate,
                AlertName = alert.AlertName,
                Link1 = alert.Link1,
                Link2 = alert.Link2,
                Link3 = alert.Link3
            };
            try
            {
                RefreshAlertsHistory();
                alertHistoryCollection.InsertOne(newDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania dokumentu <AlertsHistory> do bazy danych. Treść błędu: /n /n" + ex);
            }
        }
        /// <summary>
        /// Creates new BlackList colletions
        /// </summary>
        /// <param name="websitesBlackList">Black list of websites</param>
        /// <param name="appBlackList">Black list of applications</param>
        public void BlackListsMakeNew(
            List<string> websitesBlackList,
            List<string> appBlackList)
        {
            RefreshBlackList();
            BlackList newDocument = new BlackList
            {
                Websites = websitesBlackList,
                Apps = appBlackList
            };
            try
            {
                RefreshBlackList();
                blackListCollection.InsertOne(newDocument);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania dokumentu <BlackList> do bazy danych. Treść błędu: /n /n" + ex);
            }
        }
        /// <summary>
        /// Getting Workstations collection
        /// </summary>
        /// <returns>List of Workstations</returns>
        public List<Workstations> ShowWorkstationsCollection()
        {
            List<Workstations> documents = new List<Workstations>();
            try
            {
                RefreshWorkstations();
                documents = workstationsCollection.Find(FilterDefinition<Workstations>.Empty).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania kolekcji <Workstations> z bazy danych. Treść błędu: /n /n" + ex);
            }
            return documents;
        }

        /// <summary>
        /// Getting BlackList collection
        /// </summary>
        /// <returns>List of BlackList</returns>
        public List<BlackList> ShowBlackListCollection() /// Use to get Black list collections
        {
            List<BlackList> documents = new List<BlackList>();
            try
            {
                RefreshBlackList();
                documents = blackListCollection.Find(FilterDefinition<BlackList>.Empty).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania kolekcji <Workstations> z bazy danych. Treść błędu: /n /n" + ex);
            }
            return documents;
        }

        /// <summary>
        /// Update one field, document in Workstations
        /// </summary>
        /// <param name="fieldToUpdate">Field to update</param>
        /// <param name="newValue">New field value</param>
        /// <param name="filterValue">Workstation name</param>
        public void UpdateOne(string fieldToUpdate, string newValue, string filterValue)
        {
            try
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
                var update = Builders<Workstations>.Update.Set(fieldToUpdate, newValue);
                workstationsCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji Workstations. Treść błędu: /n /n" + ex);
            }
        }

        /// <summary>
        /// Update one field, document in Workstations - used in AlertsList
        /// </summary>
        /// <param name="fieldToUpdate">Field to update, should be Alerts</param>
        /// <param name="newList">New field value, using Alerts</param>
        /// <param name="filterValue">Workstation name</param>
        public void UpdateOneList(string fieldToUpdate, List<Alerts> newList, string filterValue)
        {
            try
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
                var update = Builders<Workstations>.Update.Set(fieldToUpdate, newList);
                workstationsCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji Workstations <Alerts>. Treść błędu: /n /n" + ex);
            }
        }

        /// <summary>
        /// Update one field, document in Workstations - used in AppList
        /// </summary>
        /// <param name="fieldToUpdate">Field to update, should be Apps</param>
        /// <param name="newList">New field value, using Apps</param>
        /// <param name="filterValue">Workstation name</param>
        public void UpdateOneList(string fieldToUpdate, List<string> newList, string filterValue)
        {
            try
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == filterValue);
                var update = Builders<Workstations>.Update.Set(fieldToUpdate, newList);
                workstationsCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji Workstations <Apps>. Treść błędu: /n /n" + ex);
            }
        }
        /// <summary>
        /// Updates one Black List of BlackList collection
        /// </summary>
        /// <param name="newBlackList">Updated black list</param>
        /// <param name="listToUpdate">List you wish to update Websites or Apps</param>
        public void UpdateOneBlackList(List<string> newBlackList, string listToUpdate) 
        {
            try
            {
                RefreshBlackList();
                var filter = Builders<BlackList>.Filter.Empty;
                var update = Builders<BlackList>.Update.Set(listToUpdate, newBlackList);
                blackListCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji <BlackList>. Treść błędu: /n /n" + ex);
            }
        }
        /// <summary>
        /// Check if document with current workstation name and user name already exists in database.
        /// </summary>
        /// <param name="workstationName">Workstation name</param>
        /// <param name="userName">User name</param>
        /// <returns>True if document exists, else False.</returns>
        public bool CheckIfExsists(string workstationName, string userName)
        {
            int query = 0;
            try
            {
                RefreshWorkstations();
                query =
                    workstationsCollection.AsQueryable()
                    .Count(w => w.WorkstationName == workstationName && w.UserName == userName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania informacji <Workstations> z bazy danych. Treść błędu: /n /n" + ex);
            }
            if (query > 0) return true;
            return false;
        }

        /// <summary>
        /// Check if document with current workstation name already exists in database.
        /// </summary>
        /// <param name="workstationName">Workstation name</param>
        /// <returns>True if document exists, else False.</returns>
        public bool CheckIfExsists(string workstationName)
        {
            int query = 0;
            try
            {
                RefreshWorkstations();
                query =
                workstationsCollection.AsQueryable()
                .Count(w => w.WorkstationName == workstationName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania informacji <Workstations> z bazy danych. Treść błędu: /n /n" + ex);
            }
            if (query > 0) return true;
            return false;
        }
        /// <summary>
        /// Checks if there is any Black list in BlackList collection
        /// </summary>
        /// <returns>Returns true if exists and false if not</returns>
        public bool CheckIfExsistsBlackList()
        {
            int query = 0;
            try
            {
                RefreshBlackList();
                query =
                    blackListCollection.AsQueryable()
                    .Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania informacji <BlackList> z bazy danych. Treść błędu: /n /n" + ex);
            }
            if (query > 0) return true;
                return false;   
        }

        /// <summary>
        /// Getting list of alerts for current workstation.
        /// </summary>
        /// <returns>Return list of alerts.</returns>
        public List<Alerts> GetWorkstationAlertList() //returns true if exists and false if it's not
        {
            IQueryable<List<Alerts>> query = null;
            try
            {
                RefreshWorkstations();
                query = from e in workstationsCollection.AsQueryable()
                        where e.WorkstationName == StationInformation.WorkstationName
                        select e.Alerts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas povierania informacji <Workstations> z bazy danych. Treść błędu: /n /n" + ex);
            }
            List<Alerts> temp = new List<Alerts>();
            if(query != null)
                foreach (var l in query)
                    temp = l;
            return temp;

        }
        /// <summary>
        /// Clearing list of alerts for current workstation.
        /// </summary>
        public void ClearAlertsList()
        {
            try
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == StationInformation.WorkstationName);
                var update = Builders<Workstations>.Update.Set("Alerts", new List<Alerts>());
                workstationsCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji informacji <Workstations><Alerts> w basie danych. Treść błędu: /n /n" + ex);
            }
        }

        /// <summary>
        /// Clearing list of apps for current workstations.
        /// </summary>
        public void ClearAppList()
        {
            try
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Where(w => w.WorkstationName == StationInformation.WorkstationName);
                var update = Builders<Workstations>.Update.Set("Apps", new List<string>());
                workstationsCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas aktualizacji informacji <Workstations><Apps> w basie danych. Treść błędu: /n /n" + ex);
            }
        }
        /// <summary>
        /// Used to send image to gridFS of database
        /// </summary>
        /// <param name="img">image source</param>
        /// <param name="name">name of the file</param>
        /// <returns>Id pointing to a new img</returns>
        public ObjectId SendImage(Image img, string name)
        {
            var bytes = ImageToBytes(img);
            var bucket = new GridFSBucket(db);
            ObjectId id = bucket.UploadFromBytes(name, bytes);
            return id;
        }
        /// <summary>
        /// Used to download image from Alerts collection
        /// </summary>
        /// <param name="alert">Single alert field</param>
        /// <param name="imgId">Id of downloading image</param>
        /// <param name="number">ordinal number, must be unique</param>
        /// <returns></returns>
        public string DownloadImage(Alerts alert, ObjectId imgId, int number)
        {
            var bucket = new GridFSBucket(db);
            var bytes = bucket.DownloadAsBytes(imgId);
            var image = BytesToImage(bytes);
           
            string path = alert.StudentFirstAndLastName+"\\"+alert.AlertName;
            //If Directory does not exists then...
            if(!(Directory.Exists(path))) Directory.CreateDirectory(path);
            string cleanString = Regex.Replace(alert.AddDate, @"[^0-9]", "_");
            string fileName = cleanString + "_"+number+".jpg";
            path = System.IO.Path.Combine(path, fileName);
            Bitmap b = new Bitmap(image);
            b.Save(path);
            return path;

        }
        /// <summary>
        /// Used to convert Image type to bytes
        /// </summary>
        /// <param name="x">variable which contains image</param>
        /// <returns>array of bytes</returns>
        public static byte[] ImageToBytes(Image imageIn)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }
        /// <summary>
        /// Used to convert bytes to Image type
        /// </summary>
        /// <param name="bytes">bytes containing Image</param>
        /// <returns>instance of Image type</returns>
        public static Image BytesToImage(byte[] bytes)
        {
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
            return x;
        }
        /// <summary>
        /// Deletes one filed form Workstation or Black List collection
        /// </summary>
        /// <param name="filteredField">spcifies which field in database is going to be filtered</param>
        /// <param name="value">value of the field we wish to delete</param>
        /// <param name="collection">collection from where value is going to be deleted</param>
        public void DeleteOne(string filteredField, string value, int collection)
        {
            //in case of 0(Workstations) then...
            if (collection == 0)
            {
                RefreshWorkstations();
                var filter = Builders<Workstations>.Filter.Eq(filteredField, ObjectId.Parse(value));
                var list = workstationsCollection.Find(filter).ToList();
                IGridFSBucket bucket = new GridFSBucket(db); ;
                foreach (var l in list)
                {
                    foreach(var a in l.Alerts)
                    {
                        bucket.Delete(a.Link1);
                        bucket.Delete(a.Link2);
                        bucket.Delete(a.Link3);
                        
                    }
                }
                workstationsCollection.DeleteOne(filter);

            }
            //in case of 1(Black List) then...
            else if (collection == 1)
            {
                var filter = Builders<BlackList>.Filter.Eq(filteredField, value);
                blackListCollection.DeleteOne(filter);
            }
        }
    }
}