using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Covece_ne_ljuti_se
{
    public partial class Form1 : Form
    {
        int brojKlika = 0;
        int redIgraca = 1;
        static int screenshots = 0;
        int ulazUKucicu;
        Boolean kockaBacena = false;
        Boolean parkiranPijun = false;
        public Form1()
        {
            InitializeComponent();
           // this.Icon = new ImageIcon(Properties.Resources.perspective_dice_six_faces_six);
            Bitmap theBitmap = new Bitmap(Properties.Resources.perspective_dice_six_faces_six, new Size(30, 30));
            IntPtr Hicon = theBitmap.GetHicon();
            Icon newIcon = Icon.FromHandle(Hicon);
            this.Icon = newIcon;
            ucitajPocetnePozicije();

        }


        public void ucitajPocetnePozicije()
        {
            zeleni.setBojaIgraca(Color.Green);
            zeleni.Invalidate();
            zuti.setBojaIgraca(Color.Yellow);
            zuti.Invalidate();
            plavi.setBojaIgraca(Color.Blue);
            plavi.Invalidate();
            crveni.setBojaIgraca(Color.Red);
            crveni.Invalidate();

            foreach (Control poljeKucica in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
            {
                PoljeKucica polje = (PoljeKucica)poljeKucica;
                if (Convert.ToInt32(polje.Tag.ToString()) < 5)
                {
                    polje.setBojaIgraca(Color.Yellow);
                    polje.setPocetnaBoja(Color.Yellow);
                }
                else if (Convert.ToInt32(polje.Tag.ToString()) > 4 && Convert.ToInt32(polje.Tag.ToString()) < 9)
                {
                    polje.setBojaIgraca(Color.Blue);
                    polje.setPocetnaBoja(Color.Blue);
                }
                else if (Convert.ToInt32(polje.Tag.ToString()) > 8 && Convert.ToInt32(polje.Tag.ToString()) < 13)
                {
                    polje.setBojaIgraca(Color.Red);
                    polje.setPocetnaBoja(Color.Red);
                }
                else
                {
                    polje.setBojaIgraca(Color.Green);
                    polje.setPocetnaBoja(Color.Green);
                }
                polje.Invalidate();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                control.Invalidate();
            }
        }

        private void kockica1_Click(object sender, EventArgs e)
        {
            
            brojKlika++;
            
            if (brojKlika == 2)
            {
                timer1.Stop();
                kockaBacena = true;
                brojKlika = 0;
                if (kockica1.getBrojKocke()!=6)
                {
                    mogucnostIgre();      
                }
               
            }
            else
            {
                timer1.Start();
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random random = new Random();
            kockica1.setBrojKocke(random.Next(1, 7));
            kockica1.Invalidate();
        }

        private void zuti_Click(object sender, EventArgs e)
        {
            izvediPijuna(zuti, redIgre(),1);
        }

        private void plavi_Click(object sender, EventArgs e)
        {
            izvediPijuna(plavi, redIgre(),11);
        }

        private void crveni_Click(object sender, EventArgs e)
        {
            izvediPijuna(crveni, redIgre(),21);
        }

        private void zeleni_Click(object sender, EventArgs e)
        {
            izvediPijuna(zeleni, redIgre(),31);
        }
        public void pomeriPijuna(Polje polje)
        {
            Color bojaPolja = Color.Black;
            int pozicija = Convert.ToInt32(polje.Tag.ToString()) + kockica1.getBrojKocke();
            if (pozicija > 40 && redIgre() != Color.Yellow)
                pozicija = pozicija - 40;
            foreach (Polje narednoPolje in tableLayoutPanel1.Controls.OfType<Polje>())
            {
                if (Convert.ToInt32(narednoPolje.Tag.ToString()) == pozicija)
                    bojaPolja = narednoPolje.getBojaPolja();
            }
            if (bojaPolja != redIgre())
            {
                if (!blizuKucice(Convert.ToInt32(polje.Tag.ToString())))
                {
                    
                    foreach (Polje narednoPolje in tableLayoutPanel1.Controls.OfType<Polje>())
                    {
                        if (Convert.ToInt32(narednoPolje.Tag.ToString()) == pozicija)
                            if (narednoPolje.getBojaPolja() != Color.White && narednoPolje.getBojaPolja() != redIgre())
                                pojediPijuna(narednoPolje);
                    }

                    promeniBoju(polje.getBojaPolja(), pozicija);
                    polje.setBojaPolja(Color.White);
                    polje.Invalidate();
                }
                else
                {
                    parkirajPijuna(pozicija);
                    if(parkiranPijun)
                    {
                        polje.setBojaPolja(Color.White);
                        polje.Invalidate();
                    }
                    parkiranPijun = false;
                }   
                if (kockica1.getBrojKocke() != 6)
                {
                    redIgraca++;
                    kockica1.Enabled = true;
                }
                kockaBacena = false;
            }
        }
        public void promeniBoju(Color boja, int tag)
        {
            foreach (Polje polje in tableLayoutPanel1.Controls.OfType<Polje>())
            {
                if (Convert.ToInt32(polje.Tag.ToString()) == tag)
                {
                    polje.setBojaPolja(boja);
                    polje.Invalidate();
                }
            }
        }

        private void polje5_Click(object sender, EventArgs e)
        {
            Polje polje = sender as Polje;
            if(kockaBacena && polje.getBojaPolja() == redIgre())
             pomeriPijuna(polje);
        }
        public Color redIgre()
        {

            if (redIgraca % 4 == 1)
            {
                return Color.Yellow;
            }
            else if (redIgraca % 4 == 2)
            {
                return Color.Blue;
            }
            else if (redIgraca % 4 == 3)
            {
                return Color.Red;
            }
            else
                return Color.Green;
               
        }

        public void izvediPijuna(PocetnePozicije pozicije,Color bojaIgraca,int tag)
        {
            if (kockica1.getBrojKocke() == 6)
            {
                if (pozicije.getBojaIgraca() == bojaIgraca)
                {
                    foreach (Polje polje in tableLayoutPanel1.Controls.OfType<Polje>())
                    {
                        if (Convert.ToInt32(polje.Tag.ToString()) == tag && polje.getBojaPolja() != redIgre())
                        {
                            if (pozicije.getCetvrtiPijun() == bojaIgraca)
                            {
                                if (pozicije.getPrviPijun() == bojaIgraca)
                                {
                                    pozicije.setPrviPijun(Color.White);
                                    pozicije.Invalidate();
                                }
                                else if (pozicije.getDrugPijun() == bojaIgraca)
                                {
                                    pozicije.setdDrugiPijun(Color.White);
                                    pozicije.Invalidate();
                                }
                                else if (pozicije.getTreciPijun() == bojaIgraca)
                                {
                                    pozicije.setTreciPijun(Color.White);
                                    pozicije.Invalidate();
                                }
                                else if (pozicije.getCetvrtiPijun() == bojaIgraca)
                                {
                                    pozicije.setCetvrtiPijun(Color.White);
                                    pozicije.Invalidate();
                                }
                                polje.setBojaPolja(bojaIgraca);
                                polje.Invalidate();
                            }
                        }
                    }
                }
            }
        }
        
        public void pojediPijuna(Polje polje)
        {
            foreach(PocetnePozicije pozicije in tableLayoutPanel1.Controls.OfType<PocetnePozicije>())
            {
                if(pozicije.getBojaIgraca() == polje.getBojaPolja())
                {
                    if(pozicije.getCetvrtiPijun() != polje.getBojaPolja())
                    {
                        pozicije.setCetvrtiPijun(polje.getBojaPolja());
                    }
                    else if (pozicije.getTreciPijun() != polje.getBojaPolja())
                    {
                        pozicije.setTreciPijun(polje.getBojaPolja());
                    }
                    else if (pozicije.getDrugPijun() != polje.getBojaPolja())
                    {
                        pozicije.setdDrugiPijun(polje.getBojaPolja());
                    }
                    else 
                    {
                        pozicije.setPrviPijun(polje.getBojaPolja());
                    }
                    pozicije.Invalidate();
                }
            }
        }
  
        public void parkirajPijuna(int pozicija)
        {
           
             int brojUKucici = pozicija - ulazUKucicu;

            foreach (PoljeKucica poljeKucica in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
            {
                if (poljeKucica.getBojaIgraca() == redIgre() && Convert.ToInt32(poljeKucica.Tag.ToString()) == brojUKucici)
                {
                    poljeKucica.setBojaIgraca(Color.White);
                    poljeKucica.Invalidate();
                    parkiranPijun = true;
                }
            }
            
            
        }
        public Boolean blizuKucice(int pozicija)
        {
            if (redIgre() == Color.Yellow && pozicija < 41 && pozicija > 34)
            {
                ulazUKucicu = 40;
                return true;
            }
            else if (redIgre() == Color.Blue && pozicija < 11 && pozicija > 4)
            {
                ulazUKucicu = 6;
                return true;
            }
            else if (redIgre() == Color.Red && pozicija < 21 && pozicija > 14)
            {
                ulazUKucicu = 12;
                return true;
            }
            else if (redIgre() == Color.Green && pozicija < 31 && pozicija > 24)
            {
                ulazUKucicu = 18;
                return true;
            }
            return false;
        }

    
        public void pomeriPijunaUKucici(PoljeKucica polje)
        {
            PoljeKucica sledecePoljeKucica = null;
            int pozicija = Convert.ToInt32(polje.Tag.ToString()) + kockica1.getBrojKocke();
            foreach (PoljeKucica narednoPolje in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
            {
                if (Convert.ToInt32(narednoPolje.Tag.ToString()) == pozicija)
                    sledecePoljeKucica = narednoPolje;
            }
            if (sledecePoljeKucica.getBojaIgraca() != Color.White)
            {
                foreach (PoljeKucica narednoPolje in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
                {
                    if (Convert.ToInt32(narednoPolje.Tag.ToString()) == pozicija && narednoPolje.getBojaIgraca() == redIgre())
                    {
                        narednoPolje.setBojaIgraca(Color.White);
                        narednoPolje.Invalidate();
                        polje.setBojaIgraca(redIgre());
                        polje.Invalidate();
                    }
                }
                if (kockica1.getBrojKocke() != 6)
                {
                    redIgraca++;
                }
                kockaBacena = false;
                proglasiPobednika(polje);
            }
        }

        private void zutaKucica1_Click(object sender, EventArgs e)
        {
            PoljeKucica polje = sender as PoljeKucica;
            if (kockaBacena && polje.getPocetnaBoja() == redIgre() && polje.getBojaIgraca() == Color.White)
                pomeriPijunaUKucici(polje);
        }
        private void mogucnostIgre()
        {
            int brojPijuna = 0;
            foreach(Polje polje in tableLayoutPanel1.Controls.OfType<Polje>())
            {
                if(polje.getBojaPolja() == redIgre())
                {
                    brojPijuna++;
                }
            }
            if (postojiPotezUKucici())
                brojPijuna++;

            if (brojPijuna == 0)
            {
                redIgraca++;
               
                kockaBacena = false;
            }
        }
        private Boolean postojiPotezUKucici()
        {
            foreach(PoljeKucica polje in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
            {
                if(polje.getBojaIgraca() == Color.White && polje.getPocetnaBoja() == redIgre())
                {
                    foreach (PoljeKucica narednoPolje in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
                    {
                        if (Convert.ToInt32(narednoPolje.Tag.ToString()) == Convert.ToInt32(polje.Tag.ToString()) + kockica1.getBrojKocke() && narednoPolje.getBojaIgraca() == redIgre())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void proglasiPobednika(PoljeKucica poljeKucica)
        {
            int brojPijunaUKucici = 0;
            foreach(PoljeKucica polje in tableLayoutPanel1.Controls.OfType<PoljeKucica>())
            {
                if (polje.getPocetnaBoja() == poljeKucica.getPocetnaBoja() && polje.getBojaIgraca() == Color.White)
                    brojPijunaUKucici++;
            }
            if (brojPijunaUKucici == 4)
            {
                foreach(Label label in tableLayoutPanel1.Controls.OfType<Label>())
                    if(label.ForeColor == redIgre())
                         MessageBox.Show("Pobednik je "+ label.Text + "!!!");
            }
        }
        public void screenshot()
        {
            screenshots++;
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("C://Users//Ruzic//Desktop//screenshot"+screenshots+".jpg", ImageFormat.Jpeg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            screenshot();
        }

        private void screenshotButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Properties.Resources.icons8_screenshot_40, 0, 0,40, 40);
        }

        private void polje1_Paint(object sender, PaintEventArgs e)
        {
            Polje polje = sender as Polje;
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Yellow, 9);
            pen.EndCap = LineCap.ArrowAnchor;

            graphics.DrawLine(pen, polje.Width / 2, 2 * polje.Height / 3, polje.Width / 2,  polje.Height / 3);

        }

        private void polje13_Paint(object sender, PaintEventArgs e)
        {
            Polje polje = sender as Polje;
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Blue, 9);
            pen.EndCap = LineCap.ArrowAnchor;

            graphics.DrawLine(pen, polje.Width /3, polje.Height/2,2* polje.Width / 3, polje.Height / 2);
        }

        private void polje23_Paint(object sender, PaintEventArgs e)
        {
            Polje polje = sender as Polje;
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Red, 9);
            pen.EndCap = LineCap.ArrowAnchor;

            graphics.DrawLine(pen, polje.Width / 2, polje.Height / 3, polje.Width / 2,2* polje.Height / 3);
        }

        private void polje33_Paint(object sender, PaintEventArgs e)
        {
            Polje polje = sender as Polje;
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Green, 9);
            pen.EndCap = LineCap.ArrowAnchor;

            graphics.DrawLine(pen,2 * polje.Width / 3, polje.Height / 2, polje.Width / 3, polje.Height / 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    } 
}
