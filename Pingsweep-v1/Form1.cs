using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Pingsweep_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView(); // Initialize ListView columns

            // Get the local IP and display it in the Label
            string localIP = GetLocalIP();
            textBox1.Text = "Local IP Address: " + localIP; // Assuming 'labelLocalIP' is the name of the Label control
        }

        // Create a ListViewItem with IP address, hostname, ping response time, and shared folders count
        private ListViewItem CreateListViewItem(string ip, string hostName, string osInfo, long pingTime, int sharedFoldersCount, int[] openPorts)
        {
            ListViewItem item = new ListViewItem(ip);
            item.Tag = ip; // Store IP address as tag for context menu
            item.SubItems.Add(hostName);
            return item;
        }

        // Initialize ListView columns
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("IP Address", 100);
            listView1.Columns.Add("Hostname", 180);
        }

        // Get the local IP address of the machine
        private string GetLocalIP()
        {
            string localIP = string.Empty;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {
                        // Check for IPv4 addresses (ignore IPv6)
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            localIP = ip.Address.ToString();
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(localIP))
                    break;
            }
            return localIP;
        }
        // Define the event handler method
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Add your logic here
            // For example, if you want to update a label or perform an action when the text changes in the TextBox
            string text = textBox1.Text; // Get the text from textBox1
                                         // Perform some action with the text, like filtering a list, etc.
            Console.WriteLine("Text changed: " + text);
        }

    }
}
