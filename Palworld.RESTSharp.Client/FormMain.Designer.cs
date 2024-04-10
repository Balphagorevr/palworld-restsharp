namespace Palworld.RESTSharp.Client
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelResponse = new Panel();
            statusStrip1 = new StatusStrip();
            connectionStatus = new ToolStripStatusLabel();
            stsPlayerCount = new ToolStripStatusLabel();
            stsServerUptimeAndFPS = new ToolStripStatusLabel();
            tAPIOptions = new TreeView();
            label1 = new Label();
            btnExecute = new Button();
            pageConfigure = new Panel();
            groupBox2 = new GroupBox();
            cbUseProxy = new CheckBox();
            txtconfigURL = new TextBox();
            txtConfigPassword = new TextBox();
            label4 = new Label();
            lblPassword = new Label();
            groupBox1 = new GroupBox();
            cbTrackMetrics = new CheckBox();
            btnSaveConfig = new Button();
            panelRequestParameters = new Panel();
            lblHeader = new Label();
            statusStrip1.SuspendLayout();
            pageConfigure.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelResponse
            // 
            panelResponse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelResponse.Location = new Point(222, 186);
            panelResponse.Name = "panelResponse";
            panelResponse.Size = new Size(770, 190);
            panelResponse.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.GripStyle = ToolStripGripStyle.Visible;
            statusStrip1.Items.AddRange(new ToolStripItem[] { connectionStatus, stsPlayerCount, stsServerUptimeAndFPS });
            statusStrip1.Location = new Point(0, 376);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(992, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // connectionStatus
            // 
            connectionStatus.Name = "connectionStatus";
            connectionStatus.Size = new Size(97, 17);
            connectionStatus.Text = "Not Connected...";
            // 
            // stsPlayerCount
            // 
            stsPlayerCount.Name = "stsPlayerCount";
            stsPlayerCount.Size = new Size(0, 17);
            stsPlayerCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stsServerUptimeAndFPS
            // 
            stsServerUptimeAndFPS.Name = "stsServerUptimeAndFPS";
            stsServerUptimeAndFPS.Size = new Size(0, 17);
            // 
            // tAPIOptions
            // 
            tAPIOptions.Dock = DockStyle.Left;
            tAPIOptions.Location = new Point(0, 0);
            tAPIOptions.Name = "tAPIOptions";
            tAPIOptions.Size = new Size(223, 376);
            tAPIOptions.TabIndex = 0;
            tAPIOptions.AfterSelect += tAPIOptions_AfterSelectAsync;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 168);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 3;
            label1.Text = "Response";
            // 
            // btnExecute
            // 
            btnExecute.Location = new Point(899, 0);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(93, 42);
            btnExecute.TabIndex = 6;
            btnExecute.Text = "Execute";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // pageConfigure
            // 
            pageConfigure.Controls.Add(groupBox2);
            pageConfigure.Controls.Add(groupBox1);
            pageConfigure.Controls.Add(btnSaveConfig);
            pageConfigure.Location = new Point(222, 0);
            pageConfigure.Name = "pageConfigure";
            pageConfigure.Size = new Size(770, 165);
            pageConfigure.TabIndex = 7;
            pageConfigure.Paint += pageConfigure_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbUseProxy);
            groupBox2.Controls.Add(txtconfigURL);
            groupBox2.Controls.Add(txtConfigPassword);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblPassword);
            groupBox2.Location = new Point(7, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(601, 100);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Configuration";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // cbUseProxy
            // 
            cbUseProxy.AutoSize = true;
            cbUseProxy.Location = new Point(6, 75);
            cbUseProxy.Name = "cbUseProxy";
            cbUseProxy.Size = new Size(113, 19);
            cbUseProxy.TabIndex = 12;
            cbUseProxy.Text = "Use Proxy Server";
            cbUseProxy.UseVisualStyleBackColor = true;
            cbUseProxy.CheckedChanged += cbUseProxy_CheckedChanged;
            // 
            // txtconfigURL
            // 
            txtconfigURL.Location = new Point(67, 18);
            txtconfigURL.Name = "txtconfigURL";
            txtconfigURL.PlaceholderText = "http://127.0.0.1:8000";
            txtconfigURL.Size = new Size(160, 23);
            txtconfigURL.TabIndex = 9;
            // 
            // txtConfigPassword
            // 
            txtConfigPassword.Location = new Point(67, 50);
            txtConfigPassword.Name = "txtConfigPassword";
            txtConfigPassword.PasswordChar = '*';
            txtConfigPassword.Size = new Size(160, 23);
            txtConfigPassword.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 21);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 10;
            label4.Text = "URL";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 53);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbTrackMetrics);
            groupBox1.Location = new Point(614, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(144, 100);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // cbTrackMetrics
            // 
            cbTrackMetrics.AutoSize = true;
            cbTrackMetrics.Location = new Point(6, 22);
            cbTrackMetrics.Name = "cbTrackMetrics";
            cbTrackMetrics.Size = new Size(132, 19);
            cbTrackMetrics.TabIndex = 11;
            cbTrackMetrics.Text = "Show Server Metrics";
            cbTrackMetrics.UseVisualStyleBackColor = true;
            cbTrackMetrics.CheckedChanged += cbTrackMetrics_CheckedChanged;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Location = new Point(5, 118);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(112, 23);
            btnSaveConfig.TabIndex = 8;
            btnSaveConfig.Text = "Connect";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // panelRequestParameters
            // 
            panelRequestParameters.BorderStyle = BorderStyle.Fixed3D;
            panelRequestParameters.Location = new Point(222, 41);
            panelRequestParameters.Name = "panelRequestParameters";
            panelRequestParameters.Size = new Size(770, 124);
            panelRequestParameters.TabIndex = 7;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(229, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(77, 21);
            lblHeader.TabIndex = 8;
            lblHeader.Text = "{Header}";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 398);
            Controls.Add(pageConfigure);
            Controls.Add(lblHeader);
            Controls.Add(panelRequestParameters);
            Controls.Add(btnExecute);
            Controls.Add(label1);
            Controls.Add(tAPIOptions);
            Controls.Add(statusStrip1);
            Controls.Add(panelResponse);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Palworld RESTSharp Client";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pageConfigure.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelResponse;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel connectionStatus;
        private TreeView tAPIOptions;
        private Label label1;
        private Button btnExecute;
        private Panel pageConfigure;
        private Label lblPassword;
        private Label label4;
        private TextBox txtconfigURL;
        private Button btnSaveConfig;
        private Panel panelRequestParameters;
        private Label lblHeader;
        private ToolStripStatusLabel stsPlayerCount;
        private ToolStripStatusLabel stsServerUptimeAndFPS;
        private CheckBox cbTrackMetrics;
        private TextBox txtConfigPassword;
        private GroupBox groupBox1;
        private CheckBox cbUseProxy;
        private GroupBox groupBox2;
    }
}
