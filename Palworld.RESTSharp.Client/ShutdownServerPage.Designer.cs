namespace Palworld.RESTSharp.Client
{
    partial class ShutdownServerPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnShutdownServer = new Button();
            numSeconds = new NumericUpDown();
            txtShutdownMessage = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pbRequestProgress = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)numSeconds).BeginInit();
            SuspendLayout();
            // 
            // btnShutdownServer
            // 
            btnShutdownServer.Location = new Point(3, 58);
            btnShutdownServer.Name = "btnShutdownServer";
            btnShutdownServer.Size = new Size(503, 23);
            btnShutdownServer.TabIndex = 1;
            btnShutdownServer.Text = "Shutdown Server";
            btnShutdownServer.UseVisualStyleBackColor = true;
            btnShutdownServer.Click += btnShutdownServer_Click;
            // 
            // numSeconds
            // 
            numSeconds.Location = new Point(92, 3);
            numSeconds.Name = "numSeconds";
            numSeconds.Size = new Size(48, 23);
            numSeconds.TabIndex = 2;
            // 
            // txtShutdownMessage
            // 
            txtShutdownMessage.Location = new Point(92, 29);
            txtShutdownMessage.Name = "txtShutdownMessage";
            txtShutdownMessage.Size = new Size(411, 23);
            txtShutdownMessage.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 4;
            label1.Text = "Delay Seconds";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 32);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 5;
            label2.Text = "Message";
            // 
            // pbRequestProgress
            // 
            pbRequestProgress.Location = new Point(3, 87);
            pbRequestProgress.Name = "pbRequestProgress";
            pbRequestProgress.Size = new Size(500, 19);
            pbRequestProgress.Style = ProgressBarStyle.Continuous;
            pbRequestProgress.TabIndex = 6;
            // 
            // ShutdownServerPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbRequestProgress);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtShutdownMessage);
            Controls.Add(numSeconds);
            Controls.Add(btnShutdownServer);
            Name = "ShutdownServerPage";
            Size = new Size(506, 254);
            ((System.ComponentModel.ISupportInitialize)numSeconds).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShutdownServer;
        private NumericUpDown numSeconds;
        private TextBox txtShutdownMessage;
        private Label label1;
        private Label label2;
        private ProgressBar pbRequestProgress;
    }
}
