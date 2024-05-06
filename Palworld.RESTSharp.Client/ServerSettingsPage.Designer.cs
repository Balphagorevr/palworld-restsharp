namespace Palworld.RESTSharp.Client
{
    partial class ServerSettingsPage
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
            btnRefresh = new Button();
            btnExportToCSV = new Button();
            lbServerSettingsList = new ListBox();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(635, 24);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExportToCSV
            // 
            btnExportToCSV.Dock = DockStyle.Top;
            btnExportToCSV.Location = new Point(0, 24);
            btnExportToCSV.Name = "btnExportToCSV";
            btnExportToCSV.Size = new Size(635, 23);
            btnExportToCSV.TabIndex = 3;
            btnExportToCSV.Text = "Export to CSV File";
            btnExportToCSV.UseVisualStyleBackColor = true;
            btnExportToCSV.Click += btnExportToCSV_Click;
            // 
            // lbServerSettingsList
            // 
            lbServerSettingsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbServerSettingsList.FormattingEnabled = true;
            lbServerSettingsList.ItemHeight = 15;
            lbServerSettingsList.Location = new Point(0, 48);
            lbServerSettingsList.Name = "lbServerSettingsList";
            lbServerSettingsList.Size = new Size(635, 244);
            lbServerSettingsList.TabIndex = 2;
            // 
            // ServerSettingsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnExportToCSV);
            Controls.Add(lbServerSettingsList);
            Controls.Add(btnRefresh);
            Name = "ServerSettingsPage";
            Size = new Size(635, 292);
            Load += ServerSettingsPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private Button btnExportToCSV;
        private ListBox lbServerSettingsList;
    }
}
