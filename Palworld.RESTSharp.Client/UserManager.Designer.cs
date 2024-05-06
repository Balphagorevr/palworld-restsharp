namespace Palworld.RESTSharp.Client
{
    partial class UserManager
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
            gridUserList = new DataGridView();
            groupBox1 = new GroupBox();
            cbEnabled = new CheckBox();
            combUserLevel = new ComboBox();
            label3 = new Label();
            btnSaveUser = new Button();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            btnAddUser = new Button();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)gridUserList).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gridUserList
            // 
            gridUserList.AllowUserToAddRows = false;
            gridUserList.AllowUserToDeleteRows = false;
            gridUserList.AllowUserToResizeColumns = false;
            gridUserList.AllowUserToResizeRows = false;
            gridUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUserList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUserList.Dock = DockStyle.Top;
            gridUserList.Location = new Point(0, 0);
            gridUserList.MultiSelect = false;
            gridUserList.Name = "gridUserList";
            gridUserList.ReadOnly = true;
            gridUserList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            gridUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUserList.ShowEditingIcon = false;
            gridUserList.Size = new Size(647, 267);
            gridUserList.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(cbEnabled);
            groupBox1.Controls.Add(combUserLevel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnSaveUser);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(135, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(499, 110);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Profile Settings";
            // 
            // cbEnabled
            // 
            cbEnabled.AutoSize = true;
            cbEnabled.Checked = true;
            cbEnabled.CheckState = CheckState.Checked;
            cbEnabled.Location = new Point(252, 47);
            cbEnabled.Name = "cbEnabled";
            cbEnabled.Size = new Size(68, 19);
            cbEnabled.TabIndex = 11;
            cbEnabled.Text = "Enabled";
            cbEnabled.UseVisualStyleBackColor = true;
            // 
            // combUserLevel
            // 
            combUserLevel.FormattingEnabled = true;
            combUserLevel.Location = new Point(331, 16);
            combUserLevel.Name = "combUserLevel";
            combUserLevel.Size = new Size(156, 23);
            combUserLevel.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(252, 19);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 9;
            label3.Text = "Access Level";
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(6, 74);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(115, 23);
            btnSaveUser.TabIndex = 7;
            btnSaveUser.Text = "Save";
            btnSaveUser.UseVisualStyleBackColor = true;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(69, 45);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(177, 23);
            txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(69, 16);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(177, 23);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(4, 273);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(125, 23);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(4, 331);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(125, 23);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(4, 302);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(125, 23);
            btnEditUser.TabIndex = 4;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(4, 360);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(125, 23);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(131, 74);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(115, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // UserManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnAddUser);
            Controls.Add(groupBox1);
            Controls.Add(gridUserList);
            Name = "UserManager";
            Size = new Size(647, 386);
            Load += UserManager_Load;
            ((System.ComponentModel.ISupportInitialize)gridUserList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridUserList;
        private GroupBox groupBox1;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsername;
        private Label label1;
        private Button btnAddUser;
        private Button btnDeleteUser;
        private Button btnEditUser;
        private Button btnSaveUser;
        private Button btnRefresh;
        private Label label3;
        private ComboBox combUserLevel;
        private CheckBox cbEnabled;
        private Button btnClear;
    }
}
