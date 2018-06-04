using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Spectrum
{
    public class PointBrush
    {
        public double[] yValue;
        public Brush[] brush;

        public PointBrush(double[] yValue, Brush[] brush)
        {
            this.yValue = yValue;
            this.brush = brush;
        }
    }
    
    public class DoubleBufferedWaterFallPanel : Panel
    {
        private List<PointBrush> historyPointBrush;

        public DoubleBufferedWaterFallPanel()
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

            historyPointBrush = new List<PointBrush>();
        }

        public Brush[] HeatMapColorBrush(double[] value, double min = 0, double max = 255)
        {
            Brush[] returnPens = new Brush[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                double val = (value[i] - min) / (max - min);
                int r = Convert.ToByte(255 * val);
                int g = 0;
                int b = Convert.ToByte(255 * (1 - val));

                returnPens[i] = new SolidBrush(Color.FromArgb(255, r, g, b));
            }

            return returnPens;
        }

        internal void Draw(double[] yValue)
        {
            historyPointBrush.Insert(0, new PointBrush(yValue, HeatMapColorBrush(yValue)));


            this.Invalidate();
        }

        internal void Clear()
        {
            historyPointBrush = new List<PointBrush>();
            this.Invalidate();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < historyPointBrush.Count; i++)
            {
                var pointBrush = historyPointBrush[i];

                float xTern = (float)Size.Width / (float)pointBrush.yValue.Length;
                float yTern = 5;

                

                for (int j = 0; j < pointBrush.brush.Length; j++)
                {
                    if (j == 0)
                    {
                        e.Graphics.FillRectangle(pointBrush.brush[j], (float)0, (float)i * yTern, (float)xTern / 2,
                            (float)yTern);
                    }

                    e.Graphics.FillRectangle(pointBrush.brush[j], (float)(j * xTern) - (xTern / 2), (float)i * yTern, (float)xTern,
                        (float)yTern);
                }
            }
        }

    }
}
