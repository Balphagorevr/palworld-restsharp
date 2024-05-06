namespace Palworld.RESTSharp.Client
{
    partial class ServerManager
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
            groupBox2 = new GroupBox();
            txtServerDescription = new TextBox();
            label2 = new Label();
            lblserverversion = new Label();
            lblserverName = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtServerDescription);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lblserverversion);
            groupBox2.Controls.Add(lblserverName);
            groupBox2.Location = new Point(13, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(622, 134);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Palworld Server Details";
            // 
            // txtServerDescription
            // 
            txtServerDescription.Location = new Point(6, 67);
            txtServerDescription.Multiline = true;
            txtServerDescription.Name = "txtServerDescription";
            txtServerDescription.ReadOnly = true;
            txtServerDescription.Size = new Size(549, 57);
            txtServerDescription.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 49);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 3;
            label2.Text = "Server Description";
            // 
            // lblserverversion
            // 
            lblserverversion.AutoSize = true;
            lblserverversion.Location = new Point(6, 34);
            lblserverversion.Name = "lblserverversion";
            lblserverversion.Size = new Size(38, 15);
            lblserverversion.TabIndex = 1;
            lblserverversion.Text = "label2";
            // 
            // lblserverName
            // 
            lblserverName.AutoSize = true;
            lblserverName.Location = new Point(6, 19);
            lblserverName.Name = "lblserverName";
            lblserverName.Size = new Size(38, 15);
            lblserverName.TabIndex = 0;
            lblserverName.Text = "label2";
            // 
            // ServerManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "ServerManager";
            Size = new Size(647, 413);
            Load += ServerManager_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtServerDescription;
        private Label label2;
        private Label lblserverversion;
        private Label lblserverName;
    }
}
