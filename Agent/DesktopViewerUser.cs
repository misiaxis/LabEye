using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Threading;

namespace Agent
{
    class DesktopViewerUser
    {
        private int localPORT; // port to listen
        private TcpClient shareclient; // administrator who asks for screenshots (view)
        private NetworkStream mainstream; // stream to screenshots

        public DesktopViewerUser(int PORT)
        {
            this.localPORT = PORT;
            Thread serwer = new Thread(StartServer);
            serwer.IsBackground = true;
            serwer.Start();
        }
        //This server keep on waiting for admin to ask permission to start sending screenshots.
        private void StartServer()
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), localPORT);
                listener.Start();
                while (true)
                {
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
