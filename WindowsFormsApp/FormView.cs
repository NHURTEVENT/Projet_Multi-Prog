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
        private int xPos;
        private int yPos;

        public FormView()
        {
            InitializeComponent();

            xPos = 540;
            yPos = 95;
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
            e.Graphics.FillRectangle(Brushes.Blue, xPos, yPos, 10, 10);
        }

        private void FormView_Load(object sender, EventArgs e)
        {

        }

        private void ticks_Tick(object sender, EventArgs e)
        {
            xPos += 2;
            Invalidate();
        }


    }

}
