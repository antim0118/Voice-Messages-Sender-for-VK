using System;
using System.Drawing;
using System.Windows.Forms;

namespace VMVK.Custom_Controls
{
    /// <summary>[!!!] Использовать Val вместо Value (0.0 - 1.0)</summary>
    public class CustomProgressbar : ProgressBar
    {
        Timer animtimer;

        public CustomProgressbar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;

            animtimer = new Timer();
            animtimer.Interval = 1000 / Program.refreshRate;
            animtimer.Tick += Animtimer_Tick;

            ForeBrush = new SolidBrush(ForeColor);
        }

        private void Animtimer_Tick(object sender, EventArgs e)
        {
            _drawval = (_val - _drawval) * Program.step + _drawval;
            this.Invalidate();

            if (Math.Abs(_drawval - _val) < 0.0001f)
                animtimer.Enabled = false;
        }

        #region public vars
        float _val, _lastval, _drawval;
        public float Val
        {
            get => _val;
            set
            {
                _lastval = _val;
                _val = value;
                animtimer.Enabled = true;
            }
        }

        Brush ForeBrush;
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                ForeBrush = new SolidBrush(value);
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(base.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //base.OnPaint(e);

            e.Graphics.FillRectangle(ForeBrush,
                0, 0,
                Width * _drawval - 1f, Height - 1f);
        }
    }
}
