namespace Palworld.RESTSharp.Client
{
    partial class UnbanUserPage
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
            txtUnbanSteamID = new TextBox();
            btnUnban = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtUnbanSteamID
            // 
            txtUnbanSteamID.Location = new Point(3, 18);
            txtUnbanSteamID.Name = "txtUnbanSteamID";
            txtUnbanSteamID.PlaceholderText = "Steam_";
            txtUnbanSteamID.Size = new Size(396, 23);
            txtUnbanSteamID.TabIndex = 0;
            // 
            // btnUnban
            // 
            btnUnban.Location = new Point(3, 47);
            btnUnban.Name = "btnUnban";
            btnUnban.Size = new Size(75, 23);
            btnUnban.TabIndex = 1;
            btnUnban.Text = "Unban";
            btnUnban.UseVisualStyleBackColor = true;
            btnUnban.Click += btnUnban_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 2;
            label1.Text = "Unban by Steam ID";
            // 
            // UnbanUserPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnUnban);
            Controls.Add(txtUnbanSteamID);
            Name = "UnbanUserPage";
            Size = new Size(523, 195);
            Load += UnbanUserPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUnbanSteamID;
        private Button btnUnban;
        private Label label1;
    }
}
