using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tucil3_13519202
{
    public partial class MapViewer : Form
    {
        public MapViewer()
        {
            InitializeComponent();
        }


        private void buttonMapViewer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f3 = new ShortestPathViewer();
            f3.ShowDialog();
        }
    }
}
