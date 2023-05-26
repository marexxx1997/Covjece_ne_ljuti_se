using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Covece_ne_ljuti_se
{
    public partial class PocetnePozicije : UserControl
    {
        Color prviPijun;
        Color drugiPijun;
        Color treciPijun;
        Color cetvrtiPijun;
        Color bojaIgraca;
        public PocetnePozicije()
        {
            InitializeComponent();
           
        }

        private void Kucica_Paint(object sender, PaintEventArgs e)
        {
 

            Graphics graphics = e.Graphics;

            graphics.FillEllipse(new SolidBrush(Color.Black), 0, 0, ClientRectangle.Width, ClientRectangle.Height);

            graphics.FillEllipse(new SolidBrush(prviPijun), 3*ClientRectangle.Width / 16, 3*ClientRectangle.Height / 16, ClientRectangle.Width / 4, ClientRectangle.Height / 4);
            graphics.FillEllipse(new SolidBrush(drugiPijun), 9 * ClientRectangle.Width / 16, 3 * ClientRectangle.Height / 16, ClientRectangle.Width / 4, ClientRectangle.Height / 4);
            graphics.FillEllipse(new SolidBrush(treciPijun), 3 * ClientRectangle.Height / 16, 9 * ClientRectangle.Width / 16, ClientRectangle.Width / 4, ClientRectangle.Height / 4);
            graphics.FillEllipse(new SolidBrush(cetvrtiPijun), 9 * ClientRectangle.Width / 16, 9 * ClientRectangle.Width / 16, ClientRectangle.Width / 4, ClientRectangle.Height / 4);


        }
        public void setBojaIgraca(Color bojaIgraca)
        {
            prviPijun = bojaIgraca;
            drugiPijun = bojaIgraca;
            treciPijun = bojaIgraca;
            cetvrtiPijun = bojaIgraca;
            this.bojaIgraca = bojaIgraca;

        }
        public Color getBojaIgraca()
        {
            return this.bojaIgraca;
        }
        public void setPrviPijun(Color prviPijun)
        {
            this.prviPijun = prviPijun;
        }
        public void setdDrugiPijun(Color drugiPijun)
        {
            this.drugiPijun = drugiPijun;
        }
        public void setTreciPijun(Color treciPijun)
        {
            this.treciPijun = treciPijun;
        }
        public void setCetvrtiPijun(Color cetvrtiPijun)
        {
            this.cetvrtiPijun = cetvrtiPijun;
        }
        public Color getPrviPijun()
        {
            return prviPijun;
        }
        public Color getDrugPijun()
        {
            return drugiPijun;
        }
        public Color getTreciPijun()
        {
            return treciPijun;
        }
        public Color getCetvrtiPijun()
        {
            return cetvrtiPijun;
        }
    }
}
