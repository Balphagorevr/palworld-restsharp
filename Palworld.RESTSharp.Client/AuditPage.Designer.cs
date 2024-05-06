namespace Palworld.RESTSharp.Client
{
    partial class AuditPage
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
            dgAuditLog = new DataGridView();
            groupBox1 = new GroupBox();
            btnWipeAudit = new Button();
            btnSearch = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgAuditLog).BeginInit();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgAuditLog
            // 
            dgAuditLog.AllowUserToAddRows = false;
            dgAuditLog.AllowUserToDeleteRows = false;
            dgAuditLog.AllowUserToResizeRows = false;
            dgAuditLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgAuditLog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgAuditLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAuditLog.Dock = DockStyle.Fill;
            dgAuditLog.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgAuditLog.Location = new Point(3, 57);
            dgAuditLog.Name = "dgAuditLog";
            dgAuditLog.ReadOnly = true;
            dgAuditLog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgAuditLog.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgAuditLog.Size = new Size(712, 233);
            dgAuditLog.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnWipeAudit);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(712, 48);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Audit Management";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnWipeAudit
            // 
            btnWipeAudit.Location = new Point(87, 22);
            btnWipeAudit.Name = "btnWipeAudit";
            btnWipeAudit.Size = new Size(104, 23);
            btnWipeAudit.TabIndex = 10;
            btnWipeAudit.Text = "Wipe Audit Log";
            btnWipeAudit.UseVisualStyleBackColor = true;
            btnWipeAudit.Click += btnWipeAudit_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(6, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Fetch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgAuditLog, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.4300346F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 81.56997F));
            tableLayoutPanel1.Size = new Size(718, 293);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // AuditPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "AuditPage";
            Size = new Size(718, 293);
            Load += AuditPage_Load;
            ((System.ComponentModel.ISupportInitialize)dgAuditLog).EndInit();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgAuditLog;
        private GroupBox groupBox1;
        private Button btnWipeAudit;
        private Button btnSearch;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
