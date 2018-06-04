using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spectrum
{
    public class DoubleBufferedWaterFallGuidePanel : Panel
    {
        public DoubleBufferedWaterFallGuidePanel()
            : base()
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            this.BackColor = Color.Black;
            this.Dock = DockStyle.Fill;
            this.Location = new Point(0, 0);
            this.Name = "panelDisp";
            this.Size = new Size(1534, 815);
            this.TabIndex = 1;
            this.Paint += new PaintEventHandler(panelMain_Paint);
        }

        public Brush[] HeatMapColorBrush(double min = 0, int max = 255)
        {
            Brush[] returnPens = new Brush[max];
            for (int i = 0; i < max; i++)
            {
                int r = Convert.ToByte(255 - i);
                int g = 0;
                int b = Convert.ToByte(i);

                returnPens[i] = new SolidBrush(Color.FromArgb(255, r, g, b));
            }

            return returnPens;
        }

        internal void Draw()
        {
            this.Invalidate();
        }


        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            var brushs = HeatMapColorBrush();
            float yTerm = (float)Size.Height / (float)brushs.Length;
            for (int i = 0; i < brushs.Length; i++)
            {
                e.Graphics.FillRectangle(brushs[i], (float)1, (float)i * yTerm, (float)Size.Width,
                    (float)yTerm);
            }
        }
    }
}
