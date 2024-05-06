namespace Palworld.RESTSharp.Client
{
    partial class BroadcastManager
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
            txtBroadcastMessage = new TextBox();
            label1 = new Label();
            btnSendMessage = new Button();
            pbRequestProgress = new ProgressBar();
            SuspendLayout();
            // 
            // txtBroadcastMessage
            // 
            txtBroadcastMessage.Location = new Point(3, 21);
            txtBroadcastMessage.Multiline = true;
            txtBroadcastMessage.Name = "txtBroadcastMessage";
            txtBroadcastMessage.Size = new Size(677, 52);
            txtBroadcastMessage.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 1;
            label1.Text = "Broadcast Message";
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(3, 79);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(677, 30);
            btnSendMessage.TabIndex = 2;
            btnSendMessage.Text = "Send Message";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // pbRequestProgress
            // 
            pbRequestProgress.Location = new Point(3, 115);
            pbRequestProgress.Name = "pbRequestProgress";
            pbRequestProgress.Size = new Size(677, 19);
            pbRequestProgress.Style = ProgressBarStyle.Continuous;
            pbRequestProgress.TabIndex = 3;
            // 
            // BroadcastManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbRequestProgress);
            Controls.Add(btnSendMessage);
            Controls.Add(label1);
            Controls.Add(txtBroadcastMessage);
            Name = "BroadcastManager";
            Size = new Size(683, 140);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBroadcastMessage;
        private Label label1;
        private Button btnSendMessage;
        private ProgressBar pbRequestProgress;
    }
}
