namespace Palworld.RESTSharp.Client
{
    partial class SaveWorldPage
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
            btnSaveWorld = new Button();
            pbRequestProgress = new ProgressBar();
            SuspendLayout();
            // 
            // btnSaveWorld
            // 
            btnSaveWorld.Location = new Point(3, 3);
            btnSaveWorld.Name = "btnSaveWorld";
            btnSaveWorld.Size = new Size(100, 23);
            btnSaveWorld.TabIndex = 1;
            btnSaveWorld.Text = "Save World";
            btnSaveWorld.UseVisualStyleBackColor = true;
            btnSaveWorld.Click += btnSaveWorld_Click;
            // 
            // pbRequestProgress
            // 
            pbRequestProgress.Location = new Point(3, 32);
            pbRequestProgress.Name = "pbRequestProgress";
            pbRequestProgress.Size = new Size(500, 19);
            pbRequestProgress.Style = ProgressBarStyle.Continuous;
            pbRequestProgress.TabIndex = 2;
            pbRequestProgress.Click += pbSaveProgress_Click;
            // 
            // SaveWorldPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbRequestProgress);
            Controls.Add(btnSaveWorld);
            Name = "SaveWorldPage";
            Size = new Size(506, 254);
            Load += SaveWorldPage_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSaveWorld;
        private ProgressBar pbRequestProgress;
    }
}
