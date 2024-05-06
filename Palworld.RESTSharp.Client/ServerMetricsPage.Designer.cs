namespace Palworld.RESTSharp.Client
{
    partial class ServerMetricsPage
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
            lbMetricsList = new ListBox();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(464, 24);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lbMetricsList
            // 
            lbMetricsList.Dock = DockStyle.Fill;
            lbMetricsList.FormattingEnabled = true;
            lbMetricsList.ItemHeight = 15;
            lbMetricsList.Location = new Point(0, 24);
            lbMetricsList.Name = "lbMetricsList";
            lbMetricsList.Size = new Size(464, 258);
            lbMetricsList.TabIndex = 1;
            // 
            // ServerMetricsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbMetricsList);
            Controls.Add(btnRefresh);
            Name = "ServerMetricsPage";
            Size = new Size(464, 282);
            Load += ServerMetricsPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnRefresh;
        private ListBox lbMetricsList;
    }
}
