using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prowadzacy_App
{
    public partial class ScreenViewer : Form
    {
        private TcpClient shareclient;
        private NetworkStream mainstream;
        private string UserIP;
        private int UserPORT;

        public ScreenViewer(string IP, int Port)
        {
            InitializeComponent();
            UserIP = IP;
            UserPORT = Port;
            Thread user = new Thread(SendRequestToUser);
            user.IsBackground = true;
            user.Start();
        }
        private void SendRequestToUser()
        {
            try
            {
                shareclient = new TcpClient();
                shareclient.Connect(new IPEndPoint(IPAddress.Parse(UserIP), UserPORT));
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
        private void StartGettingImage()
        {
            try
            {
                while (shareclient.Connected)
                {
                    BinaryFormatter binformat = new BinaryFormatter();
                    mainstream = shareclient.GetStream();
                    ScreenViewer_image.Image = (Bitmap)binformat.Deserialize(mainstream);
                    Thread.Sleep(1000);
                }
            }
            catch
            { 
                //connection lost or stream end
            }
        }
    }

}
