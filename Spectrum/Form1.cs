using System;
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
        
        private readonly DoubleBufferedWaterFallPanel WaterFallpanelDisp;
        private readonly DoubleBufferedWaterFallGuidePanel WaterFallGuidepanelDisp;
        private readonly DoubleBufferedMainPanel panelDisp;
        private double[] Ys;
        private float _zoom;
        private Point _offsetPoint;
        private bool bLMouseDown;
        private Point ptMouseDown;

        public Form1()
        {
            InitializeComponent();

            RandomData = new RandomData();
            Buffer = new Buffer();
            
            WaterFallpanelDisp = new DoubleBufferedWaterFallPanel();
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
            panelWaterFall.Controls.Add(WaterFallpanelDisp);
            panelWaterFallGuide.Controls.Add(WaterFallGuidepanelDisp);
            WaterFallGuidepanelDisp.Draw();
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
            //DisplayMouseInfo(new Point(e.X, e.Y));

            if (bLMouseDown)
            {
            //    Util.stPoint ptViewport = new Util.stPoint();
            //    ptViewport.dPointX = e.X + ptGapMouseDown.dPointX;
            //    ptViewport.dPointY = e.Y + ptGapMouseDown.dPointY;

            //    _GeoMap.SetViewPoint(ptViewport);

            //    //_DrawMap.DrawMapFile();
            //    panelDisp.Invalidate(false);

                _offsetPoint.X += e.X - ptMouseDown.X;
                _offsetPoint.Y += e.Y - ptMouseDown.Y;

                this.panelMain.Refresh();
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
            _zoom = Math.Max(0.1f, Math.Min(10.0f, zoom));

            _offsetPoint.X += (int) Math.Round(_zoom * pos.X / oldZoom) -
                             (int) cursorOffset.X;
            _offsetPoint.Y = 0;

            this.panelMain.Refresh();

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

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            if (Ys == null) return;
            float xTern = (float)this.panelDisp.Size.Width / (float)Ys.Length * (float) _zoom;
            var _pen = new Pen(Color.Red, 1);
            for (int i = 0; i < Ys.Length; i++)
            {
                if (_offsetPoint.X < 0)
                {
                    _offsetPoint.X = 0;
                } else if (_offsetPoint.X > this.panelDisp.Size.Width)
                {
                    _offsetPoint.X = this.panelDisp.Size.Width;
                }
                
                e.Graphics.DrawLine(_pen, (float)(i * xTern) - _offsetPoint.X, (float)this.panelDisp.Size.Height, (float)(i * xTern) -_offsetPoint.X, (float)(this.panelDisp.Size.Height - Ys[i]));
            }
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
            WaterFallpanelDisp.Draw(result.ToDoubleArray());

            //set component
            tbByteData.Text = byteRandomData.ToStr();
            tbBitData.Text = bitRandomData.ToStr();
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            WaterFallpanelDisp.Clear();
            
            tbBitLength.Text = "";
        }

    }
}
