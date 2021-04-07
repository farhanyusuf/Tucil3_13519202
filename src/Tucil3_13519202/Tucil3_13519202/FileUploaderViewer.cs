using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tucil3_13519202
{
    public partial class FileUploaderViewer : Form
    {
        public FileUploaderViewer()
        {
            InitializeComponent();
        }

        private void buttonFileUpload_Click(object sender, EventArgs e)
        {
            openFileDialogUpload.ShowDialog();
            string filename = openFileDialogUpload.FileName;
            this.Hide();
            Form f2 = new MapViewer();

            Global.Map = new Map();
            Global.Viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Global.Graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Global.Locations = new List<string>();

            // buat graf MSAGL - baca graf dari txt
            Global.Map.readTXT(filename, Global.Graph);

            // simpan variabel global account - variabel ini untuk memudahkan // set warna nodes ehe
            foreach (Lokasi a in Global.Map.getLocationList())
            {
                Global.Locations.Add(a.getLocationName());
                //Global.Graph.FindNode(a.getLocationName()).Attr.Color = Microsoft.Msagl.Drawing.Color.CadetBlue;
            }
            Global.Viewer.Graph = Global.Graph;
            f2.SuspendLayout();
            Global.Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            foreach (Control c in f2.Controls)
            {
                if (c.Name == "buatmsagl")
                {
                    c.Controls.Add(Global.Viewer);
                }
            }
            f2.ResumeLayout();
            f2.ShowDialog();
        }

 
    }
}
