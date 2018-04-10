using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEyeDB
{

    class Program
    {
        static void Main(string[] args)
        {
            DbManager manager = new DbManager();

            List<string> list1 = new List<string>();
            list1.Add("alert 1");
            list1.Add("alert 2");
            List<string> list2 = new List<string>();
            list2.Add("app 1");
            list2.Add("app 2");
            //manager.MakeNew("Workstation", "First Last Name", "StudentID", "HostName", "IPadrr", "username", list1, list2);
            Console.WriteLine(manager.DeleteMany("WorkstationName", "Workstation"));
            //manager.MakeNew("Workstation3", "First Last Name", "StudentID", "HostName", "IPadrr", "username", list1, list2);
            //manager.MakeNew("Workstation2", "First Last Name2", "StudentID", "HostName", "IPadrr", "username", list1, list2);
           // manager.ShowDB();
            
        }
    }
}
