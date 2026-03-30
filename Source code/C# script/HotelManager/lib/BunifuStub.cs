using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Bunifu.Framework.UI
{
    public class BunifuDragControl : Component
    {
        private Control _target;
        private bool _dragging;
        private Point _dragStart;

        public BunifuDragControl() { }
        public BunifuDragControl(IContainer container) { if (container != null) container.Add(this); }

        public bool Fixed { get; set; }
        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }

        public Control TargetControl
        {
            get { return _target; }
            set
            {
                if (_target != null)
                {
                    _target.MouseDown -= OnMouseDown;
                    _target.MouseMove -= OnMouseMove;
                    _target.MouseUp -= OnMouseUp;
                }
                _target = value;
                if (_target != null)
                {
                    _target.MouseDown += OnMouseDown;
                    _target.MouseMove += OnMouseMove;
                    _target.MouseUp += OnMouseUp;
                }
            }
        }

        private void OnMouseDown(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { _dragging = true; _dragStart = e.Location; }
        }

        private void OnMouseMove(object s, MouseEventArgs e)
        {
            if (!_dragging) return;
            var form = _target.FindForm();
            if (form == null) return;
            int dx = Horizontal ? e.X - _dragStart.X : 0;
            int dy = Vertical ? e.Y - _dragStart.Y : 0;
            form.Location = new Point(form.Location.X + dx, form.Location.Y + dy);
        }

        private void OnMouseUp(object s, MouseEventArgs e) { _dragging = false; }
    }

    public class BunifuSeparator : UserControl
    {
        public Color LineColor { get; set; } = Color.FromArgb(224, 224, 224);
        public int LineThickness { get; set; } = 1;
        public int Transparency { get; set; } = 255;
        public bool Vertical { get; set; }

        public BunifuSeparator() { SetStyle(ControlStyles.SupportsTransparentBackColor, true); BackColor = Color.Transparent; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.FromArgb(Transparency, LineColor), LineThickness))
            {
                if (Vertical)
                    e.Graphics.DrawLine(pen, Width / 2, 0, Width / 2, Height);
                else
                    e.Graphics.DrawLine(pen, 0, Height / 2, Width, Height / 2);
            }
        }
    }

    public class BunifuImageButton : PictureBox
    {
        public int Zoom { get; set; }
        public Image ImageActive { get; set; }
    }

    public class BunifuMetroTextbox : UserControl
    {
        private TextBox _inner = new TextBox();
        private Color _borderFocused = Color.SeaGreen;
        private Color _borderIdle = Color.SeaGreen;
        private Color _borderHover = Color.SeaGreen;
        private Color _currentBorder;
        private int _borderThick = 1;
        private bool _hovered;

        public BunifuMetroTextbox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            _currentBorder = _borderIdle;
            _inner.BorderStyle = BorderStyle.None;
            _inner.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Controls.Add(_inner);

            _inner.TextChanged += (s, e) => { TextChanged?.Invoke(this, e); };
            _inner.KeyPress += (s, e) => { KeyPress?.Invoke(this, e); };
            _inner.GotFocus += (s, e) => { _currentBorder = _borderFocused; Invalidate(); Enter?.Invoke(this, e); };
            _inner.LostFocus += (s, e) => { _currentBorder = _borderIdle; Invalidate(); Leave?.Invoke(this, e); };
            _inner.MouseEnter += (s, e) => { if (!_inner.Focused) { _hovered = true; _currentBorder = _borderHover; Invalidate(); } };
            _inner.MouseLeave += (s, e) => { if (!_inner.Focused) { _hovered = false; _currentBorder = _borderIdle; Invalidate(); } };
            this.MouseEnter += (s, e) => { if (!_inner.Focused) { _hovered = true; _currentBorder = _borderHover; Invalidate(); } };
            this.MouseLeave += (s, e) => { if (!_inner.Focused) { _hovered = false; _currentBorder = _borderIdle; Invalidate(); } };

            Size = new Size(250, 29);
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            int pad = _borderThick + 3;
            _inner.Location = new Point(pad, (Height - _inner.Height) / 2);
            _inner.Width = Width - pad * 2;
        }

        public Color BorderColorFocused { get { return _borderFocused; } set { _borderFocused = value; } }
        public Color BorderColorIdle { get { return _borderIdle; } set { _borderIdle = value; _currentBorder = _borderIdle; Invalidate(); } }
        public Color BorderColorMouseHover { get { return _borderHover; } set { _borderHover = value; } }
        public int BorderThickness { get { return _borderThick; } set { _borderThick = value; Invalidate(); } }
        public string characterCasing { get; set; }

        public new Cursor Cursor { get { return _inner.Cursor; } set { _inner.Cursor = value; base.Cursor = value; } }
        public new Font Font { get { return _inner.Font; } set { _inner.Font = value; OnLayout(null); Invalidate(); } }
        public new Color ForeColor { get { return _inner.ForeColor; } set { _inner.ForeColor = value; } }
        public new Color BackColor { get { return base.BackColor; } set { base.BackColor = value; _inner.BackColor = value; } }

        public bool isPassword { get { return _inner.UseSystemPasswordChar; } set { _inner.UseSystemPasswordChar = value; } }
        public int MaxLength { get { return _inner.MaxLength; } set { _inner.MaxLength = value; } }

        public new string Text { get { return _inner.Text; } set { _inner.Text = value; } }
        public new HorizontalAlignment TextAlign { get { return _inner.TextAlign; } set { _inner.TextAlign = value; } }

        public new event EventHandler TextChanged;
        public new event KeyPressEventHandler KeyPress;
        public new event EventHandler Enter;
        public new event EventHandler Leave;

        public void SelectAll() { _inner.SelectAll(); }
        public new void Focus() { _inner.Focus(); }
        public new bool Focused { get { return _inner.Focused; } }

        protected override void OnClick(EventArgs e) { base.OnClick(e); _inner.Focus(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor == Color.Empty ? Color.White : BackColor);
            using (var pen = new Pen(_currentBorder, _borderThick))
            {
                var rect = new Rectangle(_borderThick / 2, _borderThick / 2, Width - _borderThick, Height - _borderThick);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }

    public class BunifuCheckbox : UserControl
    {
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; Invalidate(); OnChange?.Invoke(this, EventArgs.Empty); }
        }
        public Color ChechedOffColor { get; set; } = Color.FromArgb(132, 135, 140);
        public Color CheckedOnColor { get; set; } = Color.SeaGreen;
        public new event EventHandler OnChange;

        public BunifuCheckbox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(20, 20);
            Cursor = Cursors.Hand;
        }

        protected override void OnClick(EventArgs e) { Checked = !Checked; base.OnClick(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var fillColor = _checked ? CheckedOnColor : ChechedOffColor;
            using (var brush = new SolidBrush(fillColor))
                g.FillRectangle(brush, 0, 0, Width, Height);
            if (_checked)
            {
                using (var pen = new Pen(Color.White, 2f))
                {
                    g.DrawLine(pen, 4, Height / 2, Width / 2 - 1, Height - 5);
                    g.DrawLine(pen, Width / 2 - 1, Height - 5, Width - 4, 4);
                }
            }
        }
    }

    public class BunifuDatepicker : UserControl
    {
        private DateTimePicker _inner = new DateTimePicker();

        public BunifuDatepicker()
        {
            _inner.Dock = DockStyle.Fill;
            Controls.Add(_inner);
            _inner.ValueChanged += (s, e) => onValueChanged?.Invoke(this, e);
            Size = new Size(200, 29);
        }

        public new Color BackColor { get { return _inner.CalendarMonthBackground; } set { try { _inner.CalendarMonthBackground = value; } catch { } } }
        public int BorderRadius { get; set; }
        public new Color ForeColor { get { return _inner.CalendarForeColor; } set { try { _inner.CalendarForeColor = value; } catch { } } }
        public new Font Font { get { return _inner.Font; } set { _inner.Font = value; } }
        public Color HeaderColor { get; set; }
        public DateTime Value { get { return _inner.Value; } set { _inner.Value = value; } }
        public new string Text { get { return _inner.Text; } set { } }
        public DateTimePickerFormat Format { get { return _inner.Format; } set { _inner.Format = value; } }
        public string FormatCustom { get { return _inner.CustomFormat; } set { _inner.CustomFormat = value; } }
        public event EventHandler onValueChanged;
    }

    public class BunifuThinButton2 : UserControl
    {
        private bool _pressed;
        private bool _hovered;

        public int ActiveBorderThickness { get; set; } = 1;
        public int ActiveCornerRadius { get; set; } = 20;
        public Color ActiveFillColor { get; set; } = Color.SeaGreen;
        public Color ActiveForecolor { get; set; } = Color.White;
        public Color ActiveLineColor { get; set; } = Color.SeaGreen;
        public string ButtonText { get; set; } = "";
        public int IdleBorderThickness { get; set; } = 1;
        public int IdleCornerRadius { get; set; } = 20;
        public Color IdleFillColor { get; set; } = Color.White;
        public Color IdleForecolor { get; set; } = Color.SeaGreen;
        public Color IdleLineColor { get; set; } = Color.SeaGreen;
        public new ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleCenter;

        public BunifuThinButton2()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(150, 40);
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; _pressed = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _pressed = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _pressed = false; Invalidate(); base.OnMouseUp(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : Color.White);

            bool active = _pressed || _hovered;
            var fill = active ? ActiveFillColor : IdleFillColor;
            var line = active ? ActiveLineColor : IdleLineColor;
            var fore = active ? ActiveForecolor : IdleForecolor;
            int radius = active ? ActiveCornerRadius : IdleCornerRadius;
            int thick = active ? ActiveBorderThickness : IdleBorderThickness;

            var rect = new Rectangle(thick, thick, Width - thick * 2 - 1, Height - thick * 2 - 1);
            var path = RoundedRect(rect, Math.Min(radius, rect.Height / 2));
            using (var brush = new SolidBrush(fill))
                g.FillPath(brush, path);
            using (var pen = new Pen(line, thick))
                g.DrawPath(pen, path);

            var textRect = new Rectangle(0, 0, Width, Height);
            TextRenderer.DrawText(g, ButtonText, Font, textRect, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private static GraphicsPath RoundedRect(Rectangle r, int rad)
        {
            var path = new GraphicsPath();
            int d = rad * 2;
            if (d <= 0) { path.AddRectangle(r); return path; }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    public class BunifuFlatButton : UserControl
    {
        private bool _hovered;
        public bool Active { get; set; }
        public Color Activecolor { get; set; } = Color.SeaGreen;
        public new Color BackColor { get { return base.BackColor; } set { base.BackColor = value; } }
        public int BorderRadius { get; set; }
        public string ButtonText { get; set; } = "";
        public Color DisabledColor { get; set; }
        public Color Iconcolor { get; set; }
        public Image Iconimage { get; set; }
        public Image Iconimage_Selected { get; set; }
        public Image Iconimage_right { get; set; }
        public Image Iconimage_right_Selected { get; set; }
        public int IconMarginLeft { get; set; }
        public int IconMarginRight { get; set; }
        public bool IconRightVisible { get; set; }
        public double IconRightZoom { get; set; }
        public bool IconVisible { get; set; } = true;
        public object IconZoom { get; set; } = 50D;
        public bool IsTab { get; set; }
        public Color Normalcolor { get; set; } = Color.FromArgb(46, 139, 87);
        public Color OnHovercolor { get; set; } = Color.FromArgb(36, 129, 77);
        public Color OnHoverTextColor { get; set; } = Color.White;
        public bool selected { get; set; }
        public new ContentAlignment TextAlign { get; set; } = ContentAlignment.MiddleLeft;
        public Font TextFont { get; set; }
        public object TextMarginLeft { get; set; } = 0;
        public Color Textcolor { get; set; } = Color.White;

        public BunifuFlatButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(200, 48);
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bg = _hovered ? OnHovercolor : Normalcolor;
            using (var brush = new SolidBrush(bg))
                g.FillRectangle(brush, ClientRectangle);

            int marginLeft = 0;
            try { marginLeft = Convert.ToInt32(TextMarginLeft); } catch { }
            int iconSize = 0;
            try { iconSize = (int)((double)(Convert.ToDouble(IconZoom)) / 100.0 * Math.Min(Width, Height)); } catch { }

            int x = IconMarginLeft + 4;
            if (IconVisible && Iconimage != null && iconSize > 0)
            {
                int iy = (Height - iconSize) / 2;
                g.DrawImage(Iconimage, x, iy, iconSize, iconSize);
                x += iconSize + 4;
            }

            var font = TextFont ?? Font;
            var textColor = _hovered ? OnHoverTextColor : Textcolor;
            var textRect = new Rectangle(x + marginLeft, 0, Width - x - marginLeft - 4, Height);
            TextRenderer.DrawText(g, ButtonText, font, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }

    public class BunifuGradientPanel : Panel
    {
        public Color GradientBottomLeft { get; set; } = Color.SeaGreen;
        public Color GradientBottomRight { get; set; } = Color.SeaGreen;
        public Color GradientTopLeft { get; set; } = Color.SeaGreen;
        public Color GradientTopRight { get; set; } = Color.SeaGreen;
        public int Quality { get; set; } = 10;

        public BunifuGradientPanel() { SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true); }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;
            using (var brush = new LinearGradientBrush(ClientRectangle, GradientTopLeft, GradientBottomRight, LinearGradientMode.ForwardDiagonal))
                e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }

    public class BunifuTileButton : UserControl
    {
        private bool _hovered;
        public new Color BackColor { get { return base.BackColor; } set { base.BackColor = value; } }
        public Color color { get; set; } = Color.SeaGreen;
        public Color colorActive { get; set; } = Color.MediumSeaGreen;
        public Image Image { get; set; }
        public object ImagePosition { get; set; }
        public int ImageZoom { get; set; } = 36;
        public string LabelText { get; set; } = "";
        public object LabelPosition { get; set; }

        public BunifuTileButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Size = new Size(110, 95);
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            var bg = _hovered ? colorActive : color;
            using (var brush = new SolidBrush(bg))
                g.FillRectangle(brush, ClientRectangle);

            if (Image != null)
            {
                int imgSize = ImageZoom > 0 ? ImageZoom : 36;
                int ix = (Width - imgSize) / 2;
                int iy = Height / 3 - imgSize / 2;
                if (iy < 2) iy = 2;
                g.DrawImage(Image, ix, iy, imgSize, imgSize);
            }

            if (!string.IsNullOrEmpty(LabelText))
            {
                var textRect = new Rectangle(2, Height * 2 / 3, Width - 4, Height / 3);
                TextRenderer.DrawText(g, LabelText, Font, textRect, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            }
        }
    }

    public class BunifuElipse : Component
    {
        public BunifuElipse() { }
        public BunifuElipse(IContainer container) { if (container != null) container.Add(this); }
        public int ElipseRadius { get; set; }
        public Control TargetControl { get; set; }
    }

    public class BunifuCustomLabel : Label { }

    public class BunifuCards : Panel
    {
        public new Color BackColor { get { return base.BackColor; } set { base.BackColor = value; } }
        public int BorderRadius { get; set; }
        public int BottomSahable { get; set; }
        public Color LeftSahable { get; set; }
        public Color ShadowColor { get; set; }
        public int ShadowDepth { get; set; }
    }
}
