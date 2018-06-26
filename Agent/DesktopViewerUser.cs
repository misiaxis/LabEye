using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows;

namespace Agent
{
    class DesktopViewerUser
    {
        private int localPORT; // port to listen
        private TcpClient shareclient; // administrator who asks for screenshots (view)
        private NetworkStream mainstream; // stream to screenshots

        public DesktopViewerUser(int PORT)
        {
            localPORT = PORT;
        }
        //This server keep on waiting for admin to ask permission to start sending screenshots.
        public void StartServer()
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), localPORT);
                listener.Start();
                while (true)
                {
                    Console.WriteLine("dzialam w tle, oczekuje na polaczenie");
                    shareclient = listener.AcceptTcpClient();
                    while (shareclient.Connected)
                    {
                        SendScreenshot();
                        Thread.Sleep(1000);
                    }
                }
            }
            catch
            {
                //error with server
            }
        }
        private string GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
        /// <summary>
        /// Used to make screen shot 
        /// </summary>
        /// <returns>screen shot as a Bitmap object</returns>
        private Bitmap GetDesktopScreenshot()
        {
            double screenLeft = SystemParameters.VirtualScreenLeft;
            double screenTop = SystemParameters.VirtualScreenTop;
            double screenWidth = SystemParameters.VirtualScreenWidth;
            double screenHeight = SystemParameters.VirtualScreenHeight;
            Bitmap screenshot = new Bitmap((int)screenWidth, (int)screenHeight, PixelFormat.Format32bppArgb);
            Graphics graph = Graphics.FromImage(screenshot);
            graph.CopyFromScreen((int)screenLeft,(int)screenTop,0,0,screenshot.Size);
            return screenshot;
        }
        private void SendScreenshot()
        {
            try
            {
                BinaryFormatter binformat = new BinaryFormatter();
                mainstream = shareclient.GetStream();
                binformat.Serialize(mainstream, GetDesktopScreenshot());
            }
            catch
            {
                //connection lost
            }
        }
    }
}
