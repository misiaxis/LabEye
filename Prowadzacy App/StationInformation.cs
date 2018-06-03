using System;
using System.Net;
using System.Net.Sockets;

namespace Prowadzacy_App
{
    /// <summary>
    /// Interaction logic for StationInformation.cs
    /// Store information about acutally running agent.
    /// </summary>
    class StationInformation
    {
        //Basic informations about user
        static public string StudentFirstAndLastName = "";
        static public string WorkstationName = "";
        static public string HostName = Dns.GetHostName();
        static public string studentId = "";
        static public string IpAdress = GetLocalIPAddress();
        static public string Username = Environment.UserName;

        //Database connection informations
        static public IPAddress DataBaseAddress = null;

        //Configuration file
        static public string ConfigurationFilePath = "Workstation.cfg";

        //Application logic variables
        static public string AdminPassword = "0000";
        static public bool isLocked = true; //is locked by admin

        //Setting domain informations
        static public string DomainName = "put.poznan.pl";

        /// <summary>
        /// Method to check local IP address.
        /// </summary>
        /// <returns>Local IP address</returns>
        private static string GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

    }

}
