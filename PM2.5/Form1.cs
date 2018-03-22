using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

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
                //if (Repload.AddSeconds(1) <= DateTime.Now)
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
                                label_lng.Text = myData.GetString(2);
                                label_lat.Text = myData.GetString(3);
                                label_alt.Text = myData.GetString(4);
                                //myData.Read();
                            }
                            //myData.Close();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.WriteLine("Error " + ex.Number + " : " + ex.Message);
                        }
                        Repload = DateTime.Now;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //new Thread(Mainloop) { IsBackground = true }.Start();
            Mainloop();
        }
        //public void timer1_Tick()
        //{
        //    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        //    timer1.Tick += new EventHandler(Mainloop);
        //    timer1.Interval = 1000;
        //    timer1.Start();
        //}
    }
}
