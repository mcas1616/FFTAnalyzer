using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum
{
    public partial class Form1 : Form
    {
        private readonly RandomData RandomData;
        private readonly Buffer Buffer;
        private readonly DoubleBufferedMainPanel mainPanelDisp;
        private readonly DoubleBufferedWaterFallPanel WaterFallpanelDisp;
        private readonly DoubleBufferedWaterFallGuidePanel WaterFallGuidepanelDisp;

        public Form1()
        {
            InitializeComponent();

            RandomData = new RandomData();
            Buffer = new Buffer();
            mainPanelDisp = new DoubleBufferedMainPanel();
            WaterFallpanelDisp = new DoubleBufferedWaterFallPanel();
            WaterFallGuidepanelDisp = new DoubleBufferedWaterFallGuidePanel();

            panelMain.Controls.Add(mainPanelDisp);
            panelWaterFall.Controls.Add(WaterFallpanelDisp);
            panelWaterFallGuide.Controls.Add(WaterFallGuidepanelDisp);
            WaterFallGuidepanelDisp.Draw();
        }

        private async void btnRandomData_Click(object sender, EventArgs e)
        {
            //Random Data
            int bitLength = int.Parse(tbBitLength.Text);
            var bitRandomData = RandomData.GetRandomData(bitLength);
            var byteRandomData = bitRandomData.ToByteArray();

            //Creat Buffer
            
            var stream = new MemoryStream(byteRandomData);
            var result = Buffer.ReadFully(stream, 32768);

            //map view
            mainPanelDisp.Draw(result.ToDoubleArray());
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
