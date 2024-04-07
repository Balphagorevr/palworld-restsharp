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
            tAPIOptions = new TreeView();
            label1 = new Label();
            btnExecute = new Button();
            pageConfigure = new Panel();
            label4 = new Label();
            txtconfigURL = new TextBox();
            btnSaveConfig = new Button();
            label3 = new Label();
            txtConfigPassword = new TextBox();
            panelRequestParameters = new Panel();
            lblHeader = new Label();
            statusStrip1.SuspendLayout();
            pageConfigure.SuspendLayout();
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { connectionStatus });
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
            pageConfigure.Controls.Add(label4);
            pageConfigure.Controls.Add(txtconfigURL);
            pageConfigure.Controls.Add(btnSaveConfig);
            pageConfigure.Controls.Add(label3);
            pageConfigure.Controls.Add(txtConfigPassword);
            pageConfigure.Location = new Point(222, 0);
            pageConfigure.Name = "pageConfigure";
            pageConfigure.Size = new Size(770, 376);
            pageConfigure.TabIndex = 7;
            pageConfigure.Paint += pageConfigure_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 12);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 10;
            label4.Text = "URL";
            // 
            // txtconfigURL
            // 
            txtconfigURL.Location = new Point(68, 8);
            txtconfigURL.Name = "txtconfigURL";
            txtconfigURL.Size = new Size(683, 23);
            txtconfigURL.TabIndex = 9;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Location = new Point(5, 66);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(112, 23);
            btnSaveConfig.TabIndex = 8;
            btnSaveConfig.Text = "Connect";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 41);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // txtConfigPassword
            // 
            txtConfigPassword.Location = new Point(68, 37);
            txtConfigPassword.Name = "txtConfigPassword";
            txtConfigPassword.Size = new Size(683, 23);
            txtConfigPassword.TabIndex = 0;
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
            Text = "Palworld REST API Test Client";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pageConfigure.ResumeLayout(false);
            pageConfigure.PerformLayout();
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
        private Label label3;
        private TextBox txtConfigPassword;
        private Label label4;
        private TextBox txtconfigURL;
        private Button btnSaveConfig;
        private Panel panelRequestParameters;
        private Label lblHeader;
    }
}
