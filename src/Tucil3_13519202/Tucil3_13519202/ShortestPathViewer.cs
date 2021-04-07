using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tucil3_13519202
{
    public partial class ShortestPathViewer : Form
    {
        public ShortestPathViewer()
        {
            InitializeComponent();
        }

        private void ShortestPathViewer_Load(object sender, EventArgs e)
        {
            ListBox mylist = new ListBox();
            mylist.Location = new Point(28, 55);
            mylist.Size = new Size(101, 64);
            mylist.BorderStyle = BorderStyle.Fixed3D;
            for (int i = 0; i < Global.Map.getLocationList().Count; i++)
            {
                mylist.Items.Add(Global.Map.getLocationList()[i].getLocationName());
            }
            this.Controls.Add(mylist);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstLocation = textBoxLoc1.Text;
            string destination = textBoxLoc2.Text;
            label5.Text = "";

            foreach (string a in Global.Locations)
            {
                Global.Graph.FindNode(a).Attr.Color = Microsoft.Msagl.Drawing.Color.CadetBlue;
            }
            //bind the graph to the viewer 
            Global.Viewer.Graph = Global.Graph;
            //associate the viewer with the form 
            Global.Viewer.Dock = System.Windows.Forms.DockStyle.Fill;

            if (Global.Locations.Contains(firstLocation) && Global.Locations.Contains(destination))
            {
                
                Global.Map.ExplorewithAStarGUI(firstLocation, destination, label5);
                groupBoxPath.Controls.Add(Global.Viewer);
            }
            else
            {
                label5.Text += "Maaf, anda memasukkan input yang tidak terdaftar";
            }
        }
    }
}
