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
using System.Threading.Tasks;
using MySql.Data;
using System.Data.SqlClient;
using System.Collections;

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
                    conn.Open();
                    
                    //進行select
                    string SQL = "select * from " +dbSelect.Text+ " WHERE PM IS NOT NULL order by id desc limit 0,1 ";  //資料庫名稱

                    if (Repload.AddSeconds(1) < DateTime.Now)
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand(SQL, conn);
                            MySqlDataReader myData = cmd.ExecuteReader();
                            while (myData.Read())
                            {
                                {
                                    this.Invoke(new Action(delegate ()
                                    {
                                        //Information
                                        label_lat.Text = myData.GetString(2);
                                        label_lng.Text = myData.GetString(3);
                                        label_pm.Text = myData.GetString(4);
                                        //label_alt.Text = myData.GetString(5);

                                        //Map
                                        var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
                                        using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                                        Key.SetValue(appName, 99999, RegistryValueKind.DWord);
                                        webBrowser1.Url = new Uri("http://140.130.20.168/googlemap/" + htmlSelect.Text + ".html");
                                    }
                                    ));
                                    
                                }
                            }
                            myData.Close();
                        }
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
            
            Thread b = new Thread(new ThreadStart(Data_Main));
            b.IsBackground = true;
            b.Start();
        }
        private void Data_Main()
        {
            int loop = 1;
            while (loop < 10)
            {
             angle();
             Thread.Sleep(500);
            }
        }
        private void angle()
        {
            string dbHost = "140.130.20.168";   //資料庫位址
            string dbUser = "gpspm2.5";         //資料庫使用者名稱
            string dbPass = "gpspm2.5";         //資料庫使用者密碼
            string dbName = "gpspm25";          //資料庫名稱          // 如果有特殊的編碼在database後面請加上;CharSet=編碼, utf8請使用utf8_general_ci

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            MySqlConnection conn = new MySqlConnection(connStr);
            // 連線到資料庫
            conn.Open();
            //計算有幾筆資料
            string SQL1 = "select count(*) from " +dbSelect.Text+ " WHERE PM IS NOT NULL";  //資料庫名稱
            MySqlCommand cmd1 = new MySqlCommand(SQL1, conn);
            int count = (int)(long)cmd1.ExecuteScalar();
            Console.WriteLine("count " + count);
            // 進行select
            int a = 0;
            int i = 0;
            double length = 0;
            double length1 = 0;
            double i_length = 0;
            double Yaxis = 0;
            double Xaxis = 0;
            double Tan = 0;
            double[] latvalue = new double[count];
            double[] lngvalue = new double[count];
            double[] pmvalue = new double[count];
            for (a = 0; a < count; a++)
            {
                string SQL = "select* from " +dbSelect.Text+ " WHERE PM IS NOT NULL order by id desc limit "+a+",1 ";   //資料庫名稱
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader myData = cmd.ExecuteReader();
                if (!myData.HasRows)
                {
                    // 如果沒有資料,顯示沒有資料的訊息
                    Console.WriteLine("No data.");
                }
                else
                {
                    // 讀取資料並且顯示出來
                    while (myData.Read())
                    {
                        if (a > 0 && a < count)
                        {
                            //放入矩陣
                            i++;
                            latvalue[i] = myData.GetDouble(2);
                            lngvalue[i] = myData.GetDouble(3);
                            pmvalue[i] = myData.GetDouble(4);
                            //前3點的合向量
                            if (3 == i)
                            {
                                double yaxis = Math.Round(latvalue[3] - latvalue[2], 6); //第3點和第2點的緯度分量
                                double xaxis = Math.Round(lngvalue[3] - lngvalue[2], 6); //經度分量
                                if (latvalue[3] == latvalue[2])
                                {
                                    yaxis = 0;
                                }
                                if (lngvalue[3] == lngvalue[2])
                                {
                                    xaxis = 0;
                                }
                                double tan = Math.Atan(yaxis / xaxis) * (180 / Math.PI);//兩點的角度
                                if (xaxis == 0)
                                {
                                    tan = 90;
                                }
                                if (yaxis == 0)
                                {
                                    tan = 0;
                                }
                                //用PM2.5判斷向量方向
                                if (yaxis > 0 && xaxis > 0)
                                {
                                    if (pmvalue[3] < pmvalue[2])
                                    {
                                        tan = tan + 180;
                                    }
                                }
                                if (yaxis < 0 && xaxis < 0)
                                {
                                    if (pmvalue[3] > pmvalue[2])
                                    {
                                        tan = tan + 180;
                                    }
                                }
                                if (yaxis < 0 && xaxis > 0)
                                {
                                    if (pmvalue[3] < pmvalue[2])
                                    {
                                        tan = tan + 180;
                                    }
                                }
                                if (yaxis > 0 && xaxis < 0)
                                {
                                    if (pmvalue[3] > pmvalue[2])
                                    {
                                        tan = tan + 180;
                                    }
                                }
                                //轉大地座標
                                if (0 < tan && tan < 90)
                                {
                                    tan = (90 - tan) * (Math.PI / 180);
                                    goto pm_length;
                                }
                                if (90 < tan && tan < 180)
                                {
                                    tan = -(tan - 90) * (Math.PI / 180);
                                    goto pm_length;
                                }
                                if (180 < tan && tan < 270)
                                {
                                    tan = (270 - (tan - 180)) * (Math.PI / 180);
                                    goto pm_length;
                                }
                                if (tan < 0 && -90 < tan)
                                {
                                    tan = (90 - (tan)) * (Math.PI / 180);
                                    goto pm_length;
                                }
                                pm_length:
                                //2點PM2.5的差
                                if (pmvalue[3] != pmvalue[2])
                                {
                                    if (pmvalue[3] > pmvalue[2])
                                    {
                                        length = (pmvalue[3] - pmvalue[2]) / 1.84;
                                    }
                                    if (pmvalue[3] > pmvalue[2])
                                    {
                                        length = (pmvalue[3] - pmvalue[2]) / 1.84;
                                    }
                                }
                                if (pmvalue[3] == pmvalue[2])
                                {
                                    length = 0;
                                }

                                double sin = length * Math.Sin(tan);//PM2.5的X分量
                                double cos = length * Math.Cos(tan);
                                if (length == 0)
                                {
                                    sin = 0;
                                    cos = 0;
                                }
                                double yaxis1 = Math.Round(latvalue[2] - latvalue[1], 6);//第2和第1點的緯度分量
                                double xaxis1 = Math.Round(lngvalue[2] - lngvalue[1], 6);//經度分量
                                if (latvalue[2] == latvalue[1])
                                {
                                    yaxis1 = 0;
                                }
                                if (lngvalue[2] == lngvalue[1])
                                {
                                    xaxis1 = 0;
                                }
                                double tan1 = Math.Atan(yaxis1 / xaxis1) * (180 / Math.PI);
                                if (xaxis1 == 0)
                                {
                                    tan1 = 90;
                                }
                                if (yaxis1 == 0)
                                {
                                    tan1 = 0;
                                }
                                if (yaxis1 > 0 && xaxis1 > 0)
                                {
                                    if (pmvalue[2] < pmvalue[1])
                                    {
                                        tan1 = tan1 + 180;
                                    }
                                }
                                if (yaxis1 < 0 && xaxis1 < 0)
                                {
                                    if (pmvalue[2] > pmvalue[1])
                                    {
                                        tan1 = tan1 + 180;
                                    }
                                }
                                if (yaxis1 < 0 && xaxis1 > 0)
                                {
                                    if (pmvalue[2] < pmvalue[1])
                                    {
                                        tan1 = tan1 + 180;
                                    }
                                }
                                if (yaxis1 > 0 && xaxis1 < 0)
                                {
                                    if (pmvalue[2] > pmvalue[1])
                                    {
                                        tan1 = tan1 + 180;
                                    }
                                }
                                //轉大地座標
                                if (0 < tan1 && tan1 < 90)
                                {
                                    tan1 = (90 - tan1) * (Math.PI / 180);
                                    goto pm_length1;
                                }
                                if (90 < tan1 && tan1 < 180)
                                {
                                    tan1 = -(tan1 - 90) * (Math.PI / 180);
                                    goto pm_length1;
                                }
                                if (180 < tan1 && tan1 < 270)
                                {
                                    tan1 = (270 - (tan1 - 180)) * (Math.PI / 180);
                                    goto pm_length1;
                                }
                                if (tan1 < 0 && -90 < tan1)
                                {
                                    tan1 = (90 - (tan1)) * (Math.PI / 180);
                                    goto pm_length1;
                                }
                                pm_length1:
                                if (pmvalue[2] != pmvalue[1])
                                {
                                    if (pmvalue[2] > pmvalue[1])
                                    {
                                        length1 = (pmvalue[2] - pmvalue[1]) / 1.84;
                                    }
                                    if (pmvalue[1] > pmvalue[2])
                                    {
                                        length1 = (pmvalue[1] - pmvalue[2]) / 1.84;
                                    }
                                }
                                if (pmvalue[2] == pmvalue[1])
                                {
                                    length1 = 0;
                                }
                                double sin1 = length1 * Math.Sin(tan1);
                                double cos1 = length1 * Math.Cos(tan1);
                                if (length1 == 0)
                                {
                                    sin1 = 0;
                                    cos1 = 0;
                                }
                                Yaxis = sin + sin1;//PM2.5的Y分量相加
                                Xaxis = cos + cos1;
                                Tan = Math.Atan(Yaxis / Xaxis) * (180 / Math.PI);//算角度
                                if (Yaxis == 0 && Xaxis == 0)
                                {
                                    Tan = 0;
                                }
                                if (Xaxis == 0 && Yaxis != 0)
                                {
                                    Tan = 90;
                                }
                                if (Xaxis < 0 && Yaxis > 0)
                                {
                                    Tan = Tan + 180;
                                }
                                if (Xaxis < 0 && Yaxis < 0)
                                {
                                    Tan = Tan + 180;
                                }

                            }

                            if (3 < i)
                            {
                                double i_yaxis = Math.Round(latvalue[i] - latvalue[i - 1], 6);
                                double i_xaxis = Math.Round(lngvalue[i] - lngvalue[i - 1], 6);
                                if (latvalue[i] == latvalue[i - 1])
                                {
                                    i_yaxis = 0;
                                }
                                if (lngvalue[i] == lngvalue[i - 1])
                                {
                                    i_xaxis = 0;
                                }
                                double i_tan = Math.Atan(i_yaxis / i_xaxis) * (180 / Math.PI);
                                if (i_xaxis == 0)
                                {
                                    i_tan = 90;
                                }
                                if (i_yaxis == 0)
                                {
                                    i_tan = 0;
                                }
                                if (i_yaxis > 0 && i_xaxis > 0)
                                {
                                    if (pmvalue[i] < pmvalue[i - 1])
                                    {
                                        i_tan = i_tan + 180;
                                    }
                                }
                                if (i_yaxis < 0 && i_xaxis < 0)
                                {
                                    if (pmvalue[i] > pmvalue[i - 1])
                                    {
                                        i_tan = i_tan + 180;
                                    }
                                }
                                if (i_yaxis < 0 && i_xaxis > 0)
                                {
                                    if (pmvalue[i] < pmvalue[i - 1])
                                    {
                                        i_tan = i_tan + 180;
                                    }
                                }
                                if (i_yaxis > 0 && i_xaxis < 0)
                                {
                                    if (pmvalue[i] > pmvalue[i - 1])
                                    {
                                        i_tan = i_tan + 180;
                                    }
                                }
                                ////////////////////////////////
                                if (0 < i_tan && i_tan < 90)
                                {
                                    i_tan = (90 - i_tan) * (Math.PI / 180);
                                    goto pm_length2;
                                }
                                if (90 < i_tan && i_tan < 180)
                                {
                                    i_tan = -(i_tan - 90) * (Math.PI / 180);
                                    goto pm_length2;
                                }
                                if (180 < i_tan && i_tan < 270)
                                {
                                    i_tan = (270 - (i_tan - 180)) * (Math.PI / 180);
                                    goto pm_length2;
                                }
                                if (i_tan < 0 && -90 < i_tan)
                                {
                                    i_tan = (90 - (i_tan)) * (Math.PI / 180);
                                    goto pm_length2;
                                }

                                pm_length2:
                                if (pmvalue[i] != pmvalue[i - 1])
                                {
                                    if (pmvalue[i] > pmvalue[i - 1])
                                    {
                                        i_length = (pmvalue[i] - pmvalue[i - 1]) / 1.84;
                                    }
                                    if (pmvalue[i - 1] > pmvalue[i])
                                    {
                                        i_length = (pmvalue[i - 1] - pmvalue[i]) / 1.84;
                                    }
                                }
                                if (pmvalue[i] == pmvalue[i - 1])
                                {
                                    i_length = 0;
                                }

                                double i_sin = i_length * Math.Sin(i_tan);
                                double i_cos = i_length * Math.Cos(i_tan);
                                if (i_length == 0)
                                {
                                    i_sin = 0;
                                    i_cos = 0;
                                }
                                Yaxis = Math.Round(Yaxis + i_sin, 2);
                                Xaxis = Math.Round(Xaxis + i_cos, 2);
                                Tan = Math.Atan(Yaxis / Xaxis) * (180 / Math.PI);
                                if (Yaxis == 0 && Xaxis == 0)
                                {
                                    Tan = 0;
                                }
                                if (Xaxis == 0 && Yaxis != 0)
                                {
                                    Tan = 90;
                                }
                                if (Xaxis < 0 && Yaxis > 0)
                                {
                                    Tan = Tan + 180;
                                }
                                if (Xaxis < 0 && Yaxis < 0)
                                {
                                    Tan = Tan + 180;
                                }

                            }
                        }
                    }
                    myData.Close();
                }
            }
            if (3 <= i)
            {
                Console.WriteLine(latvalue[1] + "  " + lngvalue[1]);
            }
            this.Invoke(new Action(delegate ()
            {
                label_angle.Text = Tan.ToString("0.00");
            }));
            Console.WriteLine(Tan.ToString("0.00"));
        }
    }
}
