using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Threading;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace PM2._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
            //map setup
            map.MapProvider = GMapProviders.GoogleMap;
            map.DragButton = MouseButtons.Left;
            //map.MapProvider = GMapProviders.BingMap;
            map.ShowCenter = false;
            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 15;
            map.Position = new PointLatLng(23.703108, 120.430151); //初始地圖
            */
            //webBrowser show google map javascript
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            Key.SetValue(appName, 99999, RegistryValueKind.DWord);
            webBrowser1.Url = new Uri("http://140.130.20.168/googlemap/mapdata6.html");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Mainloop()
        {
            DateTime Repload = DateTime.Now;

            while (true)
            {
                if (Repload.AddSeconds(1) <= DateTime.Now)
                {
                    string dbHost = "140.130.20.168";   //資料庫位址
                    string dbUser = "gpspm2.5";         //資料庫使用者帳號
                    string dbPass = "gpspm2.5";         //資料庫使用者密碼
                    string dbName = "gpspm25";          //資料庫名稱

                    string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
                    MySqlConnection conn = new MySqlConnection(connStr);

                    // 進行select
                    string SQL = "select * from test1 order by id desc limit 0,1 ";

                    if (Repload.AddSeconds(1) < DateTime.Now)
                    {
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(SQL, conn);
                            MySqlDataReader myData = cmd.ExecuteReader();

                            while (myData.Read())
                            {
                                this.Invoke(new Action(delegate ()
                                {
                                    //Information
                                    label_lng.Text = myData.GetString(2);
                                    label_lat.Text = myData.GetString(3);
                                    //label_alt.Text = myData.GetString(4);

                                    //Map
                                    /*
                                    double position_lng = Convert.ToDouble(label_lng.Text);
                                    double position_lat = Convert.ToDouble(label_lat.Text);
                                    PointLatLng point = new PointLatLng(position_lng, position_lat);
                                    GMapMarker marker = new GMarkerGoogle((point), GMarkerGoogleType.green);
                                    GMapOverlay markers = new GMapOverlay("markers");
                                    markers.Markers.Add(marker);
                                    map.Overlays.Add(markers);
                                    */
                                }
                                ));
                            }
                        }
                        //myData.Close();
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Error " + ex.Number + " : " + ex.Message);
                        }
                    }
                    Repload = DateTime.Now;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread a = new Thread(new ThreadStart (Mainloop));
            a.IsBackground = true;
            a.Start();
        }
    }
}
