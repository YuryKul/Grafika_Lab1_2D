using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //ustawia 80 pikseli na górze i na lewo od granic kształtu
            int tl = 80;
            //osi dla X i Y współrzędne dla promieni słońca.
            int x = 0;
            int y = 0;
            //tworzymy generator liczb losowych, aby promienie miały różne długości
            Random R = new Random();
            //rysuje linię o określonej szerokości i stylu
            Pen myPen = new Pen(Color.Black);
            //grafika do rysowania na płótnie
            Graphics g = e.Graphics;
            //malujemy niebo za pomocą wypełnienia gradientowego
            g.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.Blue, Color.Aqua, LinearGradientMode.BackwardDiagonal), new Rectangle(0, 0, Width, Height / 2));
            //malujemy ziemię za pomocą wypełnienia gradientowego
            g.FillRectangle(new LinearGradientBrush(new Rectangle(0, 340, Width, Height / 2), Color.Lime, Color.ForestGreen, LinearGradientMode.ForwardDiagonal), new Rectangle(0, 340, Width, Height / 2));
            //tworzymy główną część prostokątnej ściany domu i malujemy wypełnienia gradientowe
            g.FillRectangle(new LinearGradientBrush(new Rectangle(550, 450, 190, 120), Color.Pink, Color.Plum, LinearGradientMode.ForwardDiagonal), new Rectangle(550, 450, 190, 120));
            //tworzymy kwadratowe okno i malujemy wypełnienia gradientowe
            g.FillRectangle(new LinearGradientBrush(new Rectangle(570, 470, 60, 50), Color.SkyBlue, Color.SlateBlue, LinearGradientMode.ForwardDiagonal), new Rectangle(570, 470, 60, 50));
            //tworzymy prostokątne drzwi i malujemy wypełnienia gradientowe
            g.FillRectangle(new LinearGradientBrush(new Rectangle(680, 480, 40, 80), Color.Orange, Color.OrangeRed, LinearGradientMode.ForwardDiagonal), new Rectangle(680, 480, 40, 80));
            //tworzymy dach o określonych współrzędnych w tablicy dla osi XY i malujemy kolor
            g.FillPolygon(Brushes.Red, new Point[] {
                new Point(550, 450),
                new Point(645, 350),
                new Point(740, 450)
            });
            //na dachu rysuje kontury wyznaczające granice
            g.DrawPolygon(myPen, new Point[] {
                new Point(550, 450),
                new Point(645, 350),
                new Point(740, 450)
            });
            //rysujemy choinkę. W głównej części od góry tworzymy Współrzędne dla osi XY 1 trójkąta, a następnie pozostałe Trójkąty. Następnie pomaluj na zielono i narysuj kontury choinki
            g.FillPolygon(Brushes.Green, new Point[] {
                new Point(250, 150),
                new Point(150, 250),
                new Point(350, 250),
            });
            g.DrawPolygon(myPen, new Point[] {
                new Point(250, 150),
                new Point(150, 250),
                new Point(350, 250),
            });
            g.FillPolygon(Brushes.Green, new Point[] {
                new Point(250, 250),
                new Point(150, 350),
                new Point(350, 350),
            });
            g.DrawPolygon(myPen, new Point[] {
                new Point(250, 250),
                new Point(150, 350),
                new Point(350, 350),
            });
            g.FillPolygon(Brushes.Green, new Point[] {
                new Point(250, 350),
                new Point(150, 450),
                new Point(350, 450),
            });
            g.DrawPolygon(myPen, new Point[] {
                new Point(250, 350),
                new Point(150, 450),
                new Point(350, 450),
            });
            //tworzymy pień na choinkę i malujemy wypełnienia gradientowe
            g.FillRectangle(new LinearGradientBrush(new Rectangle(235, 450, 30, 70), Color.SaddleBrown, Color.Peru, LinearGradientMode.ForwardDiagonal), new Rectangle(235, 450, 30, 70));
            //przebieg cyklu od 0 do 360 w krokach co 0.9
            for (float i = 0; i <= 360; i += 0.9F) {
                //współrzędnych XY linii, gdzie początek będzie wokół środka okręgu, a koniec jest zawsze w tym samym punkcie "tl" . Oba są związane z czujnikiem liczb losowych, aby promienie miały różne długości
                x = Convert.ToInt32(Math.Cos(i) * 100 * R.Next(0, 6) + tl);
                y = Convert.ToInt32(Math.Sin(i) * 100 * R.Next(0, 6) + tl);
                //właściwie narysuj linię
                g.DrawLine(Pens.Yellow, x, y, tl, tl);
            }
            //narysuj żółte kółko ze środkiem wspólnym dla wszystkich linii (promieni)
            g.FillEllipse(Brushes.Yellow, new Rectangle(tl / 2, tl / 2, tl, tl));
        }
    }
}
