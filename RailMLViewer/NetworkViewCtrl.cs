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
     
        ScalableViewPort _viewPortTranslator;
        NetworkViewData _managedObjects;

        public NetworkViewCtrl()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _viewPortTranslator = new ScalableViewPort();

        

            this.Paint += new PaintEventHandler(this.panelPaint);

            this.MouseDown += new MouseEventHandler(MouseDownEvent);
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);
        }
        Point _leftMouseDown;
        Point _leftMouseUp;
        private void WindowNewMenu_Click(object sender, EventArgs e) {

        }

        ContextMenuStrip _lastMenu;


        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                _leftMouseDown = e.Location;               
            }
            else {

                 // Create a MenuStrip control with a new window.
                var menu = new ContextMenuStrip();
                ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("Reset view", null, new EventHandler(WindowNewMenu_Click));
                menu.Items.Add(windowNewMenu);


                _lastMenu = menu;

                var startPoint = this.PointToScreen(e.Location);
                menu.Show(startPoint);

            }
            
        }
        private void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _leftMouseUp = e.Location;
                bool moved = _viewPortTranslator.MoveOrigoScreenToScreen(_leftMouseDown, _leftMouseUp);
                
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
                _viewPortTranslator.ZoomOut(e.Location);
                Invalidate();
            }
            else
            {
                if (e.Delta > 0)
                {
                    _viewPortTranslator.ZoomIn(e.Location);
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
            _managedObjects.DrawNetworkTo(g, _viewPortTranslator, size);     

            string debug = _viewPortTranslator.BuildDebugString();            

            g.DrawString(debug,SystemFonts.DefaultFont,new SolidBrush(Color.Black),new Point(20,20));


        }
        internal void ChangeToViewNetwork(InfraReader netWork)
        {
            _managedObjects = new NetworkViewData();
            _managedObjects.CreateViewObjectsFor(netWork);

            PointF center = _managedObjects.CalcAverageCenter();

            _viewPortTranslator.SetIntialCenter(center);
        }
    }
}
