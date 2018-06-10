using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum
{
    public partial class Form1 : Form
    {
        private readonly RandomData RandomData;
        private readonly Buffer Buffer;

        //public DoubleBufferedWaterFallPanel WaterFallpanelDisp;
        private readonly DoubleBufferedWaterFallGuidePanel WaterFallGuidepanelDisp;
        private readonly DoubleBufferedMainPanel panelDisp;
        private double[] Ys;
        private float _zoom;
        private Point _offsetPoint;
        private bool bLMouseDown;
        private Point ptMouseDown;
        private DoubleBufferedMainPanel panelDispWaterFall;
        private List<PointBrush> historyPointBrush;

        private ChartBoxSize chartBoxSize;

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

        public class ChartBoxSize
        {
            public double xSize;
            public double ySize;
        }

        public Form1()
        {
            InitializeComponent();

            RandomData = new RandomData();
            Buffer = new Buffer();
            
            //WaterFallpanelDisp = new DoubleBufferedWaterFallPanel();
            WaterFallGuidepanelDisp = new DoubleBufferedWaterFallGuidePanel();


            this.panelDisp = new DoubleBufferedMainPanel();
            this.panelDisp.BackColor = Color.Black;
            this.panelDisp.Dock = DockStyle.Fill;
            this.panelDisp.Location = new Point(0, 0);
            this.panelDisp.Name = "waterFallDisp";
            this.panelDisp.Size = new Size(1534, 815);
            this.panelDisp.TabIndex = 1;
            this.panelDisp.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            this.panelDisp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            this.panelDisp.MouseEnter += new System.EventHandler(this.panelMain_MouseEnter);
            this.panelDisp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            this.panelDisp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseUp);
            panelMain.MouseWheel += panelMain_MouseWheel;
            _zoom = 1;
            this.panelMain.Controls.Add(this.panelDisp);

            this.panelDispWaterFall = new DoubleBufferedMainPanel();
            this.panelDispWaterFall.BackColor = Color.Black;
            this.panelDispWaterFall.Dock = DockStyle.Fill;
            this.panelDispWaterFall.Location = new Point(0, 0);
            this.panelDispWaterFall.Name = "panelDisp";
            this.panelDispWaterFall.Size = new Size(1534, 815);
            this.panelDispWaterFall.TabIndex = 1;
            this.panelDispWaterFall.Paint += new PaintEventHandler(panelWaterFall_Paint);
            this.panelDispWaterFall.MouseEnter += new System.EventHandler(this.panelMain_MouseEnter);
            this.panelDispWaterFall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            this.panelDispWaterFall.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            this.panelDispWaterFall.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseUp);
            panelWaterFall.MouseWheel += panelMain_MouseWheel;

            historyPointBrush = new List<PointBrush>();
            panelWaterFall.Controls.Add(this.panelDispWaterFall);
            panelWaterFallGuide.Controls.Add(WaterFallGuidepanelDisp);
            WaterFallGuidepanelDisp.Draw();

            chartBoxSize = new ChartBoxSize()
            {
                xSize = (double)this.panelDisp.Width
            };
        }

        internal void WaterFallPanelDispClear()
        {
            historyPointBrush = new List<PointBrush>();
            //this.Invalidate();
            this.Refresh();
        }

        public static Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0:
                    return Color.FromArgb(255, 255, ascending, 0);
                case 1:
                    return Color.FromArgb(255, descending, 255, 0);
                case 2:
                    return Color.FromArgb(255, 0, 255, ascending);
                case 3:
                    return Color.FromArgb(255, 0, descending, 255);
                case 4:
                    return Color.FromArgb(255, ascending, 0, 255);
                default: // case 5:
                    return Color.FromArgb(255, 255, 0, descending);
            }
        }

        public Brush[] HeatMapColorBrush(double[] value, double min = 0, double max = 255)
        {
            Brush[] returnPens = new Brush[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                returnPens[i] = new SolidBrush(Rainbow((float)value[i] / 255));
            }

            return returnPens;
        }

        private void WaterFallPanelDispDraw(double[] yValue)
        {
            historyPointBrush.Insert(0, new PointBrush(yValue, HeatMapColorBrush(yValue)));


            this.panelDispWaterFall.Invalidate();
        }

        

        private void panelMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (bLMouseDown && e.Button == MouseButtons.Left)
            {
                bLMouseDown = false;
            }
        }

        private void panelMain_MouseEnter(object sender, EventArgs e)
        {
            panelMain.Focus();
        }

        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (bLMouseDown)
            {
                _offsetPoint.X += e.X - ptMouseDown.X;
                _offsetPoint.Y += e.Y - ptMouseDown.Y;

                this.panelMain.Refresh();
                this.panelDispWaterFall.Refresh();
            }
        }

        
        private void panelMain_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = _zoom;
            Point pos = new Point(e.X, e.Y);
            PointF scrollPosition = this.panelDisp.AutoScrollPosition;
            PointF cursorOffset = new PointF(pos.X + scrollPosition.X,
                        pos.Y + scrollPosition.Y);
            
            var zoom = _zoom + 0.1f * ((e.Delta > 0) ? 1 : -1);
            _zoom = Math.Max(0.1f, Math.Min(100.0f, zoom));

            _offsetPoint.X += (int) Math.Round(_zoom * pos.X / oldZoom) -
                             (int) cursorOffset.X;
            _offsetPoint.Y = 0;

            this.panelMain.Refresh();
            this.panelDispWaterFall.Refresh();

        }

        /// <summary>
        /// Zoom/unzoom the control by a given factor. 
        /// Factor is applied to the image size.
        /// </summary>
        /// <param name="zoom">zoom factor between 0.1 and 8.0</param>
        /// <param name="pos">position under the cursor which is to be 
        /// retained</param>
        private void Zoom(float zoom, PointF pos)
        {

            // make sure an image is set
            //if (_pictureBox.Image != null)
            //{
            //    float oldZoom = _zoom;
            //    SizeF imageSize = _pictureBox.Image.Size;
            //    PointF scrollPosition = _scrollPanel.AutoScrollPosition;
            //    PointF cursorOffset = new PointF(pos.X + scrollPosition.X,
            //        pos.Y + scrollPosition.Y);

            //    _zoom = Math.Max(0.1f, Math.Min(8.0f, zoom));

            //    // disable the redraw to prevent flicker
            //    SetRedraw(_scrollPanel, false);

            //    // scale the zoom box
            //    _pictureBox.Width = (int)Math.Round(imageSize.Width * _zoom);
            //    _pictureBox.Height = (int)Math.Round(imageSize.Height * _zoom);

            //    // calculate the new scroll position
            //    _scrollPanel.AutoScrollPosition = new Point(
            //        (int)Math.Round(_zoom * pos.X / oldZoom) -
            //        (int)cursorOffset.X,
            //        (int)Math.Round(_zoom * pos.Y / oldZoom) -
            //        (int)cursorOffset.Y);
            //    _scrollPanel.PerformLayout();

            //    // reenable the redraw
            //    SetRedraw(_scrollPanel, true);
            //    _scrollPanel.Refresh();
            //}
        }


        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bLMouseDown = true;

                //Util.stPoint ptViewport = _GeoMap.GetViewPoint();

                //ptGapMouseDown = new Util.stPoint(ptViewport.dPointX - e.X, ptViewport.dPointY - e.Y);
                ptMouseDown = new Point(e.X, e.Y);
            }
        }

        private void panelWaterFall_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < historyPointBrush.Count; i++)
            {
                var pointBrush = historyPointBrush[i];
                float xTern = (float)this.panelDispWaterFall.Size.Width / (float)pointBrush.yValue.Length * (float)_zoom; ;
                float yTern = 5;

                for (int j = 0; j < pointBrush.brush.Length; j++)
                {
                    if (_offsetPoint.X < 0)
                    {
                        _offsetPoint.X = 0;
                    }
                    else if (_offsetPoint.X > chartBoxSize.xSize)
                    {
                        _offsetPoint.X = (int)chartBoxSize.xSize;
                    }

                    if (j == 0)
                    {
                        e.Graphics.FillRectangle(pointBrush.brush[j], (float)0 - _offsetPoint.X, (float)i * yTern , (float)xTern / 2,
                            (float)yTern);
                    }

                    e.Graphics.FillRectangle(pointBrush.brush[j], (float)(j * xTern) - (xTern / 2) - _offsetPoint.X, (float)i * yTern, (float)xTern,
                        (float)yTern);
                }
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            if (Ys == null) return;
            float xTern = (float)this.panelDisp.Size.Width / (float)Ys.Length * (float) _zoom;
            chartBoxSize.xSize = Ys.Length * xTern;
            var _pen = new Pen(Color.Red, 1);
            for (int i = 0; i < Ys.Length; i++)
            {
                if (_offsetPoint.X < 0)
                {
                    _offsetPoint.X = 0;
                }
                else if (_offsetPoint.X > chartBoxSize.xSize - this.panelDisp.Size.Width)
                {
                    _offsetPoint.X = (int)chartBoxSize.xSize - this.panelDisp.Size.Width;
                }

                e.Graphics.DrawLine(_pen, (float)(i * xTern) - _offsetPoint.X, (float)this.panelDisp.Size.Height, (float)(i * xTern) -_offsetPoint.X, (float)(this.panelDisp.Size.Height - Ys[i]));
            }

            var frequenctTern = (double) 8000 / Ys.Length;
            var startFrequency = Math.Round(_offsetPoint.X / xTern * frequenctTern);
            lbFrequectMin.Text = startFrequency.ToString();

            var endFrequency = Math.Round((this.panelDisp.Size.Width / xTern * frequenctTern) + startFrequency);
            lbFrequencyMax.Text = endFrequency.ToString();
        }

        internal void panelMainDraw(double[] yValue)
        {
            Ys = yValue;
            this.panelMain.Refresh();
        }

        private void btnRandomData_Click(object sender, EventArgs e)
        {
            //Random Data
            int bitLength = int.Parse(tbBitLength.Text);
            var bitRandomData = RandomData.GetRandomData(bitLength);
            var byteRandomData = bitRandomData.ToByteArray();

            //Creat Buffer
            var stream = new MemoryStream(byteRandomData);
            var result = Buffer.ReadFully(stream, 32768);

            //map view
            panelMainDraw(result.ToDoubleArray());
            WaterFallPanelDispDraw(result.ToDoubleArray());

            //set component
            tbByteData.Text = byteRandomData.ToStr();
            tbBitData.Text = bitRandomData.ToStr();
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            WaterFallPanelDispClear();
            
            tbBitLength.Text = "";
        }

    }
}
