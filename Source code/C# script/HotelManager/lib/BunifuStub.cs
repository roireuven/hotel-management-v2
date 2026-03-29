using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bunifu.Framework.UI
{
    public class BunifuDragControl : Component
    {
        public BunifuDragControl() { }
        public BunifuDragControl(IContainer container) { if (container != null) container.Add(this); }
        public bool Fixed { get; set; }
        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }
        public Control TargetControl { get; set; }
    }

    public class BunifuSeparator : UserControl
    {
        public Color LineColor { get; set; }
        public int LineThickness { get; set; }
        public int Transparency { get; set; }
        public bool Vertical { get; set; }
    }

    public class BunifuImageButton : PictureBox
    {
        public int Zoom { get; set; }
        public Image ImageActive { get; set; }
    }

    public class BunifuFlatButton : UserControl
    {
        public bool Active { get; set; }
        public Color Activecolor { get; set; }
        public new Color BackColor { get; set; }
        public int BorderRadius { get; set; }
        public string ButtonText { get; set; }
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
        public bool IconVisible { get; set; }
        public object IconZoom { get; set; }
        public bool IsTab { get; set; }
        public Color Normalcolor { get; set; }
        public Color OnHovercolor { get; set; }
        public Color OnHoverTextColor { get; set; }
        public bool selected { get; set; }
        public new ContentAlignment TextAlign { get; set; }
        public Font TextFont { get; set; }
        public object TextMarginLeft { get; set; }
        public Color Textcolor { get; set; }
    }

    public class BunifuGradientPanel : Panel
    {
        public Color GradientBottomLeft { get; set; }
        public Color GradientBottomRight { get; set; }
        public Color GradientTopLeft { get; set; }
        public Color GradientTopRight { get; set; }
        public int Quality { get; set; }
    }

    public class BunifuThinButton2 : UserControl
    {
        public int ActiveBorderThickness { get; set; }
        public int ActiveCornerRadius { get; set; }
        public Color ActiveFillColor { get; set; }
        public Color ActiveForecolor { get; set; }
        public Color ActiveLineColor { get; set; }
        public string ButtonText { get; set; }
        public int IdleBorderThickness { get; set; }
        public int IdleCornerRadius { get; set; }
        public Color IdleFillColor { get; set; }
        public Color IdleForecolor { get; set; }
        public Color IdleLineColor { get; set; }
        public new ContentAlignment TextAlign { get; set; }
    }

    public class BunifuMetroTextbox : UserControl
    {
        public Color BorderColorFocused { get; set; }
        public Color BorderColorIdle { get; set; }
        public Color BorderColorMouseHover { get; set; }
        public int BorderThickness { get; set; }
        public string characterCasing { get; set; }
        public new Cursor Cursor { get; set; }
        public new Font Font { get; set; }
        public new Color ForeColor { get; set; }
        public bool isPassword { get; set; }
        public int MaxLength { get; set; }
        public new string Text { get; set; }
        public new HorizontalAlignment TextAlign { get; set; }
        public new Color BackColor { get; set; }
        public new event EventHandler TextChanged;
        public new event KeyPressEventHandler KeyPress;
        public new event EventHandler Enter;
        public new event EventHandler Leave;

        public void SelectAll() { }
    }

    public class BunifuCheckbox : UserControl
    {
        public bool Checked { get; set; }
        public Color ChechedOffColor { get; set; }
        public Color CheckedOnColor { get; set; }
        public new event EventHandler OnChange;
    }

    public class BunifuDatepicker : UserControl
    {
        public new Color BackColor { get; set; }
        public int BorderRadius { get; set; }
        public new Color ForeColor { get; set; }
        public new Font Font { get; set; }
        public Color HeaderColor { get; set; }
        public DateTime Value { get; set; }
        public DateTimePickerFormat Format { get; set; }
        public string FormatCustom { get; set; }
        public event EventHandler onValueChanged;
    }

    public class BunifuTileButton : UserControl
    {
        public new Color BackColor { get; set; }
        public Color color { get; set; }
        public Color colorActive { get; set; }
        public Image Image { get; set; }
        public object ImagePosition { get; set; }
        public int ImageZoom { get; set; }
        public string LabelText { get; set; }
        public object LabelPosition { get; set; }
    }

    public class BunifuElipse : Component
    {
        public BunifuElipse() { }
        public BunifuElipse(IContainer container) { if (container != null) container.Add(this); }
        public int ElipseRadius { get; set; }
        public Control TargetControl { get; set; }
    }

    public class BunifuCustomLabel : Label
    {
    }

    public class BunifuCards : Panel
    {
        public new Color BackColor { get; set; }
        public int BorderRadius { get; set; }
        public int BottomSahable { get; set; }
        public Color LeftSahable { get; set; }
        public Color ShadowColor { get; set; }
        public int ShadowDepth { get; set; }
    }
}
