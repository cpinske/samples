using System.Windows.Forms;
using System.Drawing;

namespace Bowling_Score_Card.Utilities
{
    class Visual
    {
        public void TransParentBackground(Form frmForm, Control conControl)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Makes a control appear like it is transparent
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            
            conControl.Visible = false;
            conControl.Refresh();
            Application.DoEvents();
            Rectangle screenRectangle = frmForm.RectangleToScreen(frmForm.ClientRectangle);
            int titleHeight = screenRectangle.Top - frmForm.Top;
            int Right = screenRectangle.Left - frmForm.Left;
            Bitmap bmp = new Bitmap(frmForm.Width, frmForm.Height);
            frmForm.DrawToBitmap(bmp, new Rectangle(0, 0, frmForm.Width, frmForm.Height));
            Bitmap bmpImage = new Bitmap(bmp);
            bmp = bmpImage.Clone(new Rectangle(conControl.Location.X + Right, conControl.Location.Y + titleHeight, conControl.Width, conControl.Height), bmpImage.PixelFormat);
            conControl.BackgroundImage = bmp;
            conControl.Visible = true;
        }
    }
}
