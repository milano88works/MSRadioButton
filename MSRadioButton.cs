using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace milano88.UI.Controls
{
    public class MSRadioButton : RadioButton
    {

        private Color checkedColor = Color.DodgerBlue;
        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color CheckedColor
        {
            get { return checkedColor; }
            set { checkedColor = value; this.Invalidate(); }
        }

        private Color unCheckedColor = Color.Gray;
        [Category("Custom Properties")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color UnCheckedColor
        {
            get { return unCheckedColor; }
            set { unCheckedColor = value; this.Invalidate(); }
        }

        [DefaultValue(typeof(Font), "Segoe UI, 9pt")]
        public override Font Font { get => base.Font; set => base.Font = value; }

        [DefaultValue("msRadioButton")]
        public override string Text { get => base.Text; set => base.Text = value; }

        public MSRadioButton()
        {
            base.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 14F;
            float rbCheckSize = 6F;

            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2,
                Width = rbBorderSize,
                Height = rbBorderSize
            };

            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
                Y = (this.ClientRectangle.Height - rbCheckSize) / 2,
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                graphics.Clear(this.BackColor);
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);
                    graphics.FillEllipse(brushRbCheck, rectRbCheck);
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder);
                }
                TextRenderer.DrawText(graphics, this.Text, this.Font, new Point((int)rbBorderSize + 4, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2), this.ForeColor);
            }
        }
    }
}
