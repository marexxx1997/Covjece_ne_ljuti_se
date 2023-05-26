using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covece_ne_ljuti_se
{
    public partial class Polje : UserControl
    {
        Color bojaPolja = Color.White;
        public Polje()
        {
            InitializeComponent();
        }

        private void Polje_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            graphics.FillEllipse(new SolidBrush(bojaPolja), ClientRectangle.Width / 6, ClientRectangle.Height / 6, 4 * ClientRectangle.Width / 6, 4 * ClientRectangle.Height / 6);
        }
        public void setBojaPolja(Color bojaPolja)
        {
            this.bojaPolja = bojaPolja;
        }
        public Color getBojaPolja()
        {
            return bojaPolja;
        }
    }
}
