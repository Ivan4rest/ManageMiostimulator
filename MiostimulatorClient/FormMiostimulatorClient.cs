using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetManager.Client;
using System.IO.Ports;

namespace MiostimulatorClient
{
    public partial class FormMiostimulatorClient : System.Windows.Forms.Form
    {
        public FormMiostimulatorClient()
        {
            InitializeComponent();
            miostimulatorClientControl.Client.Reseive += Client_Reseive;
            miostimulatorClientControl.Client.Error += Client_Error;
        }

        private void Client_Error(object sender, NetManager.EventMsgArgs e)
        {
            MessageBox.Show(e.Msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Client_Reseive(object sender, NetManager.EventClientMsgArgs e)
        {
            int n = BitConverter.ToInt32(e.Msg, 0);
            if(n == 19)
            {
                n = (e.Msg.Length - 4) / 2;               
                string s = "";
                for (int i = 0; i < n; i++)
                {                    
                    s += BitConverter.ToChar(e.Msg, 4 + 2 * i);
                }
                Console.WriteLine(s);
                //tb_commands.Text += s + "\n";
                string[] str = s.Split(' ');
                string period_of_stimulations = str[0];
                string duration_of_the_stimulation = str[1];
                string correction = str[2];
                string amperage = str[3];
                string count_of_stimulations = str[4];
                string signal_shape = str[5];
                WorkWithUSBT.SetData(period_of_stimulations, duration_of_the_stimulation, correction, amperage, count_of_stimulations, signal_shape);
                WorkWithUSBT.StartButtonClick();
            }
        }
    }
}
