namespace ManageMiostimulator
{
    partial class ManageMiostimulatorClientControl
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
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.pNetworkSettings.SuspendLayout();
            this.gbClients.SuspendLayout();
            this.SuspendLayout();
            // 
            // pNetworkSettings
            // 
            this.pNetworkSettings.Controls.Add(this.btn_start_stop);
            this.pNetworkSettings.Size = new System.Drawing.Size(175, 98);
            this.pNetworkSettings.Controls.SetChildIndex(this.lIP, 0);
            this.pNetworkSettings.Controls.SetChildIndex(this.lPort, 0);
            this.pNetworkSettings.Controls.SetChildIndex(this.tbIP, 0);
            this.pNetworkSettings.Controls.SetChildIndex(this.lClientName, 0);
            this.pNetworkSettings.Controls.SetChildIndex(this.btn_start_stop, 0);
            // 
            // gbClients
            // 
            this.gbClients.Size = new System.Drawing.Size(175, 86);
            // 
            // chClients
            // 
            this.chClients.Size = new System.Drawing.Size(169, 64);
            // 
            // tbName
            // 
            this.tbName.Size = new System.Drawing.Size(75, 20);
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.Location = new System.Drawing.Point(89, 67);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_start_stop.TabIndex = 22;
            this.btn_start_stop.Text = "Старт";
            this.btn_start_stop.UseVisualStyleBackColor = true;
            this.btn_start_stop.Click += new System.EventHandler(this.btn_start_stop_Click);
            // 
            // ManageMiostimulatorClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ManageMiostimulatorClientControl";
            this.Size = new System.Drawing.Size(175, 184);
            this.pNetworkSettings.ResumeLayout(false);
            this.pNetworkSettings.PerformLayout();
            this.gbClients.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start_stop;
    }
}
