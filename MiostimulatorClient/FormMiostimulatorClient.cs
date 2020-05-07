using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NetManager;
using NetManager.Client;
using EEG;

namespace MiostimulatorClient
{
    public partial class FormMiostimulatorClient : System.Windows.Forms.Form
    {
        public FormMiostimulatorClient()
        {
            InitializeComponent();
            miostimulatorClientControl.Client.Reseive += Client_Reseive;
            miostimulatorClientControl.Client.Error += Client_Error;
            stimulator = new NeuroMEP4CurrentStimulator();
        }

        public NeuroMEP4CurrentStimulator stimulator;

        private void FormMiostimulatorClient_Load(object sender, EventArgs e)
        {
            stimulator.OpenStimulator();
        }

        private void FormMiostimulatorClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            stimulator.CloseStimulator();
        }

        private void Client_Error(object sender, NetManager.EventMsgArgs e)
        {
            MessageBox.Show(e.Msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Client_Reseive(object sender, NetManager.EventClientMsgArgs e)
        {
            int n = BitConverter.ToInt32(e.Msg, 4 * 0);
            if (n == 19)
            {
                n = (e.Msg.Length - 4) / 2;               
                string s = "";
                for (int i = 0; i < n; i++)
                {                    
                    s += BitConverter.ToChar(e.Msg, 4 + 2 * i);
                }
                //s = tb_commands.Text + s + "\n";
                //tb_commands.Text = s;
                string[] str = s.Split(' ');
                if (str[0] == "Start")
                {
                    stimulator.StartStimulation();
                }
                else if (str[0] == "Stop")
                {
                    stimulator.StopStimulation();
                }
                else if (str[0] == "SetParameters")
                {
                    stimulator = JsonConvert.DeserializeObject<NeuroMEP4CurrentStimulator>(str[1]);
                }
            }
            else if (n == 17)
            {
                int correlation_command = BitConverter.ToInt32(e.Msg, 4 * 1);
                stimulator.ChangeLevelStimulation(correlation_command);
            }
        }
    }
}
