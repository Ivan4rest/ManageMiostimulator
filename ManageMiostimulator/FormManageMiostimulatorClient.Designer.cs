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
            this.gb_input_data = new System.Windows.Forms.GroupBox();
            this.btn_save_file = new System.Windows.Forms.Button();
            this.btn_open_file = new System.Windows.Forms.Button();
            this.label_amplitude_step = new System.Windows.Forms.Label();
            this.tb_amplitude_step = new System.Windows.Forms.TextBox();
            this.btn_set_stimulation_parameters = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.cb_stimulation_form = new System.Windows.Forms.ComboBox();
            this.tb_polarity = new System.Windows.Forms.TextBox();
            this.label_polarity = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.label_for_tb_signal_shape = new System.Windows.Forms.Label();
            this.label_for_tb_the_time_between_stimulation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_for_tb_the_period_of_stimulation = new System.Windows.Forms.Label();
            this.label_for_tb_number_of_stimulations = new System.Windows.Forms.Label();
            this.label_for_tb_amperage = new System.Windows.Forms.Label();
            this.tb_period_of_stimulations = new System.Windows.Forms.TextBox();
            this.tb_duration_of_the_stimulation = new System.Windows.Forms.TextBox();
            this.tb_count_of_stimulations = new System.Windows.Forms.TextBox();
            this.tb_amperage = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.manageMiostimulatorClientControl = new ManageMiostimulator.ManageMiostimulatorClientControl();
            this.gb_input_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_input_data
            // 
            this.gb_input_data.Controls.Add(this.btn_save_file);
            this.gb_input_data.Controls.Add(this.btn_open_file);
            this.gb_input_data.Controls.Add(this.label_amplitude_step);
            this.gb_input_data.Controls.Add(this.tb_amplitude_step);
            this.gb_input_data.Controls.Add(this.btn_set_stimulation_parameters);
            this.gb_input_data.Controls.Add(this.btn_stop);
            this.gb_input_data.Controls.Add(this.cb_stimulation_form);
            this.gb_input_data.Controls.Add(this.tb_polarity);
            this.gb_input_data.Controls.Add(this.label_polarity);
            this.gb_input_data.Controls.Add(this.btn_start);
            this.gb_input_data.Controls.Add(this.label_for_tb_signal_shape);
            this.gb_input_data.Controls.Add(this.label_for_tb_the_time_between_stimulation);
            this.gb_input_data.Controls.Add(this.label4);
            this.gb_input_data.Controls.Add(this.label_for_tb_the_period_of_stimulation);
            this.gb_input_data.Controls.Add(this.label_for_tb_number_of_stimulations);
            this.gb_input_data.Controls.Add(this.label_for_tb_amperage);
            this.gb_input_data.Controls.Add(this.tb_period_of_stimulations);
            this.gb_input_data.Controls.Add(this.tb_duration_of_the_stimulation);
            this.gb_input_data.Controls.Add(this.tb_count_of_stimulations);
            this.gb_input_data.Controls.Add(this.tb_amperage);
            this.gb_input_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_input_data.Location = new System.Drawing.Point(175, 0);
            this.gb_input_data.Name = "gb_input_data";
            this.gb_input_data.Size = new System.Drawing.Size(389, 387);
            this.gb_input_data.TabIndex = 1;
            this.gb_input_data.TabStop = false;
            this.gb_input_data.Text = "Формирование команды";
            // 
            // btn_save_file
            // 
            this.btn_save_file.Location = new System.Drawing.Point(6, 356);
            this.btn_save_file.Name = "btn_save_file";
            this.btn_save_file.Size = new System.Drawing.Size(187, 23);
            this.btn_save_file.TabIndex = 18;
            this.btn_save_file.Text = "Сохранить файл";
            this.btn_save_file.UseVisualStyleBackColor = true;
            this.btn_save_file.Click += new System.EventHandler(this.btn_save_file_Click);
            // 
            // btn_open_file
            // 
            this.btn_open_file.Location = new System.Drawing.Point(6, 327);
            this.btn_open_file.Name = "btn_open_file";
            this.btn_open_file.Size = new System.Drawing.Size(187, 23);
            this.btn_open_file.TabIndex = 17;
            this.btn_open_file.Text = "Открыть файл";
            this.btn_open_file.UseVisualStyleBackColor = true;
            this.btn_open_file.Click += new System.EventHandler(this.btn_open_file_Click);
            // 
            // label_amplitude_step
            // 
            this.label_amplitude_step.AutoSize = true;
            this.label_amplitude_step.Location = new System.Drawing.Point(6, 251);
            this.label_amplitude_step.Name = "label_amplitude_step";
            this.label_amplitude_step.Size = new System.Drawing.Size(161, 13);
            this.label_amplitude_step.TabIndex = 16;
            this.label_amplitude_step.Text = "Шаг изменения амплитуды, А:";
            // 
            // tb_amplitude_step
            // 
            this.tb_amplitude_step.Location = new System.Drawing.Point(6, 267);
            this.tb_amplitude_step.Name = "tb_amplitude_step";
            this.tb_amplitude_step.Size = new System.Drawing.Size(374, 20);
            this.tb_amplitude_step.TabIndex = 15;
            // 
            // btn_set_stimulation_parameters
            // 
            this.btn_set_stimulation_parameters.Location = new System.Drawing.Point(6, 298);
            this.btn_set_stimulation_parameters.Name = "btn_set_stimulation_parameters";
            this.btn_set_stimulation_parameters.Size = new System.Drawing.Size(187, 23);
            this.btn_set_stimulation_parameters.TabIndex = 14;
            this.btn_set_stimulation_parameters.Text = "Задать параметры стимуляции";
            this.btn_set_stimulation_parameters.UseVisualStyleBackColor = true;
            this.btn_set_stimulation_parameters.Click += new System.EventHandler(this.btn_set_stimulation_parameters_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(193, 327);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(187, 23);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Стоп";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // cb_stimulation_form
            // 
            this.cb_stimulation_form.FormattingEnabled = true;
            this.cb_stimulation_form.Items.AddRange(new object[] {
            "rectangle",
            "trapezium",
            "unipolarMeandr",
            "bipolarMeandr",
            "sinusoid",
            "modularSinusoid"});
            this.cb_stimulation_form.Location = new System.Drawing.Point(6, 227);
            this.cb_stimulation_form.Name = "cb_stimulation_form";
            this.cb_stimulation_form.Size = new System.Drawing.Size(374, 21);
            this.cb_stimulation_form.TabIndex = 13;
            // 
            // tb_polarity
            // 
            this.tb_polarity.Location = new System.Drawing.Point(6, 149);
            this.tb_polarity.Name = "tb_polarity";
            this.tb_polarity.Size = new System.Drawing.Size(374, 20);
            this.tb_polarity.TabIndex = 12;
            // 
            // label_polarity
            // 
            this.label_polarity.AutoSize = true;
            this.label_polarity.Location = new System.Drawing.Point(3, 133);
            this.label_polarity.Name = "label_polarity";
            this.label_polarity.Size = new System.Drawing.Size(71, 13);
            this.label_polarity.TabIndex = 11;
            this.label_polarity.Text = "Полярность:";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(193, 298);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(187, 23);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Старт";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label_for_tb_signal_shape
            // 
            this.label_for_tb_signal_shape.AutoSize = true;
            this.label_for_tb_signal_shape.Location = new System.Drawing.Point(6, 211);
            this.label_for_tb_signal_shape.Name = "label_for_tb_signal_shape";
            this.label_for_tb_signal_shape.Size = new System.Drawing.Size(92, 13);
            this.label_for_tb_signal_shape.TabIndex = 10;
            this.label_for_tb_signal_shape.Text = "Форма стимула:";
            // 
            // label_for_tb_the_time_between_stimulation
            // 
            this.label_for_tb_the_time_between_stimulation.AutoSize = true;
            this.label_for_tb_the_time_between_stimulation.Location = new System.Drawing.Point(3, 16);
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
            this.label_for_tb_the_period_of_stimulation.Location = new System.Drawing.Point(3, 55);
            this.label_for_tb_the_period_of_stimulation.Name = "label_for_tb_the_period_of_stimulation";
            this.label_for_tb_the_period_of_stimulation.Size = new System.Drawing.Size(170, 13);
            this.label_for_tb_the_period_of_stimulation.TabIndex = 7;
            this.label_for_tb_the_period_of_stimulation.Text = "Длительность стимуляции, сек:";
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
            this.label_for_tb_amperage.Location = new System.Drawing.Point(3, 94);
            this.label_for_tb_amperage.Name = "label_for_tb_amperage";
            this.label_for_tb_amperage.Size = new System.Drawing.Size(74, 13);
            this.label_for_tb_amperage.TabIndex = 5;
            this.label_for_tb_amperage.Text = "Сила тока, A:";
            // 
            // tb_period_of_stimulations
            // 
            this.tb_period_of_stimulations.Location = new System.Drawing.Point(6, 32);
            this.tb_period_of_stimulations.Name = "tb_period_of_stimulations";
            this.tb_period_of_stimulations.Size = new System.Drawing.Size(374, 20);
            this.tb_period_of_stimulations.TabIndex = 3;
            // 
            // tb_duration_of_the_stimulation
            // 
            this.tb_duration_of_the_stimulation.Location = new System.Drawing.Point(6, 71);
            this.tb_duration_of_the_stimulation.Name = "tb_duration_of_the_stimulation";
            this.tb_duration_of_the_stimulation.Size = new System.Drawing.Size(374, 20);
            this.tb_duration_of_the_stimulation.TabIndex = 2;
            // 
            // tb_count_of_stimulations
            // 
            this.tb_count_of_stimulations.Location = new System.Drawing.Point(6, 188);
            this.tb_count_of_stimulations.Name = "tb_count_of_stimulations";
            this.tb_count_of_stimulations.Size = new System.Drawing.Size(374, 20);
            this.tb_count_of_stimulations.TabIndex = 1;
            // 
            // tb_amperage
            // 
            this.tb_amperage.Location = new System.Drawing.Point(6, 110);
            this.tb_amperage.Name = "tb_amperage";
            this.tb_amperage.Size = new System.Drawing.Size(374, 20);
            this.tb_amperage.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // manageMiostimulatorClientControl
            // 
            this.manageMiostimulatorClientControl.ClientName = "ManageMiostimulatorClient";
            this.manageMiostimulatorClientControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.manageMiostimulatorClientControl.IPServer = ((System.Net.IPAddress)(resources.GetObject("manageMiostimulatorClientControl.IPServer")));
            this.manageMiostimulatorClientControl.IsSyncronized = true;
            this.manageMiostimulatorClientControl.Location = new System.Drawing.Point(0, 0);
            this.manageMiostimulatorClientControl.Name = "manageMiostimulatorClientControl";
            this.manageMiostimulatorClientControl.Size = new System.Drawing.Size(175, 387);
            this.manageMiostimulatorClientControl.TabIndex = 0;
            // 
            // FormManageMiostimulatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 387);
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
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label_for_tb_signal_shape;
        private System.Windows.Forms.Label label_for_tb_the_time_between_stimulation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_for_tb_the_period_of_stimulation;
        private System.Windows.Forms.Label label_for_tb_number_of_stimulations;
        private System.Windows.Forms.Label label_for_tb_amperage;
        private System.Windows.Forms.TextBox tb_period_of_stimulations;
        private System.Windows.Forms.TextBox tb_duration_of_the_stimulation;
        private System.Windows.Forms.TextBox tb_count_of_stimulations;
        private System.Windows.Forms.TextBox tb_amperage;
        private System.Windows.Forms.TextBox tb_polarity;
        private System.Windows.Forms.Label label_polarity;
        private System.Windows.Forms.ComboBox cb_stimulation_form;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_set_stimulation_parameters;
        private System.Windows.Forms.Button btn_save_file;
        private System.Windows.Forms.Button btn_open_file;
        private System.Windows.Forms.Label label_amplitude_step;
        private System.Windows.Forms.TextBox tb_amplitude_step;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

