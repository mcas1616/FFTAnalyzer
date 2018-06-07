using System.Drawing;
using System.Windows.Forms;

namespace Spectrum
{
    public class DoubleBufferedMainPanel : Panel
    {
        public DoubleBufferedMainPanel()
            : base()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
