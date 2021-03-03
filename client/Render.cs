using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    class Render
    {
        public Render()
        { }
        public void MouseCheckButtons(Button button, PaintEventHandler pEHandler, Point location)
        {
            if (location.X > button.Location.X &&
               location.X < button.Location.X + button.Width &&
               location.Y > button.Location.Y &&
               location.Y < button.Location.Y + button.Height)
            {
                if (!(bool)button.Tag)
                {
                    var temp = new PaintEventHandler(pEHandler);
                    temp?.Invoke(button, new PaintEventArgs(button.CreateGraphics(), button.ClientRectangle));
                }
                button.Tag = true;
            }
            else if ((bool)button.Tag)
            {
                button.Tag = false;
                var temp = new PaintEventHandler(pEHandler);
                temp?.Invoke(button, new PaintEventArgs(button.CreateGraphics(), button.ClientRectangle));
            }
        }
        public void ButtonRender(PaintEventArgs e, Button button, Brush brush)
        {
            int fontSize = 16;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = button.ClientRectangle;
            if ((bool)button.Tag == true)
            {
                newRectangle.Inflate(-1, -1);
                fontSize = 18;
            }
            else
                newRectangle.Inflate(-3, -3);
            e.Graphics.FillEllipse(brush, newRectangle);
            e.Graphics.FillEllipse(Brushes.Black, newRectangle.X + 2, newRectangle.Y + 2, newRectangle.Width - 4, newRectangle.Height - 4);
            using (StringFormat strF = new StringFormat())
            {
                strF.Alignment = StringAlignment.Center;
                strF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(button.Text, new Font("Times New Roman", fontSize, FontStyle.Bold | FontStyle.Italic), Brushes.DarkOrange, newRectangle, strF);
                if (button.Capture)
                {
                    fontSize = 18;
                    e.Graphics.FillEllipse(Brushes.Gray, newRectangle);
                    e.Graphics.FillEllipse(Brushes.Black, newRectangle.X + 2, newRectangle.Y + 2, newRectangle.Width - 4, newRectangle.Height - 4);
                    e.Graphics.DrawString(button.Text, new Font("Times New Roman", fontSize, FontStyle.Bold | FontStyle.Italic), Brushes.DarkOrange, newRectangle, strF);
                }
            }
            buttonPath.AddEllipse(newRectangle);
            button.Region = new Region(buttonPath);
        }
    }
}

