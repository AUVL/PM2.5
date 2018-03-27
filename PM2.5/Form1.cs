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

namespace PM2._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                                    //label_lng.Text = myData.GetString(2);
                                    label_lng.Text = "Longitude : " + myData.GetString(2);
                                    label_lat.Text = "Latitude : " + myData.GetString(3);
                                    label_alt.Text = "Altitude : " + myData.GetString(4);
                                }));
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
