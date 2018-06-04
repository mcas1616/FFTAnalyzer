using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFChart
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
            : base()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }

    public partial class Form1 : Form
    {
        private DoubleBufferedPanel panelDisp;

        public Form1()
        {
            InitializeComponent();

            panelMain.MouseWheel += panelMain_MouseWheel;

            this.panelDisp = new DoubleBufferedPanel();
            this.panelDisp.BackColor = System.Drawing.Color.Black;
            this.panelDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisp.Location = new System.Drawing.Point(0, 0);
            this.panelDisp.Name = "panelDisp";
            this.panelDisp.Size = new System.Drawing.Size(1534, 815);
            this.panelDisp.TabIndex = 1;
            this.panelDisp.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            //this.panelDisp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            //this.panelDisp.MouseEnter += new System.EventHandler(this.panelMain_MouseEnter);
            //this.panelDisp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseMove);
            //this.panelDisp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseUp);

            //this.panelDisp.DragOver += panelDisp_DragOver;
            //this.panelDisp.DragDrop += panelDisp_DragDrop;

            this.panelMain.Controls.Add(this.panelDisp);

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

            var _pen = new Pen(Color.Red, 1);
            e.Graphics.DrawLine(_pen, (float)1, (float)1, (float)2, (float)2);
        }


        private void panelMain_MouseWheel(object sender, MouseEventArgs e)
        {
            //double dScale = _GeoMap.GetMeterPerPixel();
            ////double dScale = _DrawMap.GetBitmapScale();

            //double dTemp = 0.0;

            //if (e.Delta > 2)            // 확대
            //{
            //    dScale -= 5.0;
            //    dTemp = -1.5;
            //}
            //else if (e.Delta < -2)          // 축소
            //{
            //    dScale += 5.0;
            //    dTemp = 1.5;
            //}

            //if (dScale <= 100.0)
            //    dScale = 100.0;
            //else if (dScale >= 1000.0)
            //    dScale = 1000.0;

            ////             if (e.Delta > 2)
            ////                 dScale /= 1.1;
            ////             else if (e.Delta < -2)
            ////                 dScale *= 1.1;
            //// 
            ////             if (dScale <= 0.1)
            ////                 dScale = 0.1;
            ////             else if (dScale >= 2.0)
            ////                 dScale = 2.0;

            ////             GlobalCoordinates coord = _GeoMap.GetGeoPosition(new Util.stPoint(panelMain.Width / 2, panelMain.Height / 2));
            ////             
            ////             _GeoMap.ChangeMeterPerPixel(dScale);
            //// 
            ////             Util.stPoint ptZoomed = _GeoMap.GetWindowPos(coord);
            ////             Util.stPoint ptGap = new Util.stPoint(panelMain.Width / 2 - ptZoomed.dPointX, panelMain.Height / 2 - ptZoomed.dPointY);
            ////             Util.stPoint ptViewPoint = _GeoMap.GetViewPoint();
            //// 
            ////             _GeoMap.SetViewPoint(new Util.stPoint(ptViewPoint.dPointX + ptGap.dPointX, ptViewPoint.dPointY + ptGap.dPointY));

            //Util.stPoint ptLogical = new Util.stPoint();
            //_GeoMap.DeviceToLogical(new Util.stPoint(panelMain.Width / 2, panelMain.Height / 2), out ptLogical);

            //GlobalCoordinates coord = _GeoMap.GetGeoPosition(ptLogical);

            //_GeoMap.ChangeMeterPerPixel(dScale);
            //Util.stPoint ptZoomed = _GeoMap.GetWindowPos(coord);

            //Util.stPoint ptDevice = new Util.stPoint();
            //_GeoMap.LogicalToDevice(ptZoomed, out ptDevice);

            //Util.stPoint ptGap = new Util.stPoint(panelMain.Width / 2 - ptDevice.dPointX, panelMain.Height / 2 - ptDevice.dPointY);

            //Util.stPoint ptViewPoint = _GeoMap.GetViewPoint();
            //_GeoMap.SetViewPoint(new Util.stPoint(ptViewPoint.dPointX + ptGap.dPointX, ptViewPoint.dPointY + ptGap.dPointY));

            ////_DrawMap.DrawMapFile();
            //panelDisp.Invalidate(false);
        }



        

        public static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }

        private BitArray GetRandomData()
        {
            Random rnd = new Random();
            BitArray bits = new BitArray(32768, false);

            for (int i = 0; i < bits.Length; i++)
            {
                bits.Set(i, rnd.Next(2) == 1 ? true : false);
            }
            return bits;
        }

        private string BitArrayToStr(BitArray randBitArray)
        {
            string retrnString = "";

            for (int i = 0; i < randBitArray.Length; i++)
            {
                if (randBitArray[i] == true)
                {
                    retrnString += "1";
                }
                else
                {
                    retrnString += "0";
                }

                if (i % 8 == 7)
                {
                    retrnString += "/";
                }
            }
            return retrnString;

        }

        private string ByteArrayToStr(byte[] bytes)
        {
            string retrnString = "";
            foreach (var value in bytes)
            {
                retrnString += value + "/";
            }
            return retrnString;
        }
        


        private void btnGetData_Click(object sender, EventArgs e)
        {
            var randBitArray = GetRandomData();
            tbBitData.Text = BitArrayToStr(randBitArray);

            var bytes = ToByteArray(randBitArray);
            tbByteData.Text = ByteArrayToStr(bytes);

            var test_Stream = new MemoryStream(bytes);
            var result = ReadFully(test_Stream, 32768);
            
            double[] xs = new double[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                xs[i] = (double) i;
            }

            scottPlotUC1.Xs = xs;
            scottPlotUC1.Ys = result.ToDoubleArray(); //235999 -> Ys.Lenght = 471998
        }
    }
    public static class Extensions
    {
        public static double[] ToDoubleArray(this byte[] bytes)
        {
            double[] doubles = new double[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
                doubles[i] = Convert.ToDouble(bytes[i]);
            return doubles;
        }
    }
}
