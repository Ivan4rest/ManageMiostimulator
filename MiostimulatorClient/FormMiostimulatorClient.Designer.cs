namespace MiostimulatorClient
{
    partial class FormMiostimulatorClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiostimulatorClient));
            this.gb_output_data = new System.Windows.Forms.GroupBox();
            this.tb_commands = new System.Windows.Forms.TextBox();
            this.label_for_tb_commands = new System.Windows.Forms.Label();
            this.miostimulatorClientControl = new MiostimulatorClient.MiostimulatorClientControl();
            this.gb_output_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_output_data
            // 
            this.gb_output_data.Controls.Add(this.tb_commands);
            this.gb_output_data.Controls.Add(this.label_for_tb_commands);
            this.gb_output_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_output_data.Location = new System.Drawing.Point(174, 0);
            this.gb_output_data.Name = "gb_output_data";
            this.gb_output_data.Size = new System.Drawing.Size(340, 325);
            this.gb_output_data.TabIndex = 1;
            this.gb_output_data.TabStop = false;
            // 
            // tb_commands
            // 
            this.tb_commands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_commands.Location = new System.Drawing.Point(3, 41);
            this.tb_commands.Multiline = true;
            this.tb_commands.Name = "tb_commands";
            this.tb_commands.ReadOnly = true;
            this.tb_commands.Size = new System.Drawing.Size(334, 281);
            this.tb_commands.TabIndex = 1;
            // 
            // label_for_tb_commands
            // 
            this.label_for_tb_commands.AutoSize = true;
            this.label_for_tb_commands.Location = new System.Drawing.Point(3, 16);
            this.label_for_tb_commands.Name = "label_for_tb_commands";
            this.label_for_tb_commands.Size = new System.Drawing.Size(123, 13);
            this.label_for_tb_commands.TabIndex = 0;
            this.label_for_tb_commands.Text = "Переданные команды:";
            // 
            // miostimulatorClientControl
            // 
            this.miostimulatorClientControl.ClientName = "MiostimulatorClient";
            this.miostimulatorClientControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.miostimulatorClientControl.IPServer = ((System.Net.IPAddress)(resources.GetObject("miostimulatorClientControl.IPServer")));
            this.miostimulatorClientControl.Location = new System.Drawing.Point(0, 0);
            this.miostimulatorClientControl.Name = "miostimulatorClientControl";
            this.miostimulatorClientControl.Size = new System.Drawing.Size(174, 325);
            this.miostimulatorClientControl.TabIndex = 0;
            // 
            // FormMiostimulatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 325);
            this.Controls.Add(this.gb_output_data);
            this.Controls.Add(this.miostimulatorClientControl);
            this.Name = "FormMiostimulatorClient";
            this.Text = "MiostimulatorClient";
            this.gb_output_data.ResumeLayout(false);
            this.gb_output_data.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MiostimulatorClientControl miostimulatorClientControl;
        private System.Windows.Forms.GroupBox gb_output_data;
        private System.Windows.Forms.TextBox tb_commands;
        private System.Windows.Forms.Label label_for_tb_commands;
    }
}

