using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pingsweep_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView(); // Initialize ListView columns
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


    }
}
