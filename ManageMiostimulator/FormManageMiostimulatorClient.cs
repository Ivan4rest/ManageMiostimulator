using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetManager;
using FoundationLibrary;

namespace ManageMiostimulator
{
    public partial class FormManageMiostimulatorClient : Form
    {
        public FormManageMiostimulatorClient()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if(manageMiostimulatorClientControl.Client.IsRunning && 
              (manageMiostimulatorClientControl.CheckedClientAddresses.Count > 0) &&
              (tb_period_of_stimulations.Text != "") &&
              (tb_duration_of_the_stimulation.Text != "") &&
              (tb_correction.Text != "") &&
              (tb_amperage.Text != "") &&
              (tb_count_of_stimulations.Text != "") &&
              (tb_signal_shape.Text != ""))
            {
                //Подготовка к передаче                
                string str_command = tb_period_of_stimulations.Text + " " + tb_duration_of_the_stimulation.Text + " " + tb_correction.Text + " " + tb_amperage.Text + " " + tb_count_of_stimulations.Text + " " + tb_signal_shape.Text;
                byte[] command = new byte[str_command.Length * 2 + 4];
                Array.Copy(BitConverter.GetBytes(19), command, 4);
                for(int i = 0; i < str_command.Length; i++)
                {
                    Array.Copy(BitConverter.GetBytes(str_command[i]), 0, command, 4 + 2 * i, 2);
                }

                manageMiostimulatorClientControl.Client.SendData(manageMiostimulatorClientControl.CheckedClientAddresses.ToArray(), command);
            }
        }
    }
}
