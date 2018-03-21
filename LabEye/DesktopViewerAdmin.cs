using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.ComponentModel;
using System.IO;

namespace LabEye
{
    class DesktopViewerAdmin
    {
        private TcpClient shareclient;
        private NetworkStream mainstream;
        ScreenShare desktopViewWindow = new ScreenShare(); 
        // need to create new wpf form NAME: ScreenShare 
        // <Image Name="ScreenSharing" HorizontalAlignment="Stretch" VerticalAlignment="Stretch"/>
        // i will try to make it in code
        private string userIP;

        public DesktopViewerAdmin()
        {
            userIP = "192.168.0.23";
            desktopViewWindow.Show();
            Thread user = new Thread(SendRequestToUser);
            user.IsBackground = true;
            user.Start();
        }

        private void SendRequestToUser()
        {
            try
            {
                
                shareclient = new TcpClient();
                shareclient.Connect(new IPEndPoint(IPAddress.Parse(userIP), 5555));
                while (shareclient.Connected)
                {
                    StartGettingImage();
                }
            }
            catch
            {
                //error connection lost or unable to connect
            }
        }
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        private void StartGettingImage()
        {
            try
            {
                while (shareclient.Connected)
                {
                    BinaryFormatter binformat = new BinaryFormatter();
                    mainstream = shareclient.GetStream();
                        desktopViewWindow.Dispatcher.Invoke(() =>
                        {
                            desktopViewWindow.ScreenSharing.Source = BitmapToImageSource((Bitmap)binformat.Deserialize(mainstream));
                        });
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                //connection lost or stream end
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
    }
}
