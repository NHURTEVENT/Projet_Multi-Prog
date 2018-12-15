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
using Controller;
using Shared;

namespace RoomView
{
    public partial class FormView : Form
    {
        /*
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
        private int xHeadWaiter, yHeadWaiter;*/
        private DateTime actionTime;
        private string actionName;
        private RoomManager room;


        private readonly string logFilePath = @"C:\Projets\Projet_Multi-Prog\WindowsFormsApp\log.txt";

        public FormView(Timer timer, RoomManager room)
        {
            InitializeComponent();
            this.room = room;
            ticks = timer;
            this.ticks.Tick += new System.EventHandler(this.ticks_Tick);

            //xWaiter = 540;
            //yWaiter = 95;

            //xClient = 935;
            //yClient = 364;

            //xButler = 880;
            //yButler = 625;

            //xChef = 415;
            //yChef = 630;

            //xChefP1 = 283;
            //yChefP1 = 580;

            //xChefP2 = 283;
            //yChefP2 = 650;

            //xKClurk = 155;
            //yKClurk = 635;

            //xDishCleaner = 780;
            //yDishCleaner = 600;

            //xHeadWaiter = 30;
            //yHeadWaiter = 30;

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
            //for each personnel, paint the point at it's coords

            foreach(IPerson p in room.Peoples )
            {
                e.Graphics.FillRectangle(p.Color, p.Position.X, p.Position.Y, 10, 10);

            }




            //e.Graphics.FillRectangle(Brushes.Blue, xWaiter, yWaiter, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Black, xClient, yClient, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Brown, xButler, yButler, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Red, xChef, yChef, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Yellow, xChefP1, yChefP1, 10, 10);
            //e.Graphics.FillRectangle(Brushes.ForestGreen, xChefP2, yChefP2, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Purple, xKClurk, yKClurk, 10, 10);
            //e.Graphics.FillRectangle(Brushes.Pink, xDishCleaner, yDishCleaner, 10, 10);
            //e.Graphics.FillRectangle(Brushes.DarkGray, xHeadWaiter, yHeadWaiter, 10, 10);

        }

        private void FormView_Load(object sender, EventArgs e)
        {
            StreamWriter deleteFile = new StreamWriter(logFilePath, true);    //writing in logfile and log file path
            deleteFile.Write(String.Empty);  //log message
            deleteFile.Close();
        }

        private void ticks_Tick(object sender, EventArgs e)
        {
            foreach (IPerson p in room.Peoples)
            {
                var g = CreateGraphics();
                g.FillRectangle(p.Color, p.Position.X, p.Position.Y, 10, 10);

            }
            //xWaiter += 1;
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

        public void createView()
        {

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Clear = new System.Windows.Forms.Button();
            this.TimeX10 = new System.Windows.Forms.Button();
            this.TimeX1 = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.Logs = new System.Windows.Forms.RichTextBox();
            this.ticks = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::RoomView.Properties.Resources.map;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Clear);
            this.splitContainer2.Panel1.Controls.Add(this.TimeX10);
            this.splitContainer2.Panel1.Controls.Add(this.TimeX1);
            this.splitContainer2.Panel1.Controls.Add(this.Pause);
            this.splitContainer2.Panel1.Controls.Add(this.Play);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.title);
            this.splitContainer2.Panel2.Controls.Add(this.Logs);
            // 
            // Clear
            // 
            resources.ApplyResources(this.Clear, "Clear");
            this.Clear.Name = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // TimeX10
            // 
            this.TimeX10.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.TimeX10, "TimeX10");
            this.TimeX10.Name = "TimeX10";
            this.TimeX10.UseVisualStyleBackColor = false;
            this.TimeX10.Click += new System.EventHandler(this.TimeX10_Click);
            // 
            // TimeX1
            // 
            this.TimeX1.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.TimeX1, "TimeX1");
            this.TimeX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TimeX1.Name = "TimeX1";
            this.TimeX1.UseVisualStyleBackColor = false;
            this.TimeX1.Click += new System.EventHandler(this.TimeX1_Click);
            // 
            // Pause
            // 
            this.Pause.Image = global::RoomView.Properties.Resources.pauseSmall;
            resources.ApplyResources(this.Pause, "Pause");
            this.Pause.Name = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Play
            // 
            this.Play.Image = global::RoomView.Properties.Resources.play;
            resources.ApplyResources(this.Play, "Play");
            this.Play.Name = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // title
            // 
            resources.ApplyResources(this.title, "title");
            this.title.Name = "title";
            // 
            // Logs
            // 
            this.Logs.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.Logs, "Logs");
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.TextChanged += new System.EventHandler(this.Logs_TextChanged);
            // 
            // ticks
            // 
            this.ticks.Interval = 1000;
            //this.ticks.Tick += new System.EventHandler(this.ticks_Tick);
            // 
            // FormView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.FormView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);
            this.Resize += new System.EventHandler(this.FormView_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
