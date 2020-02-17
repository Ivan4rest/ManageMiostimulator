namespace ManageMiostimulator
{
    partial class FormManageMiostimulatorClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageMiostimulatorClient));
            this.manageMiostimulatorClientControl = new ManageMiostimulator.ManageMiostimulatorClientControl();
            this.gb_input_data = new System.Windows.Forms.GroupBox();
            this.tb_correction = new System.Windows.Forms.TextBox();
            this.label_correction = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.label_for_tb_signal_shape = new System.Windows.Forms.Label();
            this.label_for_tb_the_time_between_stimulation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_for_tb_the_period_of_stimulation = new System.Windows.Forms.Label();
            this.label_for_tb_number_of_stimulations = new System.Windows.Forms.Label();
            this.label_for_tb_amperage = new System.Windows.Forms.Label();
            this.tb_signal_shape = new System.Windows.Forms.TextBox();
            this.tb_period_of_stimulations = new System.Windows.Forms.TextBox();
            this.tb_duration_of_the_stimulation = new System.Windows.Forms.TextBox();
            this.tb_count_of_stimulations = new System.Windows.Forms.TextBox();
            this.tb_amperage = new System.Windows.Forms.TextBox();
            this.gb_input_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // manageMiostimulatorClientControl
            // 
            this.manageMiostimulatorClientControl.ClientName = "ManageMiostimulatorClient";
            this.manageMiostimulatorClientControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.manageMiostimulatorClientControl.IPServer = ((System.Net.IPAddress)(resources.GetObject("manageMiostimulatorClientControl.IPServer")));
            this.manageMiostimulatorClientControl.IsSyncronized = true;
            this.manageMiostimulatorClientControl.Location = new System.Drawing.Point(0, 0);
            this.manageMiostimulatorClientControl.Name = "manageMiostimulatorClientControl";
            this.manageMiostimulatorClientControl.Size = new System.Drawing.Size(175, 292);
            this.manageMiostimulatorClientControl.TabIndex = 0;
            // 
            // gb_input_data
            // 
            this.gb_input_data.Controls.Add(this.tb_correction);
            this.gb_input_data.Controls.Add(this.label_correction);
            this.gb_input_data.Controls.Add(this.btn_send);
            this.gb_input_data.Controls.Add(this.label_for_tb_signal_shape);
            this.gb_input_data.Controls.Add(this.label_for_tb_the_time_between_stimulation);
            this.gb_input_data.Controls.Add(this.label4);
            this.gb_input_data.Controls.Add(this.label_for_tb_the_period_of_stimulation);
            this.gb_input_data.Controls.Add(this.label_for_tb_number_of_stimulations);
            this.gb_input_data.Controls.Add(this.label_for_tb_amperage);
            this.gb_input_data.Controls.Add(this.tb_signal_shape);
            this.gb_input_data.Controls.Add(this.tb_period_of_stimulations);
            this.gb_input_data.Controls.Add(this.tb_duration_of_the_stimulation);
            this.gb_input_data.Controls.Add(this.tb_count_of_stimulations);
            this.gb_input_data.Controls.Add(this.tb_amperage);
            this.gb_input_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_input_data.Location = new System.Drawing.Point(175, 0);
            this.gb_input_data.Name = "gb_input_data";
            this.gb_input_data.Size = new System.Drawing.Size(391, 292);
            this.gb_input_data.TabIndex = 1;
            this.gb_input_data.TabStop = false;
            this.gb_input_data.Text = "Формирование команды";
            // 
            // tb_correction
            // 
            this.tb_correction.Location = new System.Drawing.Point(6, 110);
            this.tb_correction.Name = "tb_correction";
            this.tb_correction.Size = new System.Drawing.Size(373, 20);
            this.tb_correction.TabIndex = 12;
            // 
            // label_correction
            // 
            this.label_correction.AutoSize = true;
            this.label_correction.Location = new System.Drawing.Point(6, 94);
            this.label_correction.Name = "label_correction";
            this.label_correction.Size = new System.Drawing.Size(75, 13);
            this.label_correction.TabIndex = 11;
            this.label_correction.Text = "Correction, Fs:";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(6, 253);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(373, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Отправить";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label_for_tb_signal_shape
            // 
            this.label_for_tb_signal_shape.AutoSize = true;
            this.label_for_tb_signal_shape.Location = new System.Drawing.Point(6, 211);
            this.label_for_tb_signal_shape.Name = "label_for_tb_signal_shape";
            this.label_for_tb_signal_shape.Size = new System.Drawing.Size(91, 13);
            this.label_for_tb_signal_shape.TabIndex = 10;
            this.label_for_tb_signal_shape.Text = "Форма сигнала:";
            // 
            // label_for_tb_the_time_between_stimulation
            // 
            this.label_for_tb_the_time_between_stimulation.AutoSize = true;
            this.label_for_tb_the_time_between_stimulation.Location = new System.Drawing.Point(6, 16);
            this.label_for_tb_the_time_between_stimulation.Name = "label_for_tb_the_time_between_stimulation";
            this.label_for_tb_the_time_between_stimulation.Size = new System.Drawing.Size(135, 13);
            this.label_for_tb_the_time_between_stimulation.TabIndex = 9;
            this.label_for_tb_the_time_between_stimulation.Text = "Период стимуляций, сек:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-216, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // label_for_tb_the_period_of_stimulation
            // 
            this.label_for_tb_the_period_of_stimulation.AutoSize = true;
            this.label_for_tb_the_period_of_stimulation.Location = new System.Drawing.Point(6, 55);
            this.label_for_tb_the_period_of_stimulation.Name = "label_for_tb_the_period_of_stimulation";
            this.label_for_tb_the_period_of_stimulation.Size = new System.Drawing.Size(178, 13);
            this.label_for_tb_the_period_of_stimulation.TabIndex = 7;
            this.label_for_tb_the_period_of_stimulation.Text = "Длительность стимуляции, мсек:";
            // 
            // label_for_tb_number_of_stimulations
            // 
            this.label_for_tb_number_of_stimulations.AutoSize = true;
            this.label_for_tb_number_of_stimulations.Location = new System.Drawing.Point(6, 172);
            this.label_for_tb_number_of_stimulations.Name = "label_for_tb_number_of_stimulations";
            this.label_for_tb_number_of_stimulations.Size = new System.Drawing.Size(132, 13);
            this.label_for_tb_number_of_stimulations.TabIndex = 6;
            this.label_for_tb_number_of_stimulations.Text = "Количество стимуляций:";
            // 
            // label_for_tb_amperage
            // 
            this.label_for_tb_amperage.AutoSize = true;
            this.label_for_tb_amperage.Location = new System.Drawing.Point(6, 133);
            this.label_for_tb_amperage.Name = "label_for_tb_amperage";
            this.label_for_tb_amperage.Size = new System.Drawing.Size(82, 13);
            this.label_for_tb_amperage.TabIndex = 5;
            this.label_for_tb_amperage.Text = "Сила тока, mA:";
            // 
            // tb_signal_shape
            // 
            this.tb_signal_shape.Location = new System.Drawing.Point(6, 227);
            this.tb_signal_shape.Name = "tb_signal_shape";
            this.tb_signal_shape.Size = new System.Drawing.Size(373, 20);
            this.tb_signal_shape.TabIndex = 4;
            // 
            // tb_period_of_stimulations
            // 
            this.tb_period_of_stimulations.Location = new System.Drawing.Point(6, 32);
            this.tb_period_of_stimulations.Name = "tb_period_of_stimulations";
            this.tb_period_of_stimulations.Size = new System.Drawing.Size(373, 20);
            this.tb_period_of_stimulations.TabIndex = 3;
            // 
            // tb_duration_of_the_stimulation
            // 
            this.tb_duration_of_the_stimulation.Location = new System.Drawing.Point(6, 71);
            this.tb_duration_of_the_stimulation.Name = "tb_duration_of_the_stimulation";
            this.tb_duration_of_the_stimulation.Size = new System.Drawing.Size(373, 20);
            this.tb_duration_of_the_stimulation.TabIndex = 2;
            // 
            // tb_count_of_stimulations
            // 
            this.tb_count_of_stimulations.Location = new System.Drawing.Point(6, 188);
            this.tb_count_of_stimulations.Name = "tb_count_of_stimulations";
            this.tb_count_of_stimulations.Size = new System.Drawing.Size(373, 20);
            this.tb_count_of_stimulations.TabIndex = 1;
            // 
            // tb_amperage
            // 
            this.tb_amperage.Location = new System.Drawing.Point(6, 149);
            this.tb_amperage.Name = "tb_amperage";
            this.tb_amperage.Size = new System.Drawing.Size(373, 20);
            this.tb_amperage.TabIndex = 0;
            // 
            // FormManageMiostimulatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 292);
            this.Controls.Add(this.gb_input_data);
            this.Controls.Add(this.manageMiostimulatorClientControl);
            this.Name = "FormManageMiostimulatorClient";
            this.Text = "ManageMiostimulatorClient";
            this.gb_input_data.ResumeLayout(false);
            this.gb_input_data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ManageMiostimulatorClientControl manageMiostimulatorClientControl;
        private System.Windows.Forms.GroupBox gb_input_data;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label_for_tb_signal_shape;
        private System.Windows.Forms.Label label_for_tb_the_time_between_stimulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_for_tb_the_period_of_stimulation;
        private System.Windows.Forms.Label label_for_tb_number_of_stimulations;
        private System.Windows.Forms.Label label_for_tb_amperage;
        private System.Windows.Forms.TextBox tb_signal_shape;
        private System.Windows.Forms.TextBox tb_period_of_stimulations;
        private System.Windows.Forms.TextBox tb_duration_of_the_stimulation;
        private System.Windows.Forms.TextBox tb_count_of_stimulations;
        private System.Windows.Forms.TextBox tb_amperage;
        private System.Windows.Forms.TextBox tb_correction;
        private System.Windows.Forms.Label label_correction;
    }
}

