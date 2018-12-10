using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormView : Form
    {
       //Declaring variables
        private int xPosWaiter;
        private int yPosWaiter;
        private int xClient;
        private int yClient;
        private int xButler;
        private int yButler;

        public FormView()
        {
            InitializeComponent();

            // initial positions

            xPosWaiter = 540;
            yPosWaiter = 95;

            xClient = 10;
            yClient = 10;

            xButler = 880;
            yButler= 625;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormView_Resize(object sender, EventArgs e)
        {

        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
           
          //Drowing actors

           e.Graphics.FillRectangle(Brushes.Blue, xPosWaiter, yPosWaiter, 10, 10);
           e.Graphics.FillRectangle(Brushes.Black, xClient, yClient, 10, 10);
           e.Graphics.FillRectangle(Brushes.Brown, xButler, yButler, 10, 10);

        }

        private void FormView_Load(object sender, EventArgs e)
        {

        }
        // timer
        private void ticks_Tick(object sender, EventArgs e)
        {
            //Translating positions
            //test
            xPosWaiter += 2;
            Invalidate();
        }


    }

}
