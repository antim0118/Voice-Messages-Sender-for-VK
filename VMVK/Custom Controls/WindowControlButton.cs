using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VMVK.Custom_Controls
{
    public class WindowControlButton : Button
    {
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                //_foreColor_Base = base.ForeColor;
                base.ForeColor = value;
                _p = new Pen(ForeColor, 2f);
                _fb = new SolidBrush(ForeColor);
                _bb = new SolidBrush(BackColor);
            }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                _bb = new SolidBrush(BackColor);
            }
        }


        bool isHovered = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            bool h = isHovered;
            isHovered = true;
            if (!h)
                animtimer.Enabled = true;
            Cursor = Cursors.Hand;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            bool h = isHovered;
            isHovered = false;
            if (h)
                animtimer.Enabled = true;
            Cursor = Cursors.Default;
        }

        Timer animtimer;

        public WindowControlButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            this.Text = string.Empty;

            animtimer = new Timer();
            animtimer.Interval = 1000 / Program.refreshRate;
            animtimer.Tick += Animtimer_Tick;

            _fb = new SolidBrush(ForeColor);
            _p = new Pen(ForeColor, 2f);
            _bb = new SolidBrush(BackColor);
        }

        float _fade = 0.0f;
        private void Animtimer_Tick(object sender, EventArgs e)
        {
            if (isHovered)
                _fade += Program.step;
            else
                _fade -= Program.step;
            if (_fade > 1.0f) _fade = 1.0f;
            else if (_fade < 0.0f) _fade = 0.0f;

            this.Invalidate();

            if (_fade <= 0.0f || _fade >= 1.0f)
                animtimer.Enabled = false;
        }


        public enum IconPatterns { Hide, Exit, Settings }
        IconPatterns _iconpattern = IconPatterns.Hide;
        [Category("Custom Properties")]
        public IconPatterns iconPattern
        {
            get => _iconpattern;
            set => _iconpattern = value;
        }


        Pen _p;
        Pen ForePen
        {
            get
            {
                if (_p == null)
                    _p = new Pen(ForeColor, 2f);
                return _p;
            }
        }
        Brush _fb, _bb;
        Brush ForeBrush
        {
            get
            {
                if (_fb == null)
                    _fb = new SolidBrush(ForeColor);
                return _fb;
            }
        }
        Brush BackBrush
        {
            get
            {
                if (_bb == null)
                    _bb = new SolidBrush(BackColor);
                return _bb;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(base.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((byte)(180 * _fade), Color.Gray)), -1, -1, Width + 2, Height + 2);

            if (iconPattern == IconPatterns.Hide)
            {
                e.Graphics.DrawLine(ForePen, Width * 0.2f, Height * 0.5f, Width * 0.8f, Height * 0.5f);
            }
            else if (iconPattern == IconPatterns.Exit)
            {
                e.Graphics.DrawLine(ForePen, Width * 0.2f, Height * 0.2f, Width * 0.8f, Height * 0.8f);
                e.Graphics.DrawLine(ForePen, Width * 0.2f, Height * 0.8f, Width * 0.8f, Height * 0.2f);
            }
            else if (iconPattern == IconPatterns.Settings)
            {
                float f11 = 0.2f, f12 = 0.55f;
                e.Graphics.FillEllipse(ForeBrush, Width * f11, Height * f11, Width * f12, Height * f12);

                float f21 = 0.225f, f22 = 0.75f;
                e.Graphics.DrawLine(ForePen, Width * f21, Height * f21, Width * f22, Height * f22);
                e.Graphics.DrawLine(ForePen, Width * f21, Height * f22, Width * f22, Height * f21);

                float f31 = 0.125f, f32 = 0.855f;
                e.Graphics.DrawLine(ForePen, Width * f31, Height * 0.5f, Width * f32, Height * 0.5f);
                e.Graphics.DrawLine(ForePen, Width * 0.5f, Height * f31, Width * 0.5f, Height * f32);

                float f91 = 0.275f, f92 = 0.4f;
                e.Graphics.FillEllipse(BackBrush, Width * f91, Height * f91, Width * f92, Height * f92);
                e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb((byte)(180 * _fade), Color.Gray)), Width * f91, Height * f91, Width * f92, Height * f92);
            }
        }
    }
}
