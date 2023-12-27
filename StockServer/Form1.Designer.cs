namespace StockServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartServer = new Button();
            txtBoxIP = new TextBox();
            txtBoxPort = new TextBox();
            SuspendLayout();
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(58, 136);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(75, 23);
            btnStartServer.TabIndex = 0;
            btnStartServer.Text = "啟動";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // txtBoxIP
            // 
            txtBoxIP.Location = new Point(23, 28);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(145, 23);
            txtBoxIP.TabIndex = 1;
            txtBoxIP.Text = "127.0.0.1";
            // 
            // txtBoxPort
            // 
            txtBoxPort.Location = new Point(23, 79);
            txtBoxPort.Name = "txtBoxPort";
            txtBoxPort.Size = new Size(145, 23);
            txtBoxPort.TabIndex = 2;
            txtBoxPort.Text = "5566";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(191, 191);
            Controls.Add(txtBoxPort);
            Controls.Add(txtBoxIP);
            Controls.Add(btnStartServer);
            Name = "Form1";
            Text = "Form1";
            FormClosing += SocketServerForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartServer;
        private TextBox txtBoxIP;
        private TextBox txtBoxPort;
    }
}
