using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Covece_ne_ljuti_se
{
    public partial class Kockica : UserControl
    {
        int brojKocke = 5;
        public Kockica()
        {
            InitializeComponent();
        }

        private void Kockica_Paint(object sender, PaintEventArgs e)
        {
            int sirina = ClientRectangle.Width - 1;
            int visina = ClientRectangle.Height - 1;
            Graphics graphics = e.Graphics;

            GraphicsPath gp = new GraphicsPath(FillMode.Alternate);

            Pen pen = new Pen(Color.Black, 1);

            gp.AddLine(0.5f * sirina / 4, 1, 3.5f * sirina / 4, 1);
            gp.AddArc(3 * sirina / 4 , 1, sirina / 4, visina / 4, 270, 90);
            gp.AddLine(sirina-1, 0.5f * visina / 4, sirina-1, 3.5f * visina / 4);
            gp.AddArc(3 * sirina/4, 3 * visina/4, sirina/4, visina/4, 0, 90);
            gp.AddLine(3.5f * sirina/4,  visina , 0.5f * sirina/4,  visina);
            gp.AddArc(1, 3 * visina/4, sirina / 4, visina/4, 90, 90);
            gp.AddLine(1, 3.5f * visina / 4, 1, 0.5f * visina / 4);
            gp.AddArc(1, 1, sirina / 4, visina / 4,180,90);
            graphics.FillPath(new SolidBrush(Color.White), gp);
            graphics.DrawPath(pen, gp);

            if(brojKocke == 1)
            {
                graphics.FillEllipse(new SolidBrush(Color.Black), 2*ClientRectangle.Width / 5,2* ClientRectangle.Height / 5, ClientRectangle.Width / 5, ClientRectangle.Height / 5);
            }
            else if(brojKocke == 2)
            {

                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);

            }
            else if(brojKocke == 3)
            {
                graphics.FillEllipse(new SolidBrush(Color.Black), 3 * ClientRectangle.Width / 7, 3 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
            }
            else if (brojKocke == 4)
            { 
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
            }
            else if (brojKocke == 5)
            {
                graphics.FillEllipse(new SolidBrush(Color.Black), 3 * ClientRectangle.Width / 7 ,3 * ClientRectangle.Height / 7, ClientRectangle.Width / 7,  ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, ClientRectangle.Height / 7,  ClientRectangle.Width / 7,  ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, ClientRectangle.Height / 7,  ClientRectangle.Width / 7,  ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black),5 * ClientRectangle.Width / 7,5* ClientRectangle.Height / 7,  ClientRectangle.Width / 7,  ClientRectangle.Height / 7);
            }
            else if (brojKocke == 6)
            {
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, 5 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle.Width / 7, 3 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
                graphics.FillEllipse(new SolidBrush(Color.Black), 5 * ClientRectangle.Width / 7, 3 * ClientRectangle.Height / 7, ClientRectangle.Width / 7, ClientRectangle.Height / 7);
            }
        }
        public void setBrojKocke(int brojKocke)
        {
            this.brojKocke = brojKocke;
        }
        public int getBrojKocke()
        {
            return brojKocke;
        }
    }
}
