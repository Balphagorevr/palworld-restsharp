namespace Palworld.RESTSharp.Client
{
    partial class PlayerManager
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
            components = new System.ComponentModel.Container();
            dgUserList = new DataGridView();
            btnKick = new Button();
            btnBan = new Button();
            txtBanReason = new TextBox();
            btnRefresh = new Button();
            userContextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dgUserList).BeginInit();
            SuspendLayout();
            // 
            // dgUserList
            // 
            dgUserList.AllowUserToAddRows = false;
            dgUserList.AllowUserToDeleteRows = false;
            dgUserList.AllowUserToResizeRows = false;
            dgUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUserList.Dock = DockStyle.Top;
            dgUserList.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgUserList.Location = new Point(0, 0);
            dgUserList.MultiSelect = false;
            dgUserList.Name = "dgUserList";
            dgUserList.ReadOnly = true;
            dgUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUserList.Size = new Size(683, 468);
            dgUserList.TabIndex = 0;
            dgUserList.MouseClick += dgUserList_ContentClick;
            // 
            // btnKick
            // 
            btnKick.Location = new Point(524, 475);
            btnKick.Name = "btnKick";
            btnKick.Size = new Size(75, 23);
            btnKick.TabIndex = 1;
            btnKick.Text = "Kick";
            btnKick.UseVisualStyleBackColor = true;
            btnKick.Click += btnKick_Click;
            // 
            // btnBan
            // 
            btnBan.Location = new Point(605, 475);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(75, 23);
            btnBan.TabIndex = 2;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = true;
            btnBan.Click += btnBan_Click;
            // 
            // txtBanReason
            // 
            txtBanReason.Location = new Point(84, 475);
            txtBanReason.Name = "txtBanReason";
            txtBanReason.PlaceholderText = "Kick/Ban Reason";
            txtBanReason.Size = new Size(434, 23);
            txtBanReason.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 474);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // userContextMenu
            // 
            userContextMenu.Name = "userContextMenu";
            userContextMenu.Size = new Size(61, 4);
            // 
            // PlayerManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(txtBanReason);
            Controls.Add(btnBan);
            Controls.Add(btnKick);
            Controls.Add(dgUserList);
            Name = "PlayerManager";
            Size = new Size(683, 501);
            Load += PlayerManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgUserList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgUserList;
        private Button btnKick;
        private Button btnBan;
        private TextBox txtBanReason;
        private Button btnRefresh;
        private ContextMenuStrip userContextMenu;
    }
}
