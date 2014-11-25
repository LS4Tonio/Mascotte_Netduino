using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mascotte_Serveur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NetDevices nd = new NetDevices();

            // Get my PC IP address
            this.ipandmacaddresses.Text += String.Format("\nMy IP : {0}\n", nd.GetIPAddress());
            // Get My PC MAC address
            this.ipandmacaddresses.Text += String.Format("My MAC: {0}\n", nd.GetMacAddress());
            // Get all devices on network
            Dictionary<IPAddress, PhysicalAddress> all = nd.GetAllDevicesOnLAN();

            foreach (KeyValuePair<IPAddress, PhysicalAddress> kvp in all)
            {
                this.ipandmacaddresses.Text += String.Format("IP : {0} --- MAC : {1}\n", kvp.Key, kvp.Value);
            }

            byte[] macAddress = new byte[]{Byte.Parse("5C"), Byte.Parse("86"), Byte.Parse("4A"), Byte.Parse("00"), Byte.Parse("E7"), Byte.Parse("28")};
            KeyValuePair<IPAddress, PhysicalAddress> netduino = all.Single<KeyValuePair<IPAddress, PhysicalAddress>>(x => x.Value.Equals(macAddress));
            this.ipandmacaddresses.Text += String.Format("Netduino : IP : {0}\n", netduino.Key);
        }
    }
}
