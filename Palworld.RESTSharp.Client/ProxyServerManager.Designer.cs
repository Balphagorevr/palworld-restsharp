namespace Palworld.RESTSharp.Client
{
    partial class ProxyServerManager
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            lblProxyVersion = new Label();
            lblProxyURL = new LinkLabel();
            lblend = new Label();
            groupBox3 = new GroupBox();
            btnChangePassword = new Button();
            btnLogout = new Button();
            lblRole = new Label();
            lblUsername = new Label();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 5, 0, 0);
            label1.Size = new Size(237, 30);
            label1.TabIndex = 0;
            label1.Text = "Proxy Server Configuration";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblProxyVersion);
            groupBox1.Controls.Add(lblProxyURL);
            groupBox1.Controls.Add(lblend);
            groupBox1.Location = new Point(13, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(622, 64);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Proxy Server";
            // 
            // lblProxyVersion
            // 
            lblProxyVersion.AutoSize = true;
            lblProxyVersion.Location = new Point(6, 43);
            lblProxyVersion.Name = "lblProxyVersion";
            lblProxyVersion.Size = new Size(45, 15);
            lblProxyVersion.TabIndex = 4;
            lblProxyVersion.Text = "Version";
            // 
            // lblProxyURL
            // 
            lblProxyURL.AutoSize = true;
            lblProxyURL.Location = new Point(91, 19);
            lblProxyURL.Name = "lblProxyURL";
            lblProxyURL.Size = new Size(60, 15);
            lblProxyURL.TabIndex = 3;
            lblProxyURL.TabStop = true;
            lblProxyURL.Text = "linkLabel1";
            // 
            // lblend
            // 
            lblend.AutoSize = true;
            lblend.Location = new Point(6, 19);
            lblend.Name = "lblend";
            lblend.Size = new Size(79, 15);
            lblend.TabIndex = 2;
            lblend.Text = "Endpoint URL";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnChangePassword);
            groupBox3.Controls.Add(btnLogout);
            groupBox3.Controls.Add(lblRole);
            groupBox3.Controls.Add(lblUsername);
            groupBox3.Location = new Point(13, 117);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(622, 61);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "My Account";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(416, 22);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(119, 23);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(541, 22);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(6, 40);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(38, 15);
            lblRole.TabIndex = 1;
            lblRole.Text = "label3";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 19);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(38, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "label3";
            // 
            // ProxyServerManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "ProxyServerManager";
            Size = new Size(656, 338);
            Load += ProxyServerManager_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label lblend;
        private LinkLabel lblProxyURL;
        private GroupBox groupBox3;
        private Button btnLogout;
        private Label lblRole;
        private Label lblUsername;
        private Label lblProxyVersion;
        private Button btnChangePassword;
    }
}
