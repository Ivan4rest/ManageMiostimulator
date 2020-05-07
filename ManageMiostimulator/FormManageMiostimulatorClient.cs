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
using FoundationLibrary;
using MiostimulatorClient;

namespace ManageMiostimulator
{
    public partial class FormManageMiostimulatorClient : Form
    {
        public FormManageMiostimulatorClient()
        {
            InitializeComponent();
            stimulator = new NeuroMEP4CurrentStimulator();
            UpdateTextboxes();
        }

        public NeuroMEP4CurrentStimulator stimulator;

        private void UpdateTextboxes()
        {
            tb_period_of_stimulations.Text = stimulator.PeriodStimulation.ToString();
            tb_duration_of_the_stimulation.Text = stimulator.DurationStimulation.ToString();
            tb_count_of_stimulations.Text = stimulator.CountStimulations.ToString();
            tb_amperage.Text = stimulator.AmplitudeStimulation.ToString();
            tb_polarity.Text = stimulator.Polarity.ToString();
            tb_amplitude_step.Text = stimulator.AmplitudeStep.ToString();
            cb_stimulation_form.Text = stimulator.StimulationForm.ToString();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //Подготовка к передаче                
            string str_command = "Start";
            byte[] command = new byte[str_command.Length * 2 + 4];
            Array.Copy(BitConverter.GetBytes(19), command, 4);
            for (int i = 0; i < str_command.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(str_command[i]), 0, command, 4 + 2 * i, 2);
            }

            manageMiostimulatorClientControl.Client.SendData(manageMiostimulatorClientControl.CheckedClientAddresses.ToArray(), command);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            //Подготовка к передаче                
            string str_command = "Stop";
            byte[] command = new byte[str_command.Length * 2 + 4];
            Array.Copy(BitConverter.GetBytes(19), command, 4);
            for (int i = 0; i < str_command.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(str_command[i]), 0, command, 4 + 2 * i, 2);
            }

            manageMiostimulatorClientControl.Client.SendData(manageMiostimulatorClientControl.CheckedClientAddresses.ToArray(), command);
        }

        private void btn_set_stimulation_parameters_Click(object sender, EventArgs e)
        {
            if (manageMiostimulatorClientControl.Client.IsRunning &&
              (manageMiostimulatorClientControl.CheckedClientAddresses.Count > 0) &&
              (tb_period_of_stimulations.Text != "") &&
              (tb_duration_of_the_stimulation.Text != "") &&
              (tb_polarity.Text != "") &&
              (tb_amperage.Text != "") &&
              (tb_count_of_stimulations.Text != "") &&
              (cb_stimulation_form.Text != ""))
            {
                stimulator.SetStimulationParameters(tb_period_of_stimulations.Text, tb_duration_of_the_stimulation.Text, tb_count_of_stimulations.Text,
                                                    tb_amperage.Text, tb_polarity.Text, cb_stimulation_form.Text, tb_amplitude_step.Text);
                string jsonData = JsonConvert.SerializeObject(stimulator);
                //Подготовка к передаче
                string str_command = "SetParameters" + " " + jsonData;
                byte[] command = new byte[str_command.Length * 2 + 4];
                Array.Copy(BitConverter.GetBytes(19), command, 4);
                for (int i = 0; i < str_command.Length; i++)
                {
                    Array.Copy(BitConverter.GetBytes(str_command[i]), 0, command, 4 + 2 * i, 2);
                }

                manageMiostimulatorClientControl.Client.SendData(manageMiostimulatorClientControl.CheckedClientAddresses.ToArray(), command);
            }
        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            MessageBox.Show("Файл открыт");
            stimulator = JsonConvert.DeserializeObject<NeuroMEP4CurrentStimulator>(fileText);
            UpdateTextboxes();
        }

        private void btn_save_file_Click(object sender, EventArgs e)
        {
            stimulator.SetStimulationParameters(tb_period_of_stimulations.Text, tb_duration_of_the_stimulation.Text, tb_count_of_stimulations.Text,
                                                    tb_amperage.Text, tb_polarity.Text, cb_stimulation_form.Text, tb_amplitude_step.Text);
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string jsonData = JsonConvert.SerializeObject(stimulator);
            string filename = saveFileDialog.FileName;
            System.IO.File.WriteAllText(filename, jsonData);
            MessageBox.Show("Файл сохранен");
        }
    }
}
