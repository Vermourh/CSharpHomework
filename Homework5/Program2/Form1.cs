using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class draw : Form
    {
        public draw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(textBox1.Text) * Math.PI / 180;
            th2 = Convert.ToDouble(textBox2.Text) * Math.PI / 180;
            per1 = Convert.ToDouble(textBox3.Text);
            per2 = Convert.ToDouble(textBox4.Text);
            k = Convert.ToDouble(textBox5.Text);


            if (graphics==null) graphics = this.CreateGraphics();
            drawCayLeyTree(10, 200, 310, 100, -Math.PI / 2);
        }


        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        double k;
        
        void drawCayLeyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
           // double y2 = y0 + leng * k * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayLeyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayLeyTree(n - 1, x1, y1, per2 * leng, th - th2);
            drawCayLeyTree(n - 1, x2, y1, per1 * leng, th + th1);
            //drawCayLeyTree(n - 1, x2, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            //graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x2, (int)y1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
