using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace WindowsFormsApp
{
    public partial class FormView : Form
    {
        private int xWaiter;
        private int yWaiter;
        private int xClient;
        private int yClient;
        private int xButler;
        private int yButler;
        private int xChef, yChef;
        private int xChefP1, yChefP1;
        private int xChefP2, yChefP2;
        private int xKClurk, yKClurk;
        private int xDishCleaner, yDishCleaner;
        private int xHeadWaiter, yHeadWaiter;
        private DateTime actionTime;
        private string actionName;

        private readonly string logFilePath = @"C:\Projets\Projet_Multi-Prog\WindowsFormsApp\log.txt";

        public FormView()
        {
            InitializeComponent();

            xWaiter = 540;
            yWaiter = 95;

            xClient = 935;
            yClient = 364;

            xButler = 880;
            yButler = 625;

            xChef = 415;
            yChef = 630;

            xChefP1 = 283;
            yChefP1 = 580;

            xChefP2 = 283;
            yChefP2 = 650;

            xKClurk = 155;
            yKClurk = 635;

            xDishCleaner = 780;
            yDishCleaner = 600;

            xHeadWaiter = 30;
            yHeadWaiter = 30;

        }


        /* 
         Table 1 > (5,45) 2P
         Table 2 > (105,45) 2P
         Table 3 > (210,45) 2P
         Table 4 > (310,45) 2P
         Table 5 > (412,45) 2P
         Table 6 > (5,135) 4P
         Table 7 > (135,135) 4P
         Table 8 > (265,135) 4P
         Table 9 > (392,135) 4P
         Table 10 > (5,230) 4P
         Table 11 > (180,230) 6P
         Table 12 > (394,228) 4P
         Table 13 > (5,325) 4P
         Table 14 > (135,325) 4P
         Table 15 > (267,326) 4P
         Table 16 > (395,326) 4P
         Table 17 > (5,425) 2P
         Table 18 > (105,424) 2P
         Table 19 > (210,423) 2P
         Table 20 > (313,423) 2P
         Table 21 > (412,423) 2P
         Table 22 > (528,135) 10P
         Table 23 > (635,53) 8P
         Table 24 > (845,53) 8P
         Table 25 > (710,175) 10P
         Table 26 > (772,155) 6P
         Table 27 > (933,180) 6P
         Table 28 > (745,205) 6P
         Table 29 > (825,278) 6P
         Table 30 > (528,415) 8P
         Table 31 > (740,413) 8P
         Table 32 > (935,364) 8P
  
         */

        private void Play_Click(object sender, EventArgs e)
        {
            ticks.Enabled = true;
            ticks.Start();
            actionName = "Start simulation";
            LogMsg();

        }

        private void TimeX1_Click(object sender, EventArgs e)
        {
            ticks.Interval = 1000;
            actionName = "Set timer X1";
            LogMsg();

        }

        private void TimeX10_Click(object sender, EventArgs e)
        {
            ticks.Interval = 100;
            actionName = "Set timer X10";
            LogMsg();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            ticks.Stop();
            actionName = "Pause simulation";
            LogMsg();
        }

        private void Logs_TextChanged(object sender, EventArgs e)
        {

            TextReader reader = new StreamReader(logFilePath);
            Logs.Text = reader.ReadToEnd(); // Read all the text file
            Logs.Select(Logs.TextLength - 1, 1); //scroll to bottom
            Logs.ScrollToCaret(); //scroll to bottom
            reader.Close();

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e) // juste pour tests
        {
            ClearLog();
        }

        private void FormView_Resize(object sender, EventArgs e)
        {

        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.FillRectangle(Brushes.Blue, xWaiter, yWaiter, 10, 10);
            e.Graphics.FillRectangle(Brushes.Black, xClient, yClient, 10, 10);
            e.Graphics.FillRectangle(Brushes.Brown, xButler, yButler, 10, 10);
            e.Graphics.FillRectangle(Brushes.Red, xChef, yChef, 10, 10);
            e.Graphics.FillRectangle(Brushes.Yellow, xChefP1, yChefP1, 10, 10);
            e.Graphics.FillRectangle(Brushes.ForestGreen, xChefP2, yChefP2, 10, 10);
            e.Graphics.FillRectangle(Brushes.Purple, xKClurk, yKClurk, 10, 10);
            e.Graphics.FillRectangle(Brushes.Pink, xDishCleaner, yDishCleaner, 10, 10);
            e.Graphics.FillRectangle(Brushes.DarkGray, xHeadWaiter, yHeadWaiter, 10, 10);

        }

        private void FormView_Load(object sender, EventArgs e)
        {
            StreamWriter deleteFile = new StreamWriter(logFilePath, true);    //writing in logfile and log file path
            deleteFile.Write(String.Empty);  //log message
            deleteFile.Close();
        }

        private void ticks_Tick(object sender, EventArgs e)
        {
            xWaiter += 1;
            Invalidate();
            Update();
            Refresh();
        }


        private void LogMsg()
        {
            actionTime = DateTime.Now;


            StreamWriter sw = new StreamWriter(logFilePath, true);    //writing in logfile and log file path
            sw.WriteLine($"{actionName} at: {actionTime.ToString()} )");  //log message
            sw.Close();
            Logs.Text = " ";
        }

        private void ClearLog()
        {
            StreamWriter deleteFile = new StreamWriter(logFilePath, true);    //writing in logfile and log file path
            deleteFile.Write(String.Empty);  //Clearing Logs
            deleteFile.Close();
        }


    }

}
