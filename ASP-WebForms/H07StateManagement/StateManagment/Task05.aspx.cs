using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagment
{
    public partial class Task05 : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Application.Lock();
            if (Application["UsersCount"] == null)
            {
                Application["UsersCount"] = 0;
            }
            Application["UsersCount"] = (int)Application["UsersCount"] + 1;
            Application.UnLock();
            var usersCount = Application["UsersCount"].ToString();

            //var usersCount = "12";

            System.Web.UI.WebControls.Image imgVisitorsCount = new System.Web.UI.WebControls.Image();
            using (Bitmap bitMap = new Bitmap(usersCount.Length * 175, 250))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAutomationHC39M", 160);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.White);
                    SolidBrush whiteBrush = new SolidBrush(Color.Pink);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString(usersCount, oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgVisitorsCount.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(byteImage);
                }
                plVisitors.Controls.Add(imgVisitorsCount);
            }
        }
    }
}