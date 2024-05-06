namespace Palworld.RESTSharp.Client
{
    partial class StopServerPage
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
            btnStopServer = new Button();
            pbRequestProgress = new ProgressBar();
            SuspendLayout();
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(3, 3);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(100, 23);
            btnStopServer.TabIndex = 0;
            btnStopServer.Text = "Stop Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // pbRequestProgress
            // 
            pbRequestProgress.Location = new Point(3, 32);
            pbRequestProgress.Name = "pbRequestProgress";
            pbRequestProgress.Size = new Size(500, 19);
            pbRequestProgress.Style = ProgressBarStyle.Continuous;
            pbRequestProgress.TabIndex = 7;
            // 
            // StopServerPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbRequestProgress);
            Controls.Add(btnStopServer);
            Name = "StopServerPage";
            Size = new Size(506, 254);
            Load += StopServerPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStopServer;
        private ProgressBar pbRequestProgress;
    }
}
