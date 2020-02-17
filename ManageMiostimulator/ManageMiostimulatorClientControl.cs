using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManageMiostimulator
{
    public partial class ManageMiostimulatorClientControl : NetManager.Client.ClientControl
    {
        public ManageMiostimulatorClientControl()
        {
            InitializeComponent();
            Client.Stopped += Client_Stopped;               
        }

        private void Client_Stopped(object sender, EventArgs e)
        {
            btn_start_stop.Enabled = true;
            btn_start_stop.Text = "Старт";
        }

        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            if(Client.IsRunning)
            {
                btn_start_stop.Enabled = false;
                Client.StopClient();
            }
            else
            {
                btn_start_stop.Text = "Стоп";
                Client.StartClient();
            }
        }
    }
}
