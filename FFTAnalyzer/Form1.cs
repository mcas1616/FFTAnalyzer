using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace FFTAnalyzer
{
    public partial class Form1 : Form
    {
        public WaveIn wi;
        public BufferedWaveProvider bwp;
        public Int32 envelopeMax;

        private int RATE = 380000; // sample rate of the sound card
        private int BUFFERSIZE = (int)Math.Pow(2, 9); // must be a multiple of 2
        
        
        public Form1()
        {
            
            InitializeComponent();

            // see what audio devices are available
            int devcount = WaveIn.DeviceCount;
            Console.Out.WriteLine("Device Count: {0}.", devcount);

            // get the WaveIn class started
            WaveIn wi = new WaveIn();
            wi.DeviceNumber = 0;
            wi.WaveFormat = new WaveFormat(RATE, 16, 1);
            wi.BufferMilliseconds = (int)(BUFFERSIZE / (double)RATE * 1000.0);

            // create a wave buffer and start the recording
            wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
            bwp = new BufferedWaveProvider(wi.WaveFormat);
            bwp.BufferLength = BUFFERSIZE * 2;

            bwp.DiscardOnBufferOverflow = true;
            wi.StartRecording();
        }

        // adds data to the audio recording buffer
        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        

        public void UpdateAudioGraph()
        {
            // read the bytes from the stream
            int frameSize = BUFFERSIZE;
            var frames = new byte[frameSize];
            bwp.Read(frames, 0, frameSize);
            if (frames.Length == 0) return;
            if (frames[frameSize - 2] == 0) return;

            timer1.Enabled = false;

            // convert it to int32 manually (and a double for scottplot)
            int SAMPLE_RESOLUTION = 16;
            int BYTES_PER_POINT = SAMPLE_RESOLUTION / 8;
            int valsSize = frames.Length / BYTES_PER_POINT;
            //int valsSize = 471998;
            double[] vals = new double[valsSize]; //471998 -> frames.Length = 943996
            double[] Ys = new double[valsSize];   //471998 -> frames.Length = 943996
            double[] Xs = new double[valsSize];   //471998 -> frames.Length = 943996
            for (int i = 0; i < vals.Length; i++)
            {
                // bit shift the byte buffer into the right variable format
                byte hByte = frames[i * 2 + 1];
                byte lByte = frames[i * 2 + 0];
                vals[i] = (int)(short)((hByte << 8) | lByte);
                Xs[i] = (double)i / Ys.Length * RATE / 1000.0; // units are in kHz
            }
            
            //update scottplot (FFT, frequency domain)
            Ys = FFT(vals);
            scottPlotUC1.Xs = Xs.Take(Xs.Length / 2).ToArray(); //235999 -> Xs.Length = 471998
            scottPlotUC1.Ys = Ys.Take(Ys.Length / 2).ToArray(); //235999 -> Ys.Lenght = 471998

            scottPlotUC3.Xs = Xs.Take(Xs.Length / 2).ToArray();
            scottPlotUC3.Ys = Ys.Take(Ys.Length / 2).ToArray();

            Console.ReadLine();
            //// update the displays
            scottPlotUC1.UpdateGraph();
            scottPlotUC3.UpdateGraph("WaterFall");

            Application.DoEvents();
            scottPlotUC1.Update();
            //scottPlotUC2.Update();

            timer1.Enabled = true;

        }

        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length]; // this is where we will store the output (fft)
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length]; // the FFT function requires complex format
            for (int i = 0; i < data.Length; i++)
            {
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0); // make it complex format (imaginary = 0)
            }
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
            {
                //fft[i] = fftComplex[i].Magnitude; // back to double
                fft[i] = 20 * Math.Log10(fftComplex[i].Magnitude); // convert to dB
            }
            return fft;
            //todo: this could be much faster by reusing variables
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAudioGraph();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateAudioGraph();
        }
    }
}
