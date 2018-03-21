using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    //StationInformation is class created for storing information like for example: Fist and Last name of logged student, IP addres, Host Name etc

    class StationInformation
    {
        static public string StudentFirstAndLastName = "";
        static public string HostName = Dns.GetHostName();
        static public string IpAdress = Dns.GetHostAddresses(HostName)[1].ToString();
        static public string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        static public IPAddress DataBaseAddress = null;
        static public string ConfigurationFilePath = "Workstation.configuration";
    }
}
