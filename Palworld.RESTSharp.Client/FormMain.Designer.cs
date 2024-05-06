namespace Palworld.RESTSharp.Client
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("User Management");
            TreeNode treeNode2 = new TreeNode("User Audit Log");
            TreeNode treeNode3 = new TreeNode("Proxy Server", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Broadcast Message");
            TreeNode treeNode5 = new TreeNode("Server Metrics");
            TreeNode treeNode6 = new TreeNode("Server Settings");
            TreeNode treeNode7 = new TreeNode("Save World");
            TreeNode treeNode8 = new TreeNode("Stop Server");
            TreeNode treeNode9 = new TreeNode("Shutdown Server");
            TreeNode treeNode10 = new TreeNode("Server Management", new TreeNode[] { treeNode4, treeNode5, treeNode6, treeNode7, treeNode8, treeNode9 });
            TreeNode treeNode11 = new TreeNode("Unban Player");
            TreeNode treeNode12 = new TreeNode("Player Management", new TreeNode[] { treeNode11 });
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuTree = new TreeView();
            statusStripMain = new StatusStrip();
            tsLastAction = new ToolStripStatusLabel();
            connectPanel = new Panel();
            cbUseProxy = new CheckBox();
            lblAPIUrl = new Label();
            txtAPIEndpoint = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            txtPasswordToken = new TextBox();
            panelConfig = new Panel();
            statusStripMain.SuspendLayout();
            connectPanel.SuspendLayout();
            panelConfig.SuspendLayout();
            SuspendLayout();
            // 
            // menuTree
            // 
            menuTree.Dock = DockStyle.Left;
            menuTree.Location = new Point(0, 0);
            menuTree.Name = "menuTree";
            treeNode1.Name = "nProxyUserManagement";
            treeNode1.Text = "User Management";
            treeNode2.Name = "nUserAuditLog";
            treeNode2.Text = "User Audit Log";
            treeNode3.Name = "nProxyServer";
            treeNode3.Text = "Proxy Server";
            treeNode4.Name = "nBroadcastMessage";
            treeNode4.Text = "Broadcast Message";
            treeNode5.Name = "nServerMetrics";
            treeNode5.Text = "Server Metrics";
            treeNode6.Name = "nServerSettings";
            treeNode6.Text = "Server Settings";
            treeNode7.Name = "nSaveWorld";
            treeNode7.Text = "Save World";
            treeNode8.Name = "nStopServer";
            treeNode8.Text = "Stop Server";
            treeNode9.Name = "nShutdownServer";
            treeNode9.Text = "Shutdown Server";
            treeNode10.Name = "nServerManagement";
            treeNode10.Text = "Server Management";
            treeNode11.Name = "nUnbanPlayer";
            treeNode11.Text = "Unban Player";
            treeNode12.Name = "nPlayerManagement";
            treeNode12.Text = "Player Management";
            menuTree.Nodes.AddRange(new TreeNode[] { treeNode3, treeNode10, treeNode12 });
            menuTree.Size = new Size(225, 530);
            menuTree.TabIndex = 0;
            menuTree.AfterSelect += menuTree_AfterSelect;
            // 
            // statusStripMain
            // 
            statusStripMain.Items.AddRange(new ToolStripItem[] { tsLastAction });
            statusStripMain.Location = new Point(225, 508);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(712, 22);
            statusStripMain.TabIndex = 2;
            statusStripMain.Text = "statusStripMain";
            // 
            // tsLastAction
            // 
            tsLastAction.Name = "tsLastAction";
            tsLastAction.Size = new Size(697, 17);
            tsLastAction.Spring = true;
            tsLastAction.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // connectPanel
            // 
            connectPanel.BorderStyle = BorderStyle.FixedSingle;
            connectPanel.Controls.Add(cbUseProxy);
            connectPanel.Controls.Add(lblAPIUrl);
            connectPanel.Controls.Add(txtAPIEndpoint);
            connectPanel.Controls.Add(lblPassword);
            connectPanel.Controls.Add(btnLogin);
            connectPanel.Controls.Add(txtPasswordToken);
            connectPanel.Location = new Point(328, 137);
            connectPanel.Name = "connectPanel";
            connectPanel.Size = new Size(275, 135);
            connectPanel.TabIndex = 3;
            // 
            // cbUseProxy
            // 
            cbUseProxy.AutoSize = true;
            cbUseProxy.Location = new Point(85, 107);
            cbUseProxy.Name = "cbUseProxy";
            cbUseProxy.Size = new Size(113, 19);
            cbUseProxy.TabIndex = 5;
            cbUseProxy.Text = "Use Proxy Server";
            cbUseProxy.UseVisualStyleBackColor = true;
            // 
            // lblAPIUrl
            // 
            lblAPIUrl.AutoSize = true;
            lblAPIUrl.Location = new Point(3, 13);
            lblAPIUrl.Name = "lblAPIUrl";
            lblAPIUrl.Size = new Size(76, 15);
            lblAPIUrl.TabIndex = 4;
            lblAPIUrl.Text = "API Endpoint";
            // 
            // txtAPIEndpoint
            // 
            txtAPIEndpoint.Location = new Point(3, 31);
            txtAPIEndpoint.Name = "txtAPIEndpoint";
            txtAPIEndpoint.Size = new Size(251, 23);
            txtAPIEndpoint.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 57);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(4, 104);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Connect";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPasswordToken
            // 
            txtPasswordToken.Location = new Point(3, 75);
            txtPasswordToken.Name = "txtPasswordToken";
            txtPasswordToken.PasswordChar = '•';
            txtPasswordToken.Size = new Size(251, 23);
            txtPasswordToken.TabIndex = 0;
            // 
            // panelConfig
            // 
            panelConfig.Controls.Add(connectPanel);
            panelConfig.Dock = DockStyle.Fill;
            panelConfig.Location = new Point(225, 0);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new Size(712, 508);
            panelConfig.TabIndex = 4;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 530);
            Controls.Add(panelConfig);
            Controls.Add(statusStripMain);
            Controls.Add(menuTree);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            connectPanel.ResumeLayout(false);
            connectPanel.PerformLayout();
            panelConfig.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView menuTree;
        private StatusStrip statusStripMain;
        private Panel connectPanel;
        private Label lblAPIUrl;
        private TextBox txtAPIEndpoint;
        private Label lblPassword;
        private Button btnLogin;
        private TextBox txtPasswordToken;
        private Panel panelConfig;
        private ToolStripStatusLabel tsLastAction;
        private CheckBox cbUseProxy;
    }
}