using System;
using System.Drawing;
using System.Windows.Forms;

namespace VMVK
{
    public class CustomLabel : Label
    {
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                //_foreColor_Base = base.ForeColor;
                base.ForeColor = value;
                _foreColorPercent = 0.0f;
                redraw_timer.Enabled = true;
            }
        }

        Color _foreColor;//, _foreColor_Base;
        float _foreColorPercent;
        Timer redraw_timer;

        public CustomLabel()
        {
            SetStyle(ControlStyles.UserPaint, true);

            redraw_timer = new Timer();
            redraw_timer.Interval = 1000 / Program.refreshRate;
            redraw_timer.Tick += Redraw_timer_Tick;

            _foreColor = ForeColor;
        }

        private void Redraw_timer_Tick(object sender, EventArgs e)
        {
            _foreColor = Color.FromArgb((byte)((base.ForeColor.A - _foreColor.A) * _foreColorPercent + _foreColor.A),
                (byte)((base.ForeColor.R - _foreColor.R) * _foreColorPercent + _foreColor.R),
                (byte)((base.ForeColor.G - _foreColor.G) * _foreColorPercent + _foreColor.G),
                (byte)((base.ForeColor.B - _foreColor.B) * _foreColorPercent + _foreColor.B));
            this.Invalidate();

            _foreColorPercent += Program.step;
            if (_foreColorPercent >= 1.0f)
                redraw_timer.Enabled = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(base.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //base.OnPaint(e);

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(_foreColor), 0, 0);
        }
    }
}
