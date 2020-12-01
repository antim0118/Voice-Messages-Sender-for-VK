using System.Drawing;
using System.Windows.Forms;

namespace VMVK.Custom_Controls
{
    public class WaitingControl : Control
    {
        public WaitingControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.LightGray)), -1, -1, Width + 2, Height + 2);
        }
    }
}
