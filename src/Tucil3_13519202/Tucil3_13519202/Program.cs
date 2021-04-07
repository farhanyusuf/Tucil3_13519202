using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tucil3_13519202
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileUploaderViewer());
        }
    }
    public static class Global
    {
        public static Map Map;
        public static Microsoft.Msagl.GraphViewerGdi.GViewer Viewer;
        public static Microsoft.Msagl.Drawing.Graph Graph;
        public static List<string> Locations;
    }

    public class Lokasi
    {
        private string locationName;
        private List<KeyValuePair<string, double>> neighbour;
        private double latitude;
        private double longitude;
        private bool visited;

        public Lokasi(string name, double lati, double longi)
        {
            this.locationName = name;
            this.neighbour = new List<KeyValuePair<string, double>>();
            this.latitude = lati;
            this.longitude = longi;
            this.visited = false;
        }

        //getter
        public string getLocationName()
        {
            return this.locationName;
        }

        public List<KeyValuePair<string, double>> getNeighbour()
        {
            return this.neighbour;
        }

        public double getLatitude()
        {
            return this.latitude;
        }

        public double getLongitude()
        {
            return this.longitude;
        }

        public bool getVisited()
        {
            return this.visited;
        }

        //setter
        public void setLocationName(string name)
        {
            this.locationName = name;
        }

        public void setLatitude(double lat)
        {
            this.latitude = lat;
        }

        public void setLongitude(double longi)
        {
            this.longitude = longi;
        }

        public void setVisited(bool trufalse)
        {
            this.visited = trufalse;
        }

        public void addNeighbour(string name, double distance)
        {
            List<string> allKeys = (from kvp in neighbour select kvp.Key).Distinct().ToList();
            if (!allKeys.Contains(name))
            {
                neighbour.Add(new KeyValuePair<string, double>(name, distance));
            }
        }
        public bool isLocationNameEqual(string name)
        {
            return locationName.Equals(name);
        }

    }


    public class Map
    {
        private List<Lokasi> locationList;

        public Map()
        {
            locationList = new List<Lokasi>();
        }

        //getter

        public List<Lokasi> getLocationList()
        {
            return this.locationList;
        }

        public void addLocation(string name, double lati, double longi)
        {
            Lokasi a = new Lokasi(name, lati, longi);
            locationList.Add(a);
        }

        public int getIndexLocation(string name)
        {
            int iterator = 0;
            while (iterator < this.locationList.Count)
            {
                if (this.locationList[iterator].getLocationName().Equals(name))
                {
                    break;
                }
                else
                {
                    iterator++;
                }
            }
            if (iterator < this.locationList.Count)
            {
                return iterator;
            }
            else
            {
                return -1;
            }
        }


        public void addNeighbourMap(int index, string name, double distance)
        {
            this.locationList[index].addNeighbour(name, distance);
        }

        public void readTXT(string path, Microsoft.Msagl.Drawing.Graph Graph)
        {
            string[] lines = System.IO.File.ReadAllLines(@path);
            // baca berapa banyak pasangan
            int i = 0;
            int j = 0;
            int idx = 0;
            bool matriks = false;
            i++; //baris pertama hanya berisi "Position"
            while (i < lines.Length)
            {

                string word = "";
                string lati = "";
                string longi = "";
                j = 0;
                while (j < lines[i].Length && !lines[i][j].Equals(' '))
                {
                    word = word + lines[i][j];
                    j++;
                }
                j++;
                if (word.Equals("Matriks"))
                {
                    i++;
                    matriks = true;
                }
                if (matriks) {
                    j = 0;
                    int idy = 0;
                    string d = "";
                    while (j < lines[i].Length)
                    {
                        if (lines[i][j] == ' ')
                        {
                            if (d.Equals("0,0"))
                            {
                                d = "";
                                j++;
                                idy++;
                            }
                            else
                            {
                                double distance = Convert.ToDouble(d);
                                addNeighbourMap(idx, locationList[idy].getLocationName(), distance);
                                var Edge = Graph.AddEdge(this.locationList[idx].getLocationName(), this.locationList[idy].getLocationName());
                                Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                                Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                                
                                d = "";
                                j++;
                                idy++;
                            }

                        }
                        else
                        {
                            d = d + lines[i][j];
                            j++;
                        }
                    }
                    idx++;
                    i++;
                }
                else
                {
                    while (!lines[i][j].Equals(' '))
                    {
                        lati = lati + lines[i][j];
                        j++;
                    }
                    j++;
                    while (j < lines[i].Length)
                    {
                        longi = longi + lines[i][j];
                        j++;
                    }
                    double latitude = Convert.ToDouble(lati);
                    double longitude = Convert.ToDouble(longi);
                    addLocation(word, latitude, longitude);
                    i++;
                }

            }
        }
        public double haversineFormula(Lokasi A, Lokasi B)
        {
            double latA = A.getLatitude();
            double lonA = A.getLongitude();
            double latB = B.getLatitude();
            double lonB = B.getLongitude();

            double earthRadius = 6371;
            var lat = (latB - latA) * Math.PI / 180;
            var lng = (lonB - lonA) * Math.PI / 180;
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(latA * Math.PI / 180) * Math.Cos(latB * Math.PI / 180) *
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return earthRadius * h2;
        }

        public List<KeyValuePair<string, double>> ExplorewithAStar(string firstlocation, string destination)
        {

            List<KeyValuePair<string, double>> pathlist = new List<KeyValuePair<string, double>>();
            bool found = false;
           // while (found != true)
            //{
                int idx = getIndexLocation(firstlocation);
                List<KeyValuePair<string, double>> neighbour = this.locationList[idx].getNeighbour();
                List<string> allKeys = (from kvp in neighbour select kvp.Key).Distinct().ToList();
                List<double> distance = new List<double>();
                foreach (string key in allKeys)
                {
                    List<double> values = (from kvp in neighbour where kvp.Key == key select kvp.Value).ToList();
                    distance.Add(values[0]);
                }
                List<double> realdistance = new List<double>();
                foreach (double d in distance)
                {
                    List<string> keys = (from kvp in neighbour where kvp.Value == d select kvp.Key).ToList();
                    int idx2 = getIndexLocation(keys[0]);
                    double real_d = d + haversineFormula(locationList[idx], locationList[idx2]);
                    realdistance.Add(real_d);
                }
                double min = realdistance.Min();
                int idx3 = realdistance.IndexOf(min);
                List<string> keyofmin = (from kvp in neighbour where kvp.Value == distance[idx3] select kvp.Key).ToList();
                int idx4 = getIndexLocation(keyofmin[0]);
                /*while (this.locationList[idx4].getVisited() == true && realdistance != null) {
                    realdistance.Remove(realdistance.Min());
                    double min2 = realdistance.Min();
                    realdistance.IndexOf(min2);
                    int idx5 = realdistance.IndexOf(min2);
                    if (idx5 >= idx3) {
                        idx5 -= 1;
                    }
                    keyofmin = (from kvp in neighbour where kvp.Value == distance[idx5] select kvp.Key).ToList();
                    idx4 = getIndexLocation(keyofmin[0]);
                }
                this.locationList[idx4].setVisited(true);*/
                pathlist.Add(new KeyValuePair<string, double>(keyofmin[0], min));
                /*if (!keyofmin.Equals(destination))
                {
                    firstlocation = keyofmin[0];
                }
                else
                {
                    found = true;
                }*/
            //}
            return pathlist;
        }

        public void ExplorewithAStarGUI(string firstlocation, string destination, Label text)
        {
            // METHOD INI AKAN MEMANGGIL 
            List<KeyValuePair<string, double>> hasil = new List<KeyValuePair<string, double>>();
            hasil = ExplorewithAStar(firstlocation, destination);
            // warnai dulu msagl-nya
            Global.Graph.FindNode(firstlocation).Attr.Color = Microsoft.Msagl.Drawing.Color.Coral;
            Global.Graph.FindNode(destination).Attr.Color = Microsoft.Msagl.Drawing.Color.Coral;
            // salin isi
            List<string> allKeys = (from kvp in hasil select kvp.Key).Distinct().ToList();
            int i;
            for (i = 0; i < allKeys.Count - 1; i++)
            {
                text.Text += allKeys[i] + "->";
                Global.Graph.FindNode(allKeys[i]).Attr.Color = Microsoft.Msagl.Drawing.Color.Coral;
            }
        }
    }
}
