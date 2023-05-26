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
    public partial class PoljeKucica : UserControl
    {
        Color bojaIgraca = Color.White;
        Color pocetnaBoja;
        public PoljeKucica()
        {
            InitializeComponent();
        }

        private void PoljeKucica_Paint(object sender, PaintEventArgs e)
        {
          
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 1.5f);

            GraphicsPath gp = new GraphicsPath(FillMode.Alternate);
            gp.AddEllipse(ClientRectangle.Width / 6, ClientRectangle.Height / 6, 4 * ClientRectangle.Width / 6, 4 * ClientRectangle.Height / 6);

            graphics.FillPath(new SolidBrush(bojaIgraca), gp);
            graphics.DrawPath(pen, gp);
           
        }
        public void setBojaIgraca(Color bojaIgraca)
        {
            this.bojaIgraca = bojaIgraca;
        }
        public Color getBojaIgraca()
        {
            return bojaIgraca;
        }
        public void setPocetnaBoja(Color bojaIgraca)
        {
            this.pocetnaBoja = bojaIgraca;
        }
        public Color getPocetnaBoja()
        {
            return pocetnaBoja ;
        }
    }
}
