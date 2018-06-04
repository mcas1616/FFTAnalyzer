using System.Drawing;
using System.Windows.Forms;

namespace Spectrum
{
    public class DoubleBufferedMainPanel : Panel
    {
        private double[] Ys;
        public DoubleBufferedMainPanel()
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
            this.Name = "waterFallDisp";
            this.Size = new Size(1534, 255);
            this.TabIndex = 1;
            this.Paint += new PaintEventHandler(panelWaterFall_Paint);
        }

        private void panelWaterFall_Paint(object sender, PaintEventArgs e)
        {
            if (Ys == null) return;
            float xTern = (float)Size.Width / (float)Ys.Length;
            var _pen = new Pen(Color.Red, 1);
            for (int i = 0; i < Ys.Length; i++)
            {
                e.Graphics.DrawLine(_pen, (float)i * xTern, Size.Height, (float)i * xTern, (float)(Size.Height - Ys[i]));
            }
        }

        internal void Draw(double[] yValue)
        {
            Ys = yValue;
            Invalidate();
        }
    }
}
