using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using Kiosk_UI.Custom;

namespace Kiosk_UI
{
    internal class Touch
    {
        private Custom_flowpanel menuPanel;

        public Touch(Custom_flowpanel menuPanel)
        {
            this.menuPanel = menuPanel;
        }

        public class Touchscroll
        {
            private Point mouseDownpoint;
            private FlowLayoutPanel parentPanel;

            public Touchscroll(FlowLayoutPanel panel)
            {
                parentPanel = panel;
                AssignEvent(panel);
            }
            private void AssignEvent(Control control)
            {
                control.MouseDown += MouseDown;
                control.MouseMove += MouseMove;
                foreach(Control child in control.Controls)
                {
                    AssignEvent(child);
                }
            }

            private void MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    this.mouseDownpoint = Cursor.Position;
            }

            private void MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                Point pointDifference = new Point(Cursor.Position.X + mouseDownpoint.X, Cursor.Position.Y + mouseDownpoint.Y);

                if ((mouseDownpoint.X == Cursor.Position.X) && (mouseDownpoint.Y == Cursor.Position.Y))
                    return;

                Point currAutos = parentPanel.AutoScrollPosition;
                parentPanel.AutoScrollPosition = new Point(Math.Abs(currAutos.X) - pointDifference.X, Math.Abs(currAutos.Y) - pointDifference.Y);
                mouseDownpoint = Cursor.Position;
            }
        }
    }
}
