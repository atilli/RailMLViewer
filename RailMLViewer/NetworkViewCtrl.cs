using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RailMLViewer
{
    public partial class NetworkViewCtrl : UserControl
    {
     
        ScalableViewPort viewPortTranslator;
        NetworkViewData managedObjects;

        public NetworkViewCtrl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            viewPortTranslator = new ScalableViewPort();

        

            this.Paint += new PaintEventHandler(this.panelPaint);

            this.MouseDown += new MouseEventHandler(MouseDownEvent);
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);
        }
        Point leftMouseDown;
        Point leftMouseUp;

        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left)
           {
                leftMouseDown = e.Location;
               
            }
        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftMouseUp = e.Location;
                bool moved = viewPortTranslator.MoveOrigoScreenToScreen(leftMouseDown, leftMouseUp);
                
                if(moved)
                {
                    Invalidate();
                }
            }
        }
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                viewPortTranslator.ZoomOut(e.Location);
                Invalidate();
            }
            else
            {
                if (e.Delta > 0)
                {
                    viewPortTranslator.ZoomIn(e.Location);
                    Invalidate();
                }
            }                        
        }
        protected void panelPaint(object sender, PaintEventArgs e)
        {
            DrawNetworkTo(e.Graphics, Size);
        }
        // Warning super slow...
   
        internal void DrawNetworkTo(Graphics g, Size size)
        {
            managedObjects.DrawNetworkTo(g, viewPortTranslator, size);            
        }
        internal void ChangeToViewNetwork(InfraReader netWork)
        {
            managedObjects = new NetworkViewData();
            managedObjects.CreateViewObjectsFor(netWork);
        }
    }
}
