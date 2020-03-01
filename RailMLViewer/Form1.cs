using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailMLViewer
{
    public partial class Form1 : Form
    {
        NetworkViewCtrl networkView;

        public Form1()
        {
            InitializeComponent();
            networkView = new NetworkViewCtrl();
            networkView.Dock = DockStyle.Fill;
            WindowState = FormWindowState.Maximized;

            //mainView.SizeMode = PictureBoxSizeMode.
            Controls.Add(networkView);

        }
        public void SetIntialNetwork(InfraReader infra)
        {
            networkView.ChangeToViewNetwork(infra);
        }

    }
}
